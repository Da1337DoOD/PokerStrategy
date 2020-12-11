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
                ImageUrl = "https://www.chriswilcoxpoker.com/wp-content/uploads/2012/11/onlinepoker.jpg",
            });
            await dbContext.ForumCategories.AddAsync(new ForumCategory
            {
                Title = "Pot Limit Omaha",
                Description = "Join the 4-card madness",
                ImageUrl = "https://www.internettexasholdem.com/wp/wp-content/uploads/2013/06/plo-300.jpg",
            });
            await dbContext.ForumCategories.AddAsync(new ForumCategory
            {
                Title = "Fixed Limit 7-2 Triple Draw",
                Description = "How would you like to win with the weakest Poker hand?",
                ImageUrl = "https://upswingpoker.com/wp-content/uploads/2017/12/27-the-wheel-1024x643.jpg",
            });
            await dbContext.ForumCategories.AddAsync(new ForumCategory
            {
                Title = "Stud Hi",
                Description = "The good old 7 card guessing game",
                ImageUrl = "https://lh3.googleusercontent.com/proxy/a3xovTrJB-MQcpI1s3YY9XdEmZg4XdkdDAbrfB8wOQmKGML12bpX_E_-1n_ir00kID7iMVTovamRmaDMIoX1bid3b1MOK5g7ZnmtxAZkLLTbA1r-tJXSoJph8XD9vqQKSSX6Ttp5hqwSiO9WyyM",
            });
            await dbContext.ForumCategories.AddAsync(new ForumCategory
            {
                Title = "Stud Hi/Lo",
                Description = "Stud with a twist",
                ImageUrl = "https://www.casinoencyclopedia.com/wp-content/uploads/2019/12/Omaha-Hi-Lo-Poker.png",
            });
            await dbContext.ForumCategories.AddAsync(new ForumCategory
            {
                Title = "Razz",
                Description = "Lowest cards win",
                ImageUrl = "https://debitcardcasino.ca/how-to/wp-content/uploads/sites/9/2020/05/seven-stud-hi-low-wheel.png",
            });

            await dbContext.SaveChangesAsync();
        }
    }
}
