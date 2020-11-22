namespace PokerStrategy.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using PokerStrategy.Data.Models;

    public class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.ForumCategories.Any())
            {
                return;
            }

            await dbContext.ForumCategories.AddAsync(new ForumCategory
            {
                Title = "No Limit Holdem",
                Description = "The Cadillac of Poker",
            });
            await dbContext.ForumCategories.AddAsync(new ForumCategory
            {
                Title = "Pot Limit Omaha",
                Description = "Join the 4-card madness",
            });
            await dbContext.ForumCategories.AddAsync(new ForumCategory
            {
                Title = "Fixed Limit 7-2 Triple Draw",
                Description = "How would you like to win with the weakest Poker hand?",
            });
            await dbContext.ForumCategories.AddAsync(new ForumCategory
            {
                Title = "Stud Hi",
                Description = "The good old 7 card guessing game",
            });
            await dbContext.ForumCategories.AddAsync(new ForumCategory
            {
                Title = "Stud Hi/Lo",
                Description = "Stud with a twist",
            });
            await dbContext.ForumCategories.AddAsync(new ForumCategory
            {
                Title = "Razz",
                Description = "Lowest cards win",
            });

            await dbContext.SaveChangesAsync();
        }
    }
}
