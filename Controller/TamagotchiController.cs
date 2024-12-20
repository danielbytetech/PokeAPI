using System;
using System.Collections.Generic;
using Tamagotchi.Model;
using Tamagotchi.Service;
using Tamagotchi.View;

namespace Tamagotchi.Controller
{
    internal class TamagotchiController
    {
        private TamagotchiView TamagotchiView { get; set; }
        private PokemonApiService PokemonApiService { get; set; }
        private List<PokemonResult> EspeciesDisponiveis { get; set; }

        private List<TamagotchiDto> MascotesAdotados { get; set; }
        public TamagotchiController()
        {
            TamagotchiView = new TamagotchiView();
            PokemonApiService = new PokemonApiService();
            EspeciesDisponiveis = PokemonApiService.ObterEspeciesDisponiveis();
            MascotesAdotados = new List<TamagotchiDto>();
        }

        public void Jogar()
        {
            TamagotchiView.MostrarMensagemDeBoasVindas();

            while (true)
            {
                TamagotchiView.MostrarMenuPrincipal();
                int escolha = TamagotchiView.ObterEscolhaDoJogador(4);
                switch (escolha)
                {
                    case 1:
                        while (escolha != 4)
                        {
                            TamagotchiView.MostrarMenuDeAdocao();
                            escolha = TamagotchiView.ObterEscolhaDoJogador(3);
                            switch (escolha)
                            {
                                case 1:
                                    TamagotchiView.ObterEspeciesDisponiveis(EspeciesDisponiveis);
                                    break;

                                case 2:
                                    TamagotchiView.ObterEspeciesDisponiveis(EspeciesDisponiveis);
                                    int indiceEspecie = TamagotchiView.ObterEspecieEscolhida(EspeciesDisponiveis);
                                    PokemonDetailsResult detalhes = PokemonApiService.ObterDetalhesDaEspecie(EspeciesDisponiveis[indiceEspecie]);
                                    TamagotchiView.ObterDetalhesDaEspecie(detalhes);
                                    break;

                                case 3:
                                    TamagotchiView.ObterEspeciesDisponiveis(EspeciesDisponiveis);
                                    indiceEspecie = TamagotchiView.ObterEspecieEscolhida(EspeciesDisponiveis);
                                    detalhes = PokemonApiService.ObterDetalhesDaEspecie(EspeciesDisponiveis[indiceEspecie]);
                                    TamagotchiView.ObterDetalhesDaEspecie(detalhes);
                                    if (TamagotchiView.ConfirmarAdocao())
                                    {
                                        var tamagotchi = new TamagotchiDto();
                                        tamagotchi.AtualizarPropriedades(detalhes);
                                        MascotesAdotados.Add(tamagotchi);
                                        Console.WriteLine("Parabéns! Você adotou um " + detalhes.Name + "!");
                                        Console.WriteLine("──────────────");
                                        Console.WriteLine("────▄████▄────");
                                        Console.WriteLine("──▄████████▄──");
                                        Console.WriteLine("──██████████──");
                                        Console.WriteLine("──▀████████▀──");
                                        Console.WriteLine("─────▀██▀─────");
                                        Console.WriteLine("──────────────");
                                    }
                                    break;                                
                            }                            
                        }
                        break;

                    case 2:
                        if(MascotesAdotados.Count == 0)
                        {
                            Console.WriteLine("Você não tem nenhum Mascote adotado.");
                            break;
                        }

                        Console.WriteLine("Escolha um Mascote para interagir:");
                        for (int i = 0; i < MascotesAdotados.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {MascotesAdotados[i].Nome}");
                        }

                        int indiceEscolhido = TamagotchiView.ObterEscolhaDoJogador(MascotesAdotados.Count);
                        TamagotchiDto tamagotchiEscolhido = MascotesAdotados[indiceEscolhido - 1];

                        int opcaoInteracao = 0;
                        while (opcaoInteracao != 6)
                        {
                            TamagotchiView.MostrarMenuInteracao();
                            opcaoInteracao = TamagotchiView.ObterEscolhaDoJogador(5);

                            switch (opcaoInteracao)
                            {
                                case 1:
                                    tamagotchiEscolhido.MostrarStatus();
                                    break;
                                case 2:
                                    tamagotchiEscolhido.Alimentar();
                                    break;
                                case 3:
                                    tamagotchiEscolhido.Brincar();
                                    break;
                                case 4:
                                    tamagotchiEscolhido.Descansar();
                                    break;
                                case 5:
                                    tamagotchiEscolhido.DarCarinho();
                                    break;                                
                            }                            
                        }
                        break;

                    case 3:
                        TamagotchiView.MostrarMascotesAdotados(MascotesAdotados);
                        break;

                    case 4:
                        Console.WriteLine("\nObrigado por jogar! até a próxima!");
                        return;
                }
            }
        }
    }
}
