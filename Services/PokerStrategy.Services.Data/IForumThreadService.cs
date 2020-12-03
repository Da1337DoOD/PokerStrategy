namespace PokerStrategy.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using PokerStrategy.Data.Models;

    public interface IForumThreadService
    {
        ForumThread GetById(int id);

        IEnumerable<ForumThread> GetAll();

        IEnumerable<ForumThread> GetFilteredThreads(ForumCategory category, string searchQuery);

        IEnumerable<ForumThread> GetThreadsByCategory(int id);

        Task Add(ForumThread thread);

        Task Delete(int id);

        Task Edit(int id, string newContent);

        Task AddReply(ForumReply reply);

        IEnumerable<ForumThread> GetLatestThreads(int postsCount);
    }
}
