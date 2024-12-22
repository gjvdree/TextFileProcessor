using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TextFileProcessor.Web.Controllers;

namespace TextFileProcessor.Tests;

public class TextFileControllerTests
{
    private TextFileController CreateSut() => new();

    [Fact]
    public async Task TextFileController_WithoutFile_ShouldReturnError()
    {
        // Arrange        
        TextFileController sut = CreateSut();

        // Act
        IActionResult response = await sut.ModifyTextFile(null!);

        // Assert
        BadRequestObjectResult badRequestResult = Assert.IsType<BadRequestObjectResult>(response);
        Assert.Equal("Invalid file uploaded", badRequestResult.Value?.ToString());
        Assert.Equal((int)HttpStatusCode.BadRequest, badRequestResult.StatusCode);
    }

    [Fact]
    public async Task TextFileController_WithValidFile_ShouldReturnModifiedFile()
    {
        // Arrange
        TextFileController sut = CreateSut();

        FileStream stream = File.OpenRead("Testdata/Example.txt");
        IFormFile file = new FormFile(stream, 0, stream.Length, "id_from_form", "Test");

        // Act
        IActionResult response = await sut.ModifyTextFile(file);

        // Assert
        FileStreamResult streamResult = Assert.IsType<FileStreamResult>(response);
        Assert.Equal("application/text", streamResult.ContentType);
        Assert.Matches("response_\\d+T\\d+\\.txt", streamResult.FileDownloadName);
    }
}