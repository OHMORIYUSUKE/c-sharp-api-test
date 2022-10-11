using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;


class Anime
{
    public int id { get; set; }
    public string? title { get; set; }
    public string? title_short1 { get; set; }
    public string? title_short2 { get; set; }
    public string? title_short3 { get; set; }
    public string? title_en { get; set; }
    public string? public_url { get; set; }
    public string? twitter_account { get; set; }
    public string? twitter_hash_tag { get; set; }
    public int cours_id { get; set; }
    public DateTime created_at { get; set; }
    public DateTime updated_at { get; set; }
    public int? sex { get; set; }
    public int? sequel { get; set; }
    public int? city_code { get; set; }
    public string? city_name { get; set; }
    public string? product_companies { get; set; }
    public string? ogp_image_url { get; set; }
    public string? ogp_description { get; set; }
}

class Program
{
    public static void Main(string[] args)
    {
        var task = GetJson();
        task.Wait();
        Anime[] animeList = task.Result;
        for (int i = 0; i < animeList.Length; i++)
        {
            Console.WriteLine(animeList[i].title);
        }
    }

    private static async Task<Anime[]> GetJson()
    {
        var client = new HttpClient();
        var result = await client.GetAsync(@"https://raw.githubusercontent.com/OHMORIYUSUKE/animeapp-db/api/2022-4.json");
        var json = await result.Content.ReadAsStringAsync();
        var data = JsonSerializer.Deserialize<Anime[]>(json);
        return data;
    }
}
