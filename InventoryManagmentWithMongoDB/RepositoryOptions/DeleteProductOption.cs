using InputHelpers;
using RepositoryServices;
using PrintingServices;
namespace InventoryOptions
{
    public class DeleteProductOption : IRepositoryOption
    {
        private readonly IRepository _inventory;
        private readonly IPrintingService _printingService;


        public DeleteProductOption(IRepository inventory, IPrintingService printingService)
        {
            _inventory = inventory;
            _printingService = printingService;
        }

        public void Execute()
        {
            var productId = ReadInputHelper.GetStringInput("Enter the product ID you wish to delete: ");
            bool isDeleted = _inventory.DeleteProduct(productId);

            if (isDeleted)
            {
                _printingService.PrintMessage("The product has been deleted");
            }
            else
            {
                _printingService.PrintErrorMessage("The product was not found");
            }
        }
    }
}
