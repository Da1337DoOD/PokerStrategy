namespace PokerStrategy.Services.Data
{
    using System.Threading.Tasks;

    public class NewsCommentService : INewsCommentService
    {
        public Task Create(int newsId, int userId, string content)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int commentId)
        {
            throw new System.NotImplementedException();
        }

        public Task Edit(int commentId, string newContent)
        {
            throw new System.NotImplementedException();
        }
    }
}
