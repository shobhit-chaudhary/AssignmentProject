


using BlogManagement.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BlogManagement.Services
{
    public class BlogService : IBlogService
    {
        private readonly string _filePath = "Data/blogposts.json";
        private List<BlogPost> _blogPosts;

        public BlogService()
        {
            if (File.Exists(_filePath))
            {
                var jsonData = File.ReadAllText(_filePath);
                _blogPosts = JsonConvert.DeserializeObject<List<BlogPost>>(jsonData) ?? new List<BlogPost>();
            }
            else
            {
                _blogPosts = new List<BlogPost>();
            }
        }

        public IEnumerable<BlogPost> GetAllBlogPosts()
        {
            return _blogPosts;
        }

        public BlogPost GetBlogPost(int id)
        {
            return _blogPosts.FirstOrDefault(p => p.Id == id);
        }

        public BlogPost AddBlogPost(BlogPost newPost)
        {
            newPost.Id = _blogPosts.Count > 0 ? _blogPosts.Max(p => p.Id) + 1 : 1;
            _blogPosts.Add(newPost);
            SaveToFile();
            return newPost;
        }

        public BlogPost UpdateBlogPost(int id, BlogPost updatedPost)
        {
            var post = _blogPosts.FirstOrDefault(p => p.Id == id);
            if (post != null)
            {
                post.Username = updatedPost.Username;
                post.DateCreated = updatedPost.DateCreated;
                post.Text = updatedPost.Text;
                SaveToFile();
            }
            return post;
        }

        public void DeleteBlogPost(int id)
        {
            var post = _blogPosts.FirstOrDefault(p => p.Id == id);
            if (post != null)
            {
                _blogPosts.Remove(post);
                SaveToFile();
            }
        }

        private void SaveToFile()
        {
            var jsonData = JsonConvert.SerializeObject(_blogPosts, Formatting.Indented);
            File.WriteAllText(_filePath, jsonData);
        }
    }
}

