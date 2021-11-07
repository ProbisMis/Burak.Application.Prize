using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Burak.Application.Prize.Utilities
{
    public static class PlayerRewardUtil
    {
        public static Dictionary<string, string> parseReward(String reward)
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            var myJObject = JObject.Parse(reward);
            if (myJObject.ContainsKey(AppConstants.Coin) == true)
                keyValuePairs.Add(AppConstants.Coin, myJObject.First.Values().First().ToString());
            else if (myJObject.ContainsKey(AppConstants.Energy) == true)
                keyValuePairs.Add(AppConstants.Energy, myJObject.First.Values().First().ToString());

            if (keyValuePairs.Count == 0)
                return null;
            return keyValuePairs;
        }
    }
}
