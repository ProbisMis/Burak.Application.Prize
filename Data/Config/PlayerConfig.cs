using Burak.Application.Prize.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Burak.Application.Prize.Data.Config
{
    public class PlayerConfig
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Player> builder)
        {
            builder.ToTable(nameof(Player));
            builder.HasKey(model => model.Id);
            //builder.HasOne(x => x.Wallet).WithOne(c => c.Player).HasForeignKey<Player>(x => x.WalletId);
            //builder.HasOne(x => x.Reward).WithOne(c => c.Player).HasForeignKey<Player>(x => x.RewardId);
        }
    }
}
