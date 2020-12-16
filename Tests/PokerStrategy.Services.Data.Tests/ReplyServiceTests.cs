using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PokerStrategy.Data;
using PokerStrategy.Data.Models;
using PokerStrategy.Data.Repositories;
using PokerStrategy.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Xunit;
using PokerStrategy.Data.Common.Repositories;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PokerStrategy.Services.Data.Tests
{
    public class ReplyServiceTests
    {
        [Fact]
        public void GetByIdShouldReturnCorrectObject()
        {
            var store = new Mock<IUserStore<ApplicationUser>>();

            var userManager = new UserManager<ApplicationUser>(store.Object, null, null, null, null, null, null, null, null);

            var catRepo = new Mock<IDeletableEntityRepository<ForumCategory>>();
            var catService = new ForumCategoryService(catRepo.Object);

            var replyList = new List<ForumReply>();
            replyList.Add(new ForumReply() { Id = 1, ThreadId = 1 });
            replyList.Add(new ForumReply() { Id = 2, ThreadId = 2 });
            replyList.Add(new ForumReply() { Id = 3, ThreadId = 3 });
            replyList.Add(new ForumReply() { Id = 4, ThreadId = 1 });
            var replyRepo = new Mock<IDeletableEntityRepository<ForumReply>>();
            replyRepo.Setup(x => x.All()).Returns(replyList.AsQueryable());
            replyRepo.Setup(x => x.AddAsync(It.IsAny<ForumReply>()))
                .Callback((ForumReply r) => replyList.Add(r));

            var threadRepo = new Mock<IDeletableEntityRepository<ForumThread>>();
            var threadService = new ForumThreadService(threadRepo.Object, replyRepo.Object, catService, userManager);

            var replyService = new ForumReplyService(replyRepo.Object, threadService, userManager);

            var replyResult = replyService.GetById(1);

            Assert.Equal(1, replyService.GetById(1).ThreadId);
            Assert.Equal(2, replyService.GetById(2).ThreadId);
            Assert.Equal(3, replyService.GetById(3).ThreadId);
            Assert.NotEqual(3, replyService.GetById(4).ThreadId);
        }

        [Fact]
        public async Task AddReplyCorrectly()
        {
            var store = new Mock<IUserStore<ApplicationUser>>();

            var userManager = new UserManager<ApplicationUser>(store.Object, null, null, null, null, null, null, null, null);

            var catRepo = new Mock<IDeletableEntityRepository<ForumCategory>>();
            var catService = new ForumCategoryService(catRepo.Object);

            var replyList = new List<ForumReply>();
            replyList.Add(new ForumReply() { Id = 1, ThreadId = 1 });
            replyList.Add(new ForumReply() { Id = 2, ThreadId = 2 });
            replyList.Add(new ForumReply() { Id = 3, ThreadId = 3 });
            replyList.Add(new ForumReply() { Id = 4, ThreadId = 1 });
            var replyRepo = new Mock<IDeletableEntityRepository<ForumReply>>();
            replyRepo.Setup(x => x.All()).Returns(replyList.AsQueryable());
            replyRepo.Setup(x => x.AddAsync(It.IsAny<ForumReply>()))
                .Callback((ForumReply r) => replyList.Add(r));

            var threadRepo = new Mock<IDeletableEntityRepository<ForumThread>>();
            var threadService = new ForumThreadService(threadRepo.Object, replyRepo.Object, catService, userManager);

            var replyService = new ForumReplyService(replyRepo.Object, threadService, userManager);

            await replyService.AddReply("123",3,"content");

            var countResult = replyRepo.Object.All().Count();

            Assert.Equal(5, countResult);
        }

        [Fact]
        public async Task EditReplyShouldEditCorrectly()
        {
            var store = new Mock<IUserStore<ApplicationUser>>();

            var userManager = new UserManager<ApplicationUser>(store.Object, null, null, null, null, null, null, null, null);

            var catRepo = new Mock<IDeletableEntityRepository<ForumCategory>>();
            var catService = new ForumCategoryService(catRepo.Object);

            var replyList = new List<ForumReply>();
            replyList.Add(new ForumReply() { Id = 1, ThreadId = 1,Content = "123"});
            replyList.Add(new ForumReply() { Id = 2, ThreadId = 2 });
            replyList.Add(new ForumReply() { Id = 3, ThreadId = 3 });
            replyList.Add(new ForumReply() { Id = 4, ThreadId = 1 });
            var replyRepo = new Mock<IDeletableEntityRepository<ForumReply>>();
            replyRepo.Setup(x => x.All()).Returns(replyList.AsQueryable());
            replyRepo.Setup(x => x.AddAsync(It.IsAny<ForumReply>()))
                .Callback((ForumReply r) => replyList.Add(r));

            var threadRepo = new Mock<IDeletableEntityRepository<ForumThread>>();
            var threadService = new ForumThreadService(threadRepo.Object, replyRepo.Object, catService, userManager);

            var replyService = new ForumReplyService(replyRepo.Object, threadService, userManager);

            await replyService.EditAsync(1,"456");

            var replyResult = replyService.GetById(1);

            Assert.NotEqual("123", replyResult.Content);
            Assert.Equal("456", replyResult.Content);
        }

        [Fact]
        public async Task UserIsCreatorChecksCorrectly()
        {
            var store = new Mock<IUserStore<ApplicationUser>>();

            var userManager = new UserManager<ApplicationUser>(store.Object, null, null, null, null, null, null, null, null);

            var catRepo = new Mock<IDeletableEntityRepository<ForumCategory>>();
            var catService = new ForumCategoryService(catRepo.Object);

            var replyList = new List<ForumReply>();
            replyList.Add(new ForumReply() {
                Id = 1, ThreadId = 1, Content = "123", PostedById = "user1", });
            replyList.Add(new ForumReply() { Id = 2, ThreadId = 2 });
            replyList.Add(new ForumReply() { Id = 3, ThreadId = 3 });
            replyList.Add(new ForumReply() { Id = 4, ThreadId = 1 });
            var replyRepo = new Mock<IDeletableEntityRepository<ForumReply>>();
            replyRepo.Setup(x => x.All()).Returns(replyList.AsQueryable());
            replyRepo.Setup(x => x.AddAsync(It.IsAny<ForumReply>()))
                .Callback((ForumReply r) => replyList.Add(r));

            var threadRepo = new Mock<IDeletableEntityRepository<ForumThread>>();
            var threadService = new ForumThreadService(threadRepo.Object, replyRepo.Object, catService, userManager);

            var replyService = new ForumReplyService(replyRepo.Object, threadService, userManager);

            Assert.True(replyService.UserIsCreator("user1",1));
            Assert.False(replyService.UserIsCreator("user2", 1));
        }

        //[Fact]
        //public async Task EditReplyCorrectly()
        //{
        //    var options = new DbContextOptionsBuilder<ApplicationDbContext>()
        //            .UseInMemoryDatabase(databaseName: "EditReply_Database")
        //            .Options;
        //    var dbContext = new ApplicationDbContext(options);

        //    var threadService = new Mock<IDeletableEntityRepository<ForumThread>>();

        //    var replyService = new ForumReplyService(replyRepo, threadService.Object, userManager);

        //    await replyService.CreatePostAsync("Tweets", "Hello i am tweet", "u1", 1);
        //    await replyService.EditPostAsync(1, "Hello i am new content", "Hello i am new title", "u1", false);

        //    var post = await dbContext.Posts.FirstAsync();

        //    Assert.Equal(1, post.Id);
        //    Assert.Equal("Hello i am new content", post.Content);
        //    Assert.Equal("Hello i am new title", post.Title);
        //    Assert.Equal("u1", post.UserId);
        //    Assert.Equal(1, await replyService.PostsCountAsync(null));
        //}
    }
}