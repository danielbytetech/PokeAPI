using System;
using System.Collections.Generic;
using System.Linq;

namespace Tamagotchi.Model
{
    internal class TamagotchiDto
    {
        public int Alimentacao { get; private set; }
        public int Humor { get; private set; }
        public int Energia { get; private set; }
        public int Saude { get; private set; }
        public string Nome { get; set; }
        public int Tamanho { get; set; }
        public int Peso { get; set; }
        public List<Habilidade> Habilidades { get; set; }

        public TamagotchiDto()
        {
            var rand = new Random();
            Alimentacao = rand.Next(11);
            Humor = rand.Next(11);
            Energia = rand.Next(11);
            Saude = rand.Next(11);
        }

        public void AtualizarPropriedades(PokemonDetailsResult detalhes)
        {
            Nome = detalhes.Name;
            Tamanho = detalhes.Height;
            Peso = detalhes.Weight;
            Habilidades = detalhes.Abilities.Select(a => new Habilidade { Nome = a.Ability.Name}).ToList();
        }

        public void Alimentar()
        {
            Alimentacao = Math.Min(Alimentacao + 2, 10);
            Energia = Math.Max(Energia - 1, 0);

            Console.WriteLine("\nMascote Alimentado! ^_^");
        }

        public void Brincar()
        {
            Humor = Math.Min(Humor +  3, 10);
            Energia = Math.Max(Energia - 2, 0);
            Alimentacao = Math.Max(Alimentacao - 1, 0);

            Console.WriteLine("\nMascote Feliz! ^_^");
        }

        public void Descansar()
        {
            Energia = Math.Min(Energia + 4, 10);
            Humor = Math.Max(Humor + 4, 10);

            Console.WriteLine("\nMascote a Mimir! ^_^");
        }

        public void DarCarinho()
        {
            Humor = Math.Min(Humor + 2, 10);
            Saude = Math.Min(Saude + 1, 10);

            Console.WriteLine("\nMascote Amado! ^_^");
        }

        public void MostrarStatus()
        {
            Console.WriteLine("\nStatus do Mascote:");
            Console.WriteLine($"Alimentação: {Alimentacao}");
            Console.WriteLine($"Humor: {Humor}");
            Console.WriteLine($"Energia: {Energia}");
            Console.WriteLine($"Saúde: {Saude}");
        }
    }

    public class Habilidade
    {
        public string Nome { get; set; }
    }
}
