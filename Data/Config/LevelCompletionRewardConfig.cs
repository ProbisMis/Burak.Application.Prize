using Burak.Application.Prize.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Burak.Application.Prize.Data.Config
{
    public class LevelCompletionRewardConfig
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<LevelCompletionReward> builder)
        {
            builder.ToTable(nameof(LevelCompletionReward));
            builder.HasKey(model => model.Id);
            //builder.HasOne(x => x.Rewards).WithOne(c => c.CompletionReward).HasForeignKey<LevelCompletionReward>(x => x.Id);

        }
    }
}
