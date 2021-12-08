using System;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SkysCodeFirst.Data;

namespace SkysCodeFirst
{
    internal class Program
    {
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
                context.Database.Migrate(); //Skapa opm inte finns
                                                // Synka alla C# klasser -> tabeller
            }

            using (var context = new ApplicationDbContext(options.Options))
            {
                context.Person.Add(new Person
                {
                    Age = 12,
                    Name = "Stefan"
                });
                context.SaveChanges();

                foreach (var person in context.Person)
                {
                    Console.WriteLine($"{person.Name}");
                }
            }

            Console.WriteLine("Hello World!");
        }
    }
}
