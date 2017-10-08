namespace Algorithms.Sudoku
{
    public class SudokuSolver
    {
        public static int[][] GetSolution(int[][] values)
        {
            var board = new SudokuGrid(values.Length);
            board.SetGridValues(values);
            board.Solve();
            return board.GetGridValues();
        }
    }
}
