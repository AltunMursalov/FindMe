using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceImplementations;
using ApplicationCore.ServiceInterfaces;
using Infrastructure.Database;
using Infrastructure.RepositoryImplementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FindMeServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddEntityFrameworkSqlServer();
            services.AddDbContext<FindMeDbContext>(options => options.
                                    UseSqlServer("Data Source=.;Initial Catalog=FindMe;Trusted_Connection=true;",
                                    sqlOptions => sqlOptions.MigrationsAssembly("Infrastructure")));
            services.AddTransient<IDataService, DataService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<ILostRepository, LostRepository>();
            services.AddTransient<IInstitutionRepository, InstitutionRepository>();
            services.AddScoped<FindMeDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}