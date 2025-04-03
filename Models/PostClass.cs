namespace tftwebapinew.Models
{
    public class PostClass{
        public required int ClassId {get; set;}
        public required string ClassName {get; set;}
        public required string BasicEffect {get; set;}
        public required string Classimageblob { get; set; }


        public virtual ICollection<PostClassLevelBonus> Classlevelbonus { get; set; } = new List<PostClassLevelBonus>();

        public virtual ICollection<PostCharacter> Characters { get; set; } = new List<PostCharacter>();
    }
}