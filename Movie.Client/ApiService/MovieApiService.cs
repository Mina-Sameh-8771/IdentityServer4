using Movie.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityModel.Client;
using System.Net.Http;
using Newtonsoft.Json;

namespace Movie.Client.ApiService
{
    public class MovieApiService : IMovieApiService
    {
        public async Task<IEnumerable<MovieModel>> GetMovies()
        {

            var apiClientCredentials = new ClientCredentialsTokenRequest
            {
                Address = "https://localhost:5005/connect/token",
                ClientId = "movieClient",
                ClientSecret = "secret",

                Scope = "movieAPI"
            };

            var client = new HttpClient();

            var disc = await client.GetDiscoveryDocumentAsync("https://localhost:5005");
            if (disc.IsError)
            {
                return new List<MovieModel>();
            }

            var tokenResponse = await client.RequestClientCredentialsTokenAsync(apiClientCredentials);
            if (tokenResponse.IsError)
            {
                return new List<MovieModel>();
            }

            var apiClient = new HttpClient();

            apiClient.SetBearerToken(tokenResponse.AccessToken);

            var response = await apiClient.GetAsync("https://localhost:5001/api/Movie");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            var list = JsonConvert.DeserializeObject<List<MovieModel>>(content);

            return list;

        }
    }
}
