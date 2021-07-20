using FluentAssertions;
using GameOfLife;
using Xunit;

namespace GameOfLifeTests
{
    public class GameOfLifeTest
    {
        private GameofLifeDev gameoflife;
        const int rowMax = 3;
        const int columnMax = 3;
        Cell[,] board;

        public GameOfLifeTest()
        {
            gameoflife = new GameofLifeDev();
        }
        [Fact]
        public void TestUnderpopulationforCurrentCellLive_WithFewerThanTwoLiveofNeighboursDies()
        {
            Cell currentCell = new Cell() { cellPositionX = 0, cellPositionY = 0, isLive = true };

            Cell cellx0y0 = new Cell() { cellPositionX = 0, cellPositionY = 0, isLive = true };
            Cell cellx0y1 = new Cell() { cellPositionX = 0, cellPositionY = 1, isLive = false };
            Cell cellx0y2 = new Cell() { cellPositionX = 0, cellPositionY = 2, isLive = false };
            Cell cellx1y0 = new Cell() { cellPositionX = 1, cellPositionY = 0, isLive = false };
            Cell cellx1y1 = new Cell() { cellPositionX = 1, cellPositionY = 1, isLive = true };
            Cell cellx1y2 = new Cell() { cellPositionX = 1, cellPositionY = 2, isLive = true };
            Cell cellx2y0 = new Cell() { cellPositionX = 2, cellPositionY = 0, isLive = true };
            Cell cellx2y1 = new Cell() { cellPositionX = 2, cellPositionY = 1, isLive = true };
            Cell cellx2y2 = new Cell() { cellPositionX = 2, cellPositionY = 2, isLive = true };


            board = new Cell[rowMax, columnMax]
            {
             {cellx0y0, cellx0y1, cellx0y2},
             {cellx1y0, cellx1y1, cellx1y2},
             {cellx2y0, cellx2y1, cellx2y2}
            };

            gameoflife.IsCellALive(currentCell, board, rowMax, columnMax).Should().BeFalse();

        }


        [Fact]
        public void TestNextGenerationforCurrentCellLive_WithTw0LiveofNeighboursLive()
        {
            Cell currentCell = new Cell() { cellPositionX = 0, cellPositionY = 0, isLive = true };

            Cell cellx0y0 = new Cell() { cellPositionX = 0, cellPositionY = 0, isLive = true };
            Cell cellx0y1 = new Cell() { cellPositionX = 0, cellPositionY = 1, isLive = true };
            Cell cellx0y2 = new Cell() { cellPositionX = 0, cellPositionY = 2, isLive = false };
            Cell cellx1y0 = new Cell() { cellPositionX = 1, cellPositionY = 0, isLive = true };
            Cell cellx1y1 = new Cell() { cellPositionX = 1, cellPositionY = 1, isLive = false };
            Cell cellx1y2 = new Cell() { cellPositionX = 1, cellPositionY = 2, isLive = false };
            Cell cellx2y0 = new Cell() { cellPositionX = 2, cellPositionY = 0, isLive = false };
            Cell cellx2y1 = new Cell() { cellPositionX = 2, cellPositionY = 1, isLive = false };
            Cell cellx2y2 = new Cell() { cellPositionX = 2, cellPositionY = 2, isLive = false };

            board = new Cell[rowMax, columnMax]
            {
            {cellx0y0, cellx0y1, cellx0y2},
            {cellx1y0, cellx1y1, cellx1y2},
            {cellx2y0, cellx2y1, cellx2y2}
            };

            gameoflife.IsCellALive(currentCell, board, rowMax, columnMax).Should().BeTrue();

        }


        [Fact]
        public void TestNextGenerationforCurrentCellLive_WithThreeLiveofNeighboursLive()
        {
            Cell currentCell = new Cell() { cellPositionX = 0, cellPositionY = 0, isLive = true };

            Cell cellx0y0 = new Cell() { cellPositionX = 0, cellPositionY = 0, isLive = true };
            Cell cellx0y1 = new Cell() { cellPositionX = 0, cellPositionY = 1, isLive = true };
            Cell cellx0y2 = new Cell() { cellPositionX = 0, cellPositionY = 2, isLive = false };
            Cell cellx1y0 = new Cell() { cellPositionX = 1, cellPositionY = 0, isLive = true };
            Cell cellx1y1 = new Cell() { cellPositionX = 1, cellPositionY = 1, isLive = true };
            Cell cellx1y2 = new Cell() { cellPositionX = 1, cellPositionY = 2, isLive = false };
            Cell cellx2y0 = new Cell() { cellPositionX = 2, cellPositionY = 0, isLive = false };
            Cell cellx2y1 = new Cell() { cellPositionX = 2, cellPositionY = 1, isLive = false };
            Cell cellx2y2 = new Cell() { cellPositionX = 2, cellPositionY = 2, isLive = false };

            board = new Cell[rowMax, columnMax]
            {
          {cellx0y0, cellx0y1, cellx0y2},
          {cellx1y0, cellx1y1, cellx1y2},
          {cellx2y0, cellx2y1, cellx2y2}
            };

            gameoflife.IsCellALive(currentCell, board, rowMax, columnMax).Should().BeTrue();

        }


