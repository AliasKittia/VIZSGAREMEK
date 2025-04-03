using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace tftwebapinew.Models;

public partial class TftdatabaseContext : DbContext
{
    public TftdatabaseContext()
    {
    }

    public TftdatabaseContext(DbContextOptions<TftdatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Anomaly> Anomalies { get; set; }

    public virtual DbSet<Augment> Augments { get; set; }

    public virtual DbSet<Board> Boards { get; set; }

    public virtual DbSet<BoardHex> BoardHexes { get; set; }

    public virtual DbSet<Character> Characters { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Classlevelbonu> Classlevelbonus { get; set; }

    public virtual DbSet<Efmigrationshistory> Efmigrationshistories { get; set; }

    public virtual DbSet<Fullitem> Fullitems { get; set; }

    public virtual DbSet<FullitemsPartialitem> FullitemsPartialitems { get; set; }

    public virtual DbSet<Partialitem> Partialitems { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=tftdatabase;user=root;ssl mode=none", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.28-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_hungarian_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Anomaly>(entity =>
        {
            entity.HasKey(e => e.AnomalyId).HasName("PRIMARY");

            entity.ToTable("anomalies");

            entity.Property(e => e.AnomalyId).HasColumnType("int(11)");
            entity.Property(e => e.AnomalyEffect).HasColumnType("text");
            entity.Property(e => e.AnomalyName).HasMaxLength(50);
        });

        modelBuilder.Entity<Augment>(entity =>
        {
            entity.HasKey(e => e.AugmentId).HasName("PRIMARY");

            entity.ToTable("augments");

            entity.Property(e => e.AugmentId).HasColumnType("int(11)");
            entity.Property(e => e.AugmentEffect).HasColumnType("text");
            entity.Property(e => e.AugmentName).HasMaxLength(40);
            entity.Property(e => e.AugmentRarity).HasMaxLength(15);
        });

        modelBuilder.Entity<Board>(entity =>
        {
            entity.HasKey(e => e.BoardId).HasName("PRIMARY");

            entity.ToTable("board");

            entity.HasIndex(e => e.Id, "Id");

            entity.Property(e => e.BoardId)
                .HasColumnType("int(11)")
                .HasColumnName("Board_id");
            entity.Property(e => e.Boardname).HasMaxLength(100);
            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.PostUserId).HasColumnType("int(11)");

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.Boards)
                .HasForeignKey(d => d.Id)
                .HasConstraintName("board_ibfk_1");
        });

        modelBuilder.Entity<BoardHex>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("board_hexes");

            entity.HasIndex(e => e.BoardId, "Board_id");

