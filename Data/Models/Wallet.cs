using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Burak.Application.Prize.Data.Models
{
    public class Wallet
    {
        public int Id { get; set; }
        public int Player_Id { get; set; }
        public string Level { get; set; }
        public string Coin { get; set; }
        public bool Energy { get; set; }
    }
}
