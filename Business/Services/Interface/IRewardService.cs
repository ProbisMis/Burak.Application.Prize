using Burak.Application.Prize.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Burak.Application.Prize.Business.Services.Interface
{
    public interface IRewardService
    {
        Task<Rewards> Create(Rewards user);
        Task<Rewards> Update(Rewards user);
        Task<Rewards> Delete(Rewards user);
        Task<Rewards> GetRewardByPlayerById(int playerId);

        Task<Rewards> GenerateRandomReward(int playerId);

        Task<Rewards> CollectPlayerReward(int playerId);


    }
}
