using Microsoft.EntityFrameworkCore;

namespace CIDM3312_Star_Wars.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Context(serviceProvider.GetRequiredService<DbContextOptions<Context>>()))
            {
                if (context.Character.Any())
                {
                    return;
                }

                List<Character> characters = new List<Character> {

                };
                context.AddRange(characters);

                List<Weapon> weapons = new List<Weapon> {

                };
                context.AddRange(weapons);

                List<CharacterWeapon> tools = new List<CharacterWeapon> {

                };
                context.AddRange(tools);

                List<Classification> classifications = new List<Classification> {
                    
                };
                context.AddRange(classifications);

                context.SaveChanges();
            }
        }
    }
}