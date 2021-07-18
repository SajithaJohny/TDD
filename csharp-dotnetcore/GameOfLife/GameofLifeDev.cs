using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class GameofLifeDev
    {        
        static public void Main(String[] args)
        {

        }
        public Cell PlayGame(Cell currentCell,List<Cell> neigbourcells)
        {
            int deadStateCount = 0;
         
            foreach (Cell data in neigbourcells)
            {
                if(data.CellState == "Dead")
                {
                    deadStateCount ++;
                }
            }
            if((neigbourcells.Count - deadStateCount) < 2)
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

        public Cell PlayBoardGame(Cell currentCell, Cell[,] board,int rowMax,int columnMax)
        {

            List<Cell> neighbours = new List<Cell>();
            int deadStateCount = 0;
            int liveStateCount = 0;
            Cell neighbour = new Cell();
            bool loopConditionContinue= false;
            for (int x = 0; x <= rowMax; x++)
            {
                if(loopConditionContinue)
                {
                   break;
                }
                for (int y = 0; y <= columnMax; y++)
                {
                    if (currentCell.CellPositionX == x && currentCell.CellPositionY == y)
                    {
                        if (x < rowMax && y <= columnMax - 1)
                        {
                            neighbours.Add((Cell)board.GetValue(x, y + 1));
                        }
                        if (x < rowMax && y < columnMax)
                        {
                            neighbours.Add((Cell)board.GetValue(x + 1, y));
                            neighbours.Add((Cell)board.GetValue(x + 1, y + 1));
                        }
                        if (x <= rowMax && y <= columnMax && y != 0)
                        {
                            neighbours.Add((Cell)board.GetValue(x, y - 1));
                        }
                        if (x < rowMax && y <= columnMax && y != 0)
                        {
                            neighbours.Add((Cell)board.GetValue(x + 1, y - 1));
                        }
                        if (x <= rowMax && y <= columnMax && y != 0 && x != 0)
                        {
                            neighbours.Add((Cell)board.GetValue(x - 1, y - 1));
                        }
                        if (x <= rowMax && y < columnMax  && x != 0)
                        {
                            neighbours.Add((Cell)board.GetValue(x - 1, y));
                        }
                        if (x <= rowMax && y <= columnMax - 1 && x != 0)
                        {
                            neighbours.Add((Cell)board.GetValue(x - 1, y + 1));
                        }

                        loopConditionContinue = true;
                        break;
                    }


                }
            }

           
            foreach (Cell data in neighbours)
            {
                if (data.CellState == "Dead")
                {
                    deadStateCount++;
                }
            }

            liveStateCount = neighbours.Count - deadStateCount;

            //Any live cell with less than two live neighbours dies, as if by underpopulation.
            if (currentCell.CellState == "Live" && liveStateCount < 2)
            {
                currentCell.CellState = "Dead";
                return currentCell;
            }
            //Any live cell with two or three live neighbours lives on to the next generation.
            else if ((currentCell.CellState == "Live")  && (liveStateCount == 2 || liveStateCount == 3))
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
    }
}
