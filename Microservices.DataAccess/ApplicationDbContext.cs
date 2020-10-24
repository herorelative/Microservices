using System;
using System.Collections.Generic;
using System.Text;
using Microservices.Shared;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Microservices.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options){}

        public DbSet<PaymentMethod> PaymentMethods { get; set; }

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
                    Id=Guid.NewGuid(),
                    Description = "WavePay"
                }
           );
        }
    }
}
