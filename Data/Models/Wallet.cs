using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Burak.Application.Prize.Data.Models
{
    public class Wallet
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int Level { get; set; }
        public int Coin { get; set; }
        public int Energy { get; set; }

        //public virtual Player Player { get; set; }
    }
}
