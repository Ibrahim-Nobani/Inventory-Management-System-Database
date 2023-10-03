namespace PrintingServices
{
    public class PrintingService : IPrintingService
    {
        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void PrintErrorMessage(string errorMessage)
        {
            Console.WriteLine($"Error: {errorMessage}");
        }
    }
}