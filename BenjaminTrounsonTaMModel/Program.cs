using System;

namespace BenjaminTrounsonTaMModel
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game;

            game = new Game();
            game.AddLevel("level 1", 3, 1, "0000 0001 0002 1011 1010 1110");
            game.AddLevel("level 2", 3, 1, "0000 0001 0002 1011 1010 1110");
            game.AddLevel("level 3", 3, 1, "0000 0001 0002 1011 1010 1110");
            game.SetLevel("level 2");
        }
    }
}
