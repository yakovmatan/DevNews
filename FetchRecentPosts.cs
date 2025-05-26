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

    public string answer { get; private set; }

    public FetchRecentPosts()
    {
        this.url = "https://jsonplaceholder.typicode.com/posts";
    }

    public async Task HttpRequest()
    {
        var response = await this.Client.GetAsync(this.url);
        this.answer = await response.Content.ReadAsStringAsync();
    }

    public Posts[] FromStringToJson()
    {
        if (string.IsNullOrEmpty(this.answer))
            throw new InvalidOperationException("Must call HttpRequest() before parsing.");

        Posts[] posts = JsonSerializer.Deserialize<Posts[]>(this.answer);
        return posts;
        
    }


}