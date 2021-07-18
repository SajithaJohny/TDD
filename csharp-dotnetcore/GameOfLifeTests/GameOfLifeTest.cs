using FluentAssertions;
using GameOfLife;
using System.Collections.Generic;
using Xunit;

namespace GameOfLifeTests
{
    public class GameOfLifeTest
    {
        [Fact]
        public void testUnderpopulation()
        {

            Cell currentCell = new Cell() { CellState = "Live" };
            Cell cell2 = new Cell() { CellState = "Live" };
            Cell cell3 = new Cell() { CellState = "Dead" };
            Cell cell4 = new Cell() { CellState = "Dead" };
            List<Cell> neighbours = new List<Cell>() { cell2, cell3, cell4 };
            GameofLifeDev gameoflife = new GameofLifeDev();
            gameoflife.PlayGame(currentCell, neighbours).CellState.Should().NotBe("Live");

        }

        [Fact]
        public void testNextGeneration_withneighbour2Live()
        {
            Cell currentCell = new Cell() { CellState = "Live" };
            Cell cell2 = new Cell() { CellState = "Dead" };
            Cell cell3 = new Cell() { CellState = "Live" };
            Cell cell4 = new Cell() { CellState = "Live" };
            List<Cell> neighbours = new List<Cell>() { cell2, cell3, cell4 };

            GameofLifeDev gameoflife = new GameofLifeDev();
            gameoflife.PlayGame(currentCell, neighbours).CellState.Should().Be("Live");

        }
        [Fact]
        public void testNextGeneration__withneighbour3Live()
        {
            Cell currentCell = new Cell() { CellState = "Live" };
            Cell cell2 = new Cell() { CellState = "Live" };
            Cell cell3 = new Cell() { CellState = "Live" };
            Cell cell4 = new Cell() { CellState = "Live" };
            List<Cell> neighbours = new List<Cell>() { cell2, cell3, cell4 };

            GameofLifeDev gameoflife = new GameofLifeDev();
            gameoflife.PlayGame(currentCell, neighbours).CellState.Should().Be("Live");

        }

        [Fact]
        public void testOverPopulation()
        {
            Cell currentCell = new Cell() { CellState = "Live" };
            Cell cell2 = new Cell() { CellState = "Live" };
            Cell cell3 = new Cell() { CellState = "Live" };
            Cell cell4 = new Cell() { CellState = "Live" };
            Cell cell5 = new Cell() { CellState = "Live" };
            List<Cell> neighbours = new List<Cell>() { cell2, cell3, cell4, cell5 };

            GameofLifeDev gameoflife = new GameofLifeDev();
            gameoflife.PlayGame(currentCell, neighbours).CellState.Should().Be("Dead");

        }

        [Fact]
        public void testReproduction()
        {
            Cell currentCell = new Cell() { CellState = "Dead" };
            Cell cell2 = new Cell() { CellState = "Live" };
            Cell cell3 = new Cell() { CellState = "Live" };
            Cell cell4 = new Cell() { CellState = "Live" };
            List<Cell> neighbours = new List<Cell>() { cell2, cell3, cell4 };

            GameofLifeDev gameoflife = new GameofLifeDev();
            gameoflife.PlayGame(currentCell, neighbours).CellState.Should().Be("Live");

        }
        [Fact]
        public void testUnderpopulationforCurrentCellLive_WithFewerThanTwoLiveofNeighboursDies()
        {
            Cell currentCell = new Cell() { CellState = "Live", CellPositionX = 0, CellPositionY = 0 };

            Cell cellx0y0 = new Cell() { CellState = "Live", CellPositionX = 0, CellPositionY = 0 };
            Cell cellx0y1 = new Cell() { CellState = "Dead", CellPositionX = 0, CellPositionY = 1 };
            Cell cellx0y2 = new Cell() { CellState = "Dead", CellPositionX = 0, CellPositionY = 2 };
            Cell cellx1y0 = new Cell() { CellState = "Dead", CellPositionX = 1, CellPositionY = 0 };
            Cell cellx1y1 = new Cell() { CellState = "Live", CellPositionX = 1, CellPositionY = 1 };
            Cell cellx1y2 = new Cell() { CellState = "Live", CellPositionX = 1, CellPositionY = 2 };
            Cell cellx2y0 = new Cell() { CellState = "Live", CellPositionX = 2, CellPositionY = 0 };
            Cell cellx2y1 = new Cell() { CellState = "Live", CellPositionX = 2, CellPositionY = 1 };
            Cell cellx2y2 = new Cell() { CellState = "Live", CellPositionX = 2, CellPositionY = 2 };

            int rowMax = 3;
            int columnMax = 3;

            Cell[,] board = new Cell[3, 3]
            {
             {cellx0y0, cellx0y1, cellx0y2},
             {cellx1y0, cellx1y1, cellx1y2},
             {cellx2y0, cellx2y1, cellx2y2}
            };

            GameofLifeDev gameoflife = new GameofLifeDev();
            gameoflife.PlayBoardGame(currentCell, board, rowMax, columnMax).CellState.Should().NotBe("Live"); ;

        }
       
