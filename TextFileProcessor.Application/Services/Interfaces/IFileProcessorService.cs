namespace TextFileProcessor.Application.Services.Interfaces
{
    public interface IFileProcessorService
    {
        /// <summary>
        /// Adds random characters to a file
        /// </summary>
        /// <param name="filePath">Path to the file to process</param>
        /// <exception cref="ArgumentException">Exception thrown when file is absent</exception>
        Task AddRandomCharacters(string filePath);

        /// <summary>
        /// Adds an header to a file
        /// </summary>
        /// <param name="filePath">Path to the file to process</param>
        /// <param name="dateReceived">Date to add to header</param>
        /// <returns>Number of header lines added</returns>
        /// <exception cref="ArgumentException">Exception thrown when file is absent</exception>
        Task<int> AddHeaderInformation(string filePath, DateTime dateReceived);
    }
}