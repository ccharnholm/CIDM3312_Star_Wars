using Microsoft.EntityFrameworkCore;

namespace CIDM3312_Star_Wars.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Creating the keys for table that connects many-to-many relationship
            modelBuilder.Entity<CharacterWeapon>().HasKey(c => new {c.WeaponID, c.CharacterID});
        }

        public DbSet<Character> Character {get; set;} = default!;
        public DbSet<Weapon> Weapon {get; set;} = default!; 
        public DbSet<CharacterWeapon> CharacterWeapon {get; set;} = default!;
    }
}