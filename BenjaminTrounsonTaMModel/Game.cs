using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BenjaminTrounsonTaMModel
{
    public class Game : IGame
    {
        public List<string> Levels = new List<string>();
        List<string> LevelData = new List<string>();
        public int LevelWidth { get; set; }
        public int LevelHeight { get; set; }
        public int MoveCount { get; set; }
        public int LevelCount { get; set; }
        int TheseusRow { get; set; }
        int TheseusColumn { get; set; }
        int MinotaurRow { get; set; }
        int MinotaurColumn { get; set; }
        public string CurrentLevelName { get; set; } = "No levels loaded";
        public enum Moves { UP, DOWN, RIGHT, LEFT, PAUSE };
        public Square[,] level;
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
            LevelCount++;
            CurrentLevelName = LevelName;
            Level Level = new Level(LevelName, Width, Height, Data);
            //CurrentLevel = Level;
        }

        public void SetLevel(string name)
        {
            foreach (string Level in Levels)
            {
                if (Level == name)
                {
                    CurrentLevelName = name;
                }
            }
        }

        public void MoveMinotaur()
        { 
           
        }

        public void MoveTheseus(Moves moves)
        {
            if (moves == Moves.UP)
            {
                TheseusRow++;
                MoveCount++;
            }
            if (moves == Moves.DOWN)
            {
                TheseusRow--;
                MoveCount++;
            }
            if (moves == Moves.LEFT)
            {
                TheseusColumn--;
                MoveCount++;
            }
            if (moves == Moves.RIGHT)
            {
                TheseusColumn++;
                MoveCount++;
            }
            if (moves == Moves.PAUSE)
            {

            }
        }

        //public Square WhatIsAt(int row, int column)
        //{
        //    
        //}
    }
}
