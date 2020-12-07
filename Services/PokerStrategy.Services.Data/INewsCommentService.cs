namespace PokerStrategy.Services.Data
{
    using System.Threading.Tasks;

    public interface INewsCommentService
    {
        Task Create(int newsId, int userId, string content);

        Task Delete(int commentId);

        Task Edit(int commentId, string newContent);
    }
}
