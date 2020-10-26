using Microservices.PromoCodeAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices.PromoCodeAPI.Data
{
    public class PromoCodeDbContext : IdentityDbContext<PromoCodeUser>
    {
        public PromoCodeDbContext(DbContextOptions<PromoCodeDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //coc for Other ORM Provider
            builder.Entity<PromoCodeUser>(entity =>
            {
                entity.ToTable(name: "aspnetusers");
            });
            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "aspnetroles");
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("aspnetuserroles");
            });
            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("aspnetuserclaims");
            });
            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("aspnetuserlogins");
            });
            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("aspnetusertokens");
            });
            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("aspnetroleclaims");
            });
        }
    }
}
