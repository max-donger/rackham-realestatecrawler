using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Linq;
using System;
using System.IO;
using System.Globalization;

namespace Rackham
{
    public class PostInfo
    {
        public string Title { get; set; }
        public int UpvoteCount { get; set; }
        public string Url { get; set; }
    }
    public class JsonSource 
    {
        //[JsonProperty("source")]
        public string Source { get; set; }

        //[JsonProperty("realestate")]
        public IList<string> Realestate { get; set; }
    }

    public class Crawler
    {
        private HttpClient client = new HttpClient();

        public async Task Crawl(string source)
        {
            // TODO: No longer fetch from reddit but fetch from actual source
            var jsonStr = await client.GetStringAsync(string.IsNullOrEmpty(source) ? $"https://reddit.com/.json" : $"https://reddit.com/r/{source}.json");

            var subredditResponse = JsonConvert.DeserializeObject<dynamic>(jsonStr);

            // Saving to a file so it can be used as a cache.
            System.IO.File.WriteAllText("G:/Electron/source/repos/rackham-realestatecrawler/out/real-estate.json", jsonStr);            
        }

        public async Task<IEnumerable<PostInfo>> GetLatestCrawl(string source)
        {
            //JsonReader funda = JsonConvert.DeserializeObject<JsonReader>(File.ReadAllText(@"G:/Electron/source/repos/rackham-realestatecrawler/test/funda.json"));
            
            var jsonStr = await client.GetStringAsync(string.IsNullOrEmpty(source) ? $"https://reddit.com/.json" : $"https://reddit.com/r/{source}.json");

            var subredditResponse = JsonConvert.DeserializeObject<dynamic>(jsonStr);

            /*var data = File.ReadAllText(@"G:/Electron/source/repos/rackham-realestatecrawler/test/funda.json");
            var terry = JsonConvert.DeserializeObject<JsonSource>(data);

            return ((IEnumerable<dynamic>)terry).Select(post => new JsonSource
            {
                Source = post.Source
            });
            */

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

            // TODO: Remove randomness for testing and add actual check
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