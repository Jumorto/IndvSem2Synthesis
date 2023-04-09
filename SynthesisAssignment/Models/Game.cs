using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Game
    {
        private int _id;
        public int ID { get { return _id; } set { _id = value; } }

        private int _idMatch;
        public int IDMatch { get { return _idMatch; } set { _idMatch = value; } }

        private int _resultP1;
        public int ResultPlayer1 { get { return _resultP1; } set { _resultP1 = value; } }

        private int _resultP2;
        public int ResultPlayer2 { get { return _resultP2; } set { _resultP2 = value; } }

        private int _idWinner;
        public int IDWinner { get { return _idWinner; } set { _idWinner = value; } }


        public Game()
        {
            
        }
    }
}
