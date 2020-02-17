using System;

namespace Chess
{
    public class Square
    {

        public readonly int row;
        public readonly int column;

        public PieceBase piece;


        public Square(int row, int column)
        {
            this.row = row;
            this.column = column;
        }

        public Square(int row, int column, PieceBase piece)
        {
            this.row = row;
            this.column = column;
            this.piece = piece;
        }

        public string GetDisplayCoordinates()
        {
            // 0 + 65 is the start of ascii uppercase characters
            // 65 + 32 is the start of ascii lowercase characters
            char columnCoordinate = Convert.ToChar(column + 65 + 32);

            // row is 0 based index so add 1
            int rowCoordinate = row + 1;

            return columnCoordinate + rowCoordinate.ToString();
        }
    }
}
