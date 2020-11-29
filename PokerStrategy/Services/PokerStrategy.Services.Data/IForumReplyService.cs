﻿namespace PokerStrategy.Services.Data
{
    using System.Threading.Tasks;

    using PokerStrategy.Data.Models;

    public interface IForumReplyService
    {
        ForumReply GetById(int id);

        Task Edit(int id, string message);

        Task Delete(int id);
    }
}