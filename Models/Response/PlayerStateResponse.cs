using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Burak.Application.Prize.Models.Response
{
    public class PlayerStateResponse
    {
        public bool isSuccess { get; set; }
        public PlayerResponse player { get; set; }
        public WalletResponse wallet { get; set; }
        public RewardResponse rewards { get; set; }
    }
}
