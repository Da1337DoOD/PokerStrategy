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
    public class VideoServiceTests
    {
        [Fact]
        public async Task DeleteVideoCorrectly()
        {
            var videoList = new List<Video>();
            var videoRepo = new Mock<IDeletableEntityRepository<Video>>();
            videoRepo.Setup(x => x.All()).Returns(videoList.AsQueryable());
            videoRepo.Setup(x => x.AddAsync(It.IsAny<Video>()))
                .Callback((Video c) => videoList.Add(c));

            videoRepo.Setup(x => x.Delete(It.IsAny<Video>()))
                .Callback((Video c) => videoList.Remove(c));

            await videoRepo.Object.AddAsync(this.test);

            var videoService = new VideosService(videoRepo.Object);

            await videoService.Delete(this.test.Id);

            Assert.False(this.test.IsDeleted);
        }

        [Fact]
        public async Task VideoGetByIdCorrectly()
        {
            var videoList = new List<Video>();
            var videoRepo = new Mock<IDeletableEntityRepository<Video>>();
            videoRepo.Setup(x => x.All()).Returns(videoList.AsQueryable());
            videoRepo.Setup(x => x.AddAsync(It.IsAny<Video>()))
                .Callback((Video x) => videoList.Add(x));

            await videoRepo.Object.AddAsync(this.test);

            var videoService = new VideosService(videoRepo.Object);

            var videoResult = videoService.GetById(this.test.Id);

            Assert.Equal(test, videoResult);
        }

        [Fact]
        public async Task CreateNewVideoShouldAddCorrectly()
        {
            var videoList = new List<Video>();
            var videoRepo = new Mock<IDeletableEntityRepository<Video>>();
            videoRepo.Setup(x => x.All()).Returns(videoList.AsQueryable());
            videoRepo.Setup(x => x.AddAsync(It.IsAny<Video>()))
                .Callback((Video r) => videoList.Add(r));

            var videoService = new VideosService(videoRepo.Object);

            await videoService.CreateAsync(test.Title, test.Description, test.VideoUrl, test.Category);
            await videoService.CreateAsync(test2.Title, test2.Description, test2.VideoUrl, test2.Category);

            Assert.Equal(videoList[0].Title, this.test.Title);
            Assert.Equal(videoList[1].Title, this.test2.Title);
            Assert.NotEqual(videoList[1].Title, this.test.Title);
        }

        [Fact]
        public async Task GetEmbededLinkWorkFine()
        {
            var videoList = new List<Video>();
            var videoRepo = new Mock<IDeletableEntityRepository<Video>>();
            videoRepo.Setup(x => x.All()).Returns(videoList.AsQueryable());
            videoRepo.Setup(x => x.AddAsync(It.IsAny<Video>()))
                .Callback((Video r) => videoList.Add(r));

            var videoService = new VideosService(videoRepo.Object);

            await videoService.CreateAsync(test.Title, test.Description, test.VideoUrl, test.Category);
            await videoService.CreateAsync(test2.Title, test2.Description, test2.VideoUrl, test2.Category);

            var embededLink = videoService.GetEmbededVideoLink(test.VideoUrl);

            var embededLink2 = videoService.GetEmbededVideoLink(test2.VideoUrl);

            Assert.Equal("w2ze3Z6BAmg", embededLink);
            Assert.Equal("03ILbXdE8b4", embededLink2);
        }

        [Fact]
        public async Task GetCorrectThumbnailLink()
        {
            var videoList = new List<Video>();
            var videoRepo = new Mock<IDeletableEntityRepository<Video>>();
            videoRepo.Setup(x => x.All()).Returns(videoList.AsQueryable());
            videoRepo.Setup(x => x.AddAsync(It.IsAny<Video>()))
                .Callback((Video r) => videoList.Add(r));

            var videoService = new VideosService(videoRepo.Object);

            await videoService.CreateAsync(test.Title, test.Description, test.VideoUrl, test.Category);
            await videoService.CreateAsync(test2.Title, test2.Description, test2.VideoUrl, test2.Category);

            var embededLink = videoService.GetThumbnailLink(test.VideoUrl);

            var embededLink2 = videoService.GetThumbnailLink(test2.VideoUrl);

            Assert.Equal("https://i.ytimg.com/vi/w2ze3Z6BAmg/0.jpg", embededLink);
            Assert.Equal("https://i.ytimg.com/vi/03ILbXdE8b4/0.jpg", embededLink2);
        }

        [Fact]
        public async Task GetAllReturnsAllVideosCorrectly()
        {
            var videoList = new List<Video>();
            var videoRepo = new Mock<IDeletableEntityRepository<Video>>();
            videoRepo.Setup(x => x.All()).Returns(videoList.AsQueryable());
            videoRepo.Setup(x => x.AddAsync(It.IsAny<Video>()))
                .Callback((Video r) => videoList.Add(r));

            var videoService = new VideosService(videoRepo.Object);

            await videoService.CreateAsync(test.Title, test.Description, test.VideoUrl, test.Category);
            await videoService.CreateAsync(test2.Title, test2.Description, test2.VideoUrl, test2.Category);

            var resultList = videoService.GetAll().ToList().OrderBy(x => x.CreatedOn).ToList();

            Assert.Equal(videoList[0].Title, resultList[0].Title);
            Assert.Equal(videoList[0].Id, resultList[0].Id);
            Assert.Equal(videoList[1].Title, resultList[1].Title);
            Assert.Equal(videoList[1].Id, resultList[1].Id);
        }

        [Fact]
        public async Task GetLatestVideosGetsNoMoreThanFiveUniqueVideos()
        {
            var store = new Mock<IUserStore<ApplicationUser>>();

            var userManager = new UserManager<ApplicationUser>(store.Object, null, null, null, null, null, null, null, null);

            var videoList = new List<Video>();
            var videoRepo = new Mock<IDeletableEntityRepository<Video>>();
            videoRepo.Setup(x => x.All()).Returns(videoList.AsQueryable());
            videoRepo.Setup(x => x.AddAsync(It.IsAny<Video>()))
                .Callback((Video r) => videoList.Add(r));

            var videoService = new VideosService(videoRepo.Object);

            await videoService.CreateAsync(test.Title, test.Description, test.VideoUrl, test.Category);
            await videoService.CreateAsync(test2.Title, test2.Description, test2.VideoUrl, test2.Category);

            var listResult = videoService.GetLatestVideos();

            Assert.Equal(videoList.OrderByDescending(x => x.CreatedOn), listResult);
        }

        private Video test = new Video()
        {
            Id = 1,
            Title = "12345",
            VideoUrl = "https://www.youtube.com/watch?v=w2ze3Z6BAmg",
            Description = "good video",
            Category = "1",
        };

        private Video test2 = new Video()
        {
            Id = 2,
            Title = "23456",
            VideoUrl = "https://www.youtube.com/watch?v=03ILbXdE8b4",
            Description = "bad video",
            Category = "1",
        };
    }
}
