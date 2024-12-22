using TextFileProcessor.Web.Commands;
using TextFileProcessor.Web.Handlers;

namespace TextFileProcessor.Web.Tests.Handlers;

public class PersistFileToTempCommandHandlerTests
{
    private const string testFilePath = "TestData/Example.txt";

    [Fact]
    public async Task Handle_WithValidContent_ShouldWriteStreamToTempAndReturnPath()
    {
        // Arrange
        PersistFileToTempCommandHandler sut = new();
        PersistFileToTempCommand command = new("Test.txt", File.OpenRead(testFilePath));

        // Act
        string result = await sut.Handle(command, CancellationToken.None);

        // Assert
        Assert.NotEmpty(result);
        Assert.Equal(File.ReadAllText(testFilePath), File.ReadAllText(result));
    }
}