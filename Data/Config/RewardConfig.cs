using Burak.Application.Prize.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Burak.Application.Prize.Data.Config
{
    public class RewardConfig
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Rewards> builder)
        {
            builder.ToTable(nameof(Rewards));
            builder.HasKey(model => model.Id);
            //builder.HasOne(x => x.Player).WithOne(c => c.Reward).HasForeignKey<Rewards>(x => x.PlayerId);
            //builder.HasOne(x => x.CompletionReward).WithOne(c => c.Rewards).HasForeignKey<Rewards>(x => x.RewardId);

        }
    }
}
