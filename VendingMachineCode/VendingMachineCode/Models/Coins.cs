using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VendingMachineCode.Enums;

namespace VendingMachineCode.Models
{
    public class Coin //: ICoin
    {
        //public float value { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //public float coinWeight { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //public float coinSize { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //public CoinTypes coinType { get => throw new NotImplementedException(); set => throw new NotImplementedException();
        public CoinTypes coinType { get; set; }
        public float coinValue { get; set; }
        public float coinWeight { get; set; }
        public float coinSize { get; set; }
        public bool isValidCoin { get; set; }
        public Coin() { }

        public Coin(float _coinWeight, float _coinSize)
        {
            this.coinWeight = _coinWeight;
            this.coinSize = _coinSize;
            GetCoinWithAllProperties(this);
        }

        public Coin GetCoinWithAllProperties(Coin coin)
        {
            Coin currentCoinType = CoinsDenominationList.CoinsList.Where(x => x.coinSize == coinSize && x.coinWeight == coinWeight)
                .FirstOrDefault();
            coin.coinValue = currentCoinType.coinValue;
            coin.isValidCoin = currentCoinType.isValidCoin;
            coin.coinType = currentCoinType.coinType;
            return coin;
        }

       


            //public Coin(CoinTypes _coinType, float _value, float _coinWeight, float _coinSize)
            //{
            //    this.coinType = _coinType;
            //    this.value = _value;
            //    this.coinWeight = _coinWeight;
            //    this.coinSize = _coinSize;
            //}
        }

    public static class CoinsDenominationList 
    {
        //Quarters,
        //Dimes,
        //Nickels,
        //Pennies
        //accept valid coins(nickels(1/20 $), dimes(1/10 $), and quarters(1/4 $)) and reject invalid ones(pennies(1/100 $)). 
        public static readonly List<Coin> CoinsList = new List<Coin> { 
            new Coin { coinType = CoinTypes.Quarters, coinValue = 1/4, coinSize = 40.00f, coinWeight = 40.00f , isValidCoin = true},
            new Coin { coinType = CoinTypes.Dimes, coinValue = 1/10, coinSize = 30.00f, coinWeight = 30.00f , isValidCoin = true},
            new Coin { coinType = CoinTypes.Nickels, coinValue = 1/20, coinSize = 20.00f, coinWeight = 20.00f , isValidCoin = true},
            new Coin { coinType = CoinTypes.Pennies, coinValue = 1/100, coinSize = 10.00f, coinWeight = 10.00f , isValidCoin = false}
        };
    }



}
