namespace PrintingServices
{
    public interface IPrintingService
    {
        void PrintMessage(string message);
        void PrintErrorMessage(string errorMessage);
    }
}
