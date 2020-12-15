namespace PokerStrategy.Web.ViewModels.Forum
{
    using System.Collections.Generic;

    public class ThreadListingViewModel
    {
        public CategoryViewModel Category { get; set; }

        public IEnumerable<ThreadViewModel> ThreadsList { get; set; }
    }
}
