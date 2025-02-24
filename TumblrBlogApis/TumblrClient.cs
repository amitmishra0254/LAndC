namespace TumblrBlogApis
{
    public class TumblrClient
    {
        private ImageOperator imageOperator;
        private Blog blog;
        public TumblrClient(ImageOperator imageOperator, Blog blog)
        {
            this.imageOperator = imageOperator;
            this.blog = blog;
        }

        public static async Task Main(string[] args)
        {
            Console.Write("Enter the Tumblr blog name: ");
            var blogName = Console.ReadLine().Trim();
            Console.Write("Enter the range: ");
            var postRange = Array.ConvertAll(Console.ReadLine().Trim().Split('-'), int.Parse);

            BlogClient blogClient = new BlogClientImp();
            var imageOperator = new ImageOperator(blogName, blogClient);

            var blog = new Blog(blogName, blogClient);

            var tumblrClient = new TumblrClient(imageOperator, blog);
            await tumblrClient.blog.setInformation();
            tumblrClient.blog.displayInformation();
            await tumblrClient.imageOperator.getImageBetween(postRange[0], postRange[1]);
            await tumblrClient.imageOperator.displayImages();
        }
    }
}