using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using question_2_conway_s_game_of_life;
using System.IO;

namespace question_2_conway_s_game_of_life_test
{
    [TestClass]
    public class LifeTest
    {
        [TestMethod]
        public void StillLifeBlock()
        {
            Life.Position[] population = new Life.Position[]{
                new Life.Position(){ x= 1, y = 1 },
                new Life.Position(){ x = 1, y = 2 },
                new Life.Position(){ x = 2, y = 1 },
                new Life.Position(){ x = 2, y = 2 }
            };
            Life life = new Life(4, 4, population);
            life.generation();
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);
            life.printGeneration();
            string expected = string.Format("    {0} ## {0} ## {0}    {0}", Environment.NewLine);
            Assert.AreEqual<string>(expected, sw.ToString());
        }

        [TestMethod]
        public void OscillatorsBlinker()
        {
            Life.Position[] population = new Life.Position[]{
                new Life.Position(){ x= 2, y = 1 },
                new Life.Position(){ x = 2, y = 2 },
                new Life.Position(){ x = 2, y = 3 },
            };
            Life life = new Life(5, 5, population);
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);
            life.generation();
            life.printGeneration();
            string expected = string.Format("     {0}     {0} ### {0}     {0}     {0}", Environment.NewLine);
            Assert.AreEqual<string>(expected, sw.ToString());
            sw = new StringWriter();
            Console.SetOut(sw);
            life.generation();
            life.printGeneration();
            expected = string.Format("     {0}  #  {0}  #  {0}  #  {0}     {0}", Environment.NewLine);
            Assert.AreEqual<string>(expected, sw.ToString());
        }

        [TestMethod]
        public void SpaceShipsGlider()
        {
            Life.Position[] population = new Life.Position[]{
                new Life.Position(){ x= 2, y = 1 },
                new Life.Position(){ x = 3, y = 2 },
                new Life.Position(){ x = 1, y = 3 },
                new Life.Position(){ x = 2, y = 3 },
                new Life.Position(){ x = 3, y = 3 },
            };
            Life life = new Life(6, 6, population);
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);
            life.printGeneration();
            string expected = string.Format("      {0}  #   {0}   #  {0} ###  {0}      {0}      {0}", Environment.NewLine);
            Assert.AreEqual<string>(expected, sw.ToString());
            sw = new StringWriter();
            Console.SetOut(sw);
            life.generation();
            life.printGeneration();
            expected = string.Format("      {0}      {0} # #  {0}  ##  {0}  #   {0}      {0}", Environment.NewLine);
            Assert.AreEqual<string>(expected, sw.ToString());
            sw = new StringWriter();
            Console.SetOut(sw);
            life.generation();
            life.printGeneration();
            expected = string.Format("      {0}      {0}   #  {0} # #  {0}  ##  {0}      {0}", Environment.NewLine);
            Assert.AreEqual<string>(expected, sw.ToString());
            sw = new StringWriter();
            Console.SetOut(sw);
            life.generation();
            life.printGeneration();
            expected = string.Format("      {0}      {0}  #   {0}   ## {0}  ##  {0}      {0}", Environment.NewLine);
            Assert.AreEqual<string>(expected, sw.ToString());
            sw = new StringWriter();
            Console.SetOut(sw);
            life.generation();
            life.printGeneration();
            expected = string.Format("      {0}      {0}   #  {0}    # {0}  ### {0}      {0}", Environment.NewLine);
            Assert.AreEqual<string>(expected, sw.ToString());
        }
    }
}
