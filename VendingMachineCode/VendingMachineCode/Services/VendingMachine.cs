using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using VendingMachineCode.Enums;
using VendingMachineCode.Models;

namespace VendingMachineCode.Services
{
    public class VendingMachine
    {
        public ICoinsService coinsService { get; set; }
        public IProductsService productsService { get; set; }
        public IResponsesService responseService { get; set; }
        public VendingMachine( ICoinsService _coinService , IProductsService _productsService, IResponsesService _responseService
            //,Dictionary<ProductTypes, int> requestedProducts
            //,Dictionary<CoinTypes, int> insertedCoins

            //,ICoinsService coinService , IProductsService productsService,
            )
        {
            if(_coinService == null || _productsService == null || _responseService == null)
            {
                throw new ArgumentNullException("Input null");
            }
            //VendingMachineProcess(coinService, productsService);
            coinsService = _coinService;
            productsService = _productsService;
            responseService = _responseService;
        }

        public void VendingMachineProcess()//(CoinsService coinService, ProductsService productsService)
        {
            Dictionary<string, float> processedAmounts = AcceptCoins();//(coinsService);
            float paymentAmt = processedAmounts["Accepted"];
            Dictionary<ProductTypes, int> dispenseableProducts;
            float costPrice;
            RequestProducts( out dispenseableProducts, out costPrice);

            ProcessDisplay( paymentAmt, dispenseableProducts, costPrice);
        }

        private void ProcessDisplay(float paymentAmt, Dictionary<ProductTypes, int> dispenseableProducts, float costPrice)
        {
            if (paymentAmt >= costPrice)
            {
                productsService.UpdateAvailableItems(dispenseableProducts);
                responseService.DisplayResponse("Sufficient");
                //UpdateAndDispenseBalance
            }
            else
            {
                string response = string.Format("Entered Amounts {1} insufficient for CostPrice:{0}", paymentAmt, costPrice);
                responseService.DisplayResponse("Insufficient", response);
            }
        }

        private void RequestProducts(out Dictionary<ProductTypes, int> dispenseableProducts, out float costPrice)
        {
            dispenseableProducts = productsService.ProcessProductsToDispense();
            costPrice = productsService.GetTotalCostPrice(dispenseableProducts);
        }

        private Dictionary<string, float> AcceptCoins()
        {
            Dictionary<string, float> amountsProcessed  = new Dictionary<string, float>();
            coinsService.processInsertedCoinsList();
            Dictionary<CoinTypes, int> acceptedAmount = coinsService.GetProcessedCoinsInfo("Accepted");
            float paymentAmt = coinsService.GetTotalAmount(acceptedAmount);
            amountsProcessed.Add("Accepted", paymentAmt);
            Dictionary<CoinTypes, int> rejectedAmount = coinsService.GetProcessedCoinsInfo("Returned");
            float returnedAmount = coinsService.GetTotalAmount(rejectedAmount);
            amountsProcessed.Add("Returned", returnedAmount);

            return amountsProcessed;
        }






    }
}
