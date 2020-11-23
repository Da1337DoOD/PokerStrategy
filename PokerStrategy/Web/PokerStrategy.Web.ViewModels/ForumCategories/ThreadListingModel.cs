namespace PokerStrategy.Web.ViewModels.ForumCategories
{
    public class ThreadListingModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string AuthorName { get; set; }

        public string AuthorId { get; set; }

        public int AuthorPoints { get; set; }

        public string DateCreated { get; set; }

        public CategoryListingModel Category { get; set; }

        public int RepliesCount { get; set; }
    }
}