            entity.HasIndex(e => e.CharacterId, "CharacterID");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.BoardId)
                .HasColumnType("int(11)")
                .HasColumnName("Board_id");
            entity.Property(e => e.CharacterId)
                .HasColumnType("int(11)")
                .HasColumnName("CharacterID");
            entity.Property(e => e.HexX)
                .HasColumnType("int(11)")
                .HasColumnName("hex_x");
            entity.Property(e => e.HexY)
                .HasColumnType("int(11)")
                .HasColumnName("hex_y");

            entity.HasOne(d => d.Character).WithMany(p => p.BoardHexes)
                .HasForeignKey(d => d.CharacterId)
                .HasConstraintName("board_hexes_ibfk_2");
        });

        modelBuilder.Entity<Character>(entity =>
        {
            entity.HasKey(e => e.CharacterId).HasName("PRIMARY");

            entity.ToTable("character");

            entity.Property(e => e.CharacterId)
                .HasColumnType("int(11)")
                .HasColumnName("CharacterID");
            entity.Property(e => e.Ability).HasColumnType("text");
            entity.Property(e => e.AbilityName).HasMaxLength(255);
            entity.Property(e => e.AbilityPower).HasColumnType("int(11)");
            entity.Property(e => e.Armor).HasColumnType("int(11)");
            entity.Property(e => e.CharacterName).HasMaxLength(50);
            entity.Property(e => e.Characterimageblob).HasMaxLength(255);
            entity.Property(e => e.Cost).HasColumnType("int(11)");
            entity.Property(e => e.Damage).HasColumnType("int(11)");
            entity.Property(e => e.Damage1).HasColumnType("int(11)");
            entity.Property(e => e.Damage2).HasColumnType("int(11)");
            entity.Property(e => e.Health).HasColumnType("int(11)");
            entity.Property(e => e.Health1).HasColumnType("int(11)");
            entity.Property(e => e.Health2).HasColumnType("int(11)");
            entity.Property(e => e.MagicResist).HasColumnType("int(11)");
            entity.Property(e => e.ManaMax).HasColumnType("int(11)");
            entity.Property(e => e.ManaStart).HasColumnType("int(11)");
            entity.Property(e => e.Range).HasColumnType("int(11)");

            entity.HasMany(d => d.Classes).WithMany(p => p.Characters)
                .UsingEntity<Dictionary<string, object>>(
                    "Characterclass",
                    r => r.HasOne<Class>().WithMany()
                        .HasForeignKey("ClassId")
                        .HasConstraintName("characterclass_ibfk_2"),
                    l => l.HasOne<Character>().WithMany()
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("characterclass_ibfk_1"),
                    j =>
                    {
                        j.HasKey("CharacterId", "ClassId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("characterclass");
                        j.HasIndex(new[] { "ClassId" }, "ClassID");
                        j.IndexerProperty<int>("CharacterId")
                            .HasColumnType("int(11)")
                            .HasColumnName("CharacterID");
                        j.IndexerProperty<int>("ClassId")
                            .HasColumnType("int(11)")
                            .HasColumnName("ClassID");
                    });
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.ClassId).HasName("PRIMARY");

            entity.ToTable("class");

            entity.Property(e => e.ClassId)
                .HasColumnType("int(11)")
                .HasColumnName("ClassID");
            entity.Property(e => e.BasicEffect).HasColumnType("text");
            entity.Property(e => e.ClassName).HasMaxLength(50);
            entity.Property(e => e.Classimageblob).HasMaxLength(255);
        });

        modelBuilder.Entity<Classlevelbonu>(entity =>
        {
            entity.HasKey(e => new { e.ClassId, e.Level })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("classlevelbonus");

            entity.Property(e => e.ClassId)
                .HasColumnType("int(11)")
                .HasColumnName("ClassID");
            entity.Property(e => e.Level).HasColumnType("int(11)");
            entity.Property(e => e.BonusEffect).HasColumnType("text");
            entity.Property(e => e.CharacterCount).HasColumnType("int(11)");

            entity.HasOne(d => d.Class).WithMany(p => p.Classlevelbonus)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("classlevelbonus_ibfk_1");
        });

        modelBuilder.Entity<Efmigrationshistory>(entity =>
        {
            entity.HasKey(e => e.MigrationId).HasName("PRIMARY");

            entity
                .ToTable("__efmigrationshistory")
                .UseCollation("utf8mb4_general_ci");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

        modelBuilder.Entity<Fullitem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("fullitems");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.ActiveEffect).HasColumnType("text");
            entity.Property(e => e.Bonuseffect)
                .HasColumnType("text")
                .HasColumnName("bonuseffect");
            entity.Property(e => e.Bonuseffect1)
                .HasColumnType("text")
                .HasColumnName("bonuseffect1");
            entity.Property(e => e.Bonuseffect2)
                .HasColumnType("text")
                .HasColumnName("bonuseffect2");
            entity.Property(e => e.Fullitemimageblob).HasMaxLength(255);
            entity.Property(e => e.Halfitemeffect1).HasColumnType("text");
            entity.Property(e => e.Halfitemeffect2).HasColumnType("text");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<FullitemsPartialitem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("fullitems_partialitems");

            entity.HasIndex(e => e.FullItemId, "FullItemId");

            entity.HasIndex(e => e.PartialItemId1, "PartialItemId1");

            entity.HasIndex(e => e.PartialItemId2, "PartialItemId2");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.FullItemId).HasColumnType("int(11)");
            entity.Property(e => e.PartialItemId1).HasColumnType("int(11)");
            entity.Property(e => e.PartialItemId2).HasColumnType("int(11)");

            entity.HasOne(d => d.FullItem).WithMany(p => p.FullitemsPartialitems)
                .HasForeignKey(d => d.FullItemId)
                .HasConstraintName("fullitems_partialitems_ibfk_1");

            entity.HasOne(d => d.PartialItemId1Navigation).WithMany(p => p.FullitemsPartialitemPartialItemId1Navigations)
                .HasForeignKey(d => d.PartialItemId1)
                .HasConstraintName("fullitems_partialitems_ibfk_2");

            entity.HasOne(d => d.PartialItemId2Navigation).WithMany(p => p.FullitemsPartialitemPartialItemId2Navigations)
                .HasForeignKey(d => d.PartialItemId2)
                .HasConstraintName("fullitems_partialitems_ibfk_3");
        });

        modelBuilder.Entity<Partialitem>(entity =>
        {
            entity.HasKey(e => e.PartialItemId).HasName("PRIMARY");

            entity.ToTable("partialitems");

            entity.Property(e => e.PartialItemId)
                .HasColumnType("int(11)")
                .HasColumnName("partial_item_id");
            entity.Property(e => e.Effect)
                .HasColumnType("text")
                .HasColumnName("effect");
            entity.Property(e => e.HalfItemimageblob).HasMaxLength(255);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("permission");

            entity.HasIndex(e => e.Name, "Nev").IsUnique();

            entity.HasIndex(e => e.Level, "Szint").IsUnique();

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.Level).HasColumnType("int(1)");
            entity.Property(e => e.Name).HasMaxLength(32);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user");

            entity.HasIndex(e => e.Email, "Email").IsUnique();

            entity.HasIndex(e => e.PermissionId, "Jog");

            entity.HasIndex(e => e.LoginName, "LoginNev").IsUnique();

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Email).HasMaxLength(64);
            entity.Property(e => e.Hash)
                .HasMaxLength(64)
                .HasColumnName("HASH");
            entity.Property(e => e.LoginName).HasMaxLength(16);
            entity.Property(e => e.Name).HasMaxLength(64);
            entity.Property(e => e.PermissionId).HasColumnType("int(11)");
            entity.Property(e => e.ProfilePicturePath).HasMaxLength(64);
            entity.Property(e => e.Salt)
                .HasMaxLength(64)
                .HasColumnName("SALT");

            entity.HasOne(d => d.Permission).WithMany(p => p.Users)
                .HasForeignKey(d => d.PermissionId)
                .HasConstraintName("user_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
