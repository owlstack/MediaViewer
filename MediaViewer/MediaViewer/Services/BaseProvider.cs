using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MediaViewer.Services
{
    public class BaseProvider
    {
        protected string _baseImageUrl;
        protected string _baseVideoUrl;
        protected string _apiKey = "9376107-66019d38e0acfec209f5461ce";

        /// <summary>
        /// Make an get webrequest to the Pixabay api and return the deserialized object.
        /// </summary>
        /// <typeparam name="TClass">Class which should be returned</typeparam>
        /// <param name="query">Query to search for</param>
        /// <param name="isImageSearch">Indicates if this search is an image search</param>
        /// <returns>Result of type TClass</returns>
        internal async Task<TClass> GetRequestAsync<TClass>(string apiUrl, bool isImageSearch = true)
            where TClass : class
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.ExpectationFailed);

            using (var client = new HttpClient())
            {
                try
                {
                    var baseUri = isImageSearch ? _baseImageUrl : _baseVideoUrl;
                    response = await client.GetAsync($"{apiUrl}").ConfigureAwait(false);
                    var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    if (response.IsSuccessStatusCode)
                        return JsonConvert.DeserializeObject<TClass>(responseString);

                    Console.WriteLine(responseString);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("exception thrown: " + ex.Message);
                }
            }

            return default(TClass);
        }

    }
}
