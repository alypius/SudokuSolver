using System;
using System.Linq;
using Algorithms.Grid;

namespace Algorithms.Sudoku
{
    class SudokuCell : BaseCell
    {
        private bool _hasValue;
        private int _value;

        public bool HasValue { get { return this._hasValue; } }
        public int Value { get { return this._value; } }

        public SudokuCell(int row, int col) : base(row, col)
        {
            this.ClearValue();
        }

        public override char ToChar()
        {
            return this._hasValue
                ? this._value.ToString().ToCharArray().Single()
                : ' ';
        }

        public void SetValue(int value)
        {
            if (value < 1 || value > 9)
                throw new InvalidOperationException("Expecting number between 1 and 9");

            this._value = value;
            this._hasValue = true;
        }

        public void ClearValue()
        {
            this._hasValue = false;
            this._value = 0;
        }
    }
}
