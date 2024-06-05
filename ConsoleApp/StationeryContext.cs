using DBLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DBLayer.Models.Item;

namespace DBLayer
{
    public class StationeryContext:DbContext
    {
        public StationeryContext() { }

        public StationeryContext(DbContextOptions<StationeryContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StationeryDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            optionsBuilder.UseSqlServer(connString);
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Item> Items { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>(i =>
            {
                i.HasKey(c=>c.ItemId);
                i.Property(c => c.Name).HasColumnType("nvarchar").HasMaxLength(50);
                i.Property(c => c.Description).HasColumnType("nvarchar(max)");
                i.Property(c => c.Location).HasColumnType("nvarchar").HasMaxLength(50);
                i.Property(c => c.Type).
                HasConversion(
                    i => i.ToString(),
                    i => (ItemType)Enum.Parse(typeof(ItemType), i)).HasColumnType("nvarchar(50)");
                i.Property(c => c.ExpirationDate).HasColumnType("datetime");
                i.Property(c => c.ExpireFEDate).HasColumnType("datetime");
                i.ToTable("Items");
            });
        }

        
    }
}
