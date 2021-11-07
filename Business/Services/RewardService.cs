using Burak.Application.Prize.Business.Services.Interface;
using Burak.Application.Prize.Data;
using Burak.Application.Prize.Data.Models;
using Burak.Application.Prize.Utilities;
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
            _dataContext.rewards.Add(reward);
            await _dataContext.SaveChangesAsync();
            return reward;
        }

        public async Task<Rewards> Update(Rewards reward)
        {
            _dataContext.rewards.Update(reward);
            await _dataContext.SaveChangesAsync();
            return reward;
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
            await Create(reward);
            return reward;
        }

        public async Task<Rewards> GetRewardByPlayerById(int playerId)
        {
            var reward = _dataContext.rewards.Where(x => x.PlayerId == playerId);
            if (reward.Count() != 0)
                return reward.First();
            return null;
        }
       
        public async Task<Rewards> CollectPlayerReward(int playerId)
        {
            var reward = await  GetRewardByPlayerById(playerId);
            if (reward == null) throw new Exception("There is no rewards to collect");

            var itemToBeCollected = PlayerRewardUtil.parseReward(reward.Reward);
            if (itemToBeCollected != null)
            {
               var wallet =  _walletService.GetWalletByPlayerById(playerId).Result;
                if (wallet == null) throw new Exception("Player's wallet can not be found");

                if (itemToBeCollected.ContainsKey(AppConstants.Coin))
                {
                    itemToBeCollected.TryGetValue(AppConstants.Coin, out string coin);
                    wallet.Coin += Int32.Parse(coin);
                }

                if (itemToBeCollected.ContainsKey(AppConstants.Energy))
                {
                    itemToBeCollected.TryGetValue(AppConstants.Energy, out string energy);
                    wallet.Energy += Int32.Parse(energy);
                }

                await _walletService.Update(wallet);
                await Delete(reward);
            }

            return reward;
        }

        private async Task<LevelCompletionReward> GetRandomReward()
        {
            Random random = new Random();
            var skip = (int)(random.NextDouble() * _dataContext.levelcompletionreward.Count());
            var reward = _dataContext.levelcompletionreward.OrderBy(x => x.Id).Skip(skip).Take(1).First();
            return reward;
        }

      
    }
}
