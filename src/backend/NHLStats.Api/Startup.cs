using GraphiQl;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NHLStats.Api.Helpers;
using NHLStats.Api.Models;
using NHLStats.Core.Data;
using NHLStats.Data;
using NHLStats.Data.Repositories;


namespace NHLStats.Api
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
            services.AddMvc();
           
            services.AddHttpContextAccessor();
            services.AddSingleton<ContextServiceLocator>();
            services.AddDbContext<MLBStatsContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:Default"]));
            services.AddTransient<IPlayerRepository, PlayerRepository>();
            services.AddTransient<IPlayerStatisticRepository, PlayerStatisticRepository>();
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<MLBStatsQuery>();
            services.AddSingleton<MLBPlayerMutation>();
            services.AddSingleton<PlayerType>();
            services.AddSingleton<PlayerInputType>();
            services.AddSingleton<PlayerStatisticType>();

            #region saimel

            services.AddSingleton<PlayerStatisticInputType>();
            services.AddSingleton<StatisticInputType>();

            #endregion

            var sp = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new MLBStatsSchema(new FuncDependencyResolver(type => sp.GetService(type))));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, MLBStatsContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphiQl();
            app.UseMvc();
            db.EnsureSeedData();
        }
    }
}
