using CryptoExchange.Net.Clients;
using Binance.Net.Clients;
using Binance.Net.Interfaces.Clients;
using BitGet.Net.Clients;
using BitGet.Net.Interfaces.Clients;
using Bybit.Net.Clients;
using Bybit.Net.Interfaces.Clients;
using Kucoin.Net.Clients;
using Kucoin.Net.Interfaces.Clients;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TradingTest1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            //var builder = new HostBuilder();
            //builder.ConfigureServices(services =>
            //{
            //    services.AddScoped<BaseExchange>();
            //    services.AddScoped<IBinanceRestClient, BinanceRestClient>();
            //    services.AddScoped<IKucoinRestClient, KucoinRestClient>();
            //    services.AddScoped<IBybitRestClient, BybitRestClient>();
            //    //services.AddScoped<IBitGetClient, BitGetClient>(); // an error occured with cryptoexchange.net
            //});
            ApplicationConfiguration.Initialize();

            Application.Run(new MainForm());
        }
    }
}