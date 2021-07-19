using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class GameofLifeDev
    {
        static public void Main(String[] args)
        {

        }
        public Cell playGame(Cell currentCell, List<Cell> neigbourcells)
        {
            int deadStateCount = 0;

            foreach (Cell data in neigbourcells)
            {
                if (data.CellState == "Dead")
                {
                    deadStateCount++;
                }
            }
            if ((neigbourcells.Count - deadStateCount) < 2)
            {
                currentCell.CellState = "Dead";
                return currentCell;
            }
            else if ((neigbourcells.Count - deadStateCount) == 2 || (neigbourcells.Count - deadStateCount) == 3)
            {
                currentCell.CellState = "Live";
                return currentCell;
            }
            else if ((neigbourcells.Count - deadStateCount) > 3)
            {
                currentCell.CellState = "Dead";
                return currentCell;
            }
            return currentCell;
        }

        public Cell playBoardGame(Cell currentCell, Cell[,] board, int rowMax, int columnMax)
        {
            int liveStateCount = 0;
            liveStateCount = getNeighbourCount(currentCell, board, rowMax, columnMax);

            //Any live cell with less than two live neighbours dies, as if by underpopulation.
            if (currentCell.CellState == "Live" && liveStateCount < 2)
            {
                currentCell.CellState = "Dead";
                return currentCell;
            }
            //Any live cell with two or three live neighbours lives on to the next generation.
            else if ((currentCell.CellState == "Live") && (liveStateCount == 2 || liveStateCount == 3))
            {
                currentCell.CellState = "Live";
                return currentCell;
            }
            //Any live cell with more than three live neighbours dies, as if by overpopulation.
            else if ((currentCell.CellState == "Live") && (liveStateCount > 3))
            {
                currentCell.CellState = "Dead";
                return currentCell;
            }
            //Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
            else if ((currentCell.CellState == "Dead") && (liveStateCount == 3))
            {
                currentCell.CellState = "Live";
                return currentCell;
            }
            return currentCell;
        }

        public Cell[,] getFinalboard(Cell currentCell, Cell[,] board, int rowMax, int columnMax)
        {
            Cell changedCell = new Cell();
            changedCell = playBoardGame(currentCell, board, rowMax, columnMax);
            board[currentCell.CellPositionX, currentCell.CellPositionY].CellState = changedCell.CellState;
            return board;
        }

        private int getNeighbourCount(Cell currentCell, Cell[,] board, int rowMax, int columnMax)
        {
            bool loopConditionContinue = false;

            List<Cell> neighbours = new List<Cell>();

            for (int x = 0; x <= rowMax; x++)
            {
                if (loopConditionContinue)
                {
                    break;
                }
                for (int y = 0; y <= columnMax; y++)
                {
                    if (currentCell.CellPositionX == x && currentCell.CellPositionY == y)
                    {
                        if (x < rowMax && y <= columnMax - 1)
                        {
                            neighbours.Add(board[x, y + 1]);
                        }
                        if (x < rowMax && y < columnMax)
                        {
                            neighbours.Add(board[x + 1, y]);
                            neighbours.Add(board[x + 1, y + 1]);
                        }
                        if (x <= rowMax && y <= columnMax && y != 0)
                        {
                            neighbours.Add(board[x, y - 1]);
                        }
                        if (x < rowMax && y <= columnMax && y != 0)
                        {
                            neighbours.Add(board[x + 1, y - 1]);
                        }
                        if (x <= rowMax && y <= columnMax && y != 0 && x != 0)
                        {
                            neighbours.Add(board[x - 1, y - 1]);
                        }
                        if (x <= rowMax && y < columnMax && x != 0)
                        {
                            neighbours.Add(board[x - 1, y]);
                        }
                        if (x <= rowMax && y <= columnMax - 1 && x != 0)
                        {
                            neighbours.Add(board[x - 1, y + 1]);
                        }

                        loopConditionContinue = true;
                        break;
                    }
                }
            }

            int liveCount = 0;
            foreach(var n in neighbours)
            {
                if(n.CellState == "Live")
                {
                    liveCount++;
                }
            }
            return liveCount;
        }
    }
}
