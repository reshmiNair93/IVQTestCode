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

        public CoinsService
            (List<Coin> _insertedCoinsList )
        {
            insertedCoinsList = _insertedCoinsList;
            acceptedCoins = new Dictionary<CoinTypes, int>();
            rejectedCoins = new Dictionary<CoinTypes, int>();

        }

    
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





        public void processInsertedCoinsList()
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

    }
}
