using System.Text.Json.Serialization;

namespace tftwebapinew.Models
{
    public class PostBoard
    {
        public int Board_id { get; set; }
        public int id { get; set; }
        public string? Boardname { get; set; }
        public int PostUserId { get; set; } 

        [JsonIgnore]
        public virtual PostUser? PostUser { get; set; } // Made nullable to avoid initialization issues
    }
}