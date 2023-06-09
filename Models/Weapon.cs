using System.ComponentModel.DataAnnotations;

namespace CIDM3312_Star_Wars.Models
{
    public class Weapon
    {
        public int WeaponID {get; set;} // Primary Key
        [Required]
        [Display(Name = "Weapon")]
        public string WeaponName {get; set;} = string.Empty;
        
        // WeaponDamage is a string because the value is ??-?? so string allows this be inputted easier
        [Display(Name = "Damage (Back-Front)")]
        public string WeaponDamage {get; set;} = string.Empty;
        public List<CharacterWeapon> CharacterWeapons {get; set;} = default!; // Navigation Property
    }

    public class CharacterWeapon
    {
        public int CharacterID {get; set;}     // Composite Primary Key, Foreign Key 1
        public int WeaponID {get; set;}    // Composite Primary Key, Foreign Key 2
        public Character Character {get; set;} = default!; // Navigation Property. One Character per CharacterWeapon
        public Weapon Weapon {get; set;} = default!;   // Navigation Property. One Weapon per CharacterWeapon
    }
}