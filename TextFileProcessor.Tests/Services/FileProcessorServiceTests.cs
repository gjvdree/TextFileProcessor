using TextFileProcessor.Web.Services;
using TextFileProcessor.Web.Services.Interfaces;

namespace TextFileProcessor.Web.Tests.Services;

public class FileProcessorServiceTests
{

    private IFileProcessorService CreateSut() => new FileProcessorService();

    [Fact]
    public async Task AddRandomCharacters_WithValidString_ShouldAddRandomCharacters()
    {
        // Arrange 
        string lineToChange = $"Lorum Ipsum Dolor {Guid.NewGuid()}";
        string tempFilePath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
        File.WriteAllText(tempFilePath, lineToChange);

        IFileProcessorService sut = CreateSut();

        // Act
        await sut.AddRandomCharacters(tempFilePath);

        // Assert
        Assert.NotEqual(File.ReadAllText(tempFilePath), lineToChange);
    }

    [Fact]
    public async Task AddHeaderInformation_WithDate_ShouldAddHeader()
    {
        // Arrange 
        DateTime date = DateTime.UtcNow;
        string tempFilePath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
        File.WriteAllText(tempFilePath, "\r\n\r\n\r\n");

        IFileProcessorService sut = CreateSut();

        // Act
        await sut.AddHeaderInformation(tempFilePath, date);

        // Assert
        string[] fileContent = File.ReadAllLines(tempFilePath);
        Assert.StartsWith("---", fileContent[0]);
        Assert.Equal($"Received: {date:G}", fileContent[1]);
        Assert.StartsWith("---", fileContent[2]);
    }
}
