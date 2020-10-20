using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InventoryAPI.Models.FoodModels
{
    public partial class dbFoodContext : DbContext
    {
        //public dbFoodContext()
        //{
        //}

        public dbFoodContext(DbContextOptions<dbFoodContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Food> Food { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=.\\;Initial Catalog=dbFood;Persist Security Info=True;User ID=sa;Password=12345678");
//            }
//        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Food>(entity =>
        //    {
        //        entity.Property(e => e.Id).HasColumnName("id");

        //        entity.Property(e => e.Name)
        //            .HasColumnName("name")
        //            .HasMaxLength(50);

        //        entity.Property(e => e.Price).HasColumnName("price");

        //        entity.Property(e => e.Type)
        //            .HasColumnName("type")
        //            .HasMaxLength(50);
        //    });

        //    OnModelCreatingPartial(modelBuilder);
        //}

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
