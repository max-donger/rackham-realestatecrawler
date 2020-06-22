using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Linq;
using System;
using System.Configuration;
using System.IO;
using System.Globalization;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Firefox;
using Tweetinvi;
using Tweetinvi.Models;
using tweetapistream = Tweetinvi.Stream; // Due to ambiguity with System.IO.Stream, I had to change the name

namespace Rackham
{

    public class Crawler
    {
        private HttpClient client = new HttpClient();

        public async Task Crawl(string estateAgency)
        {
            // TODO: Remove this? This is old code which fetched from Reddit.json file
            // jsonRemote = await client.GetStringAsync(string.IsNullOrEmpty(source) ? $"https://reddit.com/.json" : $"https://reddit.com/r/{source}.json");
            // System.IO.File.WriteAllText("G:/Electron/source/repos/rackham-realestatecrawler/out/real-estate.json", jsonRemote);            
            try {
                // await Twitter(estateAgency);
                //await Selenium(estateAgency);
            }
            catch {
                throw new System.ArgumentException("Could not find estate agency.", estateAgency);
            }
        }

        private async Task Twitter(string estateAgency) {
            // Set up your credentials (https://apps.twitter.com)
            Auth.SetUserCredentials(ConfigurationManager.AppSettings["TwitterConsumerKey"], ConfigurationManager.AppSettings["TwitterConsumerSecret"], ConfigurationManager.AppSettings["TwitterAccessToken"], ConfigurationManager.AppSettings["TwitterAccessTokenSecret"]);

            if (estateAgency == "MoenGarantiemakelaars") {
                // Fetch the latest 5 tweets (not retweets) and print them
                var timeline = Timeline.GetUserTimeline(User.GetUserFromScreenName("Huistekoop030"), 5).ToList();
                File.WriteAllText($"G:/Electron/source/repos/rackham-realestatecrawler/out/{estateAgency}.json", JsonConvert.SerializeObject(timeline));
            }
            else if (estateAgency == "placeholderEstateAgentWithoutTwitter") {
                // TODO: Handle this
                Console.Error.WriteLine("Estate agency does not have a Twitter account.");
            }
            else {
                throw new System.ArgumentException("Unknown estateAgency.", estateAgency);
            }

            /*  TODO: Use WebHooks instead of using a stream of a users timeline.
            https://developer.twitter.com/en/docs/accounts-and-users/subscribe-account-activity/guides/getting-started-with-webhooks
            https://github.com/linvi/tweetinvi/wiki/Webhooks
            */
            /* Livestream
            var stream = tweetapistream.CreateFilteredStream();
            Console.Error.WriteLine("I am listening to Twitter");

            stream.AddFollow(User.GetUserFromScreenName("Huistekoop030"));
            
            stream.MatchingTweetReceived += (sender, arguments) =>
            {
                Console.Error.WriteLine(arguments.Tweet.Text);
            };

            stream.StartStreamMatchingAllConditions();
            */
        }
        private async Task Selenium() {
            IWebDriver driver = new FirefoxDriver();
            // RealEstateInfo realEstateInfo = new RealEstateInfo(); // I moved to Service.cs

            /* Selenium
            driver.Url = "http://donger.tv/heneknowledgebase";

            // Browse the website
            driver.FindElement(By.CssSelector("#epkb_tab_2 > .epkb-category-level-1")).Click();
            driver.FindElement(By.CssSelector(".epkb_tab_2 > .section_light_shadow:nth-child(2) .eckb-article-title > span")).Click();
            
            // Set the values
            realEstateInfo.Title = driver.FindElement(By.LinkText("techlog")).Text; 
            realEstateInfo.UpvoteCount = "bla2";
            realEstateInfo.Url = "bla";

            File.WriteAllText(@"G:/Electron/source/repos/rackham-realestatecrawler/test/fundaOUT.json", JsonConvert.SerializeObject(realEstateInfo));

            */
        }

        // TODO: Should I move to Service.cs?
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