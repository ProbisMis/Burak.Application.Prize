using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Burak.Application.Prize.Business.Mappers;
using Burak.Application.Prize.Business.Services;
using Burak.Application.Prize.Business.Services.Interface;
using Burak.Application.Prize.Data;
using Burak.Application.Prize.Utilities;
using Burak.Application.Prize.Utilities.ConfigModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NLog.Extensions.Logging;

namespace Burak.Application.Prize
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(builder => builder.AddNLog());
            services.AddMvc(options => options.EnableEndpointRouting = false);
            AddSelectedDataStorage(services);
            AddMappers(services);
            AddBusinessServices(services);


            services.AddSwaggerGen(c =>
            c.SwaggerDoc(name: "v1", new OpenApiInfo { Title = "Prize API", Version = "v1" }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(option => option.AllowAnyHeader()
                                        .AllowAnyMethod()
                                        .AllowAnyOrigin());

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Prize API");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void AddSelectedDataStorage(IServiceCollection services)
        {
            DataStorage dataStorage = ConfigurationHelper.GetDataStorage(Configuration);

            switch (dataStorage.DataStorageType)
            {
                case DataStorageTypes.SqlServer:
                    services.AddDbContext<DataContext>(builder => builder.UseSqlServer(dataStorage.ConnectionString));
                    break;
                case DataStorageTypes.PostgreServer:
                    services.AddDbContext<DataContext>(builder => builder.UseNpgsql(dataStorage.ConnectionString));
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"{dataStorage.DataStorageType} has not been pre-defined");
            }
        }

        private void AddMappers(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(PlayerStateMappingProfiles));
        }


        private void AddBusinessServices(IServiceCollection services)
        {
            services.AddScoped<IPlayerService, PlayerService>();
            services.AddScoped<IWalletService, WalletService>();
            services.AddScoped<IRewardService, RewardService>();
        }
    }
}
