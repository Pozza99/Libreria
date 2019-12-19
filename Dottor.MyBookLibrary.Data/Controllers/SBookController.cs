using Dottor.MyBookLibrary.Data.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static Dottor.MyBookLibrary.Data.Models.SBook;

namespace Dottor.MyBookLibrary.Data.Controllers
{
    public class SBookController : ISBook
    {
        public async Task<IEnumerable<Doc>> GetFacts(string title)
        {

            string title2 = WebUtility.UrlEncode(title);

            var client = new HttpClient();
            var response = await client.GetAsync("http://openlibrary.org/search.json?q=" + title2);
            response.EnsureSuccessStatusCode();
            var x = await response.Content.ReadAsStringAsync();

            var obj = JsonConvert.DeserializeObject<Rootobject>(x); // è solo uno 
            return obj.docs; //docs è dentro a RootObject e lo ritorno
        }

        public async Task<BookDetailsResult> GetDetails(string isbn)
        {
            var url = $"https://openlibrary.org/api/books?bibkeys=ISBN:{isbn}&jscmd=details&format=json";

            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var stringResult = await client.GetStringAsync(url);

            var obj = JObject.Parse(stringResult);
            var details = obj[$"ISBN:{isbn}"];

            return details.ToObject<BookDetailsResult>();
        }
    }
}
