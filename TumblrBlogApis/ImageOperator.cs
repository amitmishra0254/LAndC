using Newtonsoft.Json.Linq;

namespace TumblrBlogApis
{
    public class ImageOperator
    {
        private string blogName;
        private List<string> images;
        private readonly BlogClient client;
        public ImageOperator(string blogName, BlogClient client)
        {
            this.blogName = blogName;
            this.images = new List<string>();
            this.client = client;
        }

        public async Task getImageBetween(int fromNumber, int toNumber)
        {
            for (int index = fromNumber - 1; index < toNumber; index++)
            {
                var parameters = $"?num={1}&start={index}";
                var response = await this.client.fetchBlog(this.blogName, parameters);
                var posts = response.GetValue("posts") as JArray;
                if (posts != null)
                {
                    foreach (var post in posts)
                    {
                        var photos = post["photos"] as JArray;
                        if (photos != null && photos is JArray photosArray && photosArray.Count > 0)
                        {
                            foreach (var photo in photosArray)
                            {
                                var photoUrl = photo["photo-url-1280"]; // fetching only 1280 resolution image
                                this.images.Add(photoUrl.ToString());
                            }
                        }
                    }
                }
            }
        }

        public async Task displayImages()
        {
            Console.WriteLine("Images: ");
            foreach (var image in this.images)
            {
                Console.WriteLine(image);
            }
        }
    }
}