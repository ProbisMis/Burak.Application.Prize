using Burak.Application.Prize.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Burak.Application.Prize.Business.Services.Interface
{
    public interface IWalletService
    {
        Task<Wallet> Create(Wallet user);
        Task<Wallet> Update(Wallet user);
        Task<Wallet> Delete(Wallet user);
    }
}
