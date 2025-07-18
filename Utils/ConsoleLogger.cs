
namespace C_Sharp8.Utils
{
    public interface ILogger
    {
        void Log(string message);

        void LogError(string error) => Console.WriteLine($"Error: {error}"); // Default implementation
    }

    public class ConsoleLogger : ILogger
    {
        public void Log(string message) => Console.WriteLine(message);
        // LogError inherited automatically
    }
}
