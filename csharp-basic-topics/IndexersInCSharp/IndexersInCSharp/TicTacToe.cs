namespace IndexersInCSharp
{
    public class TicTacToe
    {
        private const int _rowCount = 3;
        private const int _colCount = 3;
        private CellStatus[,] _patch = new CellStatus[_rowCount, _colCount];
        public CellStatus this[int row, int col]
        {
            get
            {
                if (row >= _rowCount || row < 0)
                    throw new ArgumentOutOfRangeException(nameof(row));
                if (col >= _colCount || col < 0)
                    throw new ArgumentOutOfRangeException(nameof(col));

                return _patch[row, col];
            }
            set
            {
                if (row >= _rowCount || row < 0)
                    throw new ArgumentOutOfRangeException(nameof(row));
                if (col >= _colCount || col < 0)
                    throw new ArgumentOutOfRangeException(nameof(col));
                if (!Enum.IsDefined(value))
                    return;
                if (value == CellStatus.Empty)
                    return;
                if (_patch[row, col] != CellStatus.Empty)
                    return;
                _patch[row, col] = value;
            }
        }

        private static (int, int) Convert(int cellNumber)
        {
            if(cellNumber <= 0)
                throw new ArgumentOutOfRangeException(nameof(cellNumber));

            return ((cellNumber - 1) / _rowCount, (cellNumber - 1) % _colCount);
        }

        public CellStatus this[int cellNumber]
        {
            get
            {
                var result = Convert(cellNumber);

                return this[result.Item1, result.Item2];
            }
            set
            {
                var result = Convert(cellNumber);
                this[result.Item1, result.Item2] = value;
            }
        }

        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < _rowCount; i++)
            {
                for (int j = 0; j < _colCount; j++)
                {
                    s += _patch[i, j].ToString();
                    s += "\t";
                }
                s += Environment.NewLine;
            }

            return s;
        }
    }

    public enum CellStatus
    {
        Empty,
        X,
        O
    }
}
