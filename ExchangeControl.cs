using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TradingTest1.Exchanges;

namespace TradingTest1
{
    public partial class ExchangeControl : UserControl
    {
        private readonly BaseExchange _exchange;

        public ExchangeControl(BaseExchange exchange)
        {
            _exchange = exchange;
            InitializeComponent();
           
        }
    }
}
