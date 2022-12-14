using System;
using System.Collections.Generic;
using VendingMachineCode.Enums;
using VendingMachineCode.Models;
using VendingMachineCode.Services;

namespace VendingMachineCode
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome!");
            var insertedCoinsList = new List<Coin>
            {
                new Coin {  coinSize = 40.00f, coinWeight = 40.00f},
                new Coin {  coinSize = 30.00f, coinWeight = 30.00f},
                new Coin { coinSize = 20.00f, coinWeight = 20.00f},
                new Coin {  coinSize = 10.00f, coinWeight = 10.00f}
            };
            Dictionary<ProductTypes, int> requestedProducts = new Dictionary<ProductTypes, int>();
            var mach01 = new VendingMachine(new CoinsService(insertedCoinsList), new ProductsService(requestedProducts), new ResponseService());
            mach01.VendingMachineProcess();
        }
    }
}
