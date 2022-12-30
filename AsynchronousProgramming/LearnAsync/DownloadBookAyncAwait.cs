using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace AsynchronousProgramming.LearnAsync
{
    internal class DownloadBookAyncAwait
    {
        static string _theEBook = "";


        //fter creating a new instance of the HttpClient class, the code calls the GetStringAsync() method to 
        //make an HTTP Get call to retrieve the text from the website.As you can see, the HttpClient provides a much
        //more concise way to make HTTP calls.


        public static async Task GetBookAsync()
        {
            HttpClient client = new HttpClient();
            _theEBook = await client.GetStringAsync("http://www.gutenberg.org/files/98/98-0.txt");
            Console.WriteLine("Download complete.");
            GetStats();
        }

        static void GetStats()
        {
            // Get the words from the ebook.
            string[] words = _theEBook.Split(new char[]
            { ' ', '\u000A', ',', '.', ';', ':', '-', '?', '/' },
            StringSplitOptions.RemoveEmptyEntries);
            // Now, find the ten most common words.
            string[] tenMostCommon = FindTenMostCommon(words);
            // Get the longest word.
            string longestWord = FindLongestWord(words);
            // Now that all tasks are complete, build a string to show all stats.
            StringBuilder bookStats = new StringBuilder("Ten Most Common Words are:\n");
            foreach (string s in tenMostCommon)
            {
                bookStats.AppendLine(s);
            }
            bookStats.AppendFormat("Longest word is: {0}", longestWord);
            bookStats.AppendLine();
            Console.WriteLine(bookStats.ToString(), "Book info");
        }

        static string[] FindTenMostCommon(string[] words)
        {
            var frequencyOrder = from word in words
                                 where word.Length > 6
                                 group word by word into g
                                 orderby g.Count() descending
                                 select g.Key;
            string[] commonWords = (frequencyOrder.Take(10)).ToArray();
            return commonWords;
        }

        static string FindLongestWord(string[] words)
        {
            return (from w in words orderby w.Length descending select w).FirstOrDefault();
        }

    }
}
