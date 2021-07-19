using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class GameofLifeDev
    {
        List<Cell> neighbours = new List<Cell>();
        static public void Main(String[] args)
        {

        }
        public Cell[,] getUpdatedboard(Cell currentCell, Cell[,] board, int rowMax, int columnMax)
        {
            board[currentCell.CellPositionX, currentCell.CellPositionY].isLive = isCellALive(currentCell, board, rowMax, columnMax);
            return board;
        }
        public bool isCellALive(Cell currentCell, Cell[,] board, int rowMax, int columnMax)
        {
            bool loopConditionSkip = false;
            for (int x = 0; x <= rowMax; x++)
            {
                if (loopConditionSkip)
                    break;
                for (int y = 0; y <= columnMax; y++)
                {
                    //Find current cell match from array loop
                    if (currentCell.CellPositionX == x && currentCell.CellPositionY == y)
                    {
                        findNeighbours(rowMax, columnMax, x, y, board);
                        loopConditionSkip = true;
                        break;
                    }

                }
            }
            return checkIsCellALive(currentCell);
        }

        private bool checkIsCellALive(Cell currentCell)
        {
            int deadStateCount = 0;
            int liveStateCount = 0;

            deadStateCount = neighbours.Select(x => x.isLive == false).Count();
            liveStateCount = neighbours.Count - deadStateCount;

            switch (currentCell.isLive)
            {
                case true:
                    //Any live cell with less than two live neighbours dies, as if by underpopulation.
                    if (liveStateCount < 2)
                    {
                        currentCell.isLive = false;
                        return currentCell.isLive;
                    }
                    //Any live cell with two or three live neighbours lives on to the next generation.
                    else if (liveStateCount == 2 || liveStateCount == 3)
                    {
                        return currentCell.isLive;
                    }
                    //Any live cell with more than three live neighbours dies, as if by overpopulation.
                    else if (liveStateCount > 3)
                    {
                        currentCell.isLive = false;
                        return currentCell.isLive;
                    }
                    break;
                case false:
                    //Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
                    if (liveStateCount == 3)
                        return currentCell.isLive;
                    break;

            }
            return currentCell.isLive;
        }

        private void findNeighbours(int rowMax, int columnMax, int x, int y, Cell[,] board)
        {
            //Find neighbours of current cell
            if (x < rowMax)
            {
                if (y <= columnMax - 1)
                {
                    neighbours.Add((Cell)board.GetValue(x, y + 1));
                }
                if (y < columnMax)
                {
                    neighbours.Add((Cell)board.GetValue(x + 1, y));
                    neighbours.Add((Cell)board.GetValue(x + 1, y + 1));
                }
            }
            if (y != 0 && y <= columnMax)
            {
                if (x <= rowMax)
                {
                    neighbours.Add((Cell)board.GetValue(x, y - 1));
                }
                if (x < rowMax)
                {
                    neighbours.Add((Cell)board.GetValue(x + 1, y - 1));
                }
                if (x <= rowMax && x != 0)
                {
                    neighbours.Add((Cell)board.GetValue(x - 1, y - 1));
                }
            }
            if (x != 0 && x <= rowMax)
            {
                if (y < columnMax)
                {
                    neighbours.Add((Cell)board.GetValue(x - 1, y));
                }
                if (y <= columnMax - 1)
                {
                    neighbours.Add((Cell)board.GetValue(x - 1, y + 1));
                }
            }
        }
    }
}
