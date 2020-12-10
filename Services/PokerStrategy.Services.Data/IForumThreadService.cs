namespace PokerStrategy.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using PokerStrategy.Data.Models;

    public interface IForumThreadService
    {
        ForumThread GetById(int id);

        IEnumerable<ForumThread> GetAll();

        IEnumerable<ForumThread> GetThreads(ForumCategory category);

        IEnumerable<ForumThread> GetThreadsByCategory(int id);

        Task Add(ForumThread thread);

        Task Delete(int threadId);

        Task Edit(int id, string newTitle, string newContent);

        Task AddReply(ForumReply reply);

        IEnumerable<ForumThread> GetLatestThreads();
    }
}