        [Fact]
        public void testNextGenerationforCurrentCellLive_WithTw0LiveofNeighboursLive()
        {
            Cell currentCell = new Cell() { CellState = "Live", CellPositionX = 0, CellPositionY = 0 };

            Cell cellx0y0 = new Cell() { CellState = "Live", CellPositionX = 0, CellPositionY = 0 };
            Cell cellx0y1 = new Cell() { CellState = "Live", CellPositionX = 0, CellPositionY = 1 };
            Cell cellx0y2 = new Cell() { CellState = "Dead", CellPositionX = 0, CellPositionY = 2 };
            Cell cellx1y0 = new Cell() { CellState = "Live", CellPositionX = 1, CellPositionY = 0 };
            Cell cellx1y1 = new Cell() { CellState = "Dead", CellPositionX = 1, CellPositionY = 1 };
            Cell cellx1y2 = new Cell() { CellState = "Dead", CellPositionX = 1, CellPositionY = 2 };
            Cell cellx2y0 = new Cell() { CellState = "Dead", CellPositionX = 2, CellPositionY = 0 };
            Cell cellx2y1 = new Cell() { CellState = "Dead", CellPositionX = 2, CellPositionY = 1 };
            Cell cellx2y2 = new Cell() { CellState = "Dead", CellPositionX = 2, CellPositionY = 2 };

            int rowMax = 3;
            int columnMax = 3;

            Cell[,] board = new Cell[3, 3]
            {
             {cellx0y0, cellx0y1, cellx0y2},
             {cellx1y0, cellx1y1, cellx1y2},
             {cellx2y0, cellx2y1, cellx2y2}
            };

            GameofLifeDev gameoflife = new GameofLifeDev();
            gameoflife.PlayBoardGame(currentCell, board, rowMax, columnMax).CellState.Should().Be("Live"); 

        }


