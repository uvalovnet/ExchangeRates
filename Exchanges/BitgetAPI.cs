using Bitget.Net;
using Bitget.Net.Clients;
using Bitget.Net.Objects.Models;
using CryptoExchange.Net.Sockets;

namespace Exchanges
{
    public class BitgetAPI : IExchangeAPI
    {
        BitgetSocketClient? _client;
        IProgress<string> _textBox;

        public BitgetAPI(IProgress<string> textBox)
        {
            _textBox = textBox;
            Create();
        }
        public void Create()
        {
            _client = new BitgetSocketClient();
        }

        public async Task SubscribeAsync(string ticker)
        {
            await _client.FuturesApi.SubscribeToTickerUpdatesAsync(ticker, DataHandler);
        }
        async void DataHandler(DataEvent<BitgetFuturesTickerUpdate> updateData)
        {
            _textBox.Report(updateData.Data.LastTradePrice.ToString());
        }
    }
}
