using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRates
{
    class Core
    {
        static string _token = "BTCUSDT";
        public static void BackgroundWorker(List<Progress<string>> progress)
        {
            var bybitAPI = new Exchanges.BybitAPI(progress[0]);
            var binanceAPI = new Exchanges.BinanceAPI(progress[1]);
            var kucoinAPI = new Exchanges.KucoinAPI(progress[2]);
            var bitgetAPI = new Exchanges.BitgetAPI(progress[3]);
            bybitAPI.SubscribeAsync(_token);
            binanceAPI.SubscribeAsync(_token);
            kucoinAPI.SubscribeAsync(_token);
            bitgetAPI.SubscribeAsync(_token);
        }
    }
}
