using System;
using System.Collections.Generic;
using System.Text;

namespace BenjaminTrounsonTaMModel
{
    interface IGame
    {
        void WhatIsAt(int row, int column);
        void AddLevel(string CurrentLevelName, int LevelWidth, int LevelHeight, string LevelData);
        void MoveMinotaur();
        void MoveTheseus();
    }
}
