namespace tftwebapi.Models
{
    public class PostAnomalies
    {
        public required int AnomalyId { get; set; }
        public required string AnomalyName { get; set; }
        public required string AnomalyEffect { get; set; }
        
    }
}