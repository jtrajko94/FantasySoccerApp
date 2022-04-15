using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using FantasySoccerApp.MobileAppService.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using FantasySoccerApp.MobileAppService.Services;
using FantasySoccerApp.MobileAppService.Services.Interfaces;
using System.Threading.Tasks;
using FantasySoccerApp.MobileAppService.Utilities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Net;

namespace FantasySoccerApp.MobileAppService
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        Dictionary<string, string> azureVaultKeys = new Dictionary<string, string>();
        private readonly IWebHostEnvironment _env;
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            azureVaultKeys = GenerateStartupConnectionStringsAsync();

            services.AddDbContext<SQLContext>(options =>
                options.UseSqlServer(azureVaultKeys["SQLConnection"],
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 3,
                    maxRetryDelay: TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null);
                }
            ));
            services.AddIdentity<AspNetUsers, AspNetRoles>()
                .AddRoleManager<RoleManager<AspNetRoles>>()
                .AddUserManager<UserManager<AspNetUsers>>()
                .AddSignInManager<SignInManager<AspNetUsers>>()
                .AddEntityFrameworkStores<SQLContext>()
                .AddDefaultTokenProviders();

            services.AddControllers();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["Jwt:Audience"],
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy(JwtBearerDefaults.AuthenticationScheme, policy =>
                {
                    policy.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
                    policy.RequireClaim(ClaimTypes.NameIdentifier);
                });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Fantasy Soccer App API",
                    Description = "This is a restricted API for Fantasy Soccer App",
                    Version = "v1"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Please enter into field the word 'Bearer' following by space and JWT",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    In = ParameterLocation.Header
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme{
                        Reference = new OpenApiReference{
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
                });
            });

            services.AddSingleton<IAzureKeyVaultService>(new AzureKeyVaultService(azureVaultKeys));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAccountService, AccountService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger(c => {
                c.RouteTemplate = "fantasy-soccer-app/api430985/swagger/{documentName}/swagger.json";
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/fantasy-soccer-app/api430985/swagger/v1/swagger.json", "Fantasy Soccer App API v1");
                c.RoutePrefix = "fantasy-soccer-app/api430985/swagger";
                c.DocExpansion(DocExpansion.None);
            });
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            CreateUserRoles(serviceProvider).Wait();
        }

        private static Dictionary<string, string> GenerateStartupConnectionStringsAsync()
        {
            var keyVaultService = new AzureKeyVaultService();

            //For Mac - https://docs.microsoft.com/en-us/cli/azure/install-azure-cli-macos?view=azure-cli-latest (az login in terminal)
            var keys = new Dictionary<string, string> {
                {"SQLConnection", keyVaultService.GetSecretAsync("SQLConnection")}
            };

            keyVaultService.SetKeys(keys);
            return keys;
        }

        private async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<AspNetRoles>>();
            string[] roleNames = UserRoles.GetAllRoles();
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    var role = new AspNetRoles(roleName);
                    roleResult = await RoleManager.CreateAsync(role);
                }
            }
        }
    }
}