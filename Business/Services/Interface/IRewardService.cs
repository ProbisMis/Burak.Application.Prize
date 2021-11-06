using Burak.Application.Prize.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Burak.Application.Prize.Business.Services.Interface
{
    public interface IRewardService
    {
        Task<Reward> Create(Reward user);
        Task<Reward> Update(Reward user);
        Task<Reward> Delete(Reward user);
    }
}
