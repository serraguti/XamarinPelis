using MonkeyCache.FileStore;
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
            //PREGUNTAMOS SI TENEMOS DATOS EN CACHE
            //Barrel.Current.IsExpired("key: ", "value")
            if (Barrel.Current.IsExpired(key: "PELIS"))
            {
                //SI NO HAY CACHE, LOS DATOS DEL API
                String request = "api/peliculas";
                List<Pelicula> pelis =
                    await this.CallApiAsync<List<Pelicula>>(request);
                Barrel.Current.Add("PELIS", pelis
                    , TimeSpan.FromMinutes(30));
                return pelis;
            }
            else
            {
                //TENEMOS METODOS GENERICOS
                List<Pelicula> pelis =
                    Barrel.Current.Get<List<Pelicula>>("PELIS");
                return pelis;
            }
        }
    }
}
