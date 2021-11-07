using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Burak.Application.Prize.Data.Models
{
    public class Player 
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; } 
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }

        public DateTime? CreatedOnUtc { get; set; }
        public DateTime? UpdatedOnUtc { get; set; }

       // public int WalletId { get; set; }
        //public virtual Wallet Wallet { get; set; }
        //public int RewardId { get; set; }
        //public Rewards Reward { get; set; }


    }
}
