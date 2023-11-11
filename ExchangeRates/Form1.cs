
using System.ComponentModel;

namespace ExchangeRates
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ChangeBybit();
        }

        private async void ChangeBybit()
        {
            var progress = new List<Progress<string>>(){
                new Progress<string>((s) =>{ if (s != "") { label2.Text = s; } }),
                new Progress<string>((s) =>{ if (s != "") { label6.Text = s; } }),
                new Progress<string>((s) =>{ if (s != "") { label7.Text = s; } }),
                new Progress<string>((s) =>{ if (s != "") { label8.Text = s; } })
            };

            await Task.Factory.StartNew(() => Core.BackgroundWorker(progress),
                                        TaskCreationOptions.LongRunning);
        }
    }
}