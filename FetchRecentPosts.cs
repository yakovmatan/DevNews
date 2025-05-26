using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using System.Text.Json;
using System;

public class FetchRecentPosts
{
    private HttpClient Client = new HttpClient();
    public string url { get; set; }


    public FetchRecentPosts()
    {
        this.url = "https://jsonplaceholder.typicode.com/posts";
    }

    public async Task<string> HttpRequest()
    {
        var response = await this.Client.GetAsync(this.url);
        string answer = await response.Content.ReadAsStringAsync();
        return answer;

    }

    public Posts[] FromStringToJson(string answer)
    {
        try
        {
            Posts[] posts = JsonSerializer.Deserialize<Posts[]>(answer);
            return posts;
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Error concerting Jason: {ex.Message}");
            return Array.Empty<Posts>();
        }


    }


}