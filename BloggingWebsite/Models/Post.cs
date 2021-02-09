using System;

namespace BloggingWebsite
{
    public class Post
    {
        public DateTime Created { get; set; } = DateTime.Now;

        public string Description { get; set; } = "";

        public string Title { get; set; } = "";
        public Guid PostId { get; set; }
    }
}
