using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;

namespace Rackham
{
    public class PostInfo
    {
        public string Title { get; set; }
        public int UpvoteCount { get; set; }
        public string Url { get; set; }
    }
    public class Crawler
    {
        private HttpClient client = new HttpClient();

        public async Task Start(string subreddit)
        {
            var jsonStr = await client.GetStringAsync(string.IsNullOrEmpty(subreddit) ? $"https://reddit.com/.json" : $"https://reddit.com/r/{subreddit}.json");

            var subredditResponse = JsonConvert.DeserializeObject<dynamic>(jsonStr);

            // Only this and the jsonStr is probably needed if im gonna write to a file, and i should return from that file instead?
            System.IO.File.WriteAllText("G:/Electron/source/repos/rackham-realestatecrawler/out/real-estate.txt", jsonStr);            
        }
    }
}