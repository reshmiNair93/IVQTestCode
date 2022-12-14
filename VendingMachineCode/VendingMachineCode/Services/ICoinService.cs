using System;
using System.Collections.Generic;
using System.Text;
using VendingMachineCode.Enums;

namespace VendingMachineCode.Services
{
    public interface ICoinsService
    {
        public Dictionary<CoinTypes, int> GetProcessedCoinsInfo(string current);
        public float GetTotalAmount(Dictionary<CoinTypes, int> insertedCoins);
        public void processInsertedCoinsList();
    }
}
