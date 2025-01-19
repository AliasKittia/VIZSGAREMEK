namespace tftwebapi.Models;

public class PostCharacter
{
    public required int CharacterId { get; set; }
    public required string CharacterName { get; set; }
    public required string AbilityName { get; set; }
    public required string Ability { get; set; }
    public required int Cost { get; set; }
    public required List<int> Health { get; set; } = new List<int>();
    public required int AttackSpeed { get; set; }
    public required List<int> Damage { get; set; } = new List<int>();
    public required int AbilityPower { get; set; }
    public required List<int> Mana { get; set; } = new List<int>();
    public required int Armor { get; set; }
    public required int MagicResist { get; set; }
    public required int Range { get; set; }
    
}