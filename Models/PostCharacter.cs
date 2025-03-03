namespace tftwebapi.Models;

public class PostCharacter
{
    public required int CharacterId { get; set; }
    public required string CharacterName { get; set; }
    public required string AbilityName { get; set; }
    public required string Ability { get; set; }
    public required int Cost { get; set; }
    public required int Health { get; set; } 
    public required int Health1 { get; set; } 
    public required int Health2 { get; set; } 
    public required double AttackSpeed { get; set; }
    public required int Damage { get; set; } 
    public required int Damage1{ get; set; }
    public required int Damage2 { get; set; }
    public required int AbilityPower { get; set; }
    public required int ManaStart { get; set; }
    public required int ManaMax { get; set; } 
    public required int Armor { get; set; }
    public required int MagicResist { get; set; }
    public required int Range { get; set; }
    public required string CharacterImageBlob { get; set; } // Updated property name
}