        [Fact]
        public void testNextGenerationforCurrentCellLive_WithThreeLiveofNeighboursLive()
        {
            Cell currentCell = new Cell() { CellState = "Live", CellPositionX = 0, CellPositionY = 0 };

            Cell cellx0y0 = new Cell() { CellState = "Live", CellPositionX = 0, CellPositionY = 0 };
            Cell cellx0y1 = new Cell() { CellState = "Live", CellPositionX = 0, CellPositionY = 1 };
            Cell cellx0y2 = new Cell() { CellState = "Dead", CellPositionX = 0, CellPositionY = 2 };
            Cell cellx1y0 = new Cell() { CellState = "Live", CellPositionX = 1, CellPositionY = 0 };
            Cell cellx1y1 = new Cell() { CellState = "Live", CellPositionX = 1, CellPositionY = 1 };
            Cell cellx1y2 = new Cell() { CellState = "Dead", CellPositionX = 1, CellPositionY = 2 };
            Cell cellx2y0 = new Cell() { CellState = "Dead", CellPositionX = 2, CellPositionY = 0 };
            Cell cellx2y1 = new Cell() { CellState = "Dead", CellPositionX = 2, CellPositionY = 1 };
            Cell cellx2y2 = new Cell() { CellState = "Dead", CellPositionX = 2, CellPositionY = 2 };

            int rowMax = 3;
            int columnMax = 3;

            Cell[,] board = new Cell[3, 3]
            {
             {cellx0y0, cellx0y1, cellx0y2},
             {cellx1y0, cellx1y1, cellx1y2},
             {cellx2y0, cellx2y1, cellx2y2}
            };

            GameofLifeDev gameoflife = new GameofLifeDev();
            gameoflife.PlayBoardGame(currentCell, board, rowMax, columnMax).CellState.Should().Be("Live");

        }

       
        [Fact]
        public void testOverPopulationforCurrentCellLive_WithMoreThanThreeLiveofNeighboursLive()
        {
            Cell currentCell = new Cell() { CellState = "Live", CellPositionX = 1, CellPositionY = 1 };

            Cell cellx0y0 = new Cell() { CellState = "Live", CellPositionX = 0, CellPositionY = 0 };
            Cell cellx0y1 = new Cell() { CellState = "Live", CellPositionX = 0, CellPositionY = 1 };
            Cell cellx0y2 = new Cell() { CellState = "Live", CellPositionX = 0, CellPositionY = 2 };
            Cell cellx1y0 = new Cell() { CellState = "Live", CellPositionX = 1, CellPositionY = 0 };
            Cell cellx1y1 = new Cell() { CellState = "Live", CellPositionX = 1, CellPositionY = 1 };
            Cell cellx1y2 = new Cell() { CellState = "Live", CellPositionX = 1, CellPositionY = 2 };
            Cell cellx2y0 = new Cell() { CellState = "Live", CellPositionX = 2, CellPositionY = 0 };
            Cell cellx2y1 = new Cell() { CellState = "Live", CellPositionX = 2, CellPositionY = 1 };
            Cell cellx2y2 = new Cell() { CellState = "Live", CellPositionX = 2, CellPositionY = 2 };

            int rowMax = 3;
            int columnMax = 3;

            Cell[,] board = new Cell[3, 3]
            {
             {cellx0y0, cellx0y1, cellx0y2},
             {cellx1y0, cellx1y1, cellx1y2},
             {cellx2y0, cellx2y1, cellx2y2}
            };

            GameofLifeDev gameoflife = new GameofLifeDev();
            gameoflife.PlayBoardGame(currentCell, board, rowMax, columnMax).CellState.Should().Be("Dead");

        }

        
        [Fact]
        public void testReproductionforCurrentCellDead_WithexactlyThreeLiveofNeighboursLive()
        {
            Cell currentCell = new Cell() { CellState = "Dead", CellPositionX = 0, CellPositionY = 0 };

            Cell cellx0y0 = new Cell() { CellState = "Dead", CellPositionX = 0, CellPositionY = 0 };
            Cell cellx0y1 = new Cell() { CellState = "Live", CellPositionX = 0, CellPositionY = 1 };
            Cell cellx0y2 = new Cell() { CellState = "Dead", CellPositionX = 0, CellPositionY = 2 };
            Cell cellx1y0 = new Cell() { CellState = "Live", CellPositionX = 1, CellPositionY = 0 };
            Cell cellx1y1 = new Cell() { CellState = "Live", CellPositionX = 1, CellPositionY = 1 };
            Cell cellx1y2 = new Cell() { CellState = "Dead", CellPositionX = 1, CellPositionY = 2 };
            Cell cellx2y0 = new Cell() { CellState = "Dead", CellPositionX = 2, CellPositionY = 0 };
            Cell cellx2y1 = new Cell() { CellState = "Dead", CellPositionX = 2, CellPositionY = 1 };
            Cell cellx2y2 = new Cell() { CellState = "Dead", CellPositionX = 2, CellPositionY = 2 };

            int rowMax = 3;
            int columnMax = 3;

            Cell[,] board = new Cell[3, 3]
            {
             {cellx0y0, cellx0y1, cellx0y2},
             {cellx1y0, cellx1y1, cellx1y2},
             {cellx2y0, cellx2y1, cellx2y2}
            };

            GameofLifeDev gameoflife = new GameofLifeDev();
            gameoflife.PlayBoardGame(currentCell, board, rowMax, columnMax).CellState.Should().Be("Live");

        }


    }
}
