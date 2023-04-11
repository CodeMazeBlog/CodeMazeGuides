using EFCoreJsonInEntityField.Mapping;
using EFCoreJsonInEntityField.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;

namespace EFCoreJsonInEntityField
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderMap());        
        }

        public DbSet<Order> Orders { get; set; }
    }
}
