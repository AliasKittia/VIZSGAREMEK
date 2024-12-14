namespace tftwebapi.Models;

public class PostItem {
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty; // Ikon URL
    public string Description { get; set; } = string.Empty;
    public List<int> Components { get; set; } = new List<int>(); // Alapanyagok (id-k)
    public string Effects { get; set; } = string.Empty; // Speciális képesség leírása
}
