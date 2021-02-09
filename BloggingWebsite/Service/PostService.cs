using BloggingWebsite.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggingWebsite.Service
{
    public class PostService : IPostService
    {
        private AppDbContext _ctx;

        public PostService(AppDbContext appDbContext)
        {
            _ctx = appDbContext;
        }


        void IPostService.Add(Post post)
        {
            if (GetPost(post.PostId) != null)
                _ctx.Posts.Update(post);
            else
                _ctx.Posts.Add(post);
        }

        public void UpdatePost(Post post)
        {
            _ctx.Posts.Update(post);
        }

        void IPostService.Delete(Guid id)
        {
            _ctx.Posts.Remove(GetPost(id));
        }

        Post GetPost(Guid id)
        {
           return _ctx.Posts.SingleOrDefault(x => x.PostId == id);
        }

        IList<Post> IPostService.GetAllBlogs()
        {
            return _ctx.Posts.ToList();
        }

        public async Task<bool> SaveChangesAsync()
        {
            if(await _ctx.SaveChangesAsync()>0)
            {
                return true;
            }
            return false;
        }

        
    }
}
