using CryptoExchange.Net.Sockets;
using Kucoin.Net.Clients;
using Kucoin.Net.Objects.Models.Futures.Socket;

namespace Exchanges
{
    public class KucoinAPI : IExchangeAPI
    {
        KucoinSocketClient? _client;
        IProgress<string> _textBox;

        public KucoinAPI(IProgress<string> textBox) 
        {
            _textBox = textBox;
            Create();
        }

        public void Create()
        {
            _client = new KucoinSocketClient();
        }

        public async Task SubscribeAsync(string ticker)
        {
            await _client.FuturesApi.SubscribeToTickerUpdatesAsync("XBTUSDTM", DataHandler);
        }

        async void DataHandler(DataEvent<KucoinStreamFuturesTick> updateData)
        {
            _textBox.Report(updateData.Data.BestAskPrice.ToString());
        }
    }
}
