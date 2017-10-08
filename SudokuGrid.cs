using System;
using System.Collections.Generic;
using System.Linq;
using Algorithms.Grid;

namespace Algorithms.Sudoku
{
    class SudokuGrid : BaseGrid<SudokuCell>
    {
        private int subGridSize;
        private int[] possibleValues;
        private int[] possibleIndices;
        private int[] possibleSubGridIndices;

        public SudokuGrid(int sideLength)
            : base(sideLength, sideLength, (row, col) => new SudokuCell(row, col))
        {
            this.subGridSize = (int)Math.Floor(Math.Sqrt(sideLength));
            this.possibleValues = Enumerable.Range(1, sideLength).ToArray();
            this.possibleIndices = Enumerable.Range(0, sideLength).ToArray();
            this.possibleSubGridIndices = Enumerable.Range(0, subGridSize).ToArray();
        }

        public void SetGridValues(int[][] init)
        {
            if (init.Length != this.RowCount)
                throw new InvalidOperationException(String.Format("Expecting {0} rows but provided {1}", this.RowCount, init.Length));

            for (var i = 0; i < init.Length; i++)
            {
                var row = init[i];
                if (row.Length != this.ColCount)
                    throw new InvalidOperationException(String.Format("Expecting {0} columns in row {1} but provided {2}", this.ColCount, i, row.Length));

                for (var j = 0; j < row.Length; j++)
                {
                    var cell = this.GetCell(i, j);
                    var value = row[j];
                    if (value < 1 || value > 9)
                        cell.ClearValue();
                    else
                        cell.SetValue(value);
                }
            }
        }

        public int[][] GetGridValues()
        {
            return this.Get2DCellArray()
                .Select(row =>
                    row.Select(cell => cell.HasValue ? cell.Value : 0).ToArray()
                ).ToArray();
        }

        public void Solve()
        {
            var emptyCells = this.GetFlatCellArray()
                .Where(it => !it.HasValue)
                .OrderBy(it => this.GetValidValues(it.Row, it.Col).Length)
                .ToArray();

            RecursiveSolve(emptyCells, 0);
        }

        private bool RecursiveSolve(SudokuCell[] cells, int index)
        {
            if (index >= cells.Length)
                return true;

            var cell = cells[index];

            var possibilities = this.GetValidValues(cell.Row, cell.Col);
            foreach (var possibleValue in possibilities)
            {
                cell.SetValue(possibleValue);
                if (!RecursiveSolve(cells, index + 1))
                    cell.ClearValue();
                else
                    return true;
            }

            return false;
        }

        private int[] GetValidValues(int row, int col)
        {
            if (this.GetCell(row, col).HasValue)
                return new int[] { };

            var usedValuesMap = new Dictionary<int, bool>();

            foreach (var i in possibleIndices)
            {
                usedValuesMap[this.GetCell(row, i).Value] = true;
                usedValuesMap[this.GetCell(i, col).Value] = true;
            }

            var subGridUpperLeftCornerRow = row - row % subGridSize;
            var subGridUpperLeftCornerCol = col - col % subGridSize;
            foreach (var rowDelta in possibleSubGridIndices)
                foreach (var colDelta in possibleSubGridIndices)
                    usedValuesMap[this.GetCell(subGridUpperLeftCornerRow + rowDelta, subGridUpperLeftCornerCol + colDelta).Value] = true;

            return possibleValues
                .Where(it => !usedValuesMap.ContainsKey(it))
                .ToArray();
        }
    }
}
