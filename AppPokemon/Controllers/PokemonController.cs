using AppPokemon.Models;
using AppPokemon.Models.Dtos;
using AppPokemon.Repositories;
using AppPokemon.Service;
using AppPokemon.View;
using Refit;

namespace AppPokemon.Controllers
{
    public class PokemonController
    {
        public List<Pokemon> pokemonsAdotados { get; set; } = new List<Pokemon>();
        public string _usuario;
        public PokemonView pokemonView = new PokemonView();
        public PokemonService pokemonService = new PokemonService();

        public async Task<String> StartPokemon()
        {
            _usuario = pokemonView.MenuInicial();
            String sair = "";

            while (sair != "sair")
            {
                String opcao = pokemonView.Menu(_usuario);
                switch (opcao)
                {
                    case "1":
                        string sairMascote = "";
                        Pokemon selecionado = await BuscarMascote();
                        if (selecionado == null)
                        {
                            sair = "sair";
                            break;
                        }
                        while (sairMascote != "sair")
                        {
                            var opcaoMascote = pokemonView.OpcoesAdotar(selecionado, _usuario);
                            switch (opcaoMascote)
                            {
                                case "1":
                                    await pokemonView.DetalhesPokemonAsync(selecionado.Name);
                                    break;
                                case "2": // adotar
                                    pokemonsAdotados.Add(new Pokemon { Name = selecionado.Name, Url = selecionado.Url });
                                    pokemonView.MensagemAdocao(selecionado);
                                    sairMascote = "sair";
                                    break;
                                case "3": //voltar
                                    sairMascote = "sair";
                                    break;
                                default:
                                    Console.WriteLine("Opção incorreta, digite novamente!!");
                                    break;
                            }
                        }
                        break;
                    case "2":
                        ListarAdotados(pokemonsAdotados);
                        break;
                    case "3":
                        sair = "sair";
                        break;
                    default:
                        Console.WriteLine("Opção Invalida, digite novamente!!");
                        break;
                }
            }
            return "Fim de Jogo";
        }

        public async Task<Pokemon> BuscarMascote()
        {
            try
            {
                Console.WriteLine("\n----------Adotar um Mascote-------------");
                Console.WriteLine($"{_usuario} - escolha um Pokemon:");

                List<Pokemon> pokemonsList = new List<Pokemon>();
                var listaPokemons = await pokemonService.GetAllPokemon();
                if (listaPokemons is null)
                {
                    throw new Exception("Erro: Falha no retorno da lista!!!");
                }
                int seq = 1;
                foreach (var item in listaPokemons.Results)
                {
                    Console.WriteLine($"{seq} - {item.Name}");
                    seq++;
                }

                Console.WriteLine("\nDigite o código de seu Pokemon");
                int idPokemon = int.Parse(Console.ReadLine());
                Pokemon pokemonSelecionado = new Pokemon();
                pokemonSelecionado.Name = listaPokemons.Results[idPokemon].Name;
                pokemonSelecionado.Url = listaPokemons.Results[idPokemon].Url;

                return pokemonSelecionado;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return null;
            }
        }


        public void ListarAdotados(List<Pokemon> lista)
        {
            if (lista.Count == 0)
            {
                Console.WriteLine("Não há nenhum Pokemon Adotado!!");
            }
            else
            {
                var seq = 0;
                Console.WriteLine("\nPokemons Adotados!!!");
                foreach (var item in lista)
                {
                    seq += 1;
                    Console.WriteLine($"{seq} - {item.Name}");
                }
            }
        }

    }
}

