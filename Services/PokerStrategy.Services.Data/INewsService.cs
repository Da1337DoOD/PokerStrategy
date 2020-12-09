namespace PokerStrategy.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using PokerStrategy.Data.Models;

    public interface INewsService
    {
        Task<int> CreateAsync(string title, string content, string url, string newsType);

        Task Delete(int id);

        Task Edit(int id, string newTitle, string newContent);

        News GetById(int id);

        Task<bool> IncrementViews(int id);

        IEnumerable<News> GetAll();
    }
}
