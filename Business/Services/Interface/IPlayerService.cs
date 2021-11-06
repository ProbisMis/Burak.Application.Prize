using Burak.Application.Prize.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Burak.Application.Prize.Business.Services.Interface
{
    public interface IPlayerService
    {
        Task<Player> Create(Player user);
        Task<Player> Update(Player user);
        Task<Player> GetPlayerById(int userId);
        Task<Player> Delete(Player user);
        Task<Player> GetPlayerByEmail(string email);
    }
}
