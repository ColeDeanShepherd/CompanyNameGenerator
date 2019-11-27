using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CompanyNameGenerator
{
    public static class Utils
    {
        public static HttpClient HttpClient = new HttpClient();

        public static async Task<string> DownloadTxtFileWithHttpGet(Uri uri)
        {
            var response = await HttpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        public static IEnumerable<string> GetWords(string input)
        {
            var matches = Regex.Matches(input, @"\b[a-zA-Z']*\b");
            var words = (
                from m in matches.Cast<Match>()
                where !string.IsNullOrEmpty(m.Value)
                select TrimSuffix(m.Value)
            );
            return words;
        }

        public static string TrimSuffix(string word)
        {
            int apostropheIndex = word.IndexOf('\'');
            if (apostropheIndex >= 0)
            {
                word = word.Substring(0, apostropheIndex);
            }
            return word;
        }
    }
}
