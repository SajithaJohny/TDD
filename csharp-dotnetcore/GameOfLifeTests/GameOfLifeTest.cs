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
        Cell currentCell;
        Cell cellx0y0, cellx0y1, cellx0y2, cellx1y0, cellx1y1, cellx1y2, cellx2y0, cellx2y1, cellx2y2;

        public GameOfLifeTest()
        {
            gameoflife = new GameofLifeDev();
        }

        [Fact]
        public void TestUnderpopulationforCurrentCellLive_WithFewerThanTwoLiveofNeighboursDies()
        {
            currentCell = new Cell() { cellPositionX = 0, cellPositionY = 0, isLive = true };

            cellx0y0 = new Cell() {isLive = true };
            cellx0y1 = new Cell() {isLive = false };
            cellx0y2 = new Cell() {isLive = false };
            cellx1y0 = new Cell() {isLive = false };
            cellx1y1 = new Cell() {isLive = true };
            cellx1y2 = new Cell() {isLive = true };
            cellx2y0 = new Cell() {isLive = true };
            cellx2y1 = new Cell() {isLive = true };
            cellx2y2 = new Cell() {isLive = true };

            generateCurrentBoard();
            gameoflife.IsCellALive(currentCell, board, rowMax, columnMax).Should().BeFalse();
        }


        [Fact]
        public void TestNextGenerationforCurrentCellLive_WithTw0LiveofNeighboursLive()
        {
            currentCell = new Cell() { cellPositionX = 0, cellPositionY = 0, isLive = true };

            cellx0y0 = new Cell() {isLive = true };
            cellx0y1 = new Cell() {isLive = true };
            cellx0y2 = new Cell() {isLive = false };
            cellx1y0 = new Cell() {isLive = true };
            cellx1y1 = new Cell() {isLive = false };
            cellx1y2 = new Cell() {isLive = false };
            cellx2y0 = new Cell() {isLive = false };
            cellx2y1 = new Cell() {isLive = false };
            cellx2y2 = new Cell() {isLive = false };

            generateCurrentBoard();
            gameoflife.IsCellALive(currentCell, board, rowMax, columnMax).Should().BeTrue();
        }


        [Fact]
        public void TestNextGenerationforCurrentCellLive_WithThreeLiveofNeighboursLive()
        {
            currentCell = new Cell() { cellPositionX = 0, cellPositionY = 0, isLive = true };

            cellx0y0 = new Cell() {isLive = true };
            cellx0y1 = new Cell() {isLive = true };
            cellx0y2 = new Cell() {isLive = false };
            cellx1y0 = new Cell() {isLive = true };
            cellx1y1 = new Cell() {isLive = true };
            cellx1y2 = new Cell() {isLive = false };
            cellx2y0 = new Cell() {isLive = false };
            cellx2y1 = new Cell() {isLive = false };
            cellx2y2 = new Cell() {isLive = false };

            generateCurrentBoard();
            gameoflife.IsCellALive(currentCell, board, rowMax, columnMax).Should().BeTrue();
        }


        [Fact]
        public void TestOverPopulationforCurrentCellLive_WithMoreThanThreeLiveofNeighboursDead()
        {
            currentCell = new Cell() { cellPositionX = 1, cellPositionY = 1, isLive = true };

            cellx0y0 = new Cell() {isLive = true };
            cellx0y1 = new Cell() {isLive = true };
            cellx0y2 = new Cell() {isLive = true };
            cellx1y0 = new Cell() {isLive = true };
            cellx1y1 = new Cell() {isLive = true };
            cellx1y2 = new Cell() {isLive = true };
            cellx2y0 = new Cell() {isLive = true };
            cellx2y1 = new Cell() {isLive = true };
            cellx2y2 = new Cell() {isLive = true };

            generateCurrentBoard();
            gameoflife.IsCellALive(currentCell, board, rowMax, columnMax).Should().BeFalse();
        }


        [Fact]
        public void TestReproductionforCurrentCellDead_WithexactlyThreeLiveofNeighboursLive()
        {
            currentCell = new Cell() { cellPositionX = 1, cellPositionY = 1, isLive = false };

            cellx0y0 = new Cell() {isLive = false };
            cellx0y1 = new Cell() {isLive = true };
            cellx0y2 = new Cell() {isLive = false };
            cellx1y0 = new Cell() {isLive = true };
            cellx1y1 = new Cell() {isLive = false };
            cellx1y2 = new Cell() {isLive = true };
            cellx2y0 = new Cell() {isLive = false };
            cellx2y1 = new Cell() {isLive = false };
            cellx2y2 = new Cell() {isLive = false };

            generateCurrentBoard();
            gameoflife.IsCellALive(currentCell, board, rowMax, columnMax).Should().BeTrue();
        }

        [Fact]
        public void TestFinalBoard_currentBoardandFinalBoardLengthshouldbeEqual()
        {
            currentCell = new Cell() { cellPositionX = 0, cellPositionY = 0, isLive = true };

            cellx0y0 = new Cell() {isLive = true };
            cellx0y1 = new Cell() {isLive = true };
            cellx0y2 = new Cell() {isLive = false };
            cellx1y0 = new Cell() {isLive = true };
            cellx1y1 = new Cell() {isLive = false };
            cellx1y2 = new Cell() {isLive = false };
            cellx2y0 = new Cell() {isLive = false };
            cellx2y1 = new Cell() {isLive = false };
            cellx2y2 = new Cell() {isLive = false };

            generateCurrentBoard();
            gameoflife.GetUpdatedboard(currentCell, board, rowMax, columnMax).Length.Should().Be(board.Length);
        }

        private void generateCurrentBoard()
        {
            board = new Cell[rowMax, columnMax]
            {
              {cellx0y0, cellx0y1, cellx0y2},
              {cellx1y0, cellx1y1, cellx1y2},
              {cellx2y0, cellx2y1, cellx2y2}
            };
        }

    }
}
