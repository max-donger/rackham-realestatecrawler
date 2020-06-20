using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;
using System;

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

        public async Task Crawl(string source)
        {
            var jsonStr = await client.GetStringAsync(string.IsNullOrEmpty(source) ? $"https://reddit.com/.json" : $"https://reddit.com/r/{source}.json");

            var subredditResponse = JsonConvert.DeserializeObject<dynamic>(jsonStr);

            // Only this and the jsonStr is probably needed if im gonna write to a file, and i should return from that file instead?
            System.IO.File.WriteAllText("G:/Electron/source/repos/rackham-realestatecrawler/out/real-estate.json", jsonStr);            
        }

        public async Task<IEnumerable<PostInfo>> GetLatestCrawl(string source)
        {
            var jsonStr = await client.GetStringAsync(string.IsNullOrEmpty(source) ? $"https://reddit.com/.json" : $"https://reddit.com/r/{source}.json");

            var subredditResponse = JsonConvert.DeserializeObject<dynamic>(jsonStr);
            return ((IEnumerable<dynamic>)subredditResponse.data.children).Select(post => new PostInfo
            {
                Title = post.data.title,
                UpvoteCount = post.data.ups,
                Url = post.data.url
            });
        }

        public async Task<int> checkStatus(string source)
        {
            int output;

            Random rand = new Random();
            if (rand.Next(0, 2) != 0)
            {
                output = 1;
            }
            else {
                output = 2;
            }
            
            return output;
        }
    }
}