using Bybit.Net.Clients;
using Bybit.Net.Interfaces.Clients;
using CryptoExchange.Net.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingTest1.Exchanges
{
    internal class ByBitExchange : BaseExchange
    {
        private readonly IBybitRestClient _restClient;

        public ByBitExchange(IBybitRestClient restClient)
        {
            _restClient = restClient;
            Name = restClient.Exchange;
            SetFile();
        }

        protected override async void UpdatePriceAsync(string symol)
        {
            var tiker = await _restClient.SpotApiV3.ExchangeData.GetTickerAsync(symol);
            Price = tiker.Data.LastPrice;
        }
        protected async override Task<List<string>> GetSymbolsAsync()
        {
            var x = await _restClient.V5Api.ExchangeData.GetSpotSymbolsAsync();
            return x.Data.List.Select(x => x.Name).ToList();
        }
    }
}
