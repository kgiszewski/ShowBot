using System;
using System.Linq;
using System.Net.Http;
using HtmlAgilityPack;
using ShowBot.Core.Components.Robot;
using ShowBot.Core.Config;
using ShowBot.Core.Skills.Wikipedia.Models;

namespace ShowBot.Core.Skills.Wikipedia
{
    public class WikipediaSkill : ISkill<WikipediaSearchQuery, WikipediaSearchResult>
    {
        private readonly Lazy<HttpClient> _httpClient;
        private readonly Lazy<IRobot> _robot;

        public WikipediaSkill(
            Lazy<HttpClient> httpClient,
            Lazy<IRobot> robot
        )
        {
            _httpClient = httpClient;
            _robot = robot;
        }

        public WikipediaSearchResult Execute(WikipediaSearchQuery query)
        {
            var result = new WikipediaSearchResult();

            var searchResult = _httpClient.Value.GetAsync($"https://en.wikipedia.org/wiki/{query.Keyword}").Result;

            if (searchResult.IsSuccessStatusCode)
            {
                if (searchResult.Content.Headers.ContentLength > 0)
                {
                    var htmlDocument = new HtmlDocument();

                    htmlDocument.Load(searchResult.Content.ReadAsStreamAsync().Result);

                    var paragraphs = htmlDocument.DocumentNode.SelectNodes("//p");

                    if (paragraphs.Any())
                    {
                        foreach (var paragraph in paragraphs)
                        {
                            var text = paragraph.InnerText.Trim();

                            if (!string.IsNullOrEmpty(text))
                            {
                                result.TextToRead = paragraph.InnerText;

                                break;
                            }
                        }
                    }
                    else
                    {
                        result.TextToRead = "Sorry, seems there was nothing there to look at.";
                    }
                }
                else
                {
                    result.TextToRead = "Sorry, seems there was nothing there to look at.";
                }
            }
            else
            {
                result.TextToRead = AppConfigs.SpeechComponent.ErrorResponses.SorryCannotDoThat;
            }

            _robot.Value.Say(result.TextToRead);

            return result;
        }
    }
}
