using Burak.Application.Prize.Data.Models;
using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Burak.Application.Prize.Data.Migrations
{
    [Migration(1)]
    public partial class _00001_InitialCreate : Migration
    {
        public override void Up()
        {
            Create.Table("player")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Username").AsString().Nullable()
                .WithColumn("Email").AsString().Nullable()
                .WithColumn("IsActive").AsBoolean().WithDefaultValue(true)
                .WithColumn("IsDeleted").AsBoolean().WithDefaultValue(false)
                .WithColumn("CreatedOnUtc").AsDateTime2().WithDefaultValue(DateTime.Now)
                .WithColumn("UpdatedOnUtc").AsDateTime2().WithDefaultValue(DateTime.Now);

            Create.Table("levelcompletionreward")
              .WithColumn("Id").AsInt32().PrimaryKey().Identity()
              .WithColumn("Level").AsInt32().Nullable()
              .WithColumn("Reward").AsString().Nullable();

            Create.Table("rewards")
               .WithColumn("Id").AsInt32().PrimaryKey().Identity()
               .WithColumn("PlayerId").AsInt32().ForeignKey("player", "Id")
               .WithColumn("RewardId").AsInt32().ForeignKey("levelcompletionreward", "Id")
               .WithColumn("Reward").AsString().Nullable();

            Create.Table("wallet")
              .WithColumn("Id").AsInt32().PrimaryKey().Identity()
              .WithColumn("Level").AsInt32().Nullable()
              .WithColumn("PlayerId").AsInt32().ForeignKey("player", "Id")
              .WithColumn("Coin").AsInt32().Nullable()
              .WithColumn("Energy").AsInt32().Nullable();


            //Seed 
            
             Insert.IntoTable("player").Row(new { Username = "Player1" , Email = "Player1@gmail.com" });
             Insert.IntoTable("player").Row(new { Username = "Player2", Email = "Player2@gmail.com" });

             Insert.IntoTable("levelcompletionreward").Row(new { Level = 1, Reward = "{ \"coin\": 10000 }" });
             Insert.IntoTable("levelcompletionreward").Row(new { Level = 2, Reward = "{ \"energy\": 20 }" });
             Insert.IntoTable("levelcompletionreward").Row(new { Level = 3, Reward = "{ \"coin\": 20000 }" });

            
            Insert.IntoTable("rewards").Row(new { PlayerId = 1, RewardId = 1, Reward = "{ \"energy\": 20 }" });
            Insert.IntoTable("rewards").Row(new { PlayerId = 2, RewardId = 2, Reward = "{ \"coin\": 1000 }" });

            Insert.IntoTable("wallet").Row(new { PlayerId = 1, Level =1, Coin = 500, Energy = 150 });
            Insert.IntoTable("wallet").Row(new { PlayerId = 2, Level = 1, Coin = 0, Energy = 0 });

        }

        public override void Down()
        {
            Delete.Table("player");
            Delete.Table("wallet");
            Delete.Table("rewards");
            Delete.Table("levelcompletionreward");
        }
    }
}
