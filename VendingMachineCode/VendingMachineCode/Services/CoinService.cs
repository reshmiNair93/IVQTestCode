using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VendingMachineCode.Enums;
using VendingMachineCode.Models;

namespace VendingMachineCode.Services
{
    public class CoinsService : ICoinsService
    {
        public List<Coin> insertedCoinsList { get; set; }
        public Dictionary<CoinTypes, int> acceptedCoins { get; set; }
        public Dictionary<CoinTypes, int> rejectedCoins { get; set; }

        //public Dictionary<Coin, int>  insertedCoinsDetails { get; set; }
        //public Dictionary<CoinTypes, int> insertedCoinTypesList { get; set; }
        //public Dictionary<CoinTypes, int> availableCoins { get; set; }

        public CoinsService
            (List<Coin> _insertedCoinsList
             //, Dictionary<Coin, int> _insertedCoinsDetails

            //,Dictionary<CoinTypes, int> _insertedCoinTypesList,
            //Dictionary<CoinTypes, int> _acceptedCoins,
            //Dictionary<CoinTypes, int> _rejectedCoins
            //Dictionary<CoinTypes, int> _availableCoins,
            )
        {
            insertedCoinsList = _insertedCoinsList;
            acceptedCoins = new Dictionary<CoinTypes, int>();
            rejectedCoins = new Dictionary<CoinTypes, int>();

            //insertedCoinsDetails = _insertedCoinsDetails;

            //insertedCoinTypesList = _insertedCoinTypesList;
            //acceptedCoins = _acceptedCoins;
            //rejectedCoins = _rejectedCoins;

            //availableCoins = _availableCoins.Count > 0 ? _availableCoins :
            //    new Dictionary<CoinTypes, int>() {
            //        { CoinTypes.Quarters, 100 },
            //        { CoinTypes.Dimes, 100 },
            //        { CoinTypes.Nickels, 100 },
            //        { CoinTypes.Pennies, 0 },
            //    };

        }

        //1) Insert  Coin > Valid or not
        //    a) Valid : Set Value & Type
        //    b) Reject Coin
        //Dictionary<CoinTypes, int> _insertedCoinTypesList { get; set; }



        private bool isValidCoinCheckBasedOnType(CoinTypes _coinType)
        {
            return CoinsDenominationList.CoinsList.Where(x => x.coinType == _coinType).FirstOrDefault().isValidCoin;
        }

        private float GetCoinValueBasedOnType(CoinTypes _coinType)
        {
            return CoinsDenominationList.CoinsList.Where(x => x.coinType == _coinType).FirstOrDefault().coinValue;
        }

        public Dictionary<CoinTypes, int> GetProcessedCoinsInfo(string current)
        {
            switch(current)
            {
                case "Accepted":
                    return acceptedCoins;
                case "Rejected":
                    return rejectedCoins;
                default:
                    return null;
            }
        }

        public float GetTotalAmount(Dictionary<CoinTypes, int> insertedCoins)
        {
            float amount = 0;
            foreach(var insertedCoin in insertedCoins)
            {
                amount += GetCoinValueBasedOnType(insertedCoin.Key) * insertedCoin.Value;
            }
            return amount;
        }




        //Method A - If input is list of Coins

        public void processInsertedCoinsList()
            //(List<Coin> insertedCoinsList)
        {
            foreach (var coin in insertedCoinsList)
            {
                processInsertedCoin(coin);
            }
        }

        
        private void processInsertedCoin(Coin insertedCoin)
        {
            bool isValid = insertedCoin.isValidCoin;
            if (isValid)
            {
                if (!acceptedCoins.ContainsKey(insertedCoin.coinType))
                {
                    acceptedCoins.Add(insertedCoin.coinType, 1);
                }
                else
                {
                    acceptedCoins[insertedCoin.coinType] += 1;
                }
            }
            else
            {
                if (!rejectedCoins.ContainsKey(insertedCoin.coinType))
                {
                    rejectedCoins.Add(insertedCoin.coinType, 1);
                }
                else
                {
                    rejectedCoins[insertedCoin.coinType] += 1;
                }
            }
        }


        //Method 3 - Input is Dictionary of CoinTypes
        //public void processInsertedCoinsList(Dictionary<CoinTypes, int> insertedCoinsList)
        //{
        //    foreach (var types in insertedCoinsList)
        //    {
        //        processInsertedCoin(types.Key)
        //    }
        //}

        //public void processInsertedCoin(CoinTypes insertedCoin)
        //{
        //    CoinService coinService = new CoinService();
        //    bool isValid = //insertedCoin.isValidCoin;
        //    if (isValid)
        //    {
        //        if (!AcceptedCoins.ContainsKey(insertedCoin.coinType))
        //        {
        //            AcceptedCoins.Add(insertedCoin.coinType, 1);
        //        }
        //        else
        //        {
        //            Console.WriteLine("Username is taken!");
        //        }
        //    }
        //    else
        //    {

        //    }
        //}


        //InCorrect - Delete later
        //public void processInsertedCoinsDetails(Dictionary<Coin, int> insertedCoinsList)
        //{
        //    bool isValid = false;

        //    foreach (var insertedCoin in insertedCoinsList)
        //    {
        //        isValid = isValidCoinCheckBasedOnType(insertedCoin.Key.coinType);
        //        if (isValid)
        //        {
        //            if (!AcceptedCoins.ContainsKey(insertedCoin.Key.coinType))
        //            {
        //                AcceptedCoins.Add(insertedCoin.Key.coinType, 1);
        //            }
        //            else
        //            {
        //                AcceptedCoins[insertedCoin.Key.coinType] += insertedCoin.Value;
        //            }
        //        }
        //        else
        //        {
        //            if (!RejectedCoins.ContainsKey(insertedCoin.Key.coinType))
        //            {
        //                RejectedCoins.Add(insertedCoin.Key.coinType, 1);
        //            }
        //            else
        //            {
        //                RejectedCoins[insertedCoin.Key.coinType] += insertedCoin.Value;
        //            }
        //        }
        //    }
        //}

    }
}
