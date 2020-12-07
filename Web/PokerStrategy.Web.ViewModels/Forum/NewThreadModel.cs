using System.ComponentModel.DataAnnotations;

namespace PokerStrategy.Web.ViewModels.Forum
{
    public class NewThreadModel
    {
        public string CategoryName { get; set; }

        public int CategoryId { get; set; }

        public string AuthorName { get; set; }

        public string CategoryImageUrl { get; set; }

        [MaxLength(50)]
        [MinLength(5)]
        [Required]
        public string Title { get; set; }

        [MaxLength(800)]
        [MinLength(2)]
        [Required]
        public string Content { get; set; }
    }
}
