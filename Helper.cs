using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Web.Script.Serialization;
using System.IO;
using System.Globalization;

namespace BinanceArbitrage
{
    public static class Helper
    {
       
    
        public static string ToStringHex(this byte[] value)
        {
            var output = string.Empty;
            for (var i = 0; i < value.Length; i++)
            {
                output += value[i].ToString("x2", CultureInfo.InvariantCulture);
            }

            return (output);
        }
        /// <summary>
        /// Bir listeyi istenilen bölümlere ayrılmış şekilde ağırlıklı ortalamalar dizisi halinde döndürür.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="division">listeyi kaça böleceğiz? Min:1 Yüksek değerler daha kısa süreli değişen ortalamalar verir.</param>
        /// <returns></returns>
        public static List<decimal> ComputeAvgList(this List<decimal> value,int division)
        {
            decimal avg = value.Average();
            int pointsPerpart = value.Count / division;
            List<decimal> avgList = new List<decimal>();
            for (int i = 0; i < value.Count; i++)
            {
                if (i<pointsPerpart)
                {
                    avgList.Add(avg);
                 
                }           
                else
                {
                    //decimal[] dc =new decimal[avgList.Count+1] ;
                    //avgList.CopyTo(dc);

                    //dc[dc.Length - 1] = value[i];

                    //decimal valToAdd = dc.Skip(dc.Length-pointsPerpart).Average();

                  avgList.Add(value.Skip(i - pointsPerpart).Take(pointsPerpart).Average());  
                  //  avgList.Add(valToAdd);  
                
                }
                 

            }
            return avgList;

        }

        public static int ToInt32(this string value)
        {
            return Convert.ToInt32(value);
        }
        public static decimal ToDecimal(this string value)
        { return Convert.ToDecimal(value); }
        public static decimal Normalize(this decimal value)
        {
            return Math.Round(value, 8, MidpointRounding.AwayFromZero);
        }
        /// <summary>
        /// Normalizes to 2 digits after the point.
        /// </summary>       
        public static decimal NormalizeTo2(this decimal value)
        {
            return Math.Round(value, 2, MidpointRounding.AwayFromZero);
        }
        public static int ToInt(this decimal value)
        {
            return Convert.ToInt32(value);
        }
        public static long ToBigInt(this decimal value)
        {
            return Convert.ToInt64(value);
        }
        public static decimal GetUsdValueOf(string CurrencySym, decimal amount)
        {

            string url = string.Format("https://api.fixer.io/latest?symbols=USD&base={0}", CurrencySym);
            WebClient client = new WebClient();
            string result = client.DownloadString(url);
            JavaScriptSerializer serializer = new JavaScriptSerializer();
          //  Dictionary<string, object> jsonString = serializer.Deserialize<dynamic>(result);

            Dictionary<string, object> jsonString = (Dictionary<string, object>)(serializer.Deserialize<object>(result) as Dictionary<string, object>);
          
    


            decimal rate =Convert.ToDecimal( (jsonString["rates"] as Dictionary<string, object>).Values.ElementAt(0));


            return rate*amount;
        }
        /// <summary>
        /// Calculates the profit percentage of a buy price
        /// </summary>
        /// <param name="value"></param>
        /// <param name="sellPrice"></param>
        /// <returns></returns>
        public static decimal ProfitPercToSell(this decimal value, decimal sellPrice)
        {
            decimal range = sellPrice - value;
            if (value!=0)
            {  return (range * 100 / value).NormalizeTo2();

            }return 0;
          
        }
        public static decimal ProfitPercToBuy(this decimal value, decimal buyPrice)
        {
            decimal range = value - buyPrice;
            if (buyPrice!=0)
            {
return (range * 100 / buyPrice).NormalizeTo2();
            }
            return 0;
        }
        /// <summary>
        /// Calculates the difference of current value according to other one in percent. If returns negative this one is smaller, otherwise this one is bigger.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static decimal PercentageToValue(this decimal value, decimal other)
        {
            decimal range = value - other;
            if (other!=0)
            {
 return (range * 100 / other).NormalizeTo2();
            }
            return 0;
           
        }
        /// <summary>
        /// Adds the value in percent to the current value
        /// </summary>
        /// <returns></returns>
        public static decimal CalcAddedPerc(this decimal value, decimal percentage)
        {
            decimal amountToAdd = value / 100 * percentage;
            return value + amountToAdd;
        }

        public static DateTime AdjustToClient(this DateTime value,int ClientUtcOffset)
        {
        
            DateTime adjustedTime;
            adjustedTime = value.AddMinutes(ClientUtcOffset*-1);
            //if (ClientUtcOffset < 0)
            //{
               
            //}
            //else
            //{
            //    adjustedTime = value.);
            //}
            return adjustedTime;
        }
        public static decimal CalcMedian(decimal big, decimal small)
        {
            decimal priceRange = big - small;
         return small+ priceRange / 2;
        }

    
    }

}
