namespace PokerStrategy.Web.ViewModels.Videos
{
    using System;

    public class VideoViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string VideoUrl { get; set; }

        public DateTime CreatedOn { get; set; }

        public int Views { get; set; }

        private string StartLink = "https://i.ytimg.com/vi/";
        private string MidLink1 => this.VideoUrl.Replace("https://www.youtube.com/watch?v=", "");
        private string MidLink2 => MidLink1.Replace("&feature=emb_title", "");
        private string EndLink = "/0.jpg";
        public string ThumbnailLink => String.Concat(StartLink, MidLink2, EndLink);
    }
}
