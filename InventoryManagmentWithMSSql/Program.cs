using InputHelpers;
using InventoryOptions;
using RepositoryServices;
using PrintingServices;
using MongoDB.Driver;
using Models;
public class Program
{
    static void Main(string[] args)
    {

        var printingService = new PrintingService();
        var inventory = GetDatabaseInventoryFromUser();

        Dictionary<InventoryOptionsEnum, IRepositoryOption> repositoryOptions =
            new Dictionary<InventoryOptionsEnum, IRepositoryOption>
        {
            { InventoryOptionsEnum.AddProductOption, new AddProductOption(inventory, printingService) },
            { InventoryOptionsEnum.DeleteProductOption, new DeleteProductOption(inventory, printingService) },
            { InventoryOptionsEnum.EditProductOption, new EditProductOption(inventory, printingService)},
            { InventoryOptionsEnum.SearchProductOption, new SearchProductOption(inventory, printingService)}
        };


        while (true)
        {
            InventoryOptionsEnum option = GetInventoryOptionsFromUser();

            if (option == InventoryOptionsEnum.ExitOption)
            {
                break;
            }

            IRepositoryOption repositroyOption = repositoryOptions[option];
            repositroyOption.Execute();
        }
    }

    static InventoryOptionsEnum GetInventoryOptionsFromUser()
    {
        Console.WriteLine("Choose an Option from the following:");
        Console.WriteLine($"{(int)InventoryOptionsEnum.AddProductOption}. Add Product");
        Console.WriteLine($"{(int)InventoryOptionsEnum.DeleteProductOption}. Delete Product");
        Console.WriteLine($"{(int)InventoryOptionsEnum.EditProductOption}. Edit Product");
        Console.WriteLine($"{(int)InventoryOptionsEnum.SearchProductOption}. Search Product");
        Console.WriteLine($"{(int)InventoryOptionsEnum.ExitOption}. Exit");

        while (true)
        {
            int choice = ReadInputHelper.GetIntInput("Enter Your Choice: ");
            if (Enum.IsDefined(typeof(InventoryOptionsEnum), choice))
            {
                return (InventoryOptionsEnum)choice;
            }
            Console.WriteLine("Invalid choice. Please enter a valid option.");
        }
    }
    static IRepository GetDatabaseInventoryFromUser()
    {
        while (true)
        {
            Console.WriteLine("1. MSSQl");
            Console.WriteLine("2. MongoDB");

            int option = ReadInputHelper.GetIntInput("Enter the database option: ");

            if (option == 1)
            {
                string connectionString = "Data Source=IBRAHIMN;Initial Catalog=InventoryManagement;Integrated Security=True;TrustServerCertificate=True";
                return new RepositoryServiceMSSql(connectionString);
            }
            else if (option == 2)
            {
                string connectionString = "mongodb://localhost:27017";
                MongoClient client = new MongoClient(connectionString);

                IMongoDatabase database = client.GetDatabase("InventoryManagement");

                IMongoCollection<Product> collection = database.GetCollection<Product>("Products");
                return new RepositoryServiceMongo(collection);
            }
        }
    }
}