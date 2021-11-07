using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Burak.Application.Prize.Data.Models
{
    public class LevelCompletionReward
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public string Reward { get; set; }
        //public Rewards Rewards { get; set; }
    }
}
