using Binance.Net.Clients;
using Binance.Net.Interfaces.Clients;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Interfaces;
using System.ComponentModel;

namespace TradingTest1.Exchanges
{
    internal class BinanceExchange : BaseExchange
    {
        public readonly IBinanceRestClient _restClient;


        public BinanceExchange(IBinanceRestClient restClient)
        {
            _restClient = restClient;
            Name = restClient.Exchange;
            SetFile();
        }

        protected async override Task<List<string>> GetSymbolsAsync()
        {
 
            var x = await _restClient.SpotApi.ExchangeData.GetExchangeInfoAsync();
            return x.Data.Symbols.Select(x => x.Name).ToList();

        }

        protected async override void UpdatePriceAsync(string symbol)
        {
            var tiker = await _restClient.SpotApi.ExchangeData.GetTickerAsync(symbol);
            Price = tiker.Data.LastPrice;
        }
    }
}
