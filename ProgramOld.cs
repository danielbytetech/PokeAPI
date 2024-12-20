using System;
using Newtonsoft.Json;
using RestSharp;
using Tamagotchi.Model;

namespace Tamagotchi
{
    internal class ProgramOld
    {
        public static void MainOld(string[] args)
        {
            //Obter a lista de especies de Pokémon
            var client = new RestClient("https://pokeapi.co/api/v2/pokemon-species/");
            var request = new RestRequest("", Method.Get);
            var response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var pokemonEspeciesResposta = JsonConvert.DeserializeObject<PokemonSpeciesResult>(response.Content);

                //Apresentar as opções ao jogador
                Console.WriteLine("Escolha um Tamagotchi:");
                for (int i = 0; i < pokemonEspeciesResposta.Results.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {pokemonEspeciesResposta.Results[i].Name}");
                }

                // Obter a escolha do jogador
                int escolha;

                while (true)
                {
                    Console.WriteLine("\n");
                    Console.Write("Escolha um número: ");
                    if (!int.TryParse(Console.ReadLine(), out escolha) && escolha >= 1 && escolha <= pokemonEspeciesResposta.Results.Count)
                    {
                        Console.WriteLine("Escolha inválida. Tente novamente.");
                    }
                    else
                    {
                        break;
                    }
                }

                //Obter as caracteriscas do Pokémon escolhido
                client = new RestClient($"https://pokeapi.co/api/v2/pokemon/{escolha}");
                request = new RestRequest("", Method.Get);
                response = client.Execute(request);

                var pokemonDetalhes = JsonConvert.DeserializeObject<PokemonDetailsResult>(response.Content);

                var pokemonEscolhido = pokemonEspeciesResposta.Results[escolha - 1];

                Console.WriteLine("\n");
                Console.WriteLine($"Você escolheu o {pokemonEscolhido.Name}");
                Console.WriteLine("Detalhes:");
                Console.WriteLine($"- Nome: {pokemonDetalhes.Name}");
                Console.WriteLine($"- Peso: {pokemonDetalhes.Weight}");
                Console.WriteLine($"- Altura: {pokemonDetalhes.Height}");

                Console.WriteLine("\n Habilidades do Mascote: ");

                foreach (var abilityDetail in pokemonDetalhes.Abilities)
                {
                    Console.WriteLine($"Nome da Habilidade: {abilityDetail.Ability.Name}");
                }
            }
            else
            {
                Console.WriteLine(response.ErrorMessage);
            }
            Console.ReadKey();

        }
    }
}
