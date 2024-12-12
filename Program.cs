using RestSharp;
using System;

namespace PokeAPI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient("https://pokeapi.co/api/v2/pokemon/");
            var request = new RestRequest("", Method.Get);
            var reponse = client.Execute(request);

            if (reponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine(reponse.Content);
            }
            else
            {
                Console.WriteLine(reponse.ErrorMessage);
            }
            Console.ReadKey();

        }
    }
}
