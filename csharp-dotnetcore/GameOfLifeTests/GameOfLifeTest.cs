using FluentAssertions;
using GameOfLife;
using System.Collections.Generic;
using Xunit;

namespace GameOfLifeTests
{
    public class GameOfLifeTest
    {
        [Fact]
        public void testUnderpopulationforCurrentCellLive_WithFewerThanTwoLiveofNeighboursDies()
        {
            Cell currentCell = new Cell() { CellState = true, CellPositionX = 0, CellPositionY = 0 };

            Cell cellx0y0 = new Cell() { CellState = true, CellPositionX = 0, CellPositionY = 0 };
            Cell cellx0y1 = new Cell() { CellState = false, CellPositionX = 0, CellPositionY = 1 };
            Cell cellx0y2 = new Cell() { CellState = false, CellPositionX = 0, CellPositionY = 2 };
            Cell cellx1y0 = new Cell() { CellState = false, CellPositionX = 1, CellPositionY = 0 };
            Cell cellx1y1 = new Cell() { CellState = true, CellPositionX = 1, CellPositionY = 1 };
            Cell cellx1y2 = new Cell() { CellState = true, CellPositionX = 1, CellPositionY = 2 };
            Cell cellx2y0 = new Cell() { CellState = true, CellPositionX = 2, CellPositionY = 0 };
            Cell cellx2y1 = new Cell() { CellState = true, CellPositionX = 2, CellPositionY = 1 };
            Cell cellx2y2 = new Cell() { CellState = true, CellPositionX = 2, CellPositionY = 2 };

            const int rowMax = 3;
            const int columnMax = 3;

            Cell[,] board = new Cell[rowMax, columnMax]
            {
             {cellx0y0, cellx0y1, cellx0y2},
             {cellx1y0, cellx1y1, cellx1y2},
             {cellx2y0, cellx2y1, cellx2y2}
            };

            GameofLifeDev gameoflife = new GameofLifeDev();
            gameoflife.playBoardGame(currentCell, board, rowMax, columnMax).CellState.Should().BeFalse(); ;

        }

        [Fact]
        public void testNextGenerationforCurrentCellLive_WithTw0LiveofNeighboursLive()
        {
            Cell currentCell = new Cell() { CellState = true, CellPositionX = 0, CellPositionY = 0 };

            Cell cellx0y0 = new Cell() { CellState = true, CellPositionX = 0, CellPositionY = 0 };
            Cell cellx0y1 = new Cell() { CellState = true, CellPositionX = 0, CellPositionY = 1 };
            Cell cellx0y2 = new Cell() { CellState = false, CellPositionX = 0, CellPositionY = 2 };
            Cell cellx1y0 = new Cell() { CellState = true, CellPositionX = 1, CellPositionY = 0 };
            Cell cellx1y1 = new Cell() { CellState = false, CellPositionX = 1, CellPositionY = 1 };
            Cell cellx1y2 = new Cell() { CellState = false, CellPositionX = 1, CellPositionY = 2 };
            Cell cellx2y0 = new Cell() { CellState = false, CellPositionX = 2, CellPositionY = 0 };
            Cell cellx2y1 = new Cell() { CellState = false, CellPositionX = 2, CellPositionY = 1 };
            Cell cellx2y2 = new Cell() { CellState = false, CellPositionX = 2, CellPositionY = 2 };

            int rowMax = 3;
            int columnMax = 3;

            Cell[,] board = new Cell[3, 3]
            {
             {cellx0y0, cellx0y1, cellx0y2},
             {cellx1y0, cellx1y1, cellx1y2},
             {cellx2y0, cellx2y1, cellx2y2}
            };

            GameofLifeDev gameoflife = new GameofLifeDev();
            gameoflife.playBoardGame(currentCell, board, rowMax, columnMax).CellState.Should().Be(true);

        }


        [Fact]
        public void testNextGenerationforCurrentCellLive_WithThreeLiveofNeighboursLive()
        {
            Cell currentCell = new Cell() { CellState = true, CellPositionX = 0, CellPositionY = 0 };

            Cell cellx0y0 = new Cell() { CellState = true, CellPositionX = 0, CellPositionY = 0 };
            Cell cellx0y1 = new Cell() { CellState = true, CellPositionX = 0, CellPositionY = 1 };
            Cell cellx0y2 = new Cell() { CellState = false, CellPositionX = 0, CellPositionY = 2 };
            Cell cellx1y0 = new Cell() { CellState = true, CellPositionX = 1, CellPositionY = 0 };
            Cell cellx1y1 = new Cell() { CellState = true, CellPositionX = 1, CellPositionY = 1 };
            Cell cellx1y2 = new Cell() { CellState = false, CellPositionX = 1, CellPositionY = 2 };
            Cell cellx2y0 = new Cell() { CellState = false, CellPositionX = 2, CellPositionY = 0 };
            Cell cellx2y1 = new Cell() { CellState = false, CellPositionX = 2, CellPositionY = 1 };
            Cell cellx2y2 = new Cell() { CellState = false, CellPositionX = 2, CellPositionY = 2 };

            int rowMax = 3;
            int columnMax = 3;

            Cell[,] board = new Cell[3, 3]
            {
             {cellx0y0, cellx0y1, cellx0y2},
             {cellx1y0, cellx1y1, cellx1y2},
             {cellx2y0, cellx2y1, cellx2y2}
            };

            GameofLifeDev gameoflife = new GameofLifeDev();
            gameoflife.playBoardGame(currentCell, board, rowMax, columnMax).CellState.Should().Be(true);

        }


