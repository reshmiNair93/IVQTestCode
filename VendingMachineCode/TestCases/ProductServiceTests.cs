using System;
using Castle.Core.Configuration;
using System.Data;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using VendingMachineCode.Services;
using System.Collections.Generic;
using VendingMachineCode.Enums;
using VendingMachineCode.Models;
using System.Linq;
using static NUnit.Framework.Internal.OSPlatform;

namespace TestCases
{
    //[TestClass]
    public class ProductsServiceTests
    {
        Dictionary<ProductTypes, int> requestedProducts;
        Dictionary<ProductTypes, int> _availableProducts;

        [SetUp]
        public void Setup()
        {
            _availableProducts =
               new Dictionary<ProductTypes, int>() {
                    { ProductTypes.Cola, 100 },
                    { ProductTypes.Candy, 100 },
                    { ProductTypes.Chips, 100 }
                };
            requestedProducts = new Dictionary<ProductTypes, int>() {
                    { ProductTypes.Cola, 1 },
                    { ProductTypes.Candy, 2 },
                    { ProductTypes.Chips, 3 }
                };
        }

        [Test]
        public Task GetProductPriceBasedOnType_success()
        {

            // Arrange
            //var mockProductService = new Mock<IProductsService>();

            ProductsService prodService = new ProductsService(requestedProducts);

            // Act
            var result = prodService.GetProductPriceBasedOnType(ProductTypes.Cola);

            //Assert
            var priceCalc = ProductCatalog.ProductsList.Where(x => x.productType == ProductTypes.Cola).FirstOrDefault().price;
            Assert.IsNotNull(result);
            Assert.AreEqual(result, priceCalc);
            return Task.CompletedTask;
        }

    }
}
