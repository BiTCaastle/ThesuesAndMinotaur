using System;
using System.Collections.Generic;
using System.Text;

namespace BenjaminTrounsonTaMModel
{
    // Constructor to store Level Data
    public class Level
    {
        public string _levelName;
        public int _levelWidth;
        public int _levelHeight;
        public string _levelData;
        public Square[,] _levelSquare;

        public Level(string currentLevelName, int levelWidth, int levelHeight, string data)
        {
            _levelName = currentLevelName;
            _levelWidth = levelWidth;
            _levelHeight = levelHeight;
            _levelData = data;
            _levelSquare = new Square[levelWidth, levelHeight];
        }
    }
}
