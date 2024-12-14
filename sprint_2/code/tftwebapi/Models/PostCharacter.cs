namespace tftwebapi.Models;

public class PostCharacter {
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Picture { get; set; } = string.Empty; // Karakter képe (URL)
    public int Cost { get; set; } // Aranyköltség
    public List<string> Items { get; set; } = new List<string>(); // Hozzárendelt tárgyak
    public List<int> Health { get; set; } = new List<int>(); // [Health1, Health2, Health3]
    public int Mana { get; set; }
    public int Armor { get; set; }
    public int MR { get; set; }
    public List<int> DPS { get; set; } = new List<int>(); // [DPS1, DPS2, DPS3]
    public List<int> Damage { get; set; } = new List<int>(); // [Damage1, Damage2, Damage3]
    public float AtkSpd { get; set; }
    public float CritRate { get; set; }
    public int Range { get; set; }
}
