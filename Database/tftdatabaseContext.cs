using Microsoft.EntityFrameworkCore;
using tftwebapinew.Models;

namespace tftwebapinew.Database
{
    public class tftdatabaseContext : DbContext
    {
        public tftdatabaseContext(DbContextOptions<tftdatabaseContext> options) : base(options) { }

        public required DbSet<PostAnomaly> Anomalies { get; set; }
        public required DbSet<PostAugment> Augments { get; set; }
        public required DbSet<PostBoard> Board { get; set; }
        public required DbSet<PostBoardHex> boardHexes { get; set; }
        public required DbSet<PostCharacter> Character { get; set; }
        public required DbSet<PostClass> Class { get; set; }
        public virtual DbSet<PostClassLevelBonus> Classlevelbonus { get; set; }
        public required DbSet<PostFullitem_Partialitem> FullItems_PartialItems { get; set; }
        public required DbSet<PostFullitem> FullItems { get; set; }
        //public required DbSet<PostHexCell> hexCells { get; set; }
        public required DbSet<PostPartialitem> PartialItems { get; set; }
        public required DbSet<PostPermission> Permissions { get; set; }
        public required DbSet<PostUser> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the many-to-many relationship between PostCharacter and PostClass
            modelBuilder.Entity<PostCharacter>()
                .HasMany(p => p.Classes)
                .WithMany(p => p.Characters)
                .UsingEntity<Dictionary<string, object>>(
                    "characterclass",
                    j => j.HasOne<PostClass>().WithMany()
                        .HasForeignKey("ClassId")
                        .HasConstraintName("characterclass_ibfk_2"),
                    j => j.HasOne<PostCharacter>().WithMany()
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("characterclass_ibfk_1"),
                    j =>
                    {
                        j.HasKey("CharacterId", "ClassId").HasName("PRIMARY");
                        j.ToTable("characterclass");
                        j.HasIndex(new[] { "ClassId" }, "ClassID");
                        j.IndexerProperty<int>("CharacterId")
                            .HasColumnName("CharacterID");
                        j.IndexerProperty<int>("ClassId")
                            .HasColumnName("ClassID");
                    });

            // PostAnomaly configuration
            modelBuilder.Entity<PostAnomaly>()
                .HasKey(a => a.AnomalyId);

            // PostAugment configuration
            modelBuilder.Entity<PostAugment>()
                .HasKey(a => a.AugmentId);

            // PostCharacter configuration
            modelBuilder.Entity<PostCharacter>()
                .HasKey(c => c.CharacterID);

            // PostClass configuration
            modelBuilder.Entity<PostClass>()
                .HasKey(c => c.ClassId);

            // PostFullitem_Partialitem configuration
            modelBuilder.Entity<PostFullitem_Partialitem>()
                .HasKey(fipi => fipi.Id);

            // PostFullitem configuration
            modelBuilder.Entity<PostFullitem>()
                .HasKey(fi => fi.Id);

            // PostPartialitem configuration
            modelBuilder.Entity<PostPartialitem>()
                .HasKey(pi => pi.partial_item_id);

            // PostClassLevelBonus configuration - changed to composite key
            modelBuilder.Entity<PostClassLevelBonus>()
               .HasKey(clb => new { clb.ClassId, clb.Level });

            // BoardHex configuration
            modelBuilder.Entity<PostBoardHex>()
                .HasKey(bh => bh.Id);

            // Board configuration
            /*modelBuilder.Entity<PostBoard>()
                .HasKey(b => b.BoardId);*/

            // Permission configuration
            modelBuilder.Entity<PostPermission>()
                .HasKey(p => p.Id);

            // User configuration
            modelBuilder.Entity<PostUser>()
                .HasKey(u => u.Id);
        }
    }
}