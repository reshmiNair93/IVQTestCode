using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VendingMachineCode.Enums;
using VendingMachineCode.Models;

namespace VendingMachineCode.Services
{
    public class ProductsService : IProductsService
    {
        public Dictionary<ProductTypes, int> _availableProducts { get; set; }
        public Dictionary<ProductTypes, int> _requestedProducts { get; set; }
        public Dictionary<ProductTypes, int> _dispensedProducts { get; set; }

        public ProductsService(
            //Dictionary<ProductTypes, int> availableProducts, 
            Dictionary<ProductTypes, int> requestedProducts)
        {
            _availableProducts = //availableProducts.Count > 0 ? _availableProducts :
               new Dictionary<ProductTypes, int>() {
                    { ProductTypes.Cola, 100 },
                    { ProductTypes.Candy, 100 },
                    { ProductTypes.Chips, 100 }
                };
            _requestedProducts = requestedProducts;
        }

        public float GetProductPriceBasedOnType(ProductTypes productType)
        {
            return ProductCatalog.ProductsList.Where(x => x.productType == productType).FirstOrDefault().price;
        }

        public float GetTotalCostPrice(Dictionary<ProductTypes, int> productCatalog)
        {
            float amount = 0;
            foreach (var product in productCatalog)
            {
                amount += GetProductPriceBasedOnType(product.Key) * product.Value;
            }
            return amount;
        }

        //RT : Dictionary<ProductTypes, int>
        public void UpdateAvailableItems(Dictionary<ProductTypes, int> productCatalog)
        {
            foreach (var product in productCatalog)
            {
                _availableProducts[product.Key] -= product.Value;
            }
            //return _availableProducts;
        }

        //Dispense Product
        public Dictionary<ProductTypes, int> ProcessProductsToDispense()
            //(Dictionary<ProductTypes, int> requestedProducts)
        {
            foreach (var product in _requestedProducts)
            {
                if (!_availableProducts.ContainsKey(product.Key))
                {
                    throw new Exception("Product Unavailable");
                }
                else
                {
                    DispenseableProducts(product);
                }
            }
            return _dispensedProducts;
        }

        private void DispenseableProducts(KeyValuePair<ProductTypes, int> product)
        {
            if (_availableProducts[product.Key] >= product.Value)
            {
                if (!_dispensedProducts.ContainsKey(product.Key))
                {
                    _dispensedProducts.Add(product.Key, product.Value);
                }
                else
                {
                    _dispensedProducts[product.Key] += product.Value;
                }
                //UpdateProductCatalog(product);

            }
            else
            {
                throw new Exception("Less no of Products available");
            }
        }

        //public void UpdateProductCatalog(KeyValuePair<ProductTypes, int> product)
        //{
        //    _availableProducts[product.Key] -= product.Value;
        //}
    }
}
