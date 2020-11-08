using System;
using System.Collections.Generic;
using System.Text;

namespace BenjaminTrounsonTaMModel
{
    public class Game : IGame
    {
        public List<string> Levels = new List<string> { };
        List<string> LevelData = new List<string>();
        public int LevelWidth { get; set; } = 0;
        public int LevelHeight { get; set; } = 0;
        int MoveCount { get; set; } = 0;
        public int LevelCount { get; set; } = 0;
        public string CurrentLevelName { get; set; } = "No levels loaded";
        enum Moves { UP, DOWN, RIGHT, LEFT, PAUSE };
        public List<string> LevelNames() 
        {
            return Levels;
        }
        public void AddLevel(string LevelName, int Width, int Height, string Data) 
        {
            Levels.Add(LevelName);
            LevelWidth = Width;
            LevelHeight = Height;
            LevelData.Add(Data);
            LevelCount ++;
            CurrentLevelName = LevelName;
        }

        public void MoveMinotaur()
        { 
            
        }

        public void MoveTheseus()
        { 
            
        }

        public void WhatIsAt(int row, int column)
        {

        }
    }
}
