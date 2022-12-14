using System;
using System.Collections.Generic;
using System.Text;
using VendingMachineCode.Enums;

namespace VendingMachineCode.Models
{
    public interface ICoin
    {
        public float value { get; set; }
        public float coinWeight { get; set; }
        public float coinSize { get; set; }
        public CoinTypes coinType { get; set; }



    }

}
