using Burak.Application.Prize.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Burak.Application.Prize.Business.Services.Interface
{
    public interface IWalletService
    {
        Task<Wallet> Create(Wallet wallet);
        Task<Wallet> Update(Wallet wallet);
        Task<Wallet> Delete(Wallet wallet);

        Task<Wallet> LevelUp(Wallet wallet);

        Task<Wallet> GetWalletByPlayerById(int playerId);
    }
}
