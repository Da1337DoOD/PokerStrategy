namespace PokerStrategy.Web.ViewModels.ForumCategories
{
    using System.Collections.Generic;

    public class CategoryModel
    {
        public CategoryListingModel Category { get; set; }

        public IEnumerable<ThreadListingModel> ThreadList { get; set; }
    }
}
