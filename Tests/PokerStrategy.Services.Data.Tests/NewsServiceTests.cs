using Microsoft.AspNetCore.Identity;
using Moq;
using PokerStrategy.Data.Common.Repositories;
using PokerStrategy.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PokerStrategy.Services.Data.Tests
{
    public class NewsServiceTests
    {
        [Fact]
        public async Task GetAllReturnsAllNewsCorrectly()
        {
            var newsList = new List<News>();
            var newsRepo = new Mock<IDeletableEntityRepository<News>>();
            newsRepo.Setup(x => x.All()).Returns(newsList.AsQueryable());
            newsRepo.Setup(x => x.AddAsync(It.IsAny<News>()))
                .Callback((News r) => newsList.Add(r));

            var newsService = new NewsService(newsRepo.Object);

            await newsService.CreateAsync(test.Title, test.Content, test.PictureUrl, test.NewsType);
            await newsService.CreateAsync(test2.Title, test2.Content, test2.PictureUrl, test2.NewsType);

            var resultList = newsService.GetAll().ToList().OrderBy(x => x.CreatedOn).ToList();

            Assert.Equal(newsList[0].Title, resultList[0].Title);
            Assert.Equal(newsList[0].Id, resultList[0].Id);
            Assert.Equal(newsList[1].Title, resultList[1].Title);
            Assert.Equal(newsList[1].Id, resultList[1].Id);
        }

        [Fact]
        public async Task GetLatestnewssGetsNoMoreThanFiveUniqueNews()
        {
            var store = new Mock<IUserStore<ApplicationUser>>();

            var userManager = new UserManager<ApplicationUser>(store.Object, null, null, null, null, null, null, null, null);

            var newsList = new List<News>();
            var newsRepo = new Mock<IDeletableEntityRepository<News>>();
            newsRepo.Setup(x => x.All()).Returns(newsList.AsQueryable());
            newsRepo.Setup(x => x.AddAsync(It.IsAny<News>()))
                .Callback((News r) => newsList.Add(r));

            var newsService = new NewsService(newsRepo.Object);

            await newsService.CreateAsync(test.Title, test.Content, test.PictureUrl, test.NewsType);
            await newsService.CreateAsync(test2.Title, test2.Content, test2.PictureUrl, test2.NewsType);

            var listResult = newsService.GetLatestNews();

            Assert.Equal(newsList.OrderByDescending(x => x.CreatedOn), listResult);
        }

        [Fact]
        public async Task NewsGetByIdCorrectly()
        {
            var newsList = new List<News>();
            var newsRepo = new Mock<IDeletableEntityRepository<News>>();
            newsRepo.Setup(x => x.All()).Returns(newsList.AsQueryable());
            newsRepo.Setup(x => x.AddAsync(It.IsAny<News>()))
                .Callback((News x) => newsList.Add(x));

            await newsRepo.Object.AddAsync(this.test);

            var videoService = new NewsService(newsRepo.Object);

            var videoResult = videoService.GetById(this.test.Id);

            Assert.Equal(test, videoResult);
        }

        private News test = new News()
        {
            Id = 1,
            Title = "12345",
            PictureUrl = "https://www.planetware.com/wpimages/2020/02/france-in-pictures-beautiful-places-to-photograph-eiffel-tower.jpg",
            Content = "aaaaa",
            NewsType = "good",
        };

        private News test2 = new News()
        {
            Id = 2,
            Title = "23456",
            PictureUrl = "https://static01.nyt.com/images/2018/10/04/magazine/04blackhole1/04blackhole1-articleLarge-v3.jpg?quality=75&auto=webp&disable=upscale",
            Content = "bbbbb",
            NewsType = "bad",
        };

    }
}
