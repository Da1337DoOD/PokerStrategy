﻿namespace PokerStrategy.Services.Data
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
        private readonly IDeletableEntityRepository<NewsComment> commentRepository;

        public NewsService(
            IDeletableEntityRepository<News> newsRepository,
            IDeletableEntityRepository<NewsComment> commentRepository)
        {
            this.newsRepository = newsRepository;
            this.commentRepository = commentRepository;
        }

        public async Task AddReply(NewsComment reply)
        {
            await this.commentRepository.AddAsync(reply);
            await this.commentRepository.SaveChangesAsync();
        }

        public async Task<int> CreateAsync(string title, string content, string url, string newsType)
        {
            var news = new News
            {
                Title = title,
                Content = content,
                PictureUrl = url,
                NewsType = newsType,
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

        public IEnumerable<News> GetAll()
        {
            IQueryable<News> news = this.newsRepository.All()
                .OrderBy(n => n.CreatedOn);

            return news.ToList();
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