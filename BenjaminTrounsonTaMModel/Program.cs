using System;

namespace BenjaminTrounsonTaMModel
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game;
            game = new Game();

            game.AddLevel("RowRestrictedCentredMinotaurWithThesesusTopLeftIn7by7", 7, 7,
                             "0303 0000 0001"
                         + " 1001 1000 1000 1000 1000 1000 1100"
                         + " 0001 0000 0000 0000 0000 0000 0100"
                         + " 0001 0010 0010 0010 0010 0010 0100"
                         + " 0001 1010 1010 1010 1010 1010 0100"
                         + " 0001 1000 1000 1000 1000 1000 0100"
                         + " 0001 0000 0000 0000 0000 0000 0100"
                         + " 0011 0010 0010 0010 0010 0010 0110");
            game.MoveMinotaur();
            game.MoveMinotaur();
            bool expectedMinotaurAtOrigin = false;
            bool expectedMinotaurAtDestination = true;
            bool[] expected = { expectedMinotaurAtOrigin, expectedMinotaurAtDestination };
            bool acutualMinotaurAtOrigin = game.WhatIsAt(3, 3).Minotaur;
            bool actualMinotaurAtDestination = game.WhatIsAt(1, 3).Minotaur;
            bool[] actual = { acutualMinotaurAtOrigin, actualMinotaurAtDestination };

            Console.WriteLine("Actual:" + actual);
            Console.WriteLine("Actual Origin: " + acutualMinotaurAtOrigin);
            Console.WriteLine("Actual Destintation: " + actualMinotaurAtDestination);
            Console.ReadKey();
        }
    }
}
