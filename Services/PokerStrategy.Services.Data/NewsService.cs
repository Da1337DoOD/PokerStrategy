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

        public NewsService(
            IDeletableEntityRepository<News> newsRepository)
        {
            this.newsRepository = newsRepository;
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

        public async Task Delete(int newsId)
        {
            var news = this.newsRepository.All()
                .Where(n => n.Id == newsId)
                .FirstOrDefault();

            this.newsRepository.Delete(news);

            this.newsRepository.Update(news);

            await this.newsRepository.SaveChangesAsync();
        }

        public async Task EditAsync(int newsId, string title, string content, string pictureUrl)
        {
            var news = this.GetById(newsId);
            news.Title = title;
            news.Content = content;
            news.PictureUrl = pictureUrl;

            await this.newsRepository.SaveChangesAsync();

            return;
        }

        public IEnumerable<News> GetAll()
        {
            IQueryable<News> news = this.newsRepository.All()
                .OrderByDescending(n => n.CreatedOn);

            return news.ToList();
        }

        public News GetById(int id)
        {
            var news = this.newsRepository.All()
                .Where(n => n.Id == id)
                .FirstOrDefault();

            return news;
        }

        public IEnumerable<News> GetLatestNews()
        {
            var newsByDate = this.newsRepository.All()
                .OrderByDescending(n => n.CreatedOn).ToList();

            if (newsByDate.Count <= 5)
            {
                return newsByDate;
            }

            return newsByDate.Take(5);
        }

        public async Task<bool> IncrementViews(int id)
        {
            this.newsRepository.All()
                .Where(x => x.Id == id)
                .FirstOrDefault()
                .TimesSeen += 1;

            await this.newsRepository.SaveChangesAsync();

            return true;
        }
    }
}
