namespace PokerStrategy.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using PokerStrategy.Data.Common.Repositories;
    using PokerStrategy.Data.Models;

    public class NewsService : INewsService
    {
        private readonly IDeletableEntityRepository<News> newsRepository;

        public NewsService(IDeletableEntityRepository<News> newsRepository)
        {
            this.newsRepository = newsRepository;
        }

        public async Task<int> CreateAsync(string title, string content, string url, int categoryId)
        {
            var news = new News
            {
                Title = title,
                Content = content,
                PictureUrl = url,
                CategoryId = categoryId,
                CreatedOn = DateTime.UtcNow,
            };

            await this.newsRepository.AddAsync(news);
            await this.newsRepository.SaveChangesAsync();

            return news.Id;
        }

        public IEnumerable<News> GetAll(int categoryId, int? count = null)
        {
            IQueryable<News> query = this.newsRepository.All()
                .Where(n => n.CategoryId == categoryId)
                .OrderBy(n => n.CreatedOn);

            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

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
