using Binance.Net.Clients;
using Binance.Net.Objects.Models.Spot.Socket;
using CryptoExchange.Net.Sockets;

namespace Exchanges
{
    public class BinanceAPI : IExchangeAPI
    {
        BinanceSocketClient? _client;
        IProgress<string> _textBox;

        public BinanceAPI(IProgress<string> textBox)
        {
            _textBox = textBox;
            Create();
        }

        public void Create()
        {
            _client = new BinanceSocketClient();
        }

        public async Task SubscribeAsync(string ticker)
        {
            await _client.UsdFuturesApi.SubscribeToTradeUpdatesAsync(ticker, DataHandler);
        }

        async void DataHandler(DataEvent<BinanceStreamTrade> updateData)
        {
            _textBox.Report(updateData.Data.Price.ToString());
        }
    }
}
