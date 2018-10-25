using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoardF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardF.Tests
{
    [TestClass()]
    public class GameTests
    {

        [TestMethod()]
        public void StartTest()
        {
            Game game = new Game(4);
            game.Start();
            Assert.AreEqual(1, game.GetDigitAt(0, 0));
            Assert.AreEqual(2, game.GetDigitAt(1, 0));
            Assert.AreEqual(5, game.GetDigitAt(0, 1));
            Assert.AreEqual(15, game.GetDigitAt(2, 3));
            Assert.AreEqual(0, game.GetDigitAt(3, 3));
        }

        [TestMethod()]
        public void PressAtTest()
        {
            //Проверка ходов
            Game game = new Game(4);
            game.Start();
            game.PressAt(2,3);
            Assert.AreEqual(0, game.GetDigitAt(2,3));
            Assert.AreEqual(15, game.GetDigitAt(3,3));
            game.PressAt(2, 2);
            Assert.AreEqual(0, game.GetDigitAt(2, 2));
            Assert.AreEqual(11, game.GetDigitAt(2, 3));
        }

        [TestMethod()]
        public void GetDigitAtTest()
        {
            //Проверка выхода за границы, не должно ломаться
            Game game = new Game(4);
            game.Start();
            Assert.AreEqual(0, game.GetDigitAt(-5, -34));
            Assert.AreEqual(0, game.GetDigitAt(15, 64));
        }

        [TestMethod()]
        public void SolvedTest()
        {
            Game game = new Game(4);
            game.Start();
            Assert.IsTrue(game.Solved());
            game.PressAt(2, 3);
            Assert.IsFalse(game.Solved());
            game.PressAt(3, 3);
            Assert.IsTrue(game.Solved());
        }
    }
}