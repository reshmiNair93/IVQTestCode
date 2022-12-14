using System;
using System.Collections.Generic;
using System.Text;
using VendingMachineCode.Enums;

namespace VendingMachineCode.Models
{
    public interface IProduct
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public float price { get; set; }
        public ProductTypes productType { get; set; }



    }

}
