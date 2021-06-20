using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Models;

#nullable disable

namespace DBContext
{
    public partial class Project0Context : DbContext
    {
        public Project0Context()
        {
        }

        public Project0Context(DbContextOptions<Project0Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<ItemsInOrder> ItemsInOrders { get; set; }
        public virtual DbSet<LocationDirectory> LocationDirectories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Store> Stores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Project0;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => new { e.CustomerId, e.CustomerStore })
                    .HasName("PK__Customer__2BC602866F158DC4");

                entity.ToTable("Customer");

                entity.Property(e => e.CustomerId).ValueGeneratedOnAdd();

                entity.Property(e => e.CustomerCityt).HasMaxLength(60);

                entity.Property(e => e.CustomerEmail)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.CustomerFirstName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.CustomerLastName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.CustomerPassWord)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.CustomerState).HasMaxLength(2);

                entity.Property(e => e.CustomerStreet).HasMaxLength(60);

                entity.Property(e => e.CustomerUserName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.CustomerStoreNavigation)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.CustomerStore)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CustomerStore");
            });

            modelBuilder.Entity<ItemsInOrder>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.OrderId1).HasColumnName("OrderID1");

                entity.Property(e => e.OrderStoreId).HasColumnName("OrderStoreID");

                entity.HasOne(d => d.OrderId1Navigation)
                    .WithMany()
                    .HasForeignKey(d => d.OrderId1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("OrdFK1");

                entity.HasOne(d => d.Order)
                    .WithMany()
                    .HasForeignKey(d => new { d.OrderStoreId, d.OrderProductId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("OrdPFK");
            });

            modelBuilder.Entity<LocationDirectory>(entity =>
            {
                entity.HasKey(e => e.StoreId)
                    .HasName("PK__Location__3B82F10175150551");

                entity.ToTable("LocationDirectory");

                entity.Property(e => e.StoreCitytAd)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.StoreName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.StoreStateAd)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.StoreStreetAd)
                    .IsRequired()
                    .HasMaxLength(60);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OrderStoreId).HasColumnName("OrderStoreID");

                entity.HasOne(d => d.OrderNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => new { d.OrderAccountId, d.OrderStoreId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK1");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Department).HasMaxLength(200);

                entity.Property(e => e.ProductDescription).HasMaxLength(200);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ProductPrice).HasColumnType("smallmoney");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasKey(e => new { e.StoreLocation, e.StoreProduct })
                    .HasName("PK__Store__EF983EDEC8151C22");

                entity.ToTable("Store");

                entity.HasOne(d => d.StoreLocationNavigation)
                    .WithMany(p => p.Stores)
                    .HasForeignKey(d => d.StoreLocation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("StoreLocation");

                entity.HasOne(d => d.StoreProductNavigation)
                    .WithMany(p => p.Stores)
                    .HasForeignKey(d => d.StoreProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("StoreProduct");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
