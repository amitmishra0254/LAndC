using Newtonsoft.Json.Linq;

namespace TumblrBlogApis
{
    public class BlogClientImp : BlogClient
    {
        private readonly HttpClient client;
        public BlogClientImp()
        {
            this.client = new HttpClient();
        }

        public async Task<JObject> fetchBlog(string blogName, string parameters = "?num={1}") // fetching only a single blog at a time
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, new Uri($"{ApplicationConstants.baseAddress.Replace(ApplicationConstants.blogName, blogName)}{parameters}"));
            var response = await this.client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                if (responseString.Length > 0)
                {
                    // removing the starting and ending characters "var tumblr_api_read =" & ";" to parse correct JSON
                    return JObject.Parse(responseString.Substring(responseString.IndexOf('{'), responseString.Length - responseString.IndexOf('{') - 2));
                }
                else
                {
                    throw new Exception(ApplicationConstants.enptyResponseReceived);
                }
            }
            else
            {
                throw new Exception(ApplicationConstants.requestFailedException);
            }
        }
    }
}