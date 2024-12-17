using System;
using System.Collections.Generic;
using Tamagotchi.Model;

namespace Tamagotchi.View
{
    internal class TamagotchiView
    {
        public void MostrarMensagemDeBoasVindas()
        {
            Console.WriteLine(@"
▀▀█▀▀ ░█▀▀█ ▒█▀▄▀█ ░█▀▀█ ▒█▀▀█ ▒█▀▀▀█ ▀▀█▀▀ ▒█▀▀█ ▒█░▒█ ▀█▀ 
░▒█░░ ▒█▄▄█ ▒█▒█▒█ ▒█▄▄█ ▒█░▄▄ ▒█░░▒█ ░▒█░░ ▒█░░░ ▒█▀▀█ ▒█░ 
░▒█░░ ▒█░▒█ ▒█░░▒█ ▒█░▒█ ▒█▄▄█ ▒█▄▄▄█ ░▒█░░ ▒█▄▄█ ▒█░▒█ ▄█▄");

            Console.WriteLine("\nBem-vindo ao jogo de adoção de mascotes!");
            Console.Write("\nPor favor digite seu nome: ");
            string nomeUsuario = Console.ReadLine();
            Console.WriteLine($"Olá, {nomeUsuario}! Vamos começar!");

        }

        public void MostrarMenuPrincipal()
        {
            Console.WriteLine("\n--------------------- MENU ---------------------");
            Console.WriteLine("1 - Adotar Mascote Virtual");
            Console.WriteLine("2 - Ver seus Mascotes");
            Console.WriteLine("3 - Sair");
            Console.Write("Escolha uma Opção: ");
        }

        public int ObterEscolhaDoJogador()
        {
            int escolha;
            while (!int.TryParse(Console.ReadLine(), out escolha) || escolha < 1 || escolha > 4)
            {
                Console.Write("Escolha Invalida. Por favor, escolha uma opção entre 1 e 4: ");
            }
            return escolha;
        }

        public void MostrarMenuDeAdocao()
        {
            Console.WriteLine("\n--------------------- ADOÇÃO MASCOTE ---------------------");
            Console.WriteLine("1.  Ver Espécies Disponíveis");
            Console.WriteLine("2.  Ver Detalhes de uma Espécie");
            Console.WriteLine("3.  Adotar um Mascote");
            Console.WriteLine("4.  Voltar ao Menu Principal");
            Console.Write("Escolha uma opção: ");
        }

        public void ObterEspeciesDisponiveis(List<PokemonResult> especies)
        {
            Console.WriteLine("\n------------------------------------------");
            Console.WriteLine("Especies Disponiveis para a adoção:");
            for (int i = 0; i < especies.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {especies[i].Name}");
            }
        }

        public void ObterDetalhesDaEspecie(PokemonDetailsResult detalhes)
        {
            Console.WriteLine("\n------------------------------------------");
            Console.WriteLine("Detalhes da Espécie:");
            Console.WriteLine($"Nome: {detalhes.Name}");
            Console.WriteLine($"Altura: {detalhes.Height}");
            Console.WriteLine($"Peso: {detalhes.Weight}");
            Console.WriteLine("Habilidades:");
            foreach (var habilidade in detalhes.Abilities)
            {
                Console.WriteLine("-  " + habilidade.Ability.Name);
            }
        }

        public bool ConfirmarAdocao()
        {
            Console.WriteLine("\n------------------------------------------");
            Console.Write("Você deseja confirmar a adoção? (s/n): ");
            var resposta = Console.ReadLine();
            return resposta.ToLower() == "s";
        }

        public void MostrarMascotesAdotados(List<PokemonDetailsResult> mascotesAdotados)
        {
            Console.WriteLine("\n------------------------------------------");
            Console.WriteLine("Mascotes Adotados");
            if (mascotesAdotados.Count == 0)
            {
                Console.WriteLine("Você ainda não tem mascotes adotados");
            }
            else
            {
                for (int i = 0; i < mascotesAdotados.Count; i++)
                {
                    Console.WriteLine(i + 1 + ". " + mascotesAdotados[i].Name);
                }
            }
        }

        public int ObterEspecieEscolhida(List<PokemonResult> especies)
        {
            Console.WriteLine("\n------------------------------------------");
            int escolha;
            while (true)
            {
                Console.Write("Escolha uma espécie pelo número (1- " + especies.Count + "): ");
                if (int.TryParse(Console.ReadLine(), out escolha) && escolha >= 1 && escolha <= especies.Count)
                {
                    break;
                }
                Console.WriteLine("Escolha inválida.");
            }

            // Ajusta o indice baseado em 0
            return escolha - 1;
        }
    }
}
