using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace dnd.Code.Models.Auth
{
    public class SecurityContext : IdentityDbContext<ApplicationUser>
    {
        public SecurityContext() : base("dndSecurityString") { }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<IdentityUser>().ToTable("Users");
        //    modelBuilder.Entity<ApplicationUser>().ToTable("Users");
        //    modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
        //    modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");
        //    modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
        //    modelBuilder.Entity<IdentityRole>().ToTable("Roles");
        //}

    }
}