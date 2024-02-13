using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPokemon.Models.Dtos
{
    public class PokemonsDto
    {
        [JsonProperty("results")]
        public Result[]? Results { get; set; }


        public class Result
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("url")]
            public Uri Url { get; set; }
        }
    }
    public class DetalhesPokemonDto
    {
        [JsonProperty("height")]
        public double Height { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("weight")]
        public double Weight { get; set; }

        [JsonProperty("order")]
        public double Order { get; set; }

    }
}
