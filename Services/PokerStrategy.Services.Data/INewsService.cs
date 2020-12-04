namespace PokerStrategy.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using PokerStrategy.Data.Models;

    public interface INewsService
    {
        Task<int> CreateAsync(string title, string content, string url, int categoryId);

        News GetById(int id);

        Task<bool> IncrementViews(int id);

        IEnumerable<News> GetAll(int categoryId, int? count = null);
    }
}
