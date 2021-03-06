﻿namespace PokerStrategy.Services.Data
{
    using System.Threading.Tasks;

    using PokerStrategy.Data.Models;

    public interface IForumReplyService
    {
        ForumReply GetById(int id);

        Task Delete(int id);

        Task AddReply(string userId, int threadId, string content);

        Task EditAsync(int replyId, string newContent);

        bool UserIsCreator(string userId, int replyId);
    }
}
