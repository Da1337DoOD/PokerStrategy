namespace PokerStrategy.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using PokerStrategy.Data.Models;

    public class ThreadsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.ForumThreads.Any())
            {
                return;
            }

            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var reply = new ForumReply
            {
                Content = "Today was Sunday for me and I played poker all day and boy it was rough! I took a swing down to -$234 and then fought my way back to -$35.63 over 10k hands at Zoom 25M... My poker bankroll re - build is going OK. I'm saving all my Stars coins for rainy day to convert into cash if needed.  <br><br>Anyway, I just got this PokerStars mods called \"HM Classic Theme\" from pokergrahics and It includes card mods in the package deal.I just tried it out today and it was much easier on the eyes than the stock themes which allowed me to play longer and to see better so I highly recommend this mods in case you wanna chase loss all day long like I did. <br><br><img src = \"https://imagizer.imageshack.us/v2/800x600q90/923/zkktje.png\" alt = \"\" class=\"customerPost-Images\"><br><br><img src = \"https://imagizer.imageshack.us/v2/800x600q90/924/S6FGuy.png\" alt=\"\" class=\"customerPost-Images\">",
                CreatedOn = DateTime.UtcNow,
                PostedById = "THEveryBESTadminID",
            };

            var replies = new List<ForumReply>();
            replies.Add(reply);

            await dbContext.ForumThreads.AddAsync(new ForumThread
            {
                Title = "Hello fans of Stud8!",
                PostedBy = userManager.Users.Where(x => x.UserName == "nsavov21@abv.bg").FirstOrDefault(),
                Content = "Hi, I recently started playing online poker again trying to re - build my bankroll from money I already had(about $500) which I wasn't using at PokerStars. <br><br>I'm sure that everyone on PokerStars plays the card match gig for little cash but in 67K hands over the last 10 days I have never won more than $2 at a time.  So, that's what it takes to win $10 on that thing!! <br><br><img src = \"https://imagizer.imageshack.us/v2/800x600q90/924/T5E9Bh.png\" alt = \"\" class=\"customerPost-Images\"><br><img src = \"https://imagizer.imageshack.us/v2/800x600q90/924/EYgRyV.png\" alt=\"\" class=\"customerPost - Images\">",
                CategoryId = 1,
                Replies = replies,
            });


            await dbContext.SaveChangesAsync();
        }
    }
}
