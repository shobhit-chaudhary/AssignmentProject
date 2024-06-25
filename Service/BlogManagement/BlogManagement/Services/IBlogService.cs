using BlogManagement.Models;
using System.Collections.Generic;

namespace BlogManagement.Services
{
    public interface IBlogService
    {
        IEnumerable<BlogPost> GetAllBlogPosts();
        BlogPost GetBlogPost(int id);
        BlogPost AddBlogPost(BlogPost newPost);
        BlogPost UpdateBlogPost(int id, BlogPost updatedPost);
        void DeleteBlogPost(int id);
    }
}
