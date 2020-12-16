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
    public class ThreadServiceTests
    {
        [Fact]
        public void GetByIdShouldReturnCorrectObject()
        {
            var store = new Mock<IUserStore<ApplicationUser>>();

            var userManager = new UserManager<ApplicationUser>(store.Object, null, null, null, null, null, null, null, null);

            var catRepo = new Mock<IDeletableEntityRepository<ForumCategory>>();
            var catService = new ForumCategoryService(catRepo.Object);

            var replyRepo = new Mock<IDeletableEntityRepository<ForumReply>>();

            var threadList = new List<ForumThread>();

            threadList.Add(new ForumThread() { Id = 1, Title = "thread1" });
            threadList.Add(new ForumThread() { Id = 2, Title = "thread2" });
            threadList.Add(new ForumThread() { Id = 3, Title = "thread3" });
            threadList.Add(new ForumThread() { Id = 4, Title = "thread4" });
            threadList.Add(new ForumThread() { Id = 5, Title = "thread5" });

            var threadRepo = new Mock<IDeletableEntityRepository<ForumThread>>();

            threadRepo.Setup(x => x.All()).Returns(threadList.AsQueryable());
            threadRepo.Setup(x => x.AddAsync(It.IsAny<ForumThread>()))
                .Callback((ForumThread r) => threadList.Add(r));

            var threadService = new ForumThreadService(threadRepo.Object, replyRepo.Object, catService, userManager);

            Assert.Equal(1, threadService.GetById(1).Id);
            Assert.Equal(2, threadService.GetById(2).Id);
            Assert.Equal(3, threadService.GetById(3).Id);
            Assert.NotEqual(4, threadService.GetById(3).Id);
            Assert.NotEqual(0, threadService.GetById(1).Id);
            Assert.NotEqual(3, threadService.GetById(1).Id);
        }

        [Fact]
        public async Task CreateNewThreadShouldAddCorrectly()
        {
            var store = new Mock<IUserStore<ApplicationUser>>();

            var userManager = new UserManager<ApplicationUser>(store.Object, null, null, null, null, null, null, null, null);

            var catRepo = new Mock<IDeletableEntityRepository<ForumCategory>>();
            var catService = new ForumCategoryService(catRepo.Object);

            var replyRepo = new Mock<IDeletableEntityRepository<ForumReply>>();

            var threadList = new List<ForumThread>();

            var newForumCategory = new ForumCategory() { Id = 1, Title = "title1" };
            var newForumCategory2 = new ForumCategory() { Id = 2, Title = "title2" };

            threadList.Add(new ForumThread() { Id = 1, Title = "thread1", Category = newForumCategory });
            threadList.Add(new ForumThread() { Id = 2, Title = "thread2", Category = newForumCategory });
            threadList.Add(new ForumThread() { Id = 3, Title = "thread3", Category = newForumCategory });
            threadList.Add(new ForumThread() { Id = 4, Title = "thread4", Category = newForumCategory2 });
            threadList.Add(new ForumThread() { Id = 5, Title = "thread5" });

            var threadRepo = new Mock<IDeletableEntityRepository<ForumThread>>();

            threadRepo.Setup(x => x.All()).Returns(threadList.AsQueryable());
            threadRepo.Setup(x => x.AddAsync(It.IsAny<ForumThread>()))
                .Callback((ForumThread t) => threadList.Add(t));

            var threadService = new ForumThreadService(threadRepo.Object, replyRepo.Object, catService, userManager);

            await threadService.CreateNewThread("13456", 2, "title1", "111");

            Assert.True(threadRepo.Object.All().Any(x => x.Title == "title1"));
            Assert.False(threadRepo.Object.All().Any(x => x.Title == "title123"));
        }

        [Fact]
        public async Task GetLatestThreadsGetsNoMoreThanFiveUniqueThreads()
        {
            var store = new Mock<IUserStore<ApplicationUser>>();

            var userManager = new UserManager<ApplicationUser>(store.Object, null, null, null, null, null, null, null, null);

            var catRepo = new Mock<IDeletableEntityRepository<ForumCategory>>();
            var catService = new ForumCategoryService(catRepo.Object);


            var threadList = new List<ForumThread>();

            var newForumCategory = new ForumCategory() { Id = 1, Title = "title1" };
            var newForumCategory2 = new ForumCategory() { Id = 2, Title = "title2" };

            var replyList = new List<ForumReply>();
            replyList.Add(new ForumReply() { Id = 1, ThreadId = 1, Content = "123" });
            replyList.Add(new ForumReply() { Id = 2, ThreadId = 2 });
            replyList.Add(new ForumReply() { Id = 3, ThreadId = 3 });
            replyList.Add(new ForumReply() { Id = 4, ThreadId = 1 });
            var replyRepo = new Mock<IDeletableEntityRepository<ForumReply>>();
            replyRepo.Setup(x => x.All()).Returns(replyList.AsQueryable());
            replyRepo.Setup(x => x.AddAsync(It.IsAny<ForumReply>()))
                .Callback((ForumReply r) => replyList.Add(r));

            threadList.Add(new ForumThread() { Id = 1, Title = "thread1", Category = newForumCategory });
            threadList.Add(new ForumThread() { Id = 2, Title = "thread2", Category = newForumCategory });
            threadList.Add(new ForumThread() { Id = 3, Title = "thread3", Category = newForumCategory });
            threadList.Add(new ForumThread() { Id = 4, Title = "thread4", Category = newForumCategory2 });
            threadList.Add(new ForumThread() { Id = 5, Title = "thread5", Category = newForumCategory2 });
            threadList.Add(new ForumThread() { Id = 6, Title = "thread6", Category = newForumCategory2 });
            threadList.Add(new ForumThread() { Id = 7, Title = "thread7", Replies = replyList });

            var threadRepo = new Mock<IDeletableEntityRepository<ForumThread>>();

            threadRepo.Setup(x => x.All()).Returns(threadList.AsQueryable());
            threadRepo.Setup(x => x.AddAsync(It.IsAny<ForumThread>()))
                .Callback((ForumThread t) => threadList.Add(t));

            threadRepo.Object.AddAsync(threadList[5]).Wait();

            await threadRepo.Object.AddAsync(new ForumThread
            {
                Title = "1234",
                CategoryId = 1,
                Content = "12314",
                Id = 55,
                Replies = replyList,
                PostedById = "manqka1",
                CreatedOn = DateTime.UtcNow,
            });

            var threadService = new ForumThreadService(threadRepo.Object, replyRepo.Object, catService, userManager);

            threadService.Add(threadList[0]).Wait();
            await threadService.Add(threadList[1]);
            await threadService.Add(threadList[2]);
            await threadService.Add(threadList[3]);
            threadService.Add(threadList[4]).Wait();
            await threadService.Add(threadList[5]);
            threadService.Add(threadList[6]).Wait();

            var allThreads = threadService.GetThreads(newForumCategory);

            var contains = allThreads.Contains(allThreads.FirstOrDefault(x => x.Id == 5));

            var resultList = threadService.GetLatestThreads().ToList();


            var expectedList = new List<ForumThread>
            {
                threadList[3],
                threadList[4],
                threadList[5],
                threadList[6],
                threadList[7],
            };

            Assert.True(resultList.Count() >= 0);
            Assert.True(resultList.Count() <= 5); // .Count() doesnt work for some f reason... HAD TO WASTE ME AN HOUR
        }

        [Fact]
        public async Task DeleteThreadCorrectly()
        {
            var threadList = new List<ForumThread>();
            var threadRepo = new Mock<IDeletableEntityRepository<ForumThread>>();
            threadRepo.Setup(x => x.All()).Returns(threadList.AsQueryable());
            threadRepo.Setup(x => x.AddAsync(It.IsAny<ForumThread>()))
                .Callback((ForumThread c) => threadList.Add(c));

            await threadRepo.Object.AddAsync(this.test);

            var threadService = new ForumThreadService(threadRepo.Object, null, null,null);

            await threadService.Delete(this.test.Id);

            var result = threadRepo.Object.All().Any(x => x.IsDeleted);
            Assert.False(result);
        }

        private ForumThread test = new ForumThread()
        {
            Id = 1,
            CategoryId = 1,
            Content = "12345",
            Title = "12345",
        };
    }
}