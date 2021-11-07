using Burak.Application.Prize.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Burak.Application.Prize.Data.Config
{
    public class WalletConfig
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Wallet> builder)
        {
            builder.ToTable(nameof(Wallet));
            builder.HasKey(model => model.Id);
            //builder.HasOne(x => x.Player).WithOne(c => c.Wallet).HasForeignKey<Wallet>(x => x.Player_Id);
        }
    }
}
