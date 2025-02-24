using Newtonsoft.Json.Linq;

namespace TumblrBlogApis
{
    public interface BlogClient
    {
        Task<JObject> fetchBlog(string blogName, string parameters = "?num={1}");
    }
}