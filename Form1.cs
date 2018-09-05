using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Web.Script.Serialization;
namespace BinanceArbitrage

{

    public partial class Form1 : Form
    {
        protected WebClient client = null;
        protected JavaScriptSerializer serializer = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new WebClient();
            serializer = new JavaScriptSerializer();
        }


        public string Analyze(List<coinInfo> coins)
        {
            string result = "";

            //BTC-> HOT -> ETH -> BTC

            //BTC>HOT
            decimal hotBuyPrice = coins.Find(f => f.Name == "HOTBTC").SellerPrice;
            decimal hotAmount = (1 / hotBuyPrice).Normalize();
            //HOT>ETH
            decimal hotSelPrice = coins.Find(f => f.Name == "HOTETH").BuyerPrice;
            decimal ethAmount = hotAmount * hotSelPrice;
            //ETH>BTC
            decimal ethSellPrice = coins.Find(f => f.Name == "ETHBTC").BuyerPrice;
            decimal btcAmount1 = (ethSellPrice * ethAmount).Normalize();

            string success = btcAmount1 > 1 ? "***SUCCESS***" : "";

            string op1 = string.Format("BTC>HOT>ETH>BTC:{0} {1} BTC >{2} HOT >{3} ETH >{4} BTC", Environment.NewLine, 1, hotAmount, ethAmount, btcAmount1);
            result += op1 +Environment.NewLine;
           

            //BTC -> ETH -> HOT -> BTC
            //BTC>ETH
            decimal ethBuyPrice = coins.Find(f => f.Name == "ETHBTC").SellerPrice;
            decimal ethAmount2 = (1 / ethBuyPrice).Normalize();
            //ETH>HOT
            decimal hotBuyPrice2 = coins.Find(f => f.Name == "HOTETH").SellerPrice;
            decimal hotAmount2 = (ethAmount2 / hotBuyPrice2).Normalize();
            //HOT>BTC
            decimal hotSellPrice2 = coins.Find(f => f.Name == "HOTBTC").BuyerPrice;
            decimal btcAmount2 = (hotAmount2 * hotSellPrice2).Normalize();

            string op2 = string.Format("BTC>ETH>HOT>BTC:{0} {1} BTC >{2} ETH >{3} HOT >{4} BTC", Environment.NewLine, 1, ethAmount2, hotAmount2, btcAmount2);
            result += op2 + "\n";

            if (!success.Contains("SUCCESS"))
            {
                success = btcAmount2 > 1 ? "***SUCCESS***" : "";
            }

            result = success + "\n" + result;

            return result;
        }
        public List<coinInfo> GetTicker()
        {
            List<coinInfo> coins = new List<coinInfo>();

            string url = "https://api.binance.com/api/v1/ticker/24hr";
            string tickerJsonString = client.DownloadString(url);
            object[] dict = serializer.Deserialize<dynamic>(tickerJsonString) as object[];



            // GET COIN VALUES
            foreach (object coinDict in dict)
            {
                Dictionary<string, object> coinProps = coinDict as Dictionary<string, object>;
                string CoinName = coinProps["symbol"].ToString();
                coinInfo coin = new coinInfo();
                coin.Name = CoinName;
                coin.BuyerPrice = Convert.ToDecimal(coinProps["bidPrice"]).Normalize();
                coin.SellerPrice = Convert.ToDecimal(coinProps["askPrice"]).Normalize();
                coins.Add(coin);
            }
            return coins;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string analyze = Analyze(GetTicker());
            if (analyze.Contains("SUCCESS"))
            {
                txtProfitables.AppendText(string.Format("{0} -> {1}{2}", DateTime.Now.ToShortTimeString(), analyze, Environment.NewLine));
            }

            txtLastAnalyze.Text = analyze;
        }
    }




    public class coinInfo
    {
        public string Name { get; set; }
        //Ask
        public decimal SellerPrice { get; set; }
        //Bid
        public decimal BuyerPrice { get; set; }
    }
}
