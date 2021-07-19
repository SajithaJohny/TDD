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
            int liveStateCount = 0;
            liveStateCount = getNeighbourCount(currentCell, board, rowMax, columnMax);

            switch (liveStateCount)
            {
                case 0:
                case 1:
                    currentCell.CellState = false;
                    return currentCell;
            }

            //Any live cell with less than two live neighbours dies, as if by underpopulation.
            if (currentCell.CellState && liveStateCount < 2)
            {
                currentCell.CellState = false;
                return currentCell;
            }
            //Any live cell with two or three live neighbours lives on to the next generation.
            else if ((currentCell.CellState) && (liveStateCount == 2 || liveStateCount == 3))
            {
                currentCell.CellState = true;
                return currentCell;
            }
            //Any live cell with more than three live neighbours dies, as if by overpopulation.
            else if ((currentCell.CellState) && (liveStateCount > 3))
            {
                currentCell.CellState = false;
                return currentCell;
            }
            //Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
            else if ((currentCell.CellState == false) && (liveStateCount == 3))
            {
                currentCell.CellState = true;
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
            int liveCount = 0;

            int x = currentCell.CellPositionX;
            int y = currentCell.CellPositionY;

            if (x < rowMax && y <= columnMax - 1)
            {
                if (board[x, y + 1].CellState == true)
                    liveCount++;
            }
            if (x < rowMax && y < columnMax)
            {
                if (board[x + 1, y].CellState == true)
                    liveCount++;
                if (board[x + 1, y + 1].CellState == true)
                    liveCount++;
            }
            if (x <= rowMax && y <= columnMax && y != 0)
            {
                if (board[x, y - 1].CellState == true)
                    liveCount++;
            }
            if (x < rowMax && y <= columnMax && y != 0)
            {
                if (board[x + 1, y - 1].CellState == true)
                    liveCount++;
            }
            if (x <= rowMax && y <= columnMax && y != 0 && x != 0)
            {
                if (board[x - 1, y - 1].CellState == true)
                    liveCount++;
            }
            if (x <= rowMax && y < columnMax && x != 0)
            {
                if (board[x - 1, y].CellState == true)
                    liveCount++;
            }
            if (x <= rowMax && y <= columnMax - 1 && x != 0)
            {
                if (board[x - 1, y + 1].CellState == true)
                    liveCount++;
            }

            return liveCount;
        }
    }
}
