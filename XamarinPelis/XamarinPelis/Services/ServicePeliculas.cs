using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using XamarinPelis.Models;

namespace XamarinPelis.Services
{
    public class ServicePeliculas
    {
        private String url;

        public ServicePeliculas()
        {
            this.url = "https://apipeliculasxamarin.azurewebsites.net/";
        }

        private async Task<T> CallApiAsync<T>(String request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add
                    (new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response =
                    await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    String json =
                        await response.Content.ReadAsStringAsync();
                    T data =
                        JsonConvert.DeserializeObject<T>(json);
                    return data;
                }
                else
                {
                    return default(T);
                }
            }
        }

        public async Task<List<Pelicula>> GetPeliculasAsync()
        {
            String request = "api/peliculas";
            List<Pelicula> pelis =
                await this.CallApiAsync<List<Pelicula>>(request);
            return pelis;
        }
    }
}
