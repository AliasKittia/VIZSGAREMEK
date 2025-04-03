using Microsoft.EntityFrameworkCore;
using tftwebapinew.Models;
using tftwebapinew.DTO;

namespace tftwebapinew.Database
{
    public class tftdatabaseContext : DbContext
    {
        public tftdatabaseContext(DbContextOptions<tftdatabaseContext> options) : base(options) { }

        public required DbSet<PostAnomaly> Anomalies { get; set; }
        public required DbSet<PostAugment> Augments { get; set; }
        public required DbSet<PostBoard> Board {get; set;}
        public required DbSet<PostBoardHex> BoardHexes {get;set;}
        public required DbSet<PostCharacter> Character { get; set; }
        public required DbSet<PostClass> Class { get; set; }
        public virtual DbSet<PostClassLevelBonus> Classlevelbonus { get; set; }
        public required DbSet<PostFullitem_Partialitem> FullItems_PartialItems { get; set; }
        public required DbSet<PostFullitem> FullItems { get; set; }
         public required DbSet<PostPartialitem> PartialItems { get; set; }
        public required DbSet<PostPermission> Permissions {get; set;}
        public required DbSet<PostUser> User {get;set;}
       
        
protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // PostAnomalies konfiguráció
            modelBuilder.Entity<PostAnomaly>()
                .HasKey(a => a.AnomalyId); // AnomalyId mint elsődleges kulcs

            // PostAugments konfiguráció
            modelBuilder.Entity<PostAugment>()
                .HasKey(a => a.AugmentId); // AugmentId mint elsődleges kulcs

            // PostCharacter konfiguráció
            modelBuilder.Entity<PostCharacter>()
                .HasKey(c => c.CharacterID); // CharacterId mint elsődleges kulcs

            // PostClass konfiguráció
            modelBuilder.Entity<PostClass>()
                .HasKey(c => c.ClassId); // ClassId mint elsődleges kulcs

            
            // PostFullItem_PartialItems konfiguráció
            modelBuilder.Entity<PostFullitem_Partialitem>()
                .HasKey(fipi => fipi.Id); // FullItemId mint elsődleges kulcs

            // PostFullItems konfiguráció
            modelBuilder.Entity<PostFullitem>()
                .HasKey(fi => fi.Id); // FullItemId mint elsődleges kulcs

            // PostPartialItems konfiguráció
            modelBuilder.Entity<PostPartialitem>()
                .HasKey(pi => pi.partial_item_id); // PartialItemId mint elsődleges kulcs

            modelBuilder.Entity<PostClassLevelBonus>()
               .HasKey(clb => clb.ClassId); // PartialItemId mint elsődleges kulcs
        }
    }
    

    }

