using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class GameofLifeDev
    {
        static public void Main(String[] args)
        {

        }
        public Cell playBoardGame(Cell currentCell, Cell[,] board, int rowMax, int columnMax)
        {
            int liveStateCount = getNeighbourCount(currentCell, board, rowMax, columnMax);

            switch (liveStateCount)
            {
                case 0:
                case 1:
                    if (currentCell.CellState)
                        currentCell.CellState = false;
                    return currentCell;
                case 2:
                    if (currentCell.CellState)
                        currentCell.CellState = true;
                    return currentCell;
                case 3:
                    currentCell.CellState = true;
                    return currentCell;
                default:
                    if (currentCell.CellState)
                        currentCell.CellState = false;
                    return currentCell;
            }
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
            int liveCount = 0;

            int x = currentCell.CellPositionX;
            int y = currentCell.CellPositionY;
           

            for (var i = Math.Max(0, x - 1); i <= Math.Min(x + 1, rowMax); i++)
            {
                for (var j = Math.Max(0, y - 1); j <= Math.Min(y + 1, columnMax); j++)
                {
                    if (x != i || y != j)
                    {
                        if (board[i, j].CellState)
                            liveCount++;
                    }
                }
            }
            return liveCount;
        }
    }
}
