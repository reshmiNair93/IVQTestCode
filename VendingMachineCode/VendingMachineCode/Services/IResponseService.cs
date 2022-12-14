using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineCode.Services
{
    public interface IResponsesService
    {
        public string DisplayResponse(string responseType, string message = "");
    }
}
