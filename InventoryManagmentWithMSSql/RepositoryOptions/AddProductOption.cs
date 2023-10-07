using InputHelpers;
using RepositoryServices;
using PrintingServices;
using Models;
namespace InventoryOptions
{
    public class AddProductOption : IRepositoryOption
    {
        private readonly IRepository _inventory;
        private readonly IPrintingService _printingService;

        public AddProductOption(IRepository inventory, IPrintingService printingService)
        {
            _inventory = inventory;
            _printingService = printingService;
        }

        public void Execute()
        {
            string name = ReadInputHelper.GetStringInput("Enter the product name: ");
            decimal price = ReadInputHelper.GetDecimalInput("Enter the product price: ");
            int quantity = ReadInputHelper.GetIntInput("Enter the product quantity: ");

            var newProduct = new Product
            {
                Name = name,
                Price = price,
                Quantity = quantity
            };
            _inventory.AddProduct(newProduct);
            _printingService.PrintMessage($"Product added with ID: {newProduct.ProductId}");
        }
    }
}