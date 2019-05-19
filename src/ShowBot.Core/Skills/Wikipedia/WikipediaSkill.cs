using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using HtmlAgilityPack;
using ShowBot.Core.Config;
using ShowBot.Core.Skills.Events;

namespace ShowBot.Core.Skills.Wikipedia
{
    public class WikipediaSkill : ISkill<ISkillInput>
    {
        private readonly Lazy<HttpClient> _httpClient;

        public WikipediaSkill(
            Lazy<HttpClient> httpClient
        )
        {
            _httpClient = httpClient;
        }

        public string InvocationPhrase => "search wikipedia for";

        public void Execute(ISkillInput input)
        {
            input.Keyword = input.Keyword.Replace(" ", "_");

            OnSkillExecuting?.Invoke(this, new SkillInvokeEventArgs
            {
                Name = nameof(WikipediaSkill),
                Keyword = input.Keyword
            });

            var result = string.Empty;

            var searchResult = _httpClient.Value.GetAsync($"https://en.wikipedia.org/wiki/{input.Keyword}").Result;

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
                                result += paragraph.InnerText;

                                if (result.ToLower().Contains("may refer to"))
                                {
                                    var headlines = htmlDocument.DocumentNode
                                        .SelectNodes("//h2/span")
                                        .Where(x => x.InnerText.ToLower() != "see also" && x.HasClass("mw-headline"))
                                        .ToList();

                                    var counter = 0;

                                    foreach (var headline in headlines)
                                    {
                                        //if last
                                        if (counter == headlines.Count - 1)
                                        {
                                            result += $"and {headline.InnerText}.";
                                        }
                                        //second last
                                        else if (counter == headlines.Count - 2)
                                        {
                                            result += $"{headline.InnerText} ";
                                        }
                                        else
                                        {
                                            result += $"{headline.InnerText}, ";
                                        }

                                        counter++;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        result = "Sorry, seems there was nothing there to look at.";
                    }
                }
                else
                {
                    result = "Sorry, seems there was nothing there to look at.";
                }
            }
            else
            {
                result = AppConfigs.SpeechComponent.ErrorResponses.SorryCannotDoThat;
            }

            OnSkillExecuted?.Invoke(this, new SkillInvokeEventArgs
            {
                Name = nameof(WikipediaSkill),
                Keyword = input.Keyword,
                TextToRead = HtmlEntity.DeEntitize(result)
            });
        }

        public event SkillExecutingHandler OnSkillExecuting;
        public event SkillExecutedHandler OnSkillExecuted;
    }
}
