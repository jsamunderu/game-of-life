using System;

namespace question_2_conway_s_game_of_life
{
    public class Life
    {
        public struct Position
        {
            public int x;
            public int y;
        }
        enum Status : ulong { DEAD = 0, ALIVE = 1 };
        private const int PAGES_NO = 2;
        private Status[][,] pages;
        private ulong pageIndex; 

       public Life(ulong length, ulong width, Position[] population)
       {
            pages = new Status[PAGES_NO][,];
            pages[0] = new Status[length, width];
            pages[1] = new Status[length, width];
            pageIndex = 0;
            init(population);
        }

        private void init(Position[] population)
        {
            Status[,] current = currentPage();
            foreach (Position pos in population)
            {
                if (pos.y >= current.GetLength(0) || pos.y < 0
                    || pos.x >= current.GetLength(1) || pos.x < 0)
                {
                    continue;
                }
                current[pos.y, pos.x] = Status.ALIVE;
            }
        }

        private Status[,] currentPage()
        {
            return pages[pageIndex];
        }

        // alternative for nextPage() function is: pageIndex = (pageIndex + 1) % PAGES_NO;
        // or since the array is a power of 2, pageIndex = (pageIndex + 1) & (PAGES_NO - 1);
        // but just flip the bit on and off for page zero and page 1
        private Status[,] nextPage()
        {
            pageIndex ^= 1;
            return pages[pageIndex];
        }

        // Out of range neighboughs are assumed dead
        private Status getNeighbough(Status[,] page, int x, int y)
        {
            if (x >= page.GetLength(0) || x < 0)
            {
                return Status.DEAD;
            }
            if (y >= page.GetLength(1) || y < 0)
            {
                return Status.DEAD;
            }

            return page[x, y];
        }

        private ulong countNeighboughs(Status[,] page, int x, int y)
        {
            ulong north = (ulong)getNeighbough(page, x, y + 1);
            ulong south = (ulong)getNeighbough(page, x, y - 1);
            ulong east = (ulong)getNeighbough(page, x + 1, y);
            ulong west = (ulong)getNeighbough(page, x - 1, y);
            ulong northEast = (ulong)getNeighbough(page, x + 1, y + 1);
            ulong northWest = (ulong)getNeighbough(page, x - 1, y + 1);
            ulong southEast = (ulong)getNeighbough(page, x + 1, y - 1);
            ulong southWest = (ulong)getNeighbough(page, x - 1, y - 1);

            return north + south + east + west + northEast + northWest + southEast + southWest;
        }

        public void generation()
        {
            Status[,] current = currentPage();
            Status[,] next = nextPage();
            Array.Clear(next, 0, next.Length);
            for (int i = 0; i < current.GetLength(0); i++)
            {
                for (int j = 0; j < current.GetLength(1); j++)
                {
                    Status status = current[i, j];
                    ulong neighboughs = countNeighboughs(current, i, j);
                    if (status == Status.ALIVE)
                    {
                        if (neighboughs == 2 || neighboughs == 3)
                        {
                            next[i, j] = Status.ALIVE;
                        }
                        else
                        {
                            next[i, j] = Status.DEAD;
                        }
                    }
                    else
                    {
                        if (neighboughs == 3)
                        {
                            next[i, j] = Status.ALIVE;
                        }
                    }
                }
            }
        }

        public void printGeneration()
        {
            Status[,] current = currentPage();
            for (int i = 0; i < current.GetLength(0); i++)
            {
                for (int j = 0; j < current.GetLength(1); j++)
                {
                    if (current[i, j] == Status.ALIVE)
                    {
                        Console.Write("#");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
