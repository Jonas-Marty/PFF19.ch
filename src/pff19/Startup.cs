using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using pff19.DataAccess;
using pff19.DataAccess.Repositories;
using pff19.Interfaces;
using pff19.Utiles;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace pff19
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        //ValidateIssuer = true,
                        //ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                    };
                });

            // Add framework services.
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration => configuration.RootPath = "wwwroot/dist");

            if (Configuration.GetValue<bool>("UseMySql"))
            {
                services.AddDbContextPool<PffContext>( // replace "YourDbContext" with the class name of your DbContext
                    options => options.UseMySql(
                        Configuration.GetConnectionString("Dev_MySql"), // replace with your Connection String
                        mysqlOptions =>
                        {
                            mysqlOptions.ServerVersion(new Version(5, 7, 22),
                                ServerType.MySql); // replace with your Server Version and Type
                        }
                    ));
            }
            else
            {
                services.AddDbContext<PffContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("Dev"), b => b.MigrationsAssembly("pff19.DataAccess"));
                });
            }
            
            services.AddScoped<NewsRepository, NewsRepository>();
            services.AddScoped<SponsorRepository, SponsorRepository>();
            services.AddScoped<BandRepository, BandRepository>();
            services.AddScoped<UsersRepository, UsersRepository>();
            services.AddScoped<AssistantRepository, AssistantRepository>();
            services.AddScoped<FaqsRepository, FaqsRepository>();
            services.AddScoped<FileUtility, FileUtility>();
            services.AddScoped<ContactRequestRepository, ContactRequestRepository>();
            services.AddScoped<BandRequestRepository, BandRequestRepository>();
            services.AddSingleton<IInformer, MailInformer>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            Console.WriteLine("Environmentname for ASP.NET CORE is: " + env.EnvironmentName);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true, 
                    ConfigFile = "webpack.dev.js"
                });
                Console.WriteLine("!!!!!!!!!!!!!Started in Development mode!!!!!!!!!!!!!");
            }
            else
            {
                app.UseHsts();
                Console.WriteLine("*************Started in production mode**************");
            }

            app.UseAuthentication();
            app.UseMvc();

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "wwwroot/dist";
            });
        }
    }
}
