using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VendingMachineCode.Enums;
using VendingMachineCode.Models;
using VendingMachineCode.Services;

namespace TestCases
{
    public class VendingMachineTests
    {
        //Dictionary<CoinTypes, int> insertedCoins;
        Dictionary<CoinTypes, int> acceptedCoins;
        Dictionary<CoinTypes, int> rejectedCoins;

        Dictionary<ProductTypes, int> requestedProducts;
        Dictionary<ProductTypes, int> _availableProducts;

        List<Coin> insertedCoinsList;

        Mock<ICoinsService> mockCoinsService;
        Mock<IProductsService> mockProductService;
        Mock<IResponsesService> mockResponseService;

        [SetUp]
        public void Setup()
        {
            insertedCoinsList = new List<Coin>
            {
                new Coin {  coinSize = 40.00f, coinWeight = 40.00f},
                new Coin {  coinSize = 30.00f, coinWeight = 30.00f},
                new Coin { coinSize = 20.00f, coinWeight = 20.00f},
                new Coin {  coinSize = 10.00f, coinWeight = 10.00f}
            };

            //insertedCoins = new Dictionary<CoinTypes, int>() {
            //        { CoinTypes.Quarters, 1 },
            //        { CoinTypes.Nickels, 2 },
            //        { CoinTypes.Dimes, 3 },
            //        { CoinTypes.Pennies, 5 }
            //};

            acceptedCoins = new Dictionary<CoinTypes, int>() {
                    { CoinTypes.Quarters, 1 },
                    { CoinTypes.Nickels, 1 },
                    { CoinTypes.Dimes, 1 }
                };
            rejectedCoins = new Dictionary<CoinTypes, int>() {
                    { CoinTypes.Pennies, 1 }
                };

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

            mockCoinsService = new Mock<ICoinsService>();
            mockCoinsService.Setup(serv => serv.GetProcessedCoinsInfo(It.IsAny<string>())).Returns(acceptedCoins);
            mockCoinsService.Setup(serv => serv.GetTotalAmount(It.IsAny<Dictionary<CoinTypes, int>>())).Returns(100.00f);

            mockProductService = new Mock<IProductsService>();
            mockProductService.Setup(serv => serv.GetTotalCostPrice(It.IsAny<Dictionary<ProductTypes, int>>())).Returns(100f);
            mockProductService.Setup(serv => serv.GetProductPriceBasedOnType(It.IsAny<ProductTypes>())).Returns(100.00f);
            mockProductService.Setup(serv => serv.ProcessProductsToDispense()).Returns(requestedProducts);

            mockResponseService = new Mock<IResponsesService>();
            mockResponseService.Setup(serv => serv.DisplayResponse(It.IsAny<string>(), It.IsAny<string>())).Returns("Insert Coins");
            


        }

        [Test]
        public Task VendingMchine_success()
        {

            // Arrange

            VendingMachine machine = new VendingMachine(mockCoinsService.Object,mockProductService.Object,mockResponseService.Object);
            // Act
            machine.VendingMachineProcess();

            //Assert
            return Task.CompletedTask;
        }
    }
}
