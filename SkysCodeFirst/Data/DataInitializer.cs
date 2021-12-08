using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SkysCodeFirst.Data
{
    public class DataInitializer
    {
        public void MigrateAndSeed(ApplicationDbContext context)
        {
            context.Database.Migrate(); //Skapa opm inte finns
            // Synka alla C# klasser -> tabeller

            SeedCountys(context);
            context.SaveChanges();
            //Seeda en default user
            //SeedProduct();
            //SeedCategory();
        }

        private void SeedCountys(ApplicationDbContext context)
        {
            // Kolla i databasen - finns Stockholms län? Nej - SKapa
            if (!context.County.Any(r => r.Name == "Stockholms län"))
            {
                context.County.Add(new County { ContactPerson = "Kalle", Name = "Stockholms län" });
            }
            if (!context.County.Any(r => r.Name == "Västra Götalands län"))
            {
                context.County.Add(new County { ContactPerson = "Lisa", Name = "Västra Götalands län" });
            }
        }
    }
}