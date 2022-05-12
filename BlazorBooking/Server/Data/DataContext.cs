using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BlazorBooking.Server.Data
{
    public partial class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=BlazorBooking;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.HasKey(e => e.IdAppointment)
                    .HasName("appointments_PK");
                
                entity.ToTable("appointments");

                entity.Property(e => e.IdAppointment).HasColumnName("idAppointment");

                entity.Property(e => e.DateHour)
                    .HasColumnType("datetime")
                    .HasColumnName("dateHour");

                entity.Property(e => e.EventSubject)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("eventSubject");

                entity.Property(e => e.IdRoom).HasColumnName("idRoom");

                entity.HasOne(d => d.IdRoomNavigation)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.IdRoom)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("appointments_rooms_FK");

                entity.HasMany(d => d.IdEmployees)
                    .WithMany(p => p.IdAppointments)
                    .UsingEntity<Dictionary<string, object>>(
                        "Book",
                        l => l.HasOne<Employee>().WithMany().HasForeignKey("IdEmployee").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("book_employees0_FK"),
                        r => r.HasOne<Appointment>().WithMany().HasForeignKey("IdAppointment").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("book_appointments_FK"),
                        j =>
                        {
                            j.HasKey("IdAppointment", "IdEmployee").HasName("book_PK");

                            j.ToTable("book");

                            j.IndexerProperty<int>("IdAppointment").HasColumnName("idAppointment");

                            j.IndexerProperty<int>("IdEmployee").HasColumnName("idEmployee");
                        });
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.IdEmployee)
                    .HasName("employees_PK");

                entity.ToTable("employees");

                entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("firstname");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lastname");

                entity.Property(e => e.Mail)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("mail");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasKey(e => e.IdRoom)
                    .HasName("rooms_PK");

                entity.ToTable("rooms");

                entity.Property(e => e.IdRoom).HasColumnName("idRoom");

                entity.Property(e => e.MaxParticipant).HasColumnName("maxParticipant");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
