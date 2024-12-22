using TextFileProcessor.Web.Services.Interfaces;

namespace TextFileProcessor.Web.Services;

internal class FileProcessorService : IFileProcessorService
{
    /// <inheritdoc />
    public async Task<int> AddHeaderInformation(string filePath, DateTime dateReceived)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(filePath, nameof(filePath));

        if (!File.Exists(filePath))
            throw new ArgumentException($"File '{filePath}' does not exist", nameof(filePath));

        string[] header = ["--------------------------------------",
                           $"Received: {dateReceived:G}",
                           "--------------------------------------"];

        // Create a temporary file or a new file to write the updated content
        string tempFilePath = filePath + ".tmp";

        using (StreamReader reader = new(filePath))
        using (StreamWriter writer = new(tempFilePath))
        {
            // Write the header lines
            foreach (string line in header)
                await writer.WriteLineAsync(line);

            // Copy the original file's content to the new file
            while (!reader.EndOfStream)
            {
                await writer.WriteLineAsync(await reader.ReadLineAsync());
            }
        }

        ReplaceTempFile(filePath, tempFilePath);

        return header.Length;
    }

    /// <inheritdoc />
    public async Task AddRandomCharacters(string filePath)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(filePath, nameof(filePath));

        if (!File.Exists(filePath))
            throw new ArgumentException($"File '{filePath}' does not exist", nameof(filePath));

        // Create a temporary file or a new file to write the updated content
        string tempFilePath = filePath + ".tmp";

        using (StreamReader reader = new(filePath))
        using (StreamWriter writer = new(tempFilePath))
        {
            // Copy the original file's content to the new file
            while (!reader.EndOfStream)
            {
                await writer.WriteLineAsync(RandomizeLine(await reader.ReadLineAsync() ?? ""));
            }
        }

        ReplaceTempFile(filePath, tempFilePath);
    }

    /// <summary>
    /// Add random characters to a string
    /// </summary>
    /// <param name="line"></param>
    /// <returns></returns>
    private static string RandomizeLine(string line)
    {
        Random random = new();
        int randomNumber = random.Next(30, 50); //Determine number to add a character every nth character
        char randomCharacter = (char)random.Next(23, 27); //one of these => #, $, %, &

        char[] result = string.IsNullOrEmpty(line) ? [] : line
            .Select<char, char[]>((c, index) => index > 0 && index % randomNumber == 0 ? [c, randomCharacter] : [c]) // Select the character, append the randomCharacter if the character is at a index which can be divided by randomNumber 
            .Aggregate((res, arr) => [.. res, .. arr]);

        return new string(result);
    }

    /// <summary>
    ///  Replace the original file with the updated one
    /// </summary>
    /// <param name="originalPath"></param>
    /// <param name="toReplacePath"></param>
    private static void ReplaceTempFile(string originalPath, string toReplacePath)
    {
        File.Delete(originalPath);
        File.Move(toReplacePath, originalPath);
    }
}
