using Bybit.Net.Clients;
using Bybit.Net.Objects.Models.V5;
using CryptoExchange.Net.Sockets;

namespace Exchanges
{
    public class BybitAPI : IExchangeAPI
    {
        BybitSocketClient? _client;
        IProgress<string> _textBox;

        public BybitAPI(IProgress<string> textBox)
        {
            _textBox = textBox;
            Create();

        }

        public void Create()
        {
            _client = new BybitSocketClient();
        }
        public async Task SubscribeAsync(string ticker)
        {
            await _client.V5LinearApi.SubscribeToTickerUpdatesAsync(ticker, DataHandler);
        }

        async void DataHandler(DataEvent<BybitLinearTickerUpdate> updateData)
        {
            _textBox.Report(updateData.Data.LastPrice.ToString());
        }
    }
}
