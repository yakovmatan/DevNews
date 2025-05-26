using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevNews
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // Exersice 1
            var fetcher = new FetchRecentPosts();


            string answer = await fetcher.HttpRequest();


            var posts = fetcher.FromStringToJson(answer);

            int count = Math.Min(posts.Length, 5);

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(posts[i].title);
            }

        }
    }
}
