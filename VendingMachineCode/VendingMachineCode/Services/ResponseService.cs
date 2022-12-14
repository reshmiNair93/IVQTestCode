using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineCode.Services
{
    public class ResponseService : IResponsesService
    {
        public ResponseService() { }

        public string DisplayResponse(string responseType, string message = "")
        {
            switch (responseType)
            {
                case "Sufficient":
                    return "Product Dispensed. THANK YOU!";
                case "Insufficient":
                    return message;
                default:
                    return "Insert Coins";
            }
        }
    }
}
