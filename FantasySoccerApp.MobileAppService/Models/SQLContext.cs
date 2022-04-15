using FantasySoccerApp.MobileAppService.Services.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FantasySoccerApp.MobileAppService.Models
{
    public class SQLContext : IdentityDbContext<AspNetUsers, AspNetRoles, string, AspNetUserClaims, AspNetUserRoles, AspNetUserLogins, AspNetRoleClaims, AspNetUserTokens>
    {
        private readonly IAzureKeyVaultService _azureKeyVaultService;
        public SQLContext(IAzureKeyVaultService azureKeyVaultService)
        {
            _azureKeyVaultService = azureKeyVaultService;
        }

        public SQLContext(DbContextOptions<SQLContext> options, IAzureKeyVaultService azureKeyVaultService)
            : base(options)
        {
            _azureKeyVaultService = azureKeyVaultService;
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_azureKeyVaultService.GetKeys()["SQLConnection"]);
            }
        }
    }
}
