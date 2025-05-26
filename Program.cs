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
            // Exercise 1
            var fetcher = new FetchRecentPosts();


            string answer = await fetcher.HttpRequest();


            var posts = fetcher.FromStringToJson(answer);

            int count = Math.Min(posts.Length, 5);

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(posts[i].title);
            }
            // Exercise 2
            int number;
            while (true)
            {
                Console.WriteLine("enter a number between 1 and 100");
                string input = Console.ReadLine();

                if (int.TryParse(input,out number))
                {
                    break;
                }
                Console.WriteLine("invalid input, try again.");
            }
            bool flag = false;
            foreach (var post in posts)
            {
                if (post.id == number)
                {
                    Console.WriteLine(post.title,post.body);
                    flag = true;
                    break;
                }
                
            }
            if (!flag)
            {
                Console.WriteLine("The ID you entered was not found.");
            }



        }
    }
}
