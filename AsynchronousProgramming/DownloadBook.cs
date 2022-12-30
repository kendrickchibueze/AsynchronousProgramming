using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AsynchronousProgramming
{
    internal class DownloadBook
    {
         static  string _theEBook = "";

        public static void Mydownload()
        {
            //string _theEBook = "";
            GetBook();
            Console.WriteLine("Downloading book...");
            Console.ReadLine();
            void GetBook()
            {
                //NOTE: The WebClient is obsolete.
                //We will revisit this example using HttpClient when we discuss async/await
                using WebClient wc = new WebClient();
                wc.DownloadStringCompleted += (s, eArgs) =>
                {
                    _theEBook = eArgs.Result;
                    Console.WriteLine("Download complete.");
                    GetStats();
                };
                // The Project Gutenberg EBook of A Tale of Two Cities, by Charles Dickens
                // You might have to run it twice if you’ve never visited the site before, since the first
                // time you visit there is a message box that pops up, and breaks this code.
                wc.DownloadStringAsync(new Uri("http://www.gutenberg.org/files/98/98-0.txt"));
            }
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


        //You can help ensure that your application uses all available CPUs on the host machine by invoking 
        //the FindTenMostCommon() and FindLongestWord() methods in parallel


        //The Parallel.Invoke() method expects a parameter array of Action<> delegates, which you have
        //supplied indirectly using lambda expressions.Again, while the output is identical, the benefit is that the TPL
        //will now use all possible processors on the machine to invoke each method in parallel if possible.

        //static void GetStats()
        //{
        //    // Get the words from the ebook.
        //    string[] words = _theEBook.Split(
        //    new char[] { ' ', '\u000A', ',', '.', ';', ':', '-', '?', '/' },
        //    StringSplitOptions.RemoveEmptyEntries);
        //    string[] tenMostCommon = null;
        //    string longestWord = string.Empty;
        //    Parallel.Invoke(() =>
        //      {
        //          // Now, find the ten most common words.
        //          tenMostCommon = FindTenMostCommon(words);
        //      },
        //      () =>
        //      {
        //          // Get the longest word.
        //          longestWord = FindLongestWord(words);
        //      });
        //}

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
