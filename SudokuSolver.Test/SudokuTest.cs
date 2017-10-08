using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Sudoku;

namespace AlgorithmsTest.Sudoku
{
    [TestClass]
    public class SudokuTest
    {
        [TestMethod]
        public void QuickPuzzle()
        {
            var testGrid = new int[9][] {
                new int[] { 0, 0, 1, 7, 6, 0, 0, 2, 3 },
                new int[] { 0, 8, 0, 0, 4, 0, 7, 9, 0 },
                new int[] { 5, 0, 0, 2, 0, 0, 0, 0, 1 },
                new int[] { 0, 0, 8, 0, 0, 7, 0, 0, 4 },
                new int[] { 0, 3, 4, 5, 0, 8, 1, 6, 0 },
                new int[] { 6, 0, 0, 3, 0, 0, 5, 0, 0 },
                new int[] { 3, 0, 0, 0, 0, 1, 0, 0, 2 },
                new int[] { 0, 1, 5, 0, 3, 0, 0, 7, 0 },
                new int[] { 7, 4, 0, 0, 5, 6, 3, 0, 0 }
            };

            var expectedSolutionGrid = new int[9][] {
                new int[] { 4, 9, 1, 7, 6, 5, 8, 2, 3 },
                new int[] { 2, 8, 6, 1, 4, 3, 7, 9, 5 },
                new int[] { 5, 7, 3, 2, 8, 9, 6, 4, 1 },
                new int[] { 1, 5, 8, 6, 9, 7, 2, 3, 4 },
                new int[] { 9, 3, 4, 5, 2, 8, 1, 6, 7 },
                new int[] { 6, 2, 7, 3, 1, 4, 5, 8, 9 },
                new int[] { 3, 6, 9, 8, 7, 1, 4, 5, 2 },
                new int[] { 8, 1, 5, 4, 3, 2, 9, 7, 6 },
                new int[] { 7, 4, 2, 9, 5, 6, 3, 1, 8 }
            };

            Test(testGrid, expectedSolutionGrid);
        }

        [Ignore]
        [TestMethod]
        public void SlowPuzzle()
        {
            var testGrid = new int[9][] {
                new int[] { 0, 0, 0, 0, 0, 0, 0, 1, 2 },
                new int[] { 0, 0, 0, 0, 3, 5, 0, 0, 0 },
                new int[] { 0, 0, 0, 6, 0, 0, 0, 7, 0 },
                new int[] { 7, 0, 0, 0, 0, 0, 3, 0, 0 },
                new int[] { 0, 0, 0, 4, 0, 0, 8, 0, 0 },
                new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 1, 2, 0, 0, 0, 0 },
                new int[] { 0, 8, 0, 0, 0, 0, 0, 4, 0 },
                new int[] { 0, 5, 0, 0, 0, 0, 6, 0, 0 }
            };

            var expectedSolutionGrid = new int[9][] {
                new int[] { 6, 7, 3, 8, 9, 4, 5, 1, 2 },
                new int[] { 9, 1, 2, 7, 3, 5, 4, 8, 6 },
                new int[] { 8, 4, 5, 6, 1, 2, 9, 7, 3 },
                new int[] { 7, 9, 8, 2, 6, 1, 3, 5, 4 },
                new int[] { 5, 2, 6, 4, 7, 3, 8, 9, 1 },
                new int[] { 1, 3, 4, 5, 8, 9, 2, 6, 7 },
                new int[] { 4, 6, 9, 1, 2, 8, 7, 3, 5 },
                new int[] { 2, 8, 7, 3, 5, 6, 1, 4, 9 },
                new int[] { 3, 5, 1, 9, 4, 7, 6, 2, 8 }
            };

            var solution = SudokuSolver.GetSolution(testGrid);

            foreach (var i in Enumerable.Range(0, Math.Max(testGrid.Length, expectedSolutionGrid.Length)))
                CollectionAssert.AreEqual(expectedSolutionGrid[i], solution[i]);
        }

        private void Test(int[][] testGrid, int[][] expectedSolutionGrid)
        {
            var solution = SudokuSolver.GetSolution(testGrid);

            foreach (var i in Enumerable.Range(0, Math.Max(testGrid.Length, expectedSolutionGrid.Length)))
                CollectionAssert.AreEqual(expectedSolutionGrid[i], solution[i]);
        }
    }
}
