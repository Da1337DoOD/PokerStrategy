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
    public class CategoryServiceTests
    {
        [Fact]
        public async Task GetAllShouldReturnCorrectObject()
        {
            var catList = new List<ForumCategory>();
            var catRepo = new Mock<IDeletableEntityRepository<ForumCategory>>();
            catRepo.Setup(x => x.All()).Returns(catList.AsQueryable());
            catRepo.Setup(x => x.AddAsync(It.IsAny<ForumCategory>()))
                .Callback((ForumCategory c) => catList.Add(c));

            await catRepo.Object.AddAsync(this.test);

            var catService = new ForumCategoryService(catRepo.Object);

            var result = catService.GetAll();
            var expected = catRepo.Object.All();

            Assert.Equal(expected, result);
            Assert.Equal(catRepo.Object.All(), result);
            Assert.Equal(expected.Count(), result.Count());
        }

        [Fact]
        public async Task GetByIdShouldReturnCorrectObject()
        {

            var catList = new List<ForumCategory>();
            var catRepo = new Mock<IDeletableEntityRepository<ForumCategory>>();
            catRepo.Setup(x => x.All()).Returns(catList.AsQueryable());
            catRepo.Setup(x => x.AddAsync(It.IsAny<ForumCategory>()))
                .Callback((ForumCategory c) => catList.Add(c));

            await catRepo.Object.AddAsync(this.test);
            var catService = new ForumCategoryService(catRepo.Object);

            var result = catService.GetById(1).Title;
            var expected = catRepo.Object.All().Where(x => x.Id == 1).FirstOrDefault();

            Assert.Equal(expected.Title, result);
        }

        private ForumCategory test = new ForumCategory()
        {
            Id = 1,
            Title = "test",
        };
    }
}
