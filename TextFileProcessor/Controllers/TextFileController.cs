using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TextFileProcessor.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextFileController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> ModifyTextFile(IFormFile textFile)
        {
            if (textFile == null || textFile.Length == 0)
                return BadRequest("Invalid file uploaded");

            // Persist the file temporary
            string tempFilePath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            using (FileStream stream = new(tempFilePath, FileMode.Create))
            {
                await textFile.CopyToAsync(stream);
            }

            //TODO Do stuff with the file

            return File(System.IO.File.OpenRead(tempFilePath), "application/text", $"response_{DateTime.UtcNow:yyyyMMddTHHmmss}.txt"); // returns a FileStreamResult
        }
    }
}
