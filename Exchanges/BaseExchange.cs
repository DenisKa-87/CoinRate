using Binance.Net.Clients;
using Binance.Net.Objects.Models.Spot.SubAccountData;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Interfaces.CommonClients;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Timer = System.Threading.Timer;

namespace TradingTest1.Exchanges
{
    public abstract class BaseExchange : INotifyPropertyChanged
    {
        private decimal? _price;
        private List<string> _symbols = new List<string>();
        public string Name { get; set; }
        public List<string> Symbols
        {
            get => _symbols; set
            {
                _symbols = value;
                OnPropertyChanged();
            }
        }
        public decimal? Price
        {
            get => _price; set
            {
                _price = value;
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;



        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        protected async void SetFile()
        {
            string fileName = Name + "Symbols.txt";
            FileInfo fileInfo = new FileInfo(fileName);
            if (!fileInfo.Exists || fileInfo.Length == 0)
            {
                using (var file = File.Create(fileName)) ;
                var symbols = await GetSymbolsAsync();
                using (TextWriter tw = new StreamWriter(fileName))
                {
                    symbols.ForEach(symbol => tw.WriteLine(symbol));
                }
            }
            else
            {
                using (StreamReader reader = File.OpenText(fileName))
                {
                    string line = "";
                    while ((line = reader.ReadLine()) != null)
                    {
                        Symbols.Add(line);
                    }
                }
            }
            
        }

        protected abstract void UpdatePriceAsync(string symbol);
        protected abstract Task<List<string>> GetSymbolsAsync();


        public void Start(string symbol)
        {

            Timer timer = new Timer(async (state) =>
            {

                try
                {
                    //MessageBox.Show((Symbols == null).ToString());
                    UpdatePriceAsync(symbol);
                }
                catch (Exception)
                {
                    MessageBox.Show("Smth went south");
                }

                // feedback convert to json(in this example, it already is)


            }, null, TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(3));

        }
    }

}
