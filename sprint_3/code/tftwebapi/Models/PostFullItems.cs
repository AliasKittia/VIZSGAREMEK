namespace tftwebapi.Models

{
    public class PostFullItems
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required List<String> Halfitemeffect { get; set; } = new List<String>();
        public List<String> Bonuseffect { get; set; } = new List<String>();
        public required string ActiveEffect { get; set; }
    }
}