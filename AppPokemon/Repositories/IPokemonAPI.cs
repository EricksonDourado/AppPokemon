using AppPokemon.Models;
using AppPokemon.Models.Dtos;
using Refit;

namespace AppPokemon.Repositories
{
    public interface IPokemonAPI
    {
        [Get("/")]
        Task<PokemonsDto> GetAllPokemon();

        [Get("/{name}")]
        Task<DetalhesPokemonDto> GetByNamePokemon(string name);
    }
}
