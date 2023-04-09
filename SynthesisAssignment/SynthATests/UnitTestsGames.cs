using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Interfaces;
using System.Collections.Generic;

namespace SynthATests
{
    [TestClass]
    public class UnitTestsGames
    {
        [TestMethod]
        public void TestGetByID()
        {
            IGameRepo m = new GameMockDB();
            Game testGame = new Game();
            Game expectedGame = new Game();
            testGame = m.GetByID(5);

            expectedGame.ID = 5;
            expectedGame.IDMatch = 1;
            expectedGame.ResultPlayer1 = 21;
            expectedGame.ResultPlayer2 = 19;
            expectedGame.IDWinner = 1;

            Assert.AreEqual(testGame.ID, expectedGame.ID);
        }

        [TestMethod]
        public void TestGetByMatchID()
        {
            IGameRepo m = new GameMockDB();
            List<Game> testGames = new List<Game>();
            List<Game> expectedGames = new List<Game>();
            for (int i = 0; i < 10; i++)
            {
                Game g = new Game();
                g.ID = i;
                g.IDMatch = 1;
                g.ResultPlayer1 = 21;
                g.ResultPlayer2 = 19;
                g.IDWinner = 1;

                expectedGames.Add(g);
            }
            testGames = m.GetByMatchID(1);


            Assert.AreEqual(testGames.Count, expectedGames.Count);
        }

        [TestMethod]
        public void TestAddGame()
        {
            IGameRepo m = new GameMockDB();
            Game testGame = new Game();
            Game expectedGame = new Game();

            testGame.ID = 100;
            testGame.IDMatch = 1;
            testGame.ResultPlayer1 = 21;
            testGame.ResultPlayer2 = 19;
            testGame.IDWinner = 1;

            expectedGame = m.AddGame(testGame, 1);            

            Assert.AreEqual(testGame.ID, expectedGame.ID);

        }

        [TestMethod]
        public void TestEditGame()
        {
            IGameRepo m = new GameMockDB();
            Game editGame = new Game();
            editGame.ID = 1;
            editGame.IDMatch = 1;
            editGame.ResultPlayer1 = 21;
            editGame.ResultPlayer2 = 19;
            editGame.IDWinner = 1;

            Game expectedGame = m.EditGame(editGame, 1);

            Assert.AreEqual(expectedGame.ID, editGame.ID);

        }

        [TestMethod]
        public void TestDeleteGame()
        {
            IGameRepo m = new GameMockDB();
            int id = 5;

            bool expected = m.DeleteGame(id);
            Assert.IsTrue(expected);
        }
    }
}
