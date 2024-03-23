using CryptoExchange.Net.CommonObjects;

namespace TradingTest1
{
    partial class ExchangeControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            exchangeName = new Label();
            price = new Label();
            listBox1 = new ListBox();
            selectPair = new Button();
            //button1 = new Button();
            //_exchange.GetSymbolsAsync();
            SuspendLayout();
            // 
            // exchangeName
            // 
            exchangeName.AutoSize = true;
            exchangeName.Font = new Font("Times New Roman", 16F, FontStyle.Bold, GraphicsUnit.Point);
            exchangeName.ForeColor = Color.FromArgb(0, 192, 0);
            exchangeName.Location = new Point(40, 33);
            exchangeName.Name = "exchangeName";
            exchangeName.Size = new Size(0, 36);
            exchangeName.TabIndex = 0;
            exchangeName.Text = _exchange.Name;
            // 
            // price
            // 
            price.AutoSize = true;
            price.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            price.Location = new Point(40, 127);
            price.Name = "price";
            price.Size = new Size(0, 27);
            price.TabIndex = 3;
            price.TextAlign = ContentAlignment.TopCenter;
            price.Text = _exchange.Price.ToString();
            price.DataBindings.Add(new Binding("Text", _exchange, "Price", false, DataSourceUpdateMode.OnPropertyChanged));
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 25;
            listBox1.Location = new Point(25, 200);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(200, 179);
            listBox1.TabIndex = 2;
            listBox1.DataSource = _exchange.Symbols;
            //listBox1.DisplayMember = "Value";
            listBox1.DataBindings.Add(new Binding("DataSource", _exchange, "Symbols", false, DataSourceUpdateMode.OnPropertyChanged));
            // 
            // selectPair
            // 
            selectPair.Location = new Point(50, listBox1.Location.Y + listBox1.Height + 5);
            selectPair.Name = "selectPair";
            selectPair.Size = new Size(100, 40);
            selectPair.TabIndex = 3;
            selectPair.Text = "Select pair";
            selectPair.Click += ButtonClick;
            // 
            // 
            // ExchangeControl
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.Fixed3D;
            Controls.Add(listBox1);
            Controls.Add(price);
            Controls.Add(exchangeName);
            Controls.Add(selectPair);
            ForeColor = SystemColors.ControlText;
            Name = "ExchangeControl";
            Size = new Size(250, 450);
            ResumeLayout(false);
            PerformLayout();
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            selectPair.Controls.Clear();
            _exchange.Start(listBox1.SelectedValue.ToString());
            return;
        }

        #endregion

        private Label exchangeName;
        private Label price;
        private ListBox listBox1;
        private Button selectPair;
        private Button button1;
    }
}
