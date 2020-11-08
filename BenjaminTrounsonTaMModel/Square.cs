using System;
using System.Collections.Generic;
using System.Text;

namespace BenjaminTrounsonTaMModel
{
    public class Square
    {
        public bool Minotaur { get; set; }
        public bool Theseus { get; set; }
        public bool Exit { get; set; }

        public bool Top;
        public bool Left;
        public bool Bottom;
        public bool Right;

        public Square(bool top, bool left, bool bottom, bool right, bool hasMinotaur, bool hasTheseus, bool isExit)
        {
            this.Top = top;
            this.Left = left;
            this.Bottom = bottom;
            this.Right = right;
            this.Minotaur = hasMinotaur;
            this.Theseus = hasTheseus;
            this.Exit = isExit;
        }
    }
}
