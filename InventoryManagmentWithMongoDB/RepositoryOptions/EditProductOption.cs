using InputHelpers;
using RepositoryServices;
using PrintingServices;
using Models;
namespace InventoryOptions
{
    public class EditProductOption : IRepositoryOption
    {
        private readonly IRepository _inventory;

        private readonly IPrintingService _printingService;

        public EditProductOption(IRepository inventory, IPrintingService printingService)
        {
            _inventory = inventory;
            _printingService = printingService;
        }

        public void Execute()
        {
            var productId = ReadInputHelper.GetStringInput("Enter the product ID you wish to modify: ");
            Product product = _inventory.GetProductByName(productId);

            if (product != null)
            {
                string newName = ReadInputHelper.GetStringInput("Enter the new Product name: ");
                decimal newPrice = ReadInputHelper.GetDecimalInput("Enter the new Product price: ");
                int newQuantity = ReadInputHelper.GetIntInput("Enter the new Product quantity: ");

                product.Name = newName;
                product.Price = newPrice;
                product.Quantity = newQuantity;

                bool isEdited = _inventory.EditProduct(product);

                if (isEdited)
                {
                    _printingService.PrintMessage("Product updated successfully");
                }
                else
                {
                    _printingService.PrintErrorMessage("Failed to update the product");
                }
            }
            else
            {
                _printingService.PrintErrorMessage("Product not found");
            }
        }
    }
}
