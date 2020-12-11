namespace PokerStrategy.Services.Data
{
    using System.Collections.Generic;

    using PokerStrategy.Data.Models;

    public interface IForumCategoryService
    {
        ForumCategory GetById(int id);

        IEnumerable<ForumCategory> GetAll();
    }
}
