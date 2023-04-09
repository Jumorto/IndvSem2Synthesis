using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Tournament
    {
        private int _id;
        public int ID { get { return _id; } set { _id = value; } }

        private string _sport;
        public string SportType { get { return _sport; } set { _sport = value; } }

        private string _name;
        public string TournamentName { get { return _name; } set { _name = value; } }

        private string _info;
        public string TournamentInfo { get { return _info; } set { _info = value; } }

        private DateTime _start;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime TournamentStart { get { return _start; } set { _start = value; } }

        private DateTime _end;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime TournamentEnd { get { return _end; } set { _end = value; } }

        private DateTime _regDeadline;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime RegisterDeadline { get { return _regDeadline; } set { _regDeadline = value; } }

        private string _location;
        public string TournamentLocation { get { return _location; } set { _location = value; } }

        private int _minPlayers;
        public int MinPlayers { get { return _minPlayers; } set { _minPlayers = value; } }

        private int _maxPlayers;
        public int MaxPlayers { get { return _maxPlayers; } set { _maxPlayers = value; } }

        private int _idGoldWinner;
        public int Gold { get { return _idGoldWinner; } set { _idGoldWinner = value; } }

        private string _nameGoldWinner;
        public string NameGoldWinner { get { return _nameGoldWinner; } set { _nameGoldWinner = value; } }

        private int _idSilverWinner;
        public int Silver { get { return _idSilverWinner; } set { _idSilverWinner = value; } }

        private string _nameSilverWinner;
        public string NameSilverWinner { get { return _nameSilverWinner; } set { _nameSilverWinner = value; } }

        private int _idBronzeWinner;
        public int Bronze { get { return _idBronzeWinner; } set { _idBronzeWinner = value; } }

        private string _nameBronzeWinner;
        public string NameBronzeWinner { get { return _nameBronzeWinner; } set { _nameBronzeWinner = value; } }

        public Tournament()
        {

        }
    }
}
