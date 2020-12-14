namespace PokerStrategy.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using PokerStrategy.Data.Models;

    public class NewsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.News.Any())
            {
                return;
            }

            await dbContext.News.AddAsync(new News
            {
                Content = "<b>Probably one of the most controversial stories of the year was last week’s announcement than Dan Bilzerian was to be a GGPoker Ambassador.</b><br/> While his name has always been linked with poker he has always been something of an outsider in the poker industry itself, until now. <br/> It is undeniable he has influence with over 32 million Instagram followers.Mention poker to a non - player and his name is the most likely one to come up in 2020.It is also undeniable that he has a controversial toxic brand, especially when it comes to his treatment of women.The reason he has as many Instagram followers as he does is largely because it is filled with pictures of him treating women like possessions.",
                CreatedOn = DateTime.UtcNow,
                Title = "The Dan Bilzerian problem",
                NewsType = "Lifestyle",
                PictureUrl = "https://www.insidehook.com/wp-content/uploads/2020/06/GettyImages-1140982418-e1591627485300.jpg?fit=3625%2C2419",
            });

            await dbContext.News.AddAsync(new News
            {
                Content = "<b>We recap some stories you may have missed including durrrr on the future of the game and Trump hits out at the people who bet on him.</b> <br/> <h3> Gabe and AJ are back </h3> <br/> If you were not excited about the return of High Stakes Poker next week, this might finally push you over the edge.<br/> Gape Kaplan and AJ Benza will be returning to commentary duty for the new series which starts on April 16 on PokerGO.<br/> The set might be a bit different and some of the players are new, but with the commentary duo added this trailer below really does feel like the old show:<br/> Tom Dwan on the future of poker<br/> Two people expected on that very show, Brandon Adams and Tom Dwan, caught up to talk on Adams's podcast this week. <br/> It is rare to get any kind of interview at all from Tom Dwan, but just like Phil Ivey, it looks like we might be seeing more of him next year.<br/> Dwan discussed the future for the online game in the US, which he thinks is heading for a renaissance in 2021.",
                CreatedOn = DateTime.UtcNow,
                Title = "Gabe Kaplan back as High Stakes Poker host",
                NewsType = "Lifestyle",
                PictureUrl = "https://storage.googleapis.com/pokercentral/2020/03/072299d1-gabekaplan-1.jpg",
            });

            await dbContext.SaveChangesAsync();
        }
    }
}
