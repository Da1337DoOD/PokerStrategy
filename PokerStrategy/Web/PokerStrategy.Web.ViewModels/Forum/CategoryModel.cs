namespace PokerStrategy.Web.ViewModels.Forum
{
    using System.Collections.Generic;

    public class CategoryModel
    {
        public CategoryListingModel Category { get; set; }

        public IEnumerable<ThreadListingModel> Threads { get; set; }
    }
}
