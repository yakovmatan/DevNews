using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using System.Text.Json;
using System;
using System.Text;

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

    public async Task HttpPost(object obj)
    {
        var json = JsonSerializer.Serialize(obj);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await Client.PostAsync("https://jsonplaceholder.typicode.com/posts", content);
        Console.WriteLine(response.StatusCode);
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