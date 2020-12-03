namespace PokerStrategy.Web.ViewModels.Forum
{
    using System.Collections.Generic;

    public class CategoryModel
    {
        public CategoriesListingModel Category { get; set; }

        public IEnumerable<ThreadsListingModel> Threads { get; set; }
    }
}
