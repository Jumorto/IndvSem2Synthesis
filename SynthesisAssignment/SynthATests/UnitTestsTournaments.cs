using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Interfaces;
using System.Collections.Generic;
using System;

namespace SynthATests
{
    [TestClass]
    public class UnitTestsTournaments
    {
        [TestMethod]
        public void TestGetByID()
        {
            ITournamentRepo tr = new TournamentMockDB();
            Tournament testTournament = new Tournament();
            Tournament expectedTournament = new Tournament();
            testTournament = tr.GetByID(5);

            expectedTournament.ID = 5;
            expectedTournament.SportType = "Badminton";
            expectedTournament.TournamentName = "A" + 5;
            expectedTournament.TournamentInfo = "AAAAAAAA" + 5;
            expectedTournament.TournamentStart = DateTime.Now;
            expectedTournament.TournamentEnd = DateTime.Now;
            expectedTournament.RegisterDeadline = DateTime.Now;
            expectedTournament.TournamentLocation = "a" + 5;
            expectedTournament.MinPlayers = 5;
            expectedTournament.MaxPlayers = 10;
            expectedTournament.Gold = 1;
            expectedTournament.NameGoldWinner = "p1";
            expectedTournament.Silver = 2;
            expectedTournament.NameSilverWinner = "p2";
            expectedTournament.Bronze = 3;
            expectedTournament.NameBronzeWinner = "p3";

            Assert.AreEqual(testTournament.ID, expectedTournament.ID);
        }

        [TestMethod]
        public void TestAddTournament()
        {
            ITournamentRepo tr = new TournamentMockDB();
            Tournament testTournament = new Tournament();
            Tournament expectedTournament = new Tournament();

            testTournament.ID = 500;
            testTournament.SportType = "Badminton";
            testTournament.TournamentName = "A" + 5;
            testTournament.TournamentInfo = "AAAAAAAA" + 5;
            testTournament.TournamentStart = DateTime.Now;
            testTournament.TournamentEnd = DateTime.Now;
            testTournament.RegisterDeadline = DateTime.Now;
            testTournament.TournamentLocation = "a" + 5;
            testTournament.MinPlayers = 5;
            testTournament.MaxPlayers = 10;
            testTournament.Gold = 1;
            testTournament.NameGoldWinner = "p1";
            testTournament.Silver = 2;
            testTournament.NameSilverWinner = "p2";
            testTournament.Bronze = 3;
            testTournament.NameBronzeWinner = "p3";

            expectedTournament = tr.AddTournament(testTournament);

            Assert.AreEqual(testTournament.ID, expectedTournament.ID);
        }

        [TestMethod]
        public void TestEditTournament()
        {
            ITournamentRepo tr = new TournamentMockDB();
            Tournament testTournament = new Tournament();
            Tournament expectedTournament = new Tournament();
            testTournament.ID = 5;
            testTournament.SportType = "Badminton";
            testTournament.TournamentName = "A" + 5;
            testTournament.TournamentInfo = "AAAAAAAA" + 5;
            testTournament.TournamentStart = DateTime.Now;
            testTournament.TournamentEnd = DateTime.Now;
            testTournament.RegisterDeadline = DateTime.Now;
            testTournament.TournamentLocation = "a" + 5;
            testTournament.MinPlayers = 5;
            testTournament.MaxPlayers = 11;
            testTournament.Gold = 1;
            testTournament.NameGoldWinner = "p1";
            testTournament.Silver = 2;
            testTournament.NameSilverWinner = "p2";
            testTournament.Bronze = 3;
            testTournament.NameBronzeWinner = "p3";

            expectedTournament = tr.EditTournament(testTournament);

            Assert.AreEqual(testTournament.ID, expectedTournament.ID);
        }

        [TestMethod]
        public void TestDeleteTournament()
        {
            ITournamentRepo tr = new TournamentMockDB();
            int id = 5;

            bool expected = tr.DeleteTournament(id);
            Assert.IsTrue(expected);
        }

        [TestMethod]
        public void TestSearchListAllTournaments()
        {
            ITournamentRepo tr = new TournamentMockDB();
            int expectedSize = 1;
            List<Tournament> actual = tr.SearchListAllTournaments("A1", "a1", 1);

            Assert.AreEqual(expectedSize, actual.Count);
        }
    }
}
