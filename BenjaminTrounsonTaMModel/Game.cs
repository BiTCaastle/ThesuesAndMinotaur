using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BenjaminTrounsonTaMModel
{
    public class Game : IGame
    {
        public List<string> LevelNameList = new List<string>();
        List<Level> _Levels = new List<Level>();
        public int LevelWidth { get; set; }
        public int LevelHeight { get; set; }
        public int MoveCount { get; set; }
        public int LevelCount { get; set; }
        int TheseusRow { get; set; }
        int TheseusColumn { get; set; }
        int MinotaurRow { get; set; }
        int MinotaurColumn { get; set; }
        public string CurrentLevelName { get; set; } = "No levels loaded";
        public Square[,] level;
        public List<string> LevelNames()
        {
            return LevelNameList;
        }
        public void AddLevel(string newLevelName, int newLevelWidth, int newLevelHeight, string newData)
        {
            Level newLevel = new Level(newLevelName, newLevelWidth, newLevelHeight, newData);

            CurrentLevelName = newLevelName;
            LevelCount++;
            LevelNameList.Add(newLevelName);
            LevelWidth = newLevelWidth;
            LevelHeight = newLevelHeight;
            _Levels.Add(newLevel);

            LoadLevel(newLevel);
        }

        public void SetLevel(string name)
        {
            foreach (Level storedLevel in _Levels)
            {
                string levelName = storedLevel._levelName;
                if (levelName == name)
                {
                    LoadLevel(storedLevel);
                }
            }
        }

        public void LoadLevel(Level loadedLevel)
        {
            level = new Square[loadedLevel._levelHeight, loadedLevel._levelWidth];

            LevelWidth = loadedLevel._levelWidth;
            LevelHeight = loadedLevel._levelHeight;
            CurrentLevelName = loadedLevel._levelName;

            string[] squareData = loadedLevel._levelData.Split(' ');
            int wallIndex = 3;

            bool topValue = false;
            bool leftValue = false;
            bool bottomValue = false;
            bool rightValue = false;

            bool theseusValue = false;
            bool minotaurValue = false;
            bool exitValue = false;

            // Loads Level Data
            for (int i = 0; i < loadedLevel._levelHeight; i++)
            {
                for (int j = 0; j < loadedLevel._levelWidth; j++)
                {
                    // Calculating Wall Positions
                    var wallData = squareData[wallIndex];
                    int[] wallPosition = { Convert.ToInt32(wallData.Substring(0, 1)), Convert.ToInt32(wallData.Substring(1, 1)), Convert.ToInt32(wallData.Substring(2, 1)), Convert.ToInt32(wallData.Substring(3, 1)) };
                    // Convert the Integers in to true if 1 or false if 0
                    topValue = Convert.ToBoolean(wallPosition[0]);
                    rightValue = Convert.ToBoolean(wallPosition[1]);
                    bottomValue = Convert.ToBoolean(wallPosition[2]);
                    leftValue = Convert.ToBoolean(wallPosition[3]);
                    // Adds data to the Square Constructor 
                    level[i, j] = new Square(topValue, leftValue, bottomValue, rightValue, theseusValue, minotaurValue, exitValue);

                    wallIndex++;
                }
            }
            // Calculates the postition of the Minotaur
            int[] minotaurData = { Convert.ToInt32(loadedLevel._levelData.Substring(0, 2)), Convert.ToInt32(loadedLevel._levelData.Substring(2, 2)) };
            MinotaurRow = minotaurData[0];
            MinotaurColumn = minotaurData[1];
            // Calculates the postition of the Theseus
            int[] theseusData = { Convert.ToInt32(loadedLevel._levelData.Substring(5, 2)), Convert.ToInt32(loadedLevel._levelData.Substring(7, 2)) };
            TheseusRow = theseusData[0];
            TheseusColumn = theseusData[1];
            // Calculates the postition of the Exit
            int[] exitData = { Convert.ToInt32(loadedLevel._levelData.Substring(10, 2)), Convert.ToInt32(loadedLevel._levelData.Substring(12, 2)) };
            // Sets the Minotaur, Theseus and Exit Position
            WhatIsAt(TheseusRow, TheseusColumn).Theseus = true;
            WhatIsAt(MinotaurRow, MinotaurColumn).Minotaur = true;
            WhatIsAt(exitData[0], exitData[1]).Exit = true;
        }

        public void MoveMinotaur()
        {
            bool canMoveVertically = false;

            // Moving Horizontal
            if (MinotaurColumn > TheseusColumn)
            {
                if (!WhatIsAt(MinotaurRow, MinotaurColumn).Left && !WhatIsAt(MinotaurRow, MinotaurColumn - 1).Right)
                {
                    WhatIsAt(MinotaurRow, MinotaurColumn).Minotaur = false;
                    MinotaurColumn--;
                    WhatIsAt(MinotaurRow, MinotaurColumn).Minotaur = true;
                }
            }
            else if (MinotaurColumn < TheseusColumn)
            {
                if (!WhatIsAt(MinotaurRow, MinotaurColumn).Right && !WhatIsAt(MinotaurRow, MinotaurColumn + 1).Left)
                {
                    WhatIsAt(MinotaurRow, MinotaurColumn).Minotaur = false;
                    MinotaurColumn++;
                    WhatIsAt(MinotaurRow, MinotaurColumn).Minotaur = true;
                }
            }
            else
            {
                canMoveVertically = true;
            }

            // Moving Verically
            if (canMoveVertically)
            {
                if (MinotaurRow > TheseusRow)
                {
                    if (!WhatIsAt(MinotaurRow, MinotaurColumn).Top && !WhatIsAt(MinotaurRow - 1, MinotaurColumn).Bottom)
                    {
                        WhatIsAt(MinotaurRow, MinotaurColumn).Minotaur = false;
                        MinotaurRow--;
                        WhatIsAt(MinotaurRow, MinotaurColumn).Minotaur = true;
                    }
                }
            }
            else if (MinotaurRow < TheseusRow)
            {
                if (!WhatIsAt(MinotaurRow, MinotaurColumn).Bottom && !WhatIsAt(MinotaurRow + 1, MinotaurColumn).Top)
                {
                    WhatIsAt(MinotaurRow, MinotaurColumn).Minotaur = false;
                    MinotaurRow++;
                    WhatIsAt(MinotaurRow, MinotaurColumn).Minotaur = true;
                }
            }
        }

        public void MoveTheseus(Moves Dircetion)
        {
            switch (Dircetion)
            {
                case Moves.UP:
                    GoUp();
                    break;
                case Moves.DOWN:
                    GoDown();
                    break;
                case Moves.LEFT:
                    GoLeft();
                    break;
                case Moves.RIGHT:
                    GoRight();
                    break;
                case Moves.PAUSE:
                    Pause();
                    break;
                default:
                    break;
            }
        }

        public void GoUp()
        {
            if (!WhatIsAt(TheseusRow, TheseusColumn).Top && !WhatIsAt(TheseusRow - 1, TheseusColumn).Bottom)
            {
                WhatIsAt(TheseusRow, TheseusColumn).Theseus = false;
                TheseusRow--;
                WhatIsAt(TheseusRow, TheseusColumn).Theseus = true;

                MoveCount++;
            }
        }

        public void GoDown()
        {
            if (!WhatIsAt(TheseusRow, TheseusColumn).Bottom && !WhatIsAt(TheseusRow + 1, TheseusColumn).Top)
            {
                WhatIsAt(TheseusRow, TheseusColumn).Theseus = false;
                TheseusRow++;
                WhatIsAt(TheseusRow, TheseusColumn).Theseus = true;

                MoveCount++;
            }
        }

        public void GoLeft() 
        {
            if (!WhatIsAt(TheseusRow, TheseusColumn).Left && !WhatIsAt(TheseusRow, TheseusColumn - 1).Right)
            {
                WhatIsAt(TheseusRow, TheseusColumn).Theseus = false;
                TheseusColumn--;
                WhatIsAt(TheseusRow, TheseusColumn).Theseus = true;

                MoveCount++;
            }
        }

        public void GoRight() 
        {
            if (!WhatIsAt(TheseusRow, TheseusColumn).Right && !WhatIsAt(TheseusRow, TheseusColumn + 1).Left)
            {
                WhatIsAt(TheseusRow, TheseusColumn).Theseus = false;
                TheseusColumn++;
                WhatIsAt(TheseusRow, TheseusColumn).Theseus = true;

                MoveCount++;
            }
        }

        public void Pause() 
        {
            MoveCount++;
        }

        public Square WhatIsAt(int row, int column)
        {
            return level[row, column];
        }
        public bool HasMinotaurWon()
        {
            if (WhatIsAt(MinotaurRow, MinotaurColumn) == WhatIsAt(TheseusRow, TheseusColumn))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool HasTheseusWon()
        {
            if (WhatIsAt(TheseusRow, TheseusColumn).Theseus == WhatIsAt(TheseusRow, TheseusColumn).Exit)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

    }
}
