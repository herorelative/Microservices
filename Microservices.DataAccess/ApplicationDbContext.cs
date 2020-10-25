using System;
using System.Collections.Generic;
using System.Text;
using Microservices.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Microservices.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<eVoucherUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options){}

        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<EVoucher> EVouchers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<PaymentMethod>().HasData(
                new PaymentMethod
                {
                    Id = Guid.NewGuid(),
                    Description = "VISA",
                },
                new PaymentMethod
                {
                    Id = Guid.NewGuid(),
                    Description = "Mastercard"
                },
                new PaymentMethod
                {
                    Id = Guid.NewGuid(),
                    Description = "KBZ Pay"
                },
                new PaymentMethod
                {
                    Id = Guid.NewGuid(),
                    Description = "CB Pay"
                },
                new PaymentMethod
                {
                    Id = Guid.NewGuid(),
                    Description = "One Pay"
                },
                new PaymentMethod
                {
                    Id = Guid.NewGuid(),
                    Description = "WavePay"
                }
           );

            //coc for MySql DB Provider
            builder.Entity<eVoucherUser>(entity => {
                entity.ToTable(name: "aspnetusers");
            });
            builder.Entity<IdentityRole>(entity => {
                entity.ToTable(name: "aspnetroles");
            });
            builder.Entity<IdentityUserRole<string>>(entity => {
                entity.ToTable("aspnetuserroles");
            });
            builder.Entity<IdentityUserClaim<string>>(entity => {
                entity.ToTable("aspnetuserclaims");
            });
            builder.Entity<IdentityUserLogin<string>>(entity => {
                entity.ToTable("aspnetuserlogins");
            });
            builder.Entity<IdentityUserToken<string>>(entity => {
                entity.ToTable("aspnetusertokens");
            });
            builder.Entity<IdentityRoleClaim<string>>(entity => {
                entity.ToTable("aspnetroleclaims");
            });

            //builder.Entity<EVoucher>().HasData(
            //     new EVoucher
            //     {
            //         Title = "Shwe Zagar",
            //         Description = "MPT offers Lowest Call Rate Plan that includes MPT on-net calls: 10Ks/Min Off - net calls: 27Ks / Min SMS: 15 Ks Data: 8 Ks / MB",
            //         ExpireDate = DateTime.UtcNow.AddYears(2),

            //     }
            //);

        }
    }
}
