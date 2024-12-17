using System;
using System.Collections.Generic;
using Tamagotchi.Controller;
using Tamagotchi.Model;
using Tamagotchi.Service;

namespace Tamagotchi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TamagotchiController controller = new TamagotchiController();
            controller.Jogar();
        }
    }
}
