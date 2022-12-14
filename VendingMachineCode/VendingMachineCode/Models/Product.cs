using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using VendingMachineCode.Enums;

namespace VendingMachineCode.Models
{
    public class Product //: IProduct
    {
        //public int productId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //public string productName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //public float cost { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //public ProductTypes productType { get => throw new NotImplementedException(); set => throw new NotImplementedException();

        public int productId { get; set; }
        public string productName { get; set; }
        public float price { get; set; }
        public ProductTypes productType { get; set; }
    }

    public static class ProductCatalog 
    {
        //public List<Product> Products { get; set; }
        //There are three products: cola for $1.00,   candy for $0.65. and chips for $0.50

        public static readonly List<Product> ProductsList = new List<Product> {
            new Product { productType = ProductTypes.Cola, price= 1.00f, productName = "Cola" , productId = 1 },
            new Product { productType = ProductTypes.Candy,price = 0.65f,productName = "Candy", productId = 2 },
            new Product { productType = ProductTypes.Chips,price = 0.50f,productName ="Chips" , productId = 3 }
        };
    }

    //public class ProductCollection
    //{
    //    public Dictionary<ProductTypes, int> ProductCatalogue { get; set; }

    //    public ProductCollection()
    //    {
    //        ProductCatalogue = new Dictionary<ProductTypes, int>();
    //    }

    //}

}
