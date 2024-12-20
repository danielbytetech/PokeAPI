using Tamagotchi.Controller;

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
