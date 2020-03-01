using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace cw1
{
    class Program
    {
        public static async Task Main(string[] args)
        {
           foreach(var a in args)
            {
                Console.WriteLine(a);
            }
            var emails =await GetEmails(args[0]);

            foreach(var email in emails)
            {
                Console.WriteLine(email);
            }
                
        }
        static async Task<IList<string>> GetEmails(string url)
        {
            var HttpClient = new HttpClient();
            var listOfEmails = new List<string>();
            var response = await HttpClient.GetAsync(url);



            Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", RegexOptions.IgnoreCase);

            MatchCollection emailMatches = emailRegex.Matches(response.Content.ReadAsStringAsync().Result);
            foreach(var emailMatche in emailMatches)
            {
                listOfEmails.Add(emailMatche.ToString());
            }
            return listOfEmails;
        }
    }
}
