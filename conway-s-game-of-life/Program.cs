using System;
using System.Collections.Generic;

namespace question_2_conway_s_game_of_life
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 3)
            {
                Console.WriteLine("Usage: question-2-conway-s-game-of-life.exe <length> <width> <generations>");
                return;
            }

            ulong length = 1, width = 1, generations = 0;
            try
            {
                length = ulong.Parse(args[0]);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.ToString());
            }
            try
            {
                width = ulong.Parse(args[1]);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.ToString());
            }
            try
            {
                generations = ulong.Parse(args[2]);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.ToString());
            }

            if (length == 0 || width == 0 || generations == 0)
            {
                return;
            }

            ulong max = length * width;
            Random rnd = new Random();
            int populationSize = rnd.Next(1, Convert.ToInt32(max + 1));
            List<Life.Position> list = new List<Life.Position>();
            for (int i = 0; i < populationSize; i++)
            {
                Life.Position pos = new Life.Position();
                pos.x = rnd.Next(0, Convert.ToInt32(length));
                pos.y = rnd.Next(0, Convert.ToInt32(width));
                list.Add(pos);
            }
            Life.Position[] population = list.ToArray();
            Life life = new Life(length, width, population);
            for (ulong i = 0; i < generations; i++)
            {
                life.generation();
                life.printGeneration();
            }
        }
    }
}
