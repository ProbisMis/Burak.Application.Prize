using AutoMapper;
using Burak.Application.Prize.Data.Models;
using Burak.Application.Prize.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Burak.Application.Prize.Business.Mappers
{
    public class PlayerStateMappingProfiles : Profile
    {
        public PlayerStateMappingProfiles()
        {
            base.CreateMap<PlayerResponse, Player>().ReverseMap();
            base.CreateMap<WalletResponse, Wallet>().ReverseMap();
            base.CreateMap<RewardResponse, Rewards>().ReverseMap();
        }
    }
}
