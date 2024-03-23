using Binance.Net.Clients;
using BitGet.Net.Clients;
using Bybit.Net.Clients;
using Kucoin.Net.Clients;
using TradingTest1.Exchanges;

namespace TradingTest1
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            SuspendLayout();

           
            binance = new ExchangeControl(new BinanceExchange(new BinanceRestClient()));
            kucoin = new ExchangeControl(new KucointExchange(new KucoinRestClient()));
            bybit = new ExchangeControl(new ByBitExchange(new BybitRestClient()));
            //bitget = new ExchangeControl(new BitGetExchange(new BitGetClient()); //an error with BaserestClient in CryptoExchange.Net
            var customControls = new List<ExchangeControl>() { binance, bybit, kucoin };
            var lastPosition = new Point(0, 0);
            foreach (var customControl in customControls)
            {
                customControl.Location = lastPosition;
                Controls.Add(customControl);
                lastPosition = new Point(customControl.Location.X + customControl.Width + 5,
                    customControl.Location.Y);
            }
            
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1262, 500);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private ExchangeControl binance;
        private ExchangeControl kucoin;
        private ExchangeControl bybit;
        private ExchangeControl bitget;

    }
}
