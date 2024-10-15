using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WikipediaAutomation
{
    class Program
    {
        static void Main(string[] args)
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                // Initialize the Wikipedia page object
                var wikipediaPage = new WikipediaPage(driver);
                wikipediaPage.NavigateToPage();

                // Extract text from the Test-driven development section
                string text = wikipediaPage.GetTestDrivenDevelopmentText();

                // Process the text
                Dictionary<string, int> wordCount = ProcessText(text);

                // Output the word count
                foreach (var entry in wordCount)
                {
                    Console.WriteLine($"{entry.Key}: {entry.Value}");
                }
            }
        }

        static Dictionary<string, int> ProcessText(string text)
        {
            // Remove brackets and their contents
            text = Regex.Replace(text, @"\[[^\]]*\]", string.Empty);

            // Convert text to lowercase and split into words, disregarding punctuation
            var words = Regex.Split(text.ToLower(), @"\W+").Where(w => w != "");

            // Count occurrences of each word
            var wordCount = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (wordCount.ContainsKey(word))
                {
                    wordCount[word]++;
                }
                else
                {
                    wordCount[word] = 1;
                }
            }

            return wordCount;
        }
    }
}
