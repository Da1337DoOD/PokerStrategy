﻿namespace PokerStrategy.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using PokerStrategy.Data.Models;

    public interface IForumThreadService
    {
        ForumThread GetById(int id);

        IEnumerable<ForumThread> GetThreads(ForumCategory category);

        Task<ForumThread> CreateNewThread(string userId, int categoryId, string title, string content);

        Task Add(ForumThread thread);

        Task Delete(int threadId);

        Task AddReply(ForumReply reply);

        IEnumerable<ForumThread> GetLatestThreads();
    }
}
