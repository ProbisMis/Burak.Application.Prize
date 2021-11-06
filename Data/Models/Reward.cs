using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Burak.Application.Prize.Data.Models
{
    public class Reward
    {
        public int Id { get; set; }

        public int PlayerId { get; set; }

        public int RewardId { get; set; }

        public String Rewards { get; set; }

    }
}
