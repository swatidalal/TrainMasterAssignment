using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TrainMaster.Data.Models
{
    public partial class TrainMasterContext : DbContext
    {
        public TrainMasterContext()
        {
        }

        public TrainMasterContext(DbContextOptions<TrainMasterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DaysOnWhichEveryTrainRun> DaysOnWhichEveryTrainRuns { get; set; } = null!;
        public virtual DbSet<Train> Trains { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=SWATI;Database=TrainMaster;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DaysOnWhichEveryTrainRun>(entity =>
            {
                entity.Property(e => e.TrainRunDays)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.TrainNoNavigation)
                    .WithMany(p => p.DaysOnWhichEveryTrainRuns)
                    .HasForeignKey(d => d.TrainNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DaysOnWhichEveryTrainRuns_Train");
            });

            modelBuilder.Entity<Train>(entity =>
            {
                entity.HasKey(e => e.TrainNo);

                entity.ToTable("Train");

                entity.Property(e => e.TrainNo).ValueGeneratedNever();

                entity.Property(e => e.FromStation)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.ToStation)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.TrainName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
