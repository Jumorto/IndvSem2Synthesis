using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class Match
    {
        private int _id;
        public int ID { get { return _id; } set { _id = value; } }

        private int _idTournament;
        public int IDTournament { get { return _idTournament; } set { _idTournament = value; } }        

        private DateTime _start;
        public DateTime MatchStart { get { return _start; } set { _start = value; } }

        private int _player1;
        public int Player1 { get { return _player1; } set { _player1 = value; } }

        private string _player1Name;
        public string Player1Name { get { return _player1Name; } set { _player1Name = value; } }

        private int _player2;
        public int Player2 { get { return _player2; } set { _player2 = value; } }

        private string _player2Name;
        public string Player2Name { get { return _player2Name; } set { _player2Name = value; } }

        private int _idWinner;
        public int IDWinner { get { return _idWinner; } set { _idWinner = value; } }

        private string _winnerName;
        public string WinnerName { get { return _winnerName; } set { _winnerName = value; } }

        public Match()
        {

        }
    }
}
