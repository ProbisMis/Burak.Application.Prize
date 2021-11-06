using AutoMapper;
using Burak.Application.Prize.Business.Services.Interface;
using Burak.Application.Prize.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Burak.Application.Prize.Controllers
{
    /// <summary>
    /// Player Prize API
    /// </summary>
    [ApiController]
    [Route("player")]
    public class PlayerRewardController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        private readonly IRewardService _prizeService;
        private readonly IWalletService _walletService;
        private readonly ILogger<PlayerRewardController> _logger;
        private readonly IMapper _mapper;

        public PlayerRewardController(ILogger<PlayerRewardController> logger,
           IPlayerService playerService,
           IRewardService  prizeService,
           IWalletService walletService,
           IMapper mapper
           )
        {
            _logger = logger;
            _playerService = playerService;
            _prizeService = prizeService;
            _walletService = walletService;
            _mapper = mapper;
        }

        [HttpGet("{playerId}/levelup")]
        public async Task<PlayerResponse> LevelUpPlayer([FromRoute] int playerId)
        {
            PlayerResponse playerResponse;
            
            var user = await _playerService.GetPlayerById(playerId);
            playerResponse = _mapper.Map<PlayerResponse>(user);

            return playerResponse;
        }

    }
}
