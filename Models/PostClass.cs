namespace tftwebapinew.Models
{
    public class PostClass{
        public required int ClassId {get; set;}
        public required string ClassName {get; set;}
        public required string BasicEffect {get; set;}
        public required string Classimageblob { get; set; }


        public virtual ICollection<ClassLevelBonus> Classlevelbonus { get; set; } = new List<ClassLevelBonus>();

        public virtual ICollection<PostCharacter> Characters { get; set; } = new List<PostCharacter>();
    }
}