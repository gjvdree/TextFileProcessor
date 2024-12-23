using TextFileProcessor.Application.Services;
using TextFileProcessor.Application.Services.Interfaces;

namespace TextFileProcessor.Application.Tests.Services;

public class FileProcessorServiceTests
{

    private IFileProcessorService CreateSut() => new FileProcessorService();

    [Fact]
    public async Task AddRandomCharacters_WithValidString_ShouldAddRandomCharacters()
    {
        // Arrange 
        string lineToChange = $"Lorum Ipsum Dolor {Guid.NewGuid()}";
        string tempFilePath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
        await File.WriteAllTextAsync(tempFilePath, lineToChange);

        IFileProcessorService sut = CreateSut();

        // Act
        await sut.AddRandomCharacters(tempFilePath);

        // Assert
        Assert.NotEqual(await File.ReadAllTextAsync(tempFilePath), lineToChange);
    }

    [Fact]
    public async Task AddHeaderInformation_WithDate_ShouldAddHeader()
    {
        // Arrange 
        DateTime date = DateTime.UtcNow;
        string tempFilePath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
        await File.WriteAllTextAsync(tempFilePath, "\r\n\r\n\r\n");

        IFileProcessorService sut = CreateSut();

        // Act
        await sut.AddHeaderInformation(tempFilePath, date);

        // Assert
        string[] fileContent = await File.ReadAllLinesAsync(tempFilePath);
        Assert.StartsWith("---", fileContent[0]);
        Assert.Equal($"Received: {date:G}", fileContent[1]);
        Assert.StartsWith("---", fileContent[2]);
    }
}
