using AppPokemon.Controllers;
using AppPokemon.Models;
using AppPokemon.Models.Dtos;
using AppPokemon.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPokemon.View
{
    public  class PokemonView
    {
        public String MenuInicial()
        {
            Console.WriteLine("===================================================");
            Console.WriteLine("======== Bem vindo ao Game Pokemon ================");
            Console.WriteLine("===================================================\n");

            Console.WriteLine("\nQual é seu Nome?");
            return Console.ReadLine();
        }
        public String Menu(String _usuario)
        {
            Console.WriteLine("\n-------------------Menu--------------");
            Console.WriteLine($"{_usuario} você Deseja:");
            Console.WriteLine("1 -Adotar um mascote virtual");
            Console.WriteLine("2 -Ver seus Mascotes");
            Console.WriteLine("3 -Sair");
            String opcao = Console.ReadLine();

            return opcao;
        }

        public String OpcoesAdotar(Pokemon pokemon, String _usuario)
        {
            Console.WriteLine("\n-----------------Menu Adotar-----------");
            Console.WriteLine($"{_usuario} Você Deseja:");
            Console.WriteLine($"1 - Saber mais sobre o {pokemon.Name}");
            Console.WriteLine($"2 - Adotar {pokemon.Name}");
            Console.WriteLine("3 - Sair");

            String opcao = Console.ReadLine();
            return opcao;
        }

        public void MensagemAdocao(Pokemon pokemon)
        {
            Console.WriteLine("Parabéns! Você adotou um " + pokemon.Name + "!");
            Console.WriteLine("──────────────");
            Console.WriteLine("────▄████▄────");
            Console.WriteLine("──▄████████▄──");
            Console.WriteLine("──██████████──");
            Console.WriteLine("──▀████████▀──");
            Console.WriteLine("─────▀██▀─────");
            Console.WriteLine("──────────────");
        }

        public async Task DetalhesPokemonAsync(string name)
        {
            PokemonService pokemonService = new PokemonService();

            DetalhesPokemonDto detalhesPokemon = await pokemonService.GetByNamePokemon(name);
            Console.WriteLine($"\n--------------Detalhes do Pokemon------------");
            Console.WriteLine($"Nome:   {detalhesPokemon.Name}");
            Console.WriteLine($"Altura: {detalhesPokemon.Height}");
            Console.WriteLine($"Peso:   {detalhesPokemon.Weight}\n");
        }

    }
}
