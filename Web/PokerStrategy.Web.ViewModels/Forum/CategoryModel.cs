namespace PokerStrategy.Web.ViewModels.Forum
{
    using System.Collections.Generic;

    public class CategoryModel
    {
        public CategoriesListingModel Category { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<ThreadsListingModel> Threads { get; set; }

        public int DeletedThreadId { get; set; }
    }
}
