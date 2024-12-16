using System;
using System.Collections.Generic;

namespace Tamagotchi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            PokemonApiService service = new PokemonApiService();
            List<PokemonResult> especiesDisponiveis = service.ObterEspeciesDisponiveis();
            List<PokemonDetailsResult> mascotesAdotados = new List<PokemonDetailsResult>();

            menu.MostrarMensagemDeBoasVindas();

            while (true)
            {
                menu.MostrarMenuPrincipal();
                int escolha = menu.ObterEscolhaDoJogador();
                switch (escolha)
                {
                    case 1:
                        while (true)
                        {
                            menu.MostrarMenuDeAdocao();
                            escolha = menu.ObterEscolhaDoJogador();
                            switch (escolha)
                            {
                                case 1:
                                    menu.ObterEspeciesDisponiveis(especiesDisponiveis);
                                    break;

                                case 2:
                                    menu.ObterEspeciesDisponiveis(especiesDisponiveis);
                                    int indiceEspecie = menu.ObterEspecieEscolhida(especiesDisponiveis);
                                    PokemonDetailsResult detalhes = service.ObterDetalhesDaEspecie(especiesDisponiveis[indiceEspecie]);
                                    menu.ObterDetalhesDaEspecie(detalhes);
                                    break;

                                case 3:
                                    menu.ObterEspeciesDisponiveis(especiesDisponiveis);
                                    indiceEspecie = menu.ObterEspecieEscolhida(especiesDisponiveis);
                                    detalhes = service.ObterDetalhesDaEspecie(especiesDisponiveis[indiceEspecie]);
                                    menu.ObterDetalhesDaEspecie(detalhes);
                                    if (menu.ConfirmarAdocao())
                                    {
                                        mascotesAdotados.Add(detalhes);
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
                        menu.MostrarMascotesAdotados(mascotesAdotados);
                        break;

                    case 3:
                        Console.WriteLine("\nObrigado por jogar! até a próxima!");
                        return;
                }
            }
        }
    }
}
