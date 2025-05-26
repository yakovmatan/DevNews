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
            var fetcher = new FetchRecentPosts();


            await fetcher.HttpRequest();


            var posts = fetcher.FromStringToJson();


            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(posts[i].title);
            }

        }
    }
}
