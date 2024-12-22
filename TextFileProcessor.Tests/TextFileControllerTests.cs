using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;
using TextFileProcessor.Web.Commands;
using TextFileProcessor.Web.Controllers;

namespace TextFileProcessor.Web.Tests;

public class TextFileControllerTests
{
    private Mock<ISender> _senderMock;
    private Mock<IPublisher> _publisherMock;

    public TextFileControllerTests()
    {
        _senderMock = new Mock<ISender>();
        _publisherMock = new Mock<IPublisher>();
    }

    private TextFileController CreateSut() => new(_senderMock.Object, _publisherMock.Object);

    // TODO fix test to deal with mediatr


    //[Fact]
    //public async Task TextFileController_WithoutFile_ShouldReturnError()
    //{
    //    // Arrange        
    //    TextFileController sut = CreateSut();
    //    _senderMock.Setup(s => s.Send(It.IsAny<PersistFileToTempCommand>()))

    //    // Act
    //    IActionResult response = await sut.ModifyTextFile(null!, CancellationToken.None);

    //    // Assert
    //    BadRequestObjectResult badRequestResult = Assert.IsType<BadRequestObjectResult>(response);
    //    Assert.Equal("Invalid file uploaded", badRequestResult.Value?.ToString());
    //    Assert.Equal((int)HttpStatusCode.BadRequest, badRequestResult.StatusCode);
    //}

    //[Fact]
    //public async Task TextFileController_WithValidFile_ShouldReturnModifiedFile()
    //{
    //    // Arrange
    //    TextFileController sut = CreateSut();

    //    FileStream stream = File.OpenRead("Testdata/Example.txt");
    //    IFormFile file = new FormFile(stream, 0, stream.Length, "id_from_form", "Test");

    //    // Act
    //    IActionResult response = await sut.ModifyTextFile(file, CancellationToken.None);

    //    // Assert
    //    FileStreamResult streamResult = Assert.IsType<FileStreamResult>(response);
    //    Assert.Equal("application/text", streamResult.ContentType);
    //    Assert.Matches("response_\\d+T\\d+\\.txt", streamResult.FileDownloadName);
    //}
}