using Microsoft.EntityFrameworkCore;
using tftwebapi.Models;

namespace tftwebapi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public required DbSet<PostAnomalies> Anomalies { get; set; }
        public required DbSet<PostAugments> Augments { get; set; }
        public required DbSet<PostCharacter> Characters { get; set; }
        public required DbSet<PostCharacterClass> CharacterClasses { get; set; } 
        public required DbSet<PostClass> Classes { get; set; }
        public required DbSet<PostClassLvlBonus> ClassLvlBonuses { get; set; }
        public required DbSet<PostFullItem_PartialItems> FullItems_PartialItems { get; set; }
        public required DbSet<PostFullItems> FullItems { get; set; }
        public required DbSet<PostPartialItems> PartialItems { get; set; }


protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // PostAnomalies konfiguráció
            modelBuilder.Entity<PostAnomalies>()
                .HasKey(a => a.AnomalyId); // AnomalyId mint elsődleges kulcs

            // PostAugments konfiguráció
            modelBuilder.Entity<PostAugments>()
                .HasKey(a => a.AugmentId); // AugmentId mint elsődleges kulcs

            // PostCharacter konfiguráció
            modelBuilder.Entity<PostCharacter>()
                .HasKey(c => c.CharacterId); // CharacterId mint elsődleges kulcs

            // PostCharacterClass konfiguráció
            modelBuilder.Entity<PostCharacterClass>()
                .HasKey(cc => new { cc.CharacterId, cc.ClassId }); // Composite key with CharacterId and ClassId

            // PostClass konfiguráció
            modelBuilder.Entity<PostClass>()
                .HasKey(c => c.ClassId); // ClassId mint elsődleges kulcs

            // PostClassLvlBonus konfiguráció
            modelBuilder.Entity<PostClassLvlBonus>()
                .HasKey(clb => new { clb.ClassId, clb.Level }); // Composite key with ClassId and Level

            // PostFullItem_PartialItems konfiguráció
            modelBuilder.Entity<PostFullItem_PartialItems>()
                .HasKey(fipi => fipi.Id); // FullItemId mint elsődleges kulcs

            // PostFullItems konfiguráció
            modelBuilder.Entity<PostFullItems>()
                .HasKey(fi => fi.Id); // FullItemId mint elsődleges kulcs

            // PostPartialItems konfiguráció
            modelBuilder.Entity<PostPartialItems>()
                .HasKey(pi => pi.PartialItemId); // PartialItemId mint elsődleges kulcs
        }
    }
}