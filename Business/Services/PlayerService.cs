using Burak.Application.Prize.Business.Services.Interface;
using Burak.Application.Prize.Data;
using Burak.Application.Prize.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Burak.Application.Prize.Business.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly DataContext _dataContext;

        public PlayerService(DataContext dataContext)
        {
            _dataContext = dataContext;
           
        }

        #region User CRUD
        public async Task<Player> Create(Player userRequest)
        {
            var updateDate = DateTime.Now;

            userRequest.CreatedOnUtc = updateDate;
            userRequest.UpdatedOnUtc = updateDate;
            userRequest.IsDeleted = false;

            var user = _dataContext.player.Add(userRequest);
            await _dataContext.SaveChangesAsync();

            return user.Entity;
        }

        public async Task<Player> Delete(Player player)
        {
            var updateDate = DateTime.Now;

            player.UpdatedOnUtc = updateDate;
            player.IsDeleted = true;

            var user = _dataContext.player.Update(player);
            await _dataContext.SaveChangesAsync();

            return user.Entity;
        }


        public async Task<Player> Update(Player player)
        {
            var updateDate = DateTime.Now;

            player.UpdatedOnUtc = updateDate;

            var user = _dataContext.player.Update(player);
            await _dataContext.SaveChangesAsync();

            return user.Entity;
        }

        public async Task<Player> GetPlayerByEmail(string email)
        {
            var user = _dataContext.player.Where(x => x.Email == email && !x.IsDeleted && x.IsActive).First();
            return user;
        }

        public async Task<Player> GetPlayerById(int userId)
        {
            var user =  _dataContext.player.Where(x => x.Id == userId && !x.IsDeleted && x.IsActive).First();
            return user;
        }

        #endregion

    
    }
}
