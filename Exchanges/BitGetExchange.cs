using BitGet.Net.Clients;
using BitGet.Net.Interfaces.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TradingTest1.Exchanges
{
    internal class BitGetExchange : BaseExchange
    {
        private readonly IBitGetClient _restClient;

        public BitGetExchange(IBitGetClient restClient) 
        {
            Name = "BitGet";
            SetFile();
            _restClient = restClient;
        }

        protected async override Task<List<string>> GetSymbolsAsync()
        {
            var x = await _restClient.SpotApi.ExchangeData.GetExchangeInfoAsync();
            return x.Data.Data.Select(x => x.Symbol).ToList();

        }

        protected async override void UpdatePriceAsync(string symbol)
        {
            var x = await _restClient.SpotApi.ExchangeData.GetPriceAsync(symbol);
            Price = x.Data.Data.Close;
        }
    }
}
