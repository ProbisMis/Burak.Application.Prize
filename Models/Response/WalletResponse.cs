using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Burak.Application.Prize.Models.Response
{
    public class WalletResponse
    {
        public int Id { get; set; }
        public int Player_Id { get; set; }
        public int Level { get; set; }
        public int Coin { get; set; }
        public int Energy { get; set; }
    }
}
