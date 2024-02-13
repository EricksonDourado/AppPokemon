using AppPokemon.Models;
using AppPokemon.Models.Dtos;
using AppPokemon.Repositories;
using AppPokemon.View;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPokemon.Service
{
    public class PokemonService
    {
        private readonly IPokemonAPI _pokemonAPI;

        public PokemonService()
        {
            _pokemonAPI = RestService.For<IPokemonAPI>(" https://pokeapi.co/api/v2/pokemon");
        }

        public async Task<PokemonsDto> GetAllPokemon()
        {
            try
            {
                var response = await _pokemonAPI.GetAllPokemon();
                return response;
            }
            catch (Exception e)
            {

                Console.WriteLine($"Erro ao obter lista de pokemon - {e.Message}");
                return null;
            }
        }
        public async Task<DetalhesPokemonDto> GetByNamePokemon(string name)
        {
            try
            {
                var response = await _pokemonAPI.GetByNamePokemon(name);
                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao obter lista de pokemon - {e.Message}");
                DetalhesPokemonDto d = new DetalhesPokemonDto();
                return d;
            }
        }
    }
}
