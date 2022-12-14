using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachineCode.Enums;
using VendingMachineCode.Models;
using VendingMachineCode.Services;

namespace TestCases
{
    public class NewCoinsServiceTests
    {
        //Dictionary<CoinTypes, int> insertedCoins;
        Dictionary<CoinTypes, int> acceptedCoins;
        Dictionary<CoinTypes, int> rejectedCoins;

        List<Coin> insertedCoinsList;

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
        }

        [Test]
        public Task GetProcessedCoinsInfo_success()
        {

            // Arrange
            //var mockCoinsService = new Mock<ICoinsService>();
            //mockCoinsService.Setup(serv => serv.GetProcessedCoinsInfo("Accepted")).Returns(acceptedCoins);

            CoinsService coinService = new CoinsService(insertedCoinsList);
            // Act
            var result = coinService.GetProcessedCoinsInfo("Accepted");

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, acceptedCoins);
            return Task.CompletedTask;
        }
    }
}
