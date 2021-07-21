using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class GameofLifeDev
    {
        static public void Main(String[] args)
        {

        }

        /// <summary>
        /// Play Game of Life
        /// </summary>
        /// <param name="currentCell"></param>
        /// <param name="board"></param>
        /// <param name="rowMax"></param>
        /// <param name="columnMax"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Find Neighbour
        /// </summary>
        /// <param name="currentCell"></param>
        /// <param name="board"></param>
        /// <param name="rowMax"></param>
        /// <param name="columnMax"></param>
        /// <returns></returns>
        private int getNeighbourCount(Cell currentCell, Cell[,] board, int rowMax, int columnMax)
        {
            int liveCount = 0;

            int x = currentCell.CellPositionX;
            int y = currentCell.CellPositionY;


            for (var i = (x == 0 ? 0 : x - 1); i <= (x == rowMax ? rowMax : x + 1); i++)
            {
                for (var j = (y == 0 ? 0 : y - 1); j <= (y == columnMax ? columnMax : y + 1); j++)
                {
                    if ((x != i || y != j) && board[i, j].CellState)
                        liveCount++;

                }
            }
            return liveCount;
        }





    }
}
