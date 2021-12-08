using System;
using System.Linq;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SkysCodeFirst.Data;

namespace SkysCodeFirst
{
    internal class Program
    {
        //Country  
        // Code, Namn
        // SE, Sweden
        // NO, Norway

        // country_code  SE

        //Vid varje ändring i klass(er) som rör databas:
        // kör add-migration på kommandoraden
        // add-migration =  skapas KOD i en cs FIL (i Migrations)
        // Denna källkodshanteras som vanlig kod utan att vi behöver bry oss
        // När man kör f5 körs context.Database.Migrate(); 
        //      och det som händer i denna är att de cs-filer som inte är körda körs i aktuell databas 

        //NU: Attributes
        //Ändring! Lägg till kolumn 
        //Ändring 2 Lägg till tabell - County (svenska LÄN) id, namn, kontaktperson
        // Person ska ha en sån!
        // Seed data.
        // Dvs om nån F5:ar måste vi se till att det finns tex 
        //                    default data i stödtabeller etc etc
        //              Så vi ska fylla County  med "Stockholms län", "Västra Götalands län"               

        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", true, true);
            var config = builder.Build();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>();
            string s =
                config.GetConnectionString("DefaultConnection");
            options.UseSqlServer(s);

            using (var context = new ApplicationDbContext(options.Options))
            {
                var dataInitializer = new DataInitializer();
                dataInitializer.MigrateAndSeed(context);
            }

            using (var context = new ApplicationDbContext(options.Options))
            {



                Console.WriteLine("Ange namn:");
                string namn = Console.ReadLine();
                Console.WriteLine("Ange age:");
                int age = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ange shoesize:");
                int shoesize = Convert.ToInt32(Console.ReadLine());

                foreach (var county in context.County)
                {
                    Console.WriteLine($"{county.Id}  {county.Name}");
                }

                Console.WriteLine("Ange id på county:"); // Stockholms läns

                int countyid = Convert.ToInt32(Console.ReadLine());
                var coun = context.County.First(e=>e.Id == countyid);

                context.Person.Add(new Person
                {
                    Age = age,
                    Name = namn,
                    ShoeSize = shoesize,
                    County = coun
                });

                context.SaveChanges();

                foreach (var person in context.Person.Include(e => e.County))
                {
                    string countyname = "";
                    if (person.County != null)
                        countyname = person.County.Name;
                    Console.WriteLine($"{person.Name} {countyname}");
                }

            }

            Console.WriteLine("Hello World!");
        }
    }
}
