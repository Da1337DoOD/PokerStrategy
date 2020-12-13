namespace PokerStrategy.Web.ViewModels.Videos
{
    using System;

    public class VideoViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ShortenedTitle => Title.Length > 40 ? Title.Substring(0, 40) + ".." : Title;

        public string Description { get; set; }

        public string ShortenedDescription => Description.Length > 80 ? Description.Substring(0, 80) + ".." : Description;

        public string VideoUrl { get; set; }

        public DateTime CreatedOn { get; set; }

        public int Views { get; set; }

        public string VideoThumbnailUrl { get; set; }
    }
}
