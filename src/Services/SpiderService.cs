using Privateer.Rackham.Models;
using Privateer.Rackham.Repositories;
using Tweetinvi;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace Privateer.Rackham.Services
{
    public class SpiderService : ISpiderService
    {
        private ISpiderRepository _spiderRepository;
        public SpiderService(ISpiderRepository spiderRepository) 
        {
            _spiderRepository = spiderRepository ?? throw new ArgumentNullException(nameof(spiderRepository));
        }

        public Task<IEnumerable<Spider>> ReadAllAsync()
        {
            return _spiderRepository.ReadAllAsync();
        }

        public Task<Spider> ReadOneAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<int> ToggleOneActiveAsync(string spiderKey)
        {
            var toggledActiveSpider = await _spiderRepository.ToggleOneActiveAsync(spiderKey);
            return toggledActiveSpider;
        }

        /*
        public async Task ToggleOneCrawlAsync(EstateAgency estateAgency, Website website)
        {
            // TODO: Add if for website here
            try {
                await TwitterAPI(estateAgency);
                // await Selenium(estateAgency);
            }
            catch {
                throw new System.ArgumentException("Could not find estate agency.", estateAgency.Name);
            }
            return _spiderRepository.ToggleOneCrawlAsync(Website website);
        }
        */

        private async Task TwitterAPI(EstateAgency estateAgency) {
            // Set up your credentials (https://apps.twitter.com)
            Auth.SetUserCredentials(ConfigurationManager.AppSettings["TwitterConsumerKey"], ConfigurationManager.AppSettings["TwitterConsumerSecret"], ConfigurationManager.AppSettings["TwitterAccessToken"], ConfigurationManager.AppSettings["TwitterAccessTokenSecret"]);

            // TODO: Should be keys, and the estateAgencies should be generated already, or editable and then add a twitter handle.
            if (estateAgency.Name == "MoenGarantiemakelaars") {
                // Fetch the latest 5 tweets (not retweets) and print them
                var timeline = Timeline.GetUserTimeline(User.GetUserFromScreenName("Huistekoop030"), 5).ToList();
                File.WriteAllText($"G:/Electron/source/repos/rackham-realestatecrawler/out/{estateAgency}.json", JsonConvert.SerializeObject(timeline));
            }
            else if (estateAgency.Name == "placeholderEstateAgentWithoutTwitter") {
                // TODO: Handle this
                Console.Error.WriteLine("Estate agency does not have a Twitter account.");
            }
            else {
                throw new System.ArgumentException("Unknown estateAgency.", estateAgency.Name);
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
        private async Task Selenium(EstateAgency estateAgency) {
            throw new NotImplementedException();
            // IWebDriver driver = new FirefoxDriver();
            // RealEstateInfo realEstateInfo = new RealEstateInfo(); // I moved to Service.cs

            // driver.Url = "http://donger.tv/heneknowledgebase";

            // Browse the website
            // driver.FindElement(By.CssSelector("#epkb_tab_2 > .epkb-category-level-1")).Click();
            // driver.FindElement(By.CssSelector(".epkb_tab_2 > .section_light_shadow:nth-child(2) .eckb-article-title > span")).Click();
            
            // Set the values
            /*
            realEstateInfo.Title = driver.FindElement(By.LinkText("techlog")).Text; 
            realEstateInfo.UpvoteCount = "bla2";
            realEstateInfo.Url = "bla";

            File.WriteAllText(@"G:/Electron/source/repos/rackham-realestatecrawler/test/fundaOUT.json", JsonConvert.SerializeObject(realEstateInfo));
            */
            
        }

        // TODO: Add argument for spider
        public async Task<int> ReadOneStatusAsync()
        {
            int status;
            // TODO: Remove randomness for testing and add actual check
            
            Random rand = new Random();
            if (rand.Next(0, 2) != 0)
            {
                status = 1;
            }
            else {
                status = 2;
            }
            
            return status;
        }
    }
}