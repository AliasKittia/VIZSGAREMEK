using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProjectName_Backend.Models;

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

    public virtual DbSet<Fullitem> Fullitems { get; set; }

    public virtual DbSet<FullitemsPartialitem> FullitemsPartialitems { get; set; }

    public virtual DbSet<Partialitem> Partialitems { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("SERVER=localhost;PORT=3306;DATABASE=Tftdatabase;USER=root;PASSWORD=;SSL MODE=none;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Anomaly>(entity =>
        {
            entity.HasKey(e => e.AnomalyId).HasName("PRIMARY");

            entity.ToTable("anomalies");

            entity.Property(e => e.AnomalyId).HasColumnType("int(11)");
            entity.Property(e => e.AnomalyEffect)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text");
            entity.Property(e => e.AnomalyName)
                .HasMaxLength(50)
                .HasDefaultValueSql("'NULL'");
        });

        modelBuilder.Entity<Augment>(entity =>
        {
            entity.HasKey(e => e.AugmentId).HasName("PRIMARY");

            entity.ToTable("augments");

            entity.Property(e => e.AugmentId).HasColumnType("int(11)");
            entity.Property(e => e.AugmentEffect)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text");
            entity.Property(e => e.AugmentName)
                .HasMaxLength(40)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.AugmentRarity)
                .HasMaxLength(15)
                .HasDefaultValueSql("'NULL'");
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
            entity.Property(e => e.Ability)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text");
            entity.Property(e => e.AbilityName)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.AbilityPower)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.Armor)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.AttackSpeed).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.CharacterName).HasMaxLength(50);
            entity.Property(e => e.Characterimageblob).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Cost)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.Damage)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.Damage1)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.Damage2)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.Health)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.Health1)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.Health2)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.MagicResist)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.ManaMax)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.ManaStart)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.Range)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");

            entity.HasMany(d => d.Classes).WithMany(p => p.Characters)
                .UsingEntity<Dictionary<string, object>>(
                    "Characterclass",
                    r => r.HasOne<Class>().WithMany()
                        .HasForeignKey("ClassId")
                        .HasConstraintName("characterclass_ibfk_2"),
                    l => l.HasOne<Character>().WithMany()
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("characterclass_ibfk_1"),
                    j =>
                    {
                        j.HasKey("CharacterId", "ClassId").HasName("PRIMARY");
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
            entity.Property(e => e.BasicEffect)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text");
            entity.Property(e => e.ClassName).HasMaxLength(50);
            entity.Property(e => e.Classimageblob).HasDefaultValueSql("'NULL'");
        });

        modelBuilder.Entity<Classlevelbonu>(entity =>
        {
            entity.HasKey(e => new { e.ClassId, e.Level }).HasName("PRIMARY");

            entity.ToTable("classlevelbonus");

            entity.Property(e => e.ClassId)
                .HasColumnType("int(11)")
                .HasColumnName("ClassID");
            entity.Property(e => e.Level).HasColumnType("int(11)");
            entity.Property(e => e.BonusEffect)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text");
            entity.Property(e => e.CharacterCount)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");

            entity.HasOne(d => d.Class).WithMany(p => p.Classlevelbonus)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("classlevelbonus_ibfk_1");
        });

        modelBuilder.Entity<Fullitem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("fullitems");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.ActiveEffect)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text");
            entity.Property(e => e.Bonuseffect)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text")
                .HasColumnName("bonuseffect");
            entity.Property(e => e.Bonuseffect1)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text")
                .HasColumnName("bonuseffect1");
            entity.Property(e => e.Bonuseffect2)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text")
                .HasColumnName("bonuseffect2");
            entity.Property(e => e.Fullitemimageblob).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Halfitemeffect1)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text");
            entity.Property(e => e.Halfitemeffect2)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text");
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
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text")
                .HasColumnName("effect");
            entity.Property(e => e.HalfItemimageblob).HasDefaultValueSql("'NULL'");
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
