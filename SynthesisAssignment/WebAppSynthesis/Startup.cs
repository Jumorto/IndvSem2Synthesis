using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer;
using DataAccessLayer;

namespace WebAppSynthesis
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
            //enable Session State
            services.AddSession();
            services.AddMemoryCache();

            services.AddRazorPages();
            //for the connection 
            services.Add(new ServiceDescriptor(typeof(UsersLogic), new UsersLogic(new UsersDAL(Configuration.GetConnectionString("DBSynthesis")))));
            services.Add(new ServiceDescriptor(typeof(GameLogic), new GameLogic(new GameDAL(Configuration.GetConnectionString("DBSynthesis")))));
            services.Add(new ServiceDescriptor(typeof(MatchLogic), new MatchLogic(new MatchDAL(Configuration.GetConnectionString("DBSynthesis")))));
            services.Add(new ServiceDescriptor(typeof(TournamentLogic), new TournamentLogic(new TournamentDAL(Configuration.GetConnectionString("DBSynthesis")))));
            services.Add(new ServiceDescriptor(typeof(TournamentPlayersLogic), new TournamentPlayersLogic(new TournamentPlayersDAL(Configuration.GetConnectionString("DBSynthesis")))));

            //for local connection
            /*services.Add(new ServiceDescriptor(typeof(UsersLogic), new UsersLogic(Configuration.GetConnectionString("DBSynthesisLocal"))));
            services.Add(new ServiceDescriptor(typeof(GameLogic), new GameLogic(Configuration.GetConnectionString("DBSynthesisLocal"))));
            services.Add(new ServiceDescriptor(typeof(MatchLogic), new MatchLogic(Configuration.GetConnectionString("DBSynthesisLocal"))));
            services.Add(new ServiceDescriptor(typeof(TournamentLogic), new TournamentLogic(Configuration.GetConnectionString("DBSynthesisLocal"))));
            services.Add(new ServiceDescriptor(typeof(TournamentPlayersLogic), new TournamentPlayersLogic(Configuration.GetConnectionString("DBSynthesisLocal"))));*/
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSession(); // to use the session

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
