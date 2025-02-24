using Newtonsoft.Json.Linq;

namespace TumblrBlogApis
{
    public class Blog
    {
        private string name;
        private string blogName;
        private string title;
        private string description;
        private int numberOfPosts;
        private JObject blog;
        private readonly BlogClient client;

        public Blog(string blogName, BlogClient client)
        {
            this.blogName = blogName;
            this.client = client;
        }

        public async Task setInformation()
        {
            this.blog = await client.fetchBlog(this.blogName);

            this.title = this.blog.TryGetValue("tumblelog", out JToken? tumblelog) && !string.IsNullOrEmpty(tumblelog["title"].ToString()) ? tumblelog["title"].ToString() : "No Title";
            this.name = !string.IsNullOrEmpty(tumblelog["name"].ToString()) ? tumblelog["name"].ToString() : "No Name";
            this.description = !string.IsNullOrEmpty(tumblelog["description"].ToString()) ? tumblelog["description"].ToString() : "No Description";
            this.numberOfPosts = this.blog.TryGetValue("posts-total", out JToken? totalPosts) ? totalPosts.Value<int>() : 0;
        }

        public void displayInformation()
        {
            Console.WriteLine($"Title: {this.title}");
            Console.WriteLine($"Name: {this.name}");
            Console.WriteLine($"Description: {this.description}");
            Console.WriteLine($"No of Posts: {this.numberOfPosts}");
        }
    }
}