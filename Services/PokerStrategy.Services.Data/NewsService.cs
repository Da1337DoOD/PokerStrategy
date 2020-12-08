namespace PokerStrategy.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using PokerStrategy.Data.Common.Repositories;
    using PokerStrategy.Data.Models;

    public class NewsService : INewsService
    {
        private readonly IDeletableEntityRepository<News> newsRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public NewsService(
            IDeletableEntityRepository<News> newsRepository,
            UserManager<ApplicationUser> userManager)
        {
            this.newsRepository = newsRepository;
            this.userManager = userManager;
        }

        public async Task<int> CreateAsync(string title, string content, string url, string category)
        {
            var news = new News
            {
                Title = title,
                Content = content,
                PictureUrl = url,
                CategoryName = category,
                CreatedOn = DateTime.UtcNow,
            };

            await this.newsRepository.AddAsync(news);
            await this.newsRepository.SaveChangesAsync();

            return news.Id;
        }

        public async Task Delete(int id)
        {
            var thread = this.newsRepository.All()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            this.newsRepository.Delete(thread);

            this.newsRepository.Update(thread);

            await this.newsRepository.SaveChangesAsync();
        }

        public async Task Edit(int id, string newTitle, string newContent)
        {
            var thread = this.newsRepository.All()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            thread.Title = newTitle;
            thread.Content = newContent;

            this.newsRepository.Update(thread);

            await this.newsRepository.SaveChangesAsync();
        }

        public IEnumerable<News> GetAll()
        {
            IQueryable<News> query = this.newsRepository.All()
           //     .Where(n => n.CategoryName == categoryName)
                .OrderBy(n => n.CreatedOn);

            //if (count.HasValue)
            //{
            //    query = query.Take(count.Value);
            //}

            return query.ToList();
        }

        public News GetById(int id)
        {
            var news = this.newsRepository.All()
                .Where(n => n.Id == id)
                .FirstOrDefault();

            return news;
        }

        public async Task<bool> IncrementViews(int id)
        {
            this.newsRepository.All()
                .Where(x => x.Id == id)
                .FirstOrDefault()
                .TimeSeen += 1;

            await this.newsRepository.SaveChangesAsync();

            return true;
        }
    }
}
