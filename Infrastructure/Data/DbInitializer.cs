using Core.Entities;
using System;
using System.Linq;

namespace Infrastructure.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Topics.Any())
            {
                Console.WriteLine($"    -   DB has been seeded");
                return;
            }

            var topics = new Topic[]
            {
                Topic.Create("Frontend"),
                Topic.Create("Backend"),
                Topic.Create("Frontend and Backend")
            };
            foreach (Topic t in topics)
            {
                context.Topics.Add(t);
            }
            context.SaveChanges();
            Console.WriteLine($"    -   seeding DB ...");
        }
    }
}