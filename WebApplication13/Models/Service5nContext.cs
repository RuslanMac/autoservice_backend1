using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebApplication13
{
    public partial class Service5nContext : DbContext
    {
        public Service5nContext()
        {
        }

        public Service5nContext(DbContextOptions<Service5nContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<DriverLicense> DriverLicenses { get; set; }
        public virtual DbSet<License> Licenses { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Rate> Rates { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<Route> Routes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-19PT7TH;Database=Service5n;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(e => e.IdCar)
                    .HasName("Unique_Identifier3");

                entity.ToTable("Car");

                entity.HasIndex(e => e.IdLicense, "IX_Relationship9");

                entity.Property(e => e.IdCar).HasColumnName("ID_Car");

                entity.Property(e => e.Brand)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.IdLicense).HasColumnName("ID_License");

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdLicenseNavigation)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.IdLicense)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship9");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.IdClient)
                    .HasName("Unique_Identifier8");

                entity.ToTable("Client");

                entity.Property(e => e.IdClient).HasColumnName("ID_Client");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("First_Name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Last_Name");

                entity.Property(e => e.Patronymic)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.HasKey(e => e.IdDriver)
                    .HasName("Unique_Identifier1");

                entity.ToTable("Driver");

                entity.Property(e => e.IdDriver).HasColumnName("ID_Driver");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("First_Name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Last_Name");

                entity.Property(e => e.Patronymic)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DriverLicense>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Driver_License");

                entity.Property(e => e.IdDriver).HasColumnName("ID_Driver");

                entity.Property(e => e.IdLicense).HasColumnName("ID_License");
            });

            modelBuilder.Entity<License>(entity =>
            {
                entity.HasKey(e => e.IdLicense)
                    .HasName("Unique_Identifier2");

                entity.ToTable("License");

                entity.Property(e => e.IdLicense).HasColumnName("ID_License");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.IdOrder)
                    .HasName("Unique_Identifier4");

                entity.ToTable("Order");

                entity.HasIndex(e => e.IdCar, "IX_Relationship1");

                entity.HasIndex(e => e.IdTariff, "IX_Relationship4");

                entity.HasIndex(e => e.IdDriver, "IX_Relationship6");

                entity.HasIndex(e => e.IdRoute, "IX_Relationship7");

                entity.HasIndex(e => e.IdClient, "IX_Relationship8");

                entity.Property(e => e.IdOrder).HasColumnName("ID_Order");

                entity.Property(e => e.Cost).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.DeliveryDate).HasColumnName("Delivery_Date");

                entity.Property(e => e.IdCar).HasColumnName("ID_Car");

                entity.Property(e => e.IdClient).HasColumnName("ID_Client");

                entity.Property(e => e.IdDriver).HasColumnName("ID_Driver");

                entity.Property(e => e.IdRoute).HasColumnName("ID_Route");

                entity.Property(e => e.IdTariff).HasColumnName("ID_tariff");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Order_Date");

                entity.HasOne(d => d.IdCarNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdCar)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Delivers an order");

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship8");

                entity.HasOne(d => d.IdDriverNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdDriver)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship6");

                entity.HasOne(d => d.IdRouteNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdRoute)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship7");

                entity.HasOne(d => d.IdTariffNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdTariff)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship4");
            });

            modelBuilder.Entity<Rate>(entity =>
            {
                entity.HasKey(e => e.IdRate)
                    .HasName("Unique_Identifier7");

                entity.ToTable("Rate");

                entity.Property(e => e.IdRate).HasColumnName("ID_rate");

                entity.Property(e => e.description)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(90)
                    .IsUnicode(false);

                entity.Property(e => e.price).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.HasKey(e => e.IdRegion)
                    .HasName("Unique_Identifier6");

                entity.ToTable("Region");

                entity.Property(e => e.IdRegion).HasColumnName("ID_Region");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Route>(entity =>
            {
                entity.HasKey(e => e.IdRoute)
                    .HasName("Unique_Identifier5");

                entity.ToTable("Route");

                entity.HasIndex(e => e.IdRegion, "IX_Relationship2");

                entity.HasIndex(e => e.IdRegionD, "IX_Relationship3");

                entity.Property(e => e.IdRoute).HasColumnName("ID_Route");

                entity.Property(e => e.Distance).HasColumnType("decimal(10, 3)");

                entity.Property(e => e.IdRegion).HasColumnName("ID_Region");

                entity.Property(e => e.IdRegionD).HasColumnName("ID_Region_D");

                entity.HasOne(d => d.IdRegionNavigation)
                    .WithMany(p => p.RouteIdRegionNavigations)
                    .HasForeignKey(d => d.IdRegion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Source region");

                entity.HasOne(d => d.IdRegionDNavigation)
                    .WithMany(p => p.RouteIdRegionDNavigations)
                    .HasForeignKey(d => d.IdRegionD)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Destination");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
