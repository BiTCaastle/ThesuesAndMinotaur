using System;
using System.Collections.Generic;
using System.Text;

namespace BenjaminTrounsonTaMModel
{
    public interface IGame
    {
        void AddLevel(string CurrentLevelName, int LevelWidth, int LevelHeight, string LevelData);
        List<string> LevelNames();
        void SetLevel(string name);
        void LoadLevel(Level loadedLevel);
        Square WhatIsAt(int row, int column);
        void MoveMinotaur();
        void MoveTheseus(Moves Direction);
        void GoUp();
        void GoLeft();
        void GoRight();
        void GoDown();
        void Pause();
        bool HasTheseusWon();
        bool HasMinotaurWon();

    }
}
