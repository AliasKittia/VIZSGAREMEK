namespace tftwebapinew.DTO{
    public class HexCellDTO
    {
        public int Id { get; set; }
        public int BoardId { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int? CharacterId { get; set; }
    }
}