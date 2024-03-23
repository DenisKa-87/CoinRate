using CryptoExchange.Net.Interfaces;
using Kucoin.Net.Clients;
using Kucoin.Net.Interfaces.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingTest1.Exchanges
{
    internal class KucointExchange : BaseExchange
    {
        private readonly IKucoinRestClient _restClient;

        public KucointExchange(IKucoinRestClient restClient)
        {
            _restClient = restClient;
            Name = restClient.Exchange;
            SetFile();
        }

        protected async override void UpdatePriceAsync(string symbol)
        {
            var tiker = await _restClient.SpotApi.ExchangeData.GetTickerAsync(symbol);
            Price = tiker.Data.LastPrice;
        }

        protected async override Task<List<string>> GetSymbolsAsync()
        {
            var x = await _restClient.SpotApi.ExchangeData.GetSymbolsAsync();
            return x.Data.Select(x => x.Symbol).ToList();
        }
    }
}
