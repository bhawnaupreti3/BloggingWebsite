using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BloggingWebsite.Service
{
    /// <summary>
    /// Post Service Interface
    /// </summary>
    public interface IPostService
    {

        void Add(Post post);
        void Delete(Guid id);
        void UpdatePost(Post post);
        IList<Post> GetAllBlogs();


        Task<bool> SaveChangesAsync();


    }
}
