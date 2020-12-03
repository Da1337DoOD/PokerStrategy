using PokerStrategy.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokerStrategy.Services.Data
{
    public interface IForumCategoryService
    {
        ForumCategory GetById(int id);

        IEnumerable<ForumCategory> GetAll();

        Task Create(ForumCategory forumCategory);

        Task Delete(int forumCategoryId);

        Task UpdateTitle(int categoryId, string newTitle);

        Task UpdateDescription(int categoryId, string newDescription);
    }
}
