using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIDM3312_Star_Wars.Models
{
    public class Character
    {
        public int CharacterID {get; set;}

        [Required]
        public string Name {get; set;} = string.Empty;

        public int Health  {get; set;}
        public int BattlePoints {get; set;}
        public List<CharacterWeapon>? CharacterWeapons {get; set;} = default!; // Navigation Property. Weapon can have many CharacterWeapon
        public ICollection<Classification>? Classifications {get; set;} = default!; // Navigation Property for Classification

    }

    public class Classification
    {
        public int CharacterIdFK {get; set;}     // Composite Primary Key, Foreign Key 1

        [Required]
        public string Class {get; set;} = string.Empty;

        [Required]
        public string Subclass {get; set;} = string.Empty;

        [Required]
        public string Allegiance {get; set;} = string.Empty;

        public Character Character {get; set;} = default!; // Navigation Property. One Character per Classification
    }
}