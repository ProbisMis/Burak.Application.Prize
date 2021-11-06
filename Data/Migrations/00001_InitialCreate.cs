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
            Create.Table(nameof(Player))
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Username").AsString().Nullable()
                .WithColumn("Email").AsString().Nullable()
                .WithColumn("IsActive").AsBoolean().WithDefaultValue(true)
                .WithColumn("IsDeleted").AsBoolean().WithDefaultValue(false)
                .WithColumn("CreatedOnUtc").AsDateTime2().WithDefaultValue(DateTime.Now)
                .WithColumn("UpdatedOnUtc").AsDateTime2().WithDefaultValue(DateTime.Now);

            Create.Table(nameof(LevelCompletionReward))
              .WithColumn("Id").AsInt32().PrimaryKey().Identity()
              .WithColumn("Level").AsInt32().Nullable()
              .WithColumn("Reward").AsString().Nullable();

            Create.Table(nameof(Reward))
               .WithColumn("Id").AsInt32().PrimaryKey().Identity()
               .WithColumn("PlayerId").AsInt32().ForeignKey(nameof(Player), "Id")
               .WithColumn("RewardId").AsInt32().ForeignKey(nameof(LevelCompletionReward), "Id")
               .WithColumn("Rewards").AsString().Nullable();

            Create.Table(nameof(Wallet))
              .WithColumn("Id").AsInt32().PrimaryKey().Identity()
              .WithColumn("PlayerId").AsInt32().ForeignKey(nameof(Player), "Id")
              .WithColumn("Coin").AsInt32().Nullable()
              .WithColumn("Energy").AsInt32().Nullable();


            //Seed 
            
             Insert.IntoTable(nameof(Player)).Row(new { Username = "Player1" , Email = "Player1@gmail.com" });
             Insert.IntoTable(nameof(Player)).Row(new { Username = "Player2", Email = "Player2@gmail.com" });

             Insert.IntoTable(nameof(LevelCompletionReward)).Row(new { Level = 1, Reward = "{ “coin”: 10000 }" });
             Insert.IntoTable(nameof(LevelCompletionReward)).Row(new { Level = 2, Reward = "{ “energy”: 20 }" });
             Insert.IntoTable(nameof(LevelCompletionReward)).Row(new { Level = 3, Reward = "{ “coin”: 20000 }" });

            
            Insert.IntoTable(nameof(Reward)).Row(new { PlayerId = 1, RewardId = 1 });
             Insert.IntoTable(nameof(Reward)).Row(new { PlayerId = 2, RewardId = 2 });

             Insert.IntoTable(nameof(Wallet)).Row(new { PlayerId = 1, Coin = 500, Energy = 150 });

        }

        public override void Down()
        {
            Delete.Table(nameof(Player));
            Delete.Table(nameof(Wallet));
            Delete.Table(nameof(Reward));
            Delete.Table(nameof(LevelCompletionReward));
        }
    }
}
