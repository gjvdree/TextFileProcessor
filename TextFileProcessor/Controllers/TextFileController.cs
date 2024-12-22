using MediatR;
using Microsoft.AspNetCore.Mvc;
using TextFileProcessor.Web.Commands;
using TextFileProcessor.Web.Events;
using TextFileProcessor.Web.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TextFileProcessor.Web.Controllers;

[Route("api/[controller]")]
public class TextFileController(ISender sender, IPublisher publisher) : ControllerBase
{
    /// <summary>
    /// Hande a file upload, modify the file and return the modified file as response
    /// </summary>
    /// <param name="textFile">The textfile to process</param>
    /// <param name="cancellationToken">Cancellationtoken to support cancellation mid request</param>
    /// <returns>Filestream to modified file</returns>
    [HttpPost]
    public async Task<IActionResult> ModifyTextFile(IFormFile textFile, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested(); // Request cancelled

        // Validate filenamme, TODO: Move to validators
        ArgumentNullException.ThrowIfNull(textFile, nameof(textFile));

        // Write the file to the temp directory, save the temp filepath
        string tempFilePath = await sender.Send(new PersistFileToTempCommand(textFile.FileName, textFile.OpenReadStream()), cancellationToken);

        // Publish event of file received, this will modify the file contents, and add a header
        await publisher.Publish(new FileUploadedEvent(tempFilePath), cancellationToken);

        /// Query to get the modified file
        Stream fileStream = await sender.Send(new GetFileByNameQuery(tempFilePath), cancellationToken);
        return File(fileStream, "application/text", textFile.FileName); // returns a FileStreamResult
    }
}
