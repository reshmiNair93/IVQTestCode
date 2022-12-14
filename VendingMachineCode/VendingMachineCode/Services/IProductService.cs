using System;
using System.Collections.Generic;
using System.Text;
using VendingMachineCode.Enums;

namespace VendingMachineCode.Services
{
    public interface IProductsService
    {
        public float GetProductPriceBasedOnType(ProductTypes productType);
        public float GetTotalCostPrice(Dictionary<ProductTypes, int> productCatalog);
        public void UpdateAvailableItems(Dictionary<ProductTypes, int> productCatalog);
        public Dictionary<ProductTypes, int> ProcessProductsToDispense();
    }
}
