using AutoMapper;
using Burak.Application.Prize.Business.Services.Interface;
using Burak.Application.Prize.Data.Models;
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
    [Route("players")]
    public class PlayerRewardController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        private readonly IRewardService _rewardService;
        private readonly IWalletService _walletService;
        private readonly ILogger<PlayerRewardController> _logger;
        private readonly IMapper _mapper;

        public PlayerRewardController(ILogger<PlayerRewardController> logger,
           IPlayerService playerService,
           IRewardService  rewardService,
           IWalletService walletService,
           IMapper mapper
           )
        {
            _logger = logger;
            _playerService = playerService;
            _rewardService = rewardService;
            _walletService = walletService;
            _mapper = mapper;
        }

        /// <summary>
        /// Levels up player
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns></returns>
        [HttpPost("{playerId}/levelup")]
        public async Task<PlayerStateResponse> PlayerLevelUp([FromRoute] int playerId)
        {
            PlayerStateResponse playerStateResponse = new PlayerStateResponse();
            
            try
            {
                var user = await _playerService.GetPlayerById(playerId);

                if (user == null) throw new Exception("User can not be found");
                var wallet = await _walletService.GetWalletByPlayerById(playerId);
                if (wallet == null) throw new Exception("Wallet can not be found");
                wallet = await _walletService.LevelUp(wallet);
                await _rewardService.GenerateRandomReward(playerId);
                var rewards = await _rewardService.GetRewardByPlayerById(playerId);

                playerStateResponse = mapDtoToResponse(user, wallet, rewards);
                playerStateResponse.isSuccess = true;
            }
            catch (Exception ex)
            {
                playerStateResponse.Message = ex.Message;
                playerStateResponse.isSuccess = false;
            }

           
            return playerStateResponse;
        }

        /// <summary>
        /// Gets Player's data
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns></returns>
        [HttpGet("{playerId}/state")]
        public async Task<PlayerStateResponse> PlayerGetState([FromRoute] int playerId)
        {
            PlayerStateResponse playerStateResponse = new PlayerStateResponse();
            try
            {
                var user = await _playerService.GetPlayerById(playerId);
                var wallet = await _walletService.GetWalletByPlayerById(playerId);
                var rewards = await _rewardService.GetRewardByPlayerById(playerId);

                playerStateResponse = mapDtoToResponse(user, wallet, rewards);
                playerStateResponse.isSuccess = true;
                
            }
            catch (Exception ex)
            {
                playerStateResponse.Message = ex.Message;
                playerStateResponse.isSuccess = false;
            }
            return playerStateResponse;
        }

        /// <summary>
        /// Collects available rewards 
        /// </summary>
        /// <param name="playerId"></param>
        /// <param name="rewardId"></param>
        /// <returns></returns>
        [HttpPost("{playerId}/collect/{rewardId}")]
        public async Task<PlayerStateResponse> PlayerCollectReward([FromRoute] int playerId, [FromRoute] int rewardId)
        {   
            PlayerStateResponse playerStateResponse = new PlayerStateResponse();

            try
            {
                await _rewardService.CollectPlayerReward(playerId);
                playerStateResponse = await PlayerGetState(playerId);

            }
            catch (Exception ex)
            {
                playerStateResponse.Message = ex.Message;
                playerStateResponse.isSuccess = false;
            }

            
            return playerStateResponse;
        }

        private PlayerStateResponse mapDtoToResponse(Player player, Wallet wallet, Rewards rewards)
        {
            PlayerStateResponse playerStateResponse = new PlayerStateResponse();
            PlayerResponse playerResponse = _mapper.Map<PlayerResponse>(player);
            WalletResponse walletResponse = _mapper.Map<WalletResponse>(wallet);
            RewardResponse rewardResponse = _mapper.Map<RewardResponse>(rewards);
            playerStateResponse.player = playerResponse;
            playerStateResponse.wallet = walletResponse;
            playerStateResponse.rewards = rewardResponse;
            return playerStateResponse;
        }

    }
}
