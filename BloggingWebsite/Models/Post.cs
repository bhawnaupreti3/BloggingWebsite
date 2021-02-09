using System;

namespace BloggingWebsite
{
    /// <summary>
    /// Post model
    /// </summary>
    public class Post
    {
        /// <summary>
        /// Date of post creation
        /// </summary>
        public DateTime Created { get; set; } = DateTime.Now;

        /// <summary>
        /// Description of post , default empty
        /// </summary>
        public string Description { get; set; } = "";

        /// <summary>
        /// Title of post, default empty
        /// </summary>
        public string Title { get; set; } = "";

        /// <summary>
        /// Post Id, guid
        /// </summary>
        public Guid PostId { get; set; }
    }
}
