using Burak.Application.Prize.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Burak.Application.Prize.Business.Services.Interface
{
    public interface IPlayerService
    {
        Task<Player> Create(Player player);
        Task<Player> Update(Player player);
        Task<Player> GetPlayerById(int userId);
        Task<Player> Delete(Player player);
        Task<Player> GetPlayerByEmail(string email);

    }
}
