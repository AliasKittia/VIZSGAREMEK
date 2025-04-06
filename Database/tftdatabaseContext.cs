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
        public required DbSet<PostPartialitem> PartialItems { get; set; }
        public required DbSet<PostPermission> Permission { get; set; }
        public required DbSet<PostUser> User { get; set; }
        public required DbSet<PostCharacterClass> CharacterClass { get; set; } // Many-to-many relationship

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the many-to-many relationship between PostCharacter and PostClass
            modelBuilder.Entity<PostCharacterClass>()
                .HasKey(cc => new { cc.CharacterID, cc.ClassID });

            modelBuilder.Entity<PostCharacterClass>()
                .HasOne<PostCharacter>()
                .WithMany()
                .HasForeignKey(cc => cc.CharacterID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PostCharacterClass>()
                .HasOne<PostClass>()
                .WithMany()
                .HasForeignKey(cc => cc.ClassID)
                .OnDelete(DeleteBehavior.Restrict);

            // Entity configurations
            modelBuilder.Entity<PostAnomaly>().HasKey(a => a.AnomalyId);
            modelBuilder.Entity<PostAugment>().HasKey(a => a.AugmentId);
            modelBuilder.Entity<PostCharacter>().HasKey(c => c.CharacterID);
            modelBuilder.Entity<PostClass>().HasKey(c => c.ClassId);
            modelBuilder.Entity<PostFullitem_Partialitem>().HasKey(fipi => fipi.Id);
            modelBuilder.Entity<PostFullitem>().HasKey(fi => fi.Id);
            modelBuilder.Entity<PostPartialitem>().HasKey(pi => pi.partial_item_id);
            modelBuilder.Entity<PostClassLevelBonus>().HasKey(clb => new { clb.ClassId, clb.Level });
            modelBuilder.Entity<PostBoardHex>().HasKey(bh => bh.Id);
            modelBuilder.Entity<PostPermission>().HasKey(p => p.Id);
            modelBuilder.Entity<PostUser>().HasKey(u => u.Id);
        }
    }
}
