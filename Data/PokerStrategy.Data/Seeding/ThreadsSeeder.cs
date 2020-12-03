namespace PokerStrategy.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using PokerStrategy.Data.Models;

    public class ThreadsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.ForumThreads.Any())
            {
                return;
            }

            await dbContext.ForumThreads.AddAsync(new ForumThread
            {
                CategoryId = 1,
                Title = "Rules",
                Content = "You cannot swear. That's pretty much it.",
                PostedById = "1",
            });

            await dbContext.SaveChangesAsync();
        }
    }
}
