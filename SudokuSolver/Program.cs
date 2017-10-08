using System;
using System.Linq;

namespace Algorithms.Sudoku
{
    class Program
    {
        static void Main(string[] args)
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

            var solution = SudokuSolver.GetSolution(testGrid);

            Console.WriteLine(GetDisplay(solution));

            Console.ReadLine();
        }

        private static string GetDisplay(int[][] grid)
        {
            var formatted = grid.Select((line, lineIndex) =>
            {
                var formattedLine = line.Select((value, valueIndex) =>
                    String.Format("{0}{1}", value, IsBoundaryIndex(valueIndex) ? "|" : " "));

                var separator = IsBoundaryIndex(lineIndex) ? String.Format("\n{0}", horizontalSeparator) : String.Empty;

                return String.Format("|{0}{1}", String.Join("", formattedLine), separator);
            });

            return String.Format("{0}\n{1}", horizontalSeparator, String.Join('\n', formatted));
        }

        private static bool IsBoundaryIndex(int index)
        {
            return index % 3 == 2;
        }

        private static readonly string horizontalSeparator = String.Format("{0}", new String('-', 19));
    }
}
