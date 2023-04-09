using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Interfaces;
using BusinessLogicLayer;
using System.Collections.Generic;
using System;
using System.Data;

namespace SynthATests
{
    [TestClass]
    public class UnitTestsMatches
    {
        [TestMethod]
        public void TestGetByID()
        {
            //IMatchRepo m = new MatchMockDB();
            MatchLogic m = new MatchLogic(new MatchMockDB());
            Match testMatch = new Match();
            Match expectedMatch = new Match();
            testMatch = m.GetById(5);

            expectedMatch.ID = 5;

            Assert.AreEqual(expectedMatch.ID, testMatch.ID);
        }

        [TestMethod]
        public void TestGetByTournamentID()
        {
            MatchLogic mr = new MatchLogic(new MatchMockDB());
            List<Match> test = new List<Match>();

            test = mr.GetMatchesInTournamentWeb(1);

            Assert.AreEqual(10, test.Count);
        }

        [TestMethod]
        public void TestEditMatch()
        {
            MatchLogic mr = new MatchLogic(new MatchMockDB());
            Match expectedMatch = new Match();

            expectedMatch.ID = 1;

            Match testMatch = mr.UpdateMatch(expectedMatch);

            Assert.AreEqual(expectedMatch.ID, testMatch.ID);
        }

        [TestMethod]
        public void TestGetByPlayerID()
        {
            MatchLogic mr = new MatchLogic(new MatchMockDB());
            List<Match> testMatch = new List<Match>();
            testMatch = mr.GetMatchesByPlayerIDWeb(1);

            Assert.AreEqual(10, testMatch.Count);
        }

        [TestMethod]
        public void TestRoundRobinEven()
        {           
            MatchLogic mL = new MatchLogic();            
            List<int> players = new List<int>();
            int idTournament = 1;
            DateTime start = DateTime.Now;
            DateTime end = DateTime.Now.AddDays(5);            

            List<Match> test = new List<Match>();
            for (int i = 1; i <= 10; i++)
            {
                players.Add(i);
            }
            int round = players.Count - 1;
            int match = round * (players.Count / 2);
            test = mL.RoundRobinMatches(players, idTournament, start, end);

            Assert.AreEqual(match, test.Count);
        }

        [TestMethod]
        public void TestRoundRobinOdd()
        {
            MatchLogic mL = new MatchLogic();
            List<int> players = new List<int>();
            int idTournament = 1;
            DateTime start = DateTime.Now;
            DateTime end = DateTime.Now.AddDays(5);

            List<Match> test = new List<Match>();
            for (int i = 1; i < 10; i++)
            {
                players.Add(i);
            }
            int round = players.Count;
            int match = round * ((players.Count +1) / 2) - round;
            test = mL.RoundRobinMatches(players, idTournament, start, end);

            Assert.AreEqual(match, test.Count);
        }


        /*        [TestMethod]
        public void TestGetMatchWinners()
        {
            MatchLogic mr = new MatchLogic("", new MatchMockDB());
            List<Object[]> testWinners = new List<Object[]>();

            testWinners = mr.Get(1);
            Assert.AreEqual(10 , testWinners.Count);
        }
        
                [TestMethod]
        public void TestDetermineMatchWinner()
        {
            MatchLogic mr = new MatchLogic("", new MatchMockDB());
            List<Object[]> testWinner = mr.GoldSilverBronzeWinners(1);

            Assert.AreEqual(2, testWinner.Count);
        }
         
         
         
         */
    }
}
