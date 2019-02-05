using AkkaNetTrading;
using AkkaNetTrading.Messages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AkkaNetTradingTest
{
    [TestClass]
    public class AkkaNetTests
    {
        [TestMethod]
        public void BuyTest()
        {
            TradingSystem.Trade("Endava", 125, TradeType.Buy);
        }

        [TestMethod]
        public void OverTradeLimitTest()
        {
            TradingSystem.Trade("Endava", 500, TradeType.Buy);
        }
    }
}