using System;
using System.Collections.Generic;
using Tamagotchi.Model;
using Tamagotchi.Service;
using Tamagotchi.View;

namespace Tamagotchi.Controller
{
    internal class TamagotchiController
    {
        private TamagotchiView Menu { get; set; }
        private PokemonApiService PokemonApiService { get; set; }
        private List<PokemonResult> EspeciesDisponiveis { get; set; }

        private List<PokemonDetailsResult> MascotesAdotados { get; set; }
        public TamagotchiController()
        {
            Menu = new TamagotchiView();
            PokemonApiService = new PokemonApiService();
            EspeciesDisponiveis = PokemonApiService.ObterEspeciesDisponiveis();
            MascotesAdotados = new List<PokemonDetailsResult>();
        }

        public void Jogar()
        {
            Menu.MostrarMensagemDeBoasVindas();

            while (true)
            {
                Menu.MostrarMenuPrincipal();
                int escolha = Menu.ObterEscolhaDoJogador();
                switch (escolha)
                {
                    case 1:
                        while (true)
                        {
                            Menu.MostrarMenuDeAdocao();
                            escolha = Menu.ObterEscolhaDoJogador();
                            switch (escolha)
                            {
                                case 1:
                                    Menu.ObterEspeciesDisponiveis(EspeciesDisponiveis);
                                    break;

                                case 2:
                                    Menu.ObterEspeciesDisponiveis(EspeciesDisponiveis);
                                    int indiceEspecie = Menu.ObterEspecieEscolhida(EspeciesDisponiveis);
                                    PokemonDetailsResult detalhes = PokemonApiService.ObterDetalhesDaEspecie(EspeciesDisponiveis[indiceEspecie]);
                                    Menu.ObterDetalhesDaEspecie(detalhes);
                                    break;

                                case 3:
                                    Menu.ObterEspeciesDisponiveis(EspeciesDisponiveis);
                                    indiceEspecie = Menu.ObterEspecieEscolhida(EspeciesDisponiveis);
                                    detalhes = PokemonApiService.ObterDetalhesDaEspecie(EspeciesDisponiveis[indiceEspecie]);
                                    Menu.ObterDetalhesDaEspecie(detalhes);
                                    if (Menu.ConfirmarAdocao())
                                    {
                                        MascotesAdotados.Add(detalhes);
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

                                case 4:
                                    break;
                            }
                            if (escolha == 4)
                            {
                                break;
                            }
                        }
                        break;

                    case 2:
                        Menu.MostrarMascotesAdotados(MascotesAdotados);
                        break;

                    case 3:
                        Console.WriteLine("\nObrigado por jogar! até a próxima!");
                        return;
                }
            }
        }
    }
}
