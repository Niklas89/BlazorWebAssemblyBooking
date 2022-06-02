using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApsideBookingRoomApp.Server.Data
{
    public partial class ApsideBookingRoomDBContext : DbContext
    {
        public ApsideBookingRoomDBContext()
        {
        }

        public ApsideBookingRoomDBContext(DbContextOptions<ApsideBookingRoomDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=localhost;database=ApsideBookingRoomDB;trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasKey(e => e.IdBooking)
                    .HasName("Booking_PK");

                entity.ToTable("Booking");

                entity.Property(e => e.IdBooking).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Comment).HasMaxLength(100);

                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.Subject).HasMaxLength(50);

                entity.HasOne(d => d.IdRoomNavigation)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.IdRoom)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Booking_Rooms_FK");

                entity.HasMany(d => d.IdUsers)
                    .WithMany(p => p.IdBookings)
                    .UsingEntity<Dictionary<string, object>>(
                        "Book",
                        l => l.HasOne<User>().WithMany().HasForeignKey("IdUser").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("book_Users0_FK"),
                        r => r.HasOne<Booking>().WithMany().HasForeignKey("IdBooking").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("book_Booking_FK"),
                        j =>
                        {
                            j.HasKey("IdBooking", "IdUser").HasName("book_PK");

                            j.ToTable("book");
                        });
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRole)
                    .HasName("Role_PK");

                entity.ToTable("Role");

                entity.Property(e => e.RoleName).HasMaxLength(50);

                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasMany(d => d.IdUsers)
                    .WithMany(p => p.IdRoles)
                    .UsingEntity<Dictionary<string, object>>(
                        "UserHasRole",
                        l => l.HasOne<User>().WithMany().HasForeignKey("IdUser").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("userHasRole_Users0_FK"),
                        r => r.HasOne<Role>().WithMany().HasForeignKey("IdRole").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("userHasRole_Role_FK"),
                        j =>
                        {
                            j.HasKey("IdRole", "IdUser").HasName("userHasRole_PK");

                            j.ToTable("userHasRole");
                        });
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasKey(e => e.IdRoom)
                    .HasName("Rooms_PK");

                entity.Property(e => e.IdRoom).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Image).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("Users_PK");

                entity.Property(e => e.IdUser).HasDefaultValueSql("(newid())");

                entity.Property(e => e.FullName).HasMaxLength(100);

                entity.Property(e => e.Mail).HasMaxLength(100);

                entity.Property(e => e.Password).HasMaxLength(100);

                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
