using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using BenjaminTrounsonTaMModel;

namespace BenjaminTrounsonTaMTests
{
    [TestClass]
    public class GameTests
    {
        Game game;

        public void MakeEmptyGame()
        {
            game = new Game();
        }
        [TestMethod, TestCategory("0Levels")]
        public void EmptyGameHasLevelCountOf0()
        {
            MakeEmptyGame();
            Assert.AreEqual(0, game.LevelCount);
        }
        [TestMethod, TestCategory("0Levels")]
        public void EmptyGameHasHeight0()
        {
            MakeEmptyGame();
            Assert.AreEqual(0, game.LevelHeight);
        }

        [TestMethod, TestCategory("0Levels")]
        public void EmptyGameHasWidth0()
        {
            MakeEmptyGame();
            Assert.AreEqual(0, game.LevelWidth);
        }

        [TestMethod, TestCategory("0Levels")]
        public void EmptyGameHasLevelNameOf_no_levels_loaded()
        {
            MakeEmptyGame();
            string expectedLevelName = "No levels loaded";
            string actualLevelName = game.CurrentLevelName;
            Assert.AreSame(expectedLevelName, actualLevelName);
        }

        [TestMethod, TestCategory("0Levels")]
        public void EmptyGameHasEmptyNamesList()
        {
            MakeEmptyGame();
            int actualNumberOfNames = game.LevelNames().Count;
            Assert.AreEqual(0, actualNumberOfNames);
        }
        void MakeGameWithOneLevel()
        {
            game = new Game();
            game.AddLevel("level 1", 3, 1, "0000 0001 0002 1011 1010 1110");
        }
        [TestMethod, TestCategory("1level")]
        public void GameWithOneLevelHasLevelCountOf1()
        {
            MakeGameWithOneLevel();
            Assert.AreEqual(1, game.LevelCount);
        }
        [TestMethod, TestCategory("1level")]
        public void GameWithOneLevelHasHeightOfLevel()
        {
            MakeGameWithOneLevel();
            Assert.AreEqual(1, game.LevelHeight);
        }
        [TestMethod, TestCategory("1level")]
        public void GameWithOneLevelHasWidthOfLevel()
        {
            MakeGameWithOneLevel();
            Assert.AreEqual(3, game.LevelWidth);
        }

        [TestMethod, TestCategory("1level")]
        public void GameWithOneLevelHasLevelName()
        {
            MakeGameWithOneLevel();
            string expectedLevelName = "level 1";
            string actuallevelName = game.CurrentLevelName;
            Assert.AreSame(expectedLevelName, actuallevelName);
        }
        [TestMethod, TestCategory("1level")]
        public void GameWithOneLevelHasSingleEntryNamesList()
        {
            MakeGameWithOneLevel();
            int actualNumberOfNames = game.LevelNames().Count;
            Assert.AreEqual(1, actualNumberOfNames);
        }
        void MakeGameWithThreeLevels()
        {
            game = new Game();
            game.AddLevel("level 1", 3, 1, "0000 0001 0002 1011 1010 1110");
            game.AddLevel("level 2", 3, 1, "0000 0001 0002 1011 1010 1110");
            game.AddLevel("level 3", 3, 1, "0000 0001 0002 1011 1010 1110");
        }

        [TestMethod, TestCategory("3levels")]
        public void GameWithThreeLevelsHasLevelCountOf3()
        {
            MakeGameWithThreeLevels();
            int expectedLevelCount = 3;
            int actualLevelCount = game.LevelCount;
            Assert.AreEqual(expectedLevelCount, actualLevelCount);
        }
        [TestMethod, TestCategory("3levels")]
        public void GameWithThreeLevelsHasHeightOfLastLevel()
        {
            MakeGameWithThreeLevels();
            Assert.AreEqual(1, game.LevelHeight);
        }

        [TestMethod, TestCategory("3levels")]
        public void GameWithThreeLevelsHasWidthOflastLevel()
        {
            MakeGameWithThreeLevels();
            Assert.AreEqual(3, game.LevelWidth);
        }

        [TestMethod, TestCategory("3levels")]
        public void GameWithThreeLevelsHasLastLevelName()
        {
            MakeGameWithThreeLevels();
            string expectedLevelName = "level 3";
            string actuallevelName = game.CurrentLevelName;
            Assert.AreSame(expectedLevelName, actuallevelName);
        }
        [TestMethod, TestCategory("3levels")]
        public void GameWithThreeLevelsHasThreeEntryNamesList()
        {
            MakeGameWithThreeLevels();
            int actualNumberOfNames = game.LevelNames().Count;
            Assert.AreEqual(3, actualNumberOfNames);
        }
        [TestMethod, TestCategory("3levels")]
        public void GameWithThreeLevelsHasCorrectNamesList()
        {
            MakeGameWithThreeLevels();
            List<string> actualNames = game.LevelNames();
            List<string> expectedNames = new List<string>();
            expectedNames.Add("level 1");
            expectedNames.Add("level 2");
            expectedNames.Add("level 3");
            CollectionAssert.AreEqual(expectedNames, actualNames);
        }
    }
}
