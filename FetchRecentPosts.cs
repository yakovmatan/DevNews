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

    public async Task<string> HttpGet()
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

    public async Task httpPut()
    {
        var json = "{\"title\": \"Updated Title\", \"body\": \"Updadted Content\"}";
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await Client.PutAsync("https://jsonplaceholder.typicode.com/posts/1", content);
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("The post updated successfully.");
        }
        else
        {
            Console.WriteLine($"Failed to update post");
        }
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