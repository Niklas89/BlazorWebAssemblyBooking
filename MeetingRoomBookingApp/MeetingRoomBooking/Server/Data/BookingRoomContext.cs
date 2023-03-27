using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MeetingRoomBooking.Server;

namespace MeetingRoomBooking.Server.Data
{
    public partial class BookingRoomContext : DbContext
    {
        public BookingRoomContext()
        {
        }

        public BookingRoomContext(DbContextOptions<BookingRoomContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<FileTmp> FileTmps { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=localhost;database=BookingRoom;trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking", "BookingRoom");

                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Comment).HasMaxLength(150);

                entity.Property(e => e.RecurrenceExceptions).HasMaxLength(250);

                entity.Property(e => e.RecurrenceRule).HasMaxLength(150);

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.CreationUser)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.CreationUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Booking_User_FK");

                entity.HasOne(d => d.IdRoomNavigation)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.IdRoom)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Booking_Room_FK");
            });

            modelBuilder.Entity<FileTmp>(entity =>
            {
                entity.ToTable("FileTmp", "BookingRoom");

                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Content).IsRequired();

                entity.Property(e => e.Extension)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role", "Security");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("Room", "BookingRoom");

                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.IdFileNavigation)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.IdFile)
                    .HasConstraintName("Room_FileTmp_FK");
            });

            modelBuilder.Entity<Setting>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PK__Setting__737584F7B8DC6C86");

                entity.ToTable("Setting", "BookingRoom");

                entity.Property(e => e.Name).HasMaxLength(64);

                entity.Property(e => e.Description).HasMaxLength(2048);

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(2048);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User", "Security");

                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Mail)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PasswordHash).IsRequired();

                entity.Property(e => e.PasswordSalt).IsRequired();

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("UserRole", "Security");

                entity.HasIndex(e => new { e.IdRole, e.IdUser }, "UserRole_Unique")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.IdRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("UserRole_Role_FK");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("UserRole_User_FK");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
