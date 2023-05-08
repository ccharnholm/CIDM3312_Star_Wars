using System.ComponentModel.DataAnnotations;

namespace CIDM3312_Star_Wars.Models
{
    public class Character
    {
        public int CharacterID {get; set;}

        [Required]
        public string Name {get; set;} = string.Empty;

        public int Health  {get; set;}
        public int BattlePoints {get; set;}
        
        [Required]
        public string Class {get; set;} = string.Empty;

        [Required]
        public string Subclass {get; set;} = string.Empty;

        [Required]
        public string Allegiance {get; set;} = string.Empty;
        public List<CharacterWeapon>? CharacterWeapons {get; set;} = default!; // Navigation Property. Character can have many CharacterWeapon

    }
}