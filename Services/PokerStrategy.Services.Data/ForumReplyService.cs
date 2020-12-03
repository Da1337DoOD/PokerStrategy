﻿namespace PokerStrategy.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using PokerStrategy.Data.Common.Repositories;
    using PokerStrategy.Data.Models;

    public class ForumReplyService : IForumReplyService
    {
        private readonly IDeletableEntityRepository<ForumReply> replyRepository;

        public ForumReplyService(IDeletableEntityRepository<ForumReply> replyRepository)
        {
            this.replyRepository = replyRepository;
        }

        public async Task Delete(int id)
        {
            var reply = this.GetById(id);
            this.replyRepository.Delete(reply); // Remove or other method??

            await this.replyRepository.SaveChangesAsync();
        }

        public async Task Edit(int id, string editedContent)
        {
            var reply = this.GetById(id);
            reply.Content = editedContent; // ??

            await this.replyRepository.SaveChangesAsync();

            //this.replyRepository.Update(reply);
            //await this.replyRepository.SaveChangesAsync();
        }

        public ForumReply GetById(int id)
        {
            return this.replyRepository.All()
                .Include(r => r.Thread)
                    .ThenInclude(t => t.Category)
                .Include(r => r.Thread)
                    .ThenInclude(t => t.PostedBy)
                .First(r => r.Id == id); // First on top?
        }
    }
}
