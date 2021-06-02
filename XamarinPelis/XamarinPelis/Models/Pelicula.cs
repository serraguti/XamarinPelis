using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinPelis.Models
{
    public class Pelicula
    {
        [JsonProperty("idPelicula")]
        public int IdPelicula { get; set; }
        [JsonProperty("titulo")]
        public String Titulo { get; set; }
        [JsonProperty("argumento")]
        public String Argumento { get; set; }
        [JsonProperty("poster")]
        public String Poster { get; set; }
    }
}
