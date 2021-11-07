using Burak.Application.Prize.Business.Services.Interface;
using Burak.Application.Prize.Data;
using Burak.Application.Prize.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Burak.Application.Prize.Business.Services
{
    public class WalletService : IWalletService
    {
        private readonly DataContext _dataContext;

        public WalletService(DataContext dataContext)
        {
            _dataContext = dataContext;

        }

        public async Task<Wallet> Create(Wallet wallet)
        {
            var walletResponse = _dataContext.wallet.Add(wallet);
            await _dataContext.SaveChangesAsync();

            return walletResponse.Entity;
        }

        public async Task<Wallet> Delete(Wallet wallet)
        {
            var walletResponse = _dataContext.wallet.Remove(wallet);
            await _dataContext.SaveChangesAsync();

            return walletResponse.Entity;
        }

        public async Task<Wallet> Update(Wallet wallet)
        {
            var walletResponse = _dataContext.wallet.Update(wallet);
            await _dataContext.SaveChangesAsync();

            return walletResponse.Entity;
        }

        public async Task<Wallet> LevelUp(Wallet wallet)
        {
            wallet.Level++;

            var user = _dataContext.wallet.Update(wallet);
            await _dataContext.SaveChangesAsync();

            return user.Entity;
        }

        public async Task<Wallet> GetWalletByPlayerById(int playerId)
        {
            var wallet =  _dataContext.wallet.Where(x => x.PlayerId == playerId).First();
            return wallet;
        }
    }
}
