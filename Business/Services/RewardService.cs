using Burak.Application.Prize.Business.Services.Interface;
using Burak.Application.Prize.Data;
using Burak.Application.Prize.Data.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Burak.Application.Prize.Business.Services
{
    public class RewardService : IRewardService
    {
        private readonly DataContext _dataContext;
        private readonly IWalletService _walletService;

        public RewardService(DataContext dataContext, IWalletService walletService)
        {
            _dataContext = dataContext;
            _walletService = walletService;
        }

        public async Task<Rewards> Create(Rewards reward)
        {
            throw new NotImplementedException();
        }

        public async Task<Rewards> Delete(Rewards reward)
        {
             _dataContext.rewards.Remove(reward);
            await _dataContext.SaveChangesAsync();
            return reward;
        }

        public async Task<Rewards> GenerateRandomReward(int playerId)
        {
            var levelReward = GetRandomReward().Result;
            Rewards reward = new Rewards
            {
                PlayerId = playerId,
                RewardId = levelReward.Id,
                Reward = levelReward.Reward
            };
            _dataContext.rewards.Add(reward);
            await _dataContext.SaveChangesAsync();

            return reward;
        }

        public async Task<Rewards> GetRewardByPlayerById(int playerId)
        {
            var reward = _dataContext.rewards.Where(x => x.PlayerId == playerId);
            if (reward.Count() != 0)
                return reward.First();
            return null;
        }
        private async Task<LevelCompletionReward> GetRandomReward()
        {
            Random random = new Random();
            var skip = (int)(random.NextDouble() * _dataContext.levelcompletionreward.Count());
            var reward = _dataContext.levelcompletionreward.OrderBy(x => x.Id).Skip(skip).Take(1).First();
            return reward;
        }
        public async Task<Rewards> CollectPlayerReward(int playerId)
        {
            var reward = _dataContext.rewards.Where(x => x.PlayerId == playerId).First();
            var itemToBeCollected = parseReward(reward.Reward);
            if (itemToBeCollected != null)
            {
               var wallet =  _walletService.GetWalletByPlayerById(playerId).Result;
                if (itemToBeCollected.ContainsKey("coin"))
                {
                    itemToBeCollected.TryGetValue("coin", out string coin);
                    wallet.Coin += Int32.Parse(coin);
                }

                if (itemToBeCollected.ContainsKey("energy"))
                {
                    itemToBeCollected.TryGetValue("energy", out string energy);
                    wallet.Energy += Int32.Parse(energy);
                }

                await _walletService.Update(wallet);
                await Delete(reward);
            }

            return reward;
        }

        private Dictionary<string, string> parseReward(String reward)
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            var myJObject = JObject.Parse(reward);
            if (myJObject.ContainsKey("coin") == true)
                keyValuePairs.Add("coin", myJObject.First.Values().First().ToString());
            else if (myJObject.ContainsKey("energy") == true)
                keyValuePairs.Add("energy", myJObject.First.Values().First().ToString());

            if (keyValuePairs.Count == 0)
                return null;
            return keyValuePairs;
        }

        public async Task<Rewards> Update(Rewards user)
        {
            throw new NotImplementedException();
        }
    }
}
