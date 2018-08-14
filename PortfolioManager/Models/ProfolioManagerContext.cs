using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PortfolioManager.Models
{
    public partial class ProfolioManagerContext : DbContext
    {
        public ProfolioManagerContext()
        {
        }

        public ProfolioManagerContext(DbContextOptions<ProfolioManagerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Instruments> Instruments { get; set; }
        public virtual DbSet<Portfolios> Portfolios { get; set; }
        public virtual DbSet<Positions> Positions { get; set; }
        public virtual DbSet<Prices> Prices { get; set; }
        public virtual DbSet<PtfValuePerDay> PtfValuePerDay { get; set; }
        public virtual DbSet<Trades> Trades { get; set; }
        public virtual DbSet<Users> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Instruments>(entity =>
            {
                entity.HasKey(e => e.Symbol);

                entity.ToTable("instruments");

                entity.Property(e => e.Symbol)
                    .HasColumnName("symbol")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Portfolios>(entity =>
            {
                entity.ToTable("portfolios");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cash)
                    .HasColumnName("cash")
                    .HasColumnType("money");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("createDate")
                    .HasColumnType("date");

                entity.Property(e => e.Limit)
                    .HasColumnName("limit")
                    .HasColumnType("money");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Policy)
                    .IsRequired()
                    .HasColumnName("policy")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Soeid)
                    .IsRequired()
                    .HasColumnName("soeid")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Soe)
                    .WithMany(p => p.Portfolios)
                    .HasForeignKey(d => d.Soeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_portfolios_users");
            });

            modelBuilder.Entity<Positions>(entity =>
            {
                entity.ToTable("positions");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BidPrice)
                    .HasColumnName("bidPrice")
                    .HasColumnType("money");

                entity.Property(e => e.InitialDate)
                    .HasColumnName("initialDate")
                    .HasColumnType("date");

                entity.Property(e => e.Ptfid).HasColumnName("ptfid");

                entity.Property(e => e.Qty).HasColumnName("qty");

                entity.Property(e => e.Symbol)
                    .IsRequired()
                    .HasColumnName("symbol")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Ptf)
                    .WithMany(p => p.Positions)
                    .HasForeignKey(d => d.Ptfid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_positions_portfolios");
            });

            modelBuilder.Entity<Prices>(entity =>
            {
                entity.ToTable("prices");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ChangeRate)
                    .HasColumnName("changeRate")
                    .HasColumnType("numeric(5, 2)");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.HighPrice)
                    .HasColumnName("highPrice")
                    .HasColumnType("money");

                entity.Property(e => e.LowPrice)
                    .HasColumnName("lowPrice")
                    .HasColumnType("money");

                entity.Property(e => e.OpenPrice)
                    .HasColumnName("openPrice")
                    .HasColumnType("money");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("money");

                entity.Property(e => e.Symbol)
                    .IsRequired()
                    .HasColumnName("symbol")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.SymbolNavigation)
                    .WithMany(p => p.Prices)
                    .HasForeignKey(d => d.Symbol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_prices_instruments");
            });

            modelBuilder.Entity<PtfValuePerDay>(entity =>
            {
                entity.ToTable("ptfValuePerDay");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Ptfid).HasColumnName("ptfid");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasColumnType("money");

                entity.HasOne(d => d.Ptf)
                    .WithMany(p => p.PtfValuePerDay)
                    .HasForeignKey(d => d.Ptfid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ptfValuePerDay_portfolios");
            });

            modelBuilder.Entity<Trades>(entity =>
            {
                entity.ToTable("trades");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("money");

                entity.Property(e => e.Ptfid).HasColumnName("ptfid");

                entity.Property(e => e.Qty).HasColumnName("qty");

                entity.Property(e => e.Symbol)
                    .IsRequired()
                    .HasColumnName("symbol")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Ptf)
                    .WithMany(p => p.Trades)
                    .HasForeignKey(d => d.Ptfid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trades_portfolios");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Soeid);

                entity.ToTable("users");

                entity.Property(e => e.Soeid)
                    .HasColumnName("soeid")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Limit)
                    .HasColumnName("limit")
                    .HasColumnType("money");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });
        }
    }
}
