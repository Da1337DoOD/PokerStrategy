namespace PokerStrategy.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using PokerStrategy.Data.Models;

    public interface IForumReplyService
    {
        ForumReply GetById(int id);

        ForumReply GetLatest(int threadId);

        IEnumerable<ForumReply> GetAll();

        Task Edit(int id, string message);

        Task Delete(int id);
    }
}
