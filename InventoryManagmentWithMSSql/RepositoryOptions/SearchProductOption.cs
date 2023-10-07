using InputHelpers;
using RepositoryServices;
using PrintingServices;
using Models;
namespace InventoryOptions
{
    public class SearchProductOption : IRepositoryOption
    {
        private readonly IRepository _inventory;

        private readonly IPrintingService _printingService;

        public SearchProductOption(IRepository inventory, IPrintingService printingService)
        {
            _inventory = inventory;
            _printingService = printingService;
        }

        public void Execute()
        {
            int productId = ReadInputHelper.GetIntInput("Enter the product ID you are looking for: ");
            Product product = _inventory.GetProductById(productId);

            if (product != null)
            {
                _printingService.PrintMessage($"Product ID: {product.ProductId}, Name: {product.Name}, Price: {product.Price}, Quantity: {product.Quantity}");
            }
            else
            {
                _printingService.PrintErrorMessage("Product not found");
            }
        }
    }
}