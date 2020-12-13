namespace PokerStrategy.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using PokerStrategy.Data.Models;

    public class VideosSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Videos.Any())
            {
                return;
            }

            await dbContext.Videos.AddAsync(new Video
            {
                Category = "PLO",
                Description = "First part of 5 Card PLO8 tutorial. Enjoy!",
                Title = "5 Card PLO8 Tutorial - Part 1",
                CreatedOn = DateTime.UtcNow,
                VideoUrl = "https://www.youtube.com/watch?v=TZe7YYo_yHk&list=PLcVum1emliVJ1Kg7XoLcDp_8IxmLQQLk0&index=11&t=176s",
            });

            await dbContext.Videos.AddAsync(new Video
            {
                Category = "PLO",
                Description = "Second part of 5 Card PLO8 tutorial. Enjoy!",
                Title = "5 Card PLO8 Tutorial - Part 2",
                CreatedOn = DateTime.UtcNow,
                VideoUrl = "https://www.youtube.com/watch?v=bVlS72JrRi8&list=PLcVum1emliVJ1Kg7XoLcDp_8IxmLQQLk0&index=10",
            });

            await dbContext.Videos.AddAsync(new Video
            {
                Category = "PLO",
                Description = "Third part of 5 Card PLO8 tutorial. We discuss a very interesting hand. Enjoy!",
                Title = "5 Card PLO8 Tutorial - Part 3",
                CreatedOn = DateTime.UtcNow,
                VideoUrl = "https://www.youtube.com/watch?v=XyDXOTGsv4w&list=PLcVum1emliVJ1Kg7XoLcDp_8IxmLQQLk0&index=9",
            });

            await dbContext.SaveChangesAsync();
        }
    }
}