        [Fact]
        public void TestOverPopulationforCurrentCellLive_WithMoreThanThreeLiveofNeighboursDead()
        {
            Cell currentCell = new Cell() { cellPositionX = 1, cellPositionY = 1, isLive = true };

            Cell cellx0y0 = new Cell() { cellPositionX = 0, cellPositionY = 0, isLive = true };
            Cell cellx0y1 = new Cell() { cellPositionX = 0, cellPositionY = 1, isLive = true };
            Cell cellx0y2 = new Cell() { cellPositionX = 0, cellPositionY = 2, isLive = true };
            Cell cellx1y0 = new Cell() { cellPositionX = 1, cellPositionY = 0, isLive = true };
            Cell cellx1y1 = new Cell() { cellPositionX = 1, cellPositionY = 1, isLive = true };
            Cell cellx1y2 = new Cell() { cellPositionX = 1, cellPositionY = 2, isLive = true };
            Cell cellx2y0 = new Cell() { cellPositionX = 2, cellPositionY = 0, isLive = true };
            Cell cellx2y1 = new Cell() { cellPositionX = 2, cellPositionY = 1, isLive = true };
            Cell cellx2y2 = new Cell() { cellPositionX = 2, cellPositionY = 2, isLive = true };

            board = new Cell[rowMax, columnMax]
            {
          {cellx0y0, cellx0y1, cellx0y2},
          {cellx1y0, cellx1y1, cellx1y2},
          {cellx2y0, cellx2y1, cellx2y2}
            };

            gameoflife.IsCellALive(currentCell, board, rowMax, columnMax).Should().BeFalse();

        }


        [Fact]
        public void TestReproductionforCurrentCellDead_WithexactlyThreeLiveofNeighboursLive()
        {
            Cell currentCell = new Cell() { cellPositionX = 1, cellPositionY = 1, isLive = false };

            Cell cellx0y0 = new Cell() { cellPositionX = 0, cellPositionY = 0, isLive = false };
            Cell cellx0y1 = new Cell() { cellPositionX = 0, cellPositionY = 1, isLive = true };
            Cell cellx0y2 = new Cell() { cellPositionX = 0, cellPositionY = 2, isLive = false };
            Cell cellx1y0 = new Cell() { cellPositionX = 1, cellPositionY = 0, isLive = true };
            Cell cellx1y1 = new Cell() { cellPositionX = 1, cellPositionY = 1, isLive = false };
            Cell cellx1y2 = new Cell() { cellPositionX = 1, cellPositionY = 2, isLive = true };
            Cell cellx2y0 = new Cell() { cellPositionX = 2, cellPositionY = 0, isLive = false };
            Cell cellx2y1 = new Cell() { cellPositionX = 2, cellPositionY = 1, isLive = false };
            Cell cellx2y2 = new Cell() { cellPositionX = 2, cellPositionY = 2, isLive = false };

            board = new Cell[rowMax, columnMax]
            {
          {cellx0y0, cellx0y1, cellx0y2},
          {cellx1y0, cellx1y1, cellx1y2},
          {cellx2y0, cellx2y1, cellx2y2}
            };

            gameoflife.IsCellALive(currentCell, board, rowMax, columnMax).Should().BeTrue();

        }

        [Fact]
        public void TestFinalBoard_currentBoardandFinalBoardLengthshouldbeEqual()
        {
            Cell currentCell = new Cell() { cellPositionX = 0, cellPositionY = 0, isLive = true };

            Cell cellx0y0 = new Cell() { cellPositionX = 0, cellPositionY = 0, isLive = true };
            Cell cellx0y1 = new Cell() { cellPositionX = 0, cellPositionY = 1, isLive = true };
            Cell cellx0y2 = new Cell() { cellPositionX = 0, cellPositionY = 2, isLive = false };
            Cell cellx1y0 = new Cell() { cellPositionX = 1, cellPositionY = 0, isLive = true };
            Cell cellx1y1 = new Cell() { cellPositionX = 1, cellPositionY = 1, isLive = false };
            Cell cellx1y2 = new Cell() { cellPositionX = 1, cellPositionY = 2, isLive = false };
            Cell cellx2y0 = new Cell() { cellPositionX = 2, cellPositionY = 0, isLive = false };
            Cell cellx2y1 = new Cell() { cellPositionX = 2, cellPositionY = 1, isLive = false };
            Cell cellx2y2 = new Cell() { cellPositionX = 2, cellPositionY = 2, isLive = false };

            board = new Cell[rowMax, columnMax]
            {
          {cellx0y0, cellx0y1, cellx0y2},
          {cellx1y0, cellx1y1, cellx1y2},
          {cellx2y0, cellx2y1, cellx2y2}
            };

            gameoflife.GetUpdatedboard(currentCell, board, rowMax, columnMax).Length.Should().Be(board.Length);
        }

    }
}