        [Fact]
        public void testOverPopulationforCurrentCellLive_WithMoreThanThreeLiveofNeighboursDead()
        {
            Cell currentCell = new Cell() { CellState = true, CellPositionX = 1, CellPositionY = 1 };

            Cell cellx0y0 = new Cell() { CellState = true, CellPositionX = 0, CellPositionY = 0 };
            Cell cellx0y1 = new Cell() { CellState = true, CellPositionX = 0, CellPositionY = 1 };
            Cell cellx0y2 = new Cell() { CellState = true, CellPositionX = 0, CellPositionY = 2 };
            Cell cellx1y0 = new Cell() { CellState = true, CellPositionX = 1, CellPositionY = 0 };
            Cell cellx1y1 = new Cell() { CellState = true, CellPositionX = 1, CellPositionY = 1 };
            Cell cellx1y2 = new Cell() { CellState = true, CellPositionX = 1, CellPositionY = 2 };
            Cell cellx2y0 = new Cell() { CellState = true, CellPositionX = 2, CellPositionY = 0 };
            Cell cellx2y1 = new Cell() { CellState = true, CellPositionX = 2, CellPositionY = 1 };
            Cell cellx2y2 = new Cell() { CellState = true, CellPositionX = 2, CellPositionY = 2 };

            int rowMax = 3;
            int columnMax = 3;

            Cell[,] board = new Cell[3, 3]
            {
             {cellx0y0, cellx0y1, cellx0y2},
             {cellx1y0, cellx1y1, cellx1y2},
             {cellx2y0, cellx2y1, cellx2y2}
            };

            GameofLifeDev gameoflife = new GameofLifeDev();
            gameoflife.playBoardGame(currentCell, board, rowMax, columnMax).CellState.Should().Be(false);

        }


        [Fact]
        public void testReproductionforCurrentCellDead_WithexactlyThreeLiveofNeighboursLive()
        {
            Cell currentCell = new Cell() { CellState = false, CellPositionX = 0, CellPositionY = 0 };

            Cell cellx0y0 = new Cell() { CellState = false, CellPositionX = 0, CellPositionY = 0 };
            Cell cellx0y1 = new Cell() { CellState = true, CellPositionX = 0, CellPositionY = 1 };
            Cell cellx0y2 = new Cell() { CellState = false, CellPositionX = 0, CellPositionY = 2 };
            Cell cellx1y0 = new Cell() { CellState = true, CellPositionX = 1, CellPositionY = 0 };
            Cell cellx1y1 = new Cell() { CellState = true, CellPositionX = 1, CellPositionY = 1 };
            Cell cellx1y2 = new Cell() { CellState = false, CellPositionX = 1, CellPositionY = 2 };
            Cell cellx2y0 = new Cell() { CellState = false, CellPositionX = 2, CellPositionY = 0 };
            Cell cellx2y1 = new Cell() { CellState = false, CellPositionX = 2, CellPositionY = 1 };
            Cell cellx2y2 = new Cell() { CellState = false, CellPositionX = 2, CellPositionY = 2 };

            int rowMax = 3;
            int columnMax = 3;

            Cell[,] board = new Cell[3, 3]
            {
             {cellx0y0, cellx0y1, cellx0y2},
             {cellx1y0, cellx1y1, cellx1y2},
             {cellx2y0, cellx2y1, cellx2y2}
            };

            GameofLifeDev gameoflife = new GameofLifeDev();
            gameoflife.playBoardGame(currentCell, board, rowMax, columnMax).CellState.Should().Be(true);

        }

        [Fact]
        public void testFinalBoard_currentBoardandFinalBoardLengthshouldbeEqual()
        {
            Cell currentCell = new Cell() { CellState = true, CellPositionX = 0, CellPositionY = 0 };

            Cell cellx0y0 = new Cell() { CellState = true, CellPositionX = 0, CellPositionY = 0 };
            Cell cellx0y1 = new Cell() { CellState = true, CellPositionX = 0, CellPositionY = 1 };
            Cell cellx0y2 = new Cell() { CellState = false, CellPositionX = 0, CellPositionY = 2 };
            Cell cellx1y0 = new Cell() { CellState = true, CellPositionX = 1, CellPositionY = 0 };
            Cell cellx1y1 = new Cell() { CellState = false, CellPositionX = 1, CellPositionY = 1 };
            Cell cellx1y2 = new Cell() { CellState = false, CellPositionX = 1, CellPositionY = 2 };
            Cell cellx2y0 = new Cell() { CellState = false, CellPositionX = 2, CellPositionY = 0 };
            Cell cellx2y1 = new Cell() { CellState = false, CellPositionX = 2, CellPositionY = 1 };
            Cell cellx2y2 = new Cell() { CellState = false, CellPositionX = 2, CellPositionY = 2 };

            int rowMax = 3;
            int columnMax = 3;

            Cell[,] board = new Cell[3, 3]
            {
             {cellx0y0, cellx0y1, cellx0y2},
             {cellx1y0, cellx1y1, cellx1y2},
             {cellx2y0, cellx2y1, cellx2y2}
            };

            GameofLifeDev gameoflife = new GameofLifeDev();
            gameoflife.getFinalboard(currentCell, board, rowMax, columnMax).Length.Should().Be(board.Length);
        }
    }
}
