using System;
using System.Collections.Generic;

namespace Chess
{
    public class Board
    {

        private const int MAX_ROW_SIZE = 8;
        private const int MAX_COLUMN_SIZE = 8;

        public readonly Square[,] squares = new Square[MAX_ROW_SIZE,MAX_COLUMN_SIZE];

        public Board()
        {
            for (int i = 0; i < MAX_ROW_SIZE; i++)
            {
                for (int j = 0; j < MAX_COLUMN_SIZE; j++)
                {
                    squares[i,j] = new Square(i, j);
                }
            }
        }

        public List<Square> GetAvailableMoves(Square startingSquare)
        {
            if (startingSquare.piece == null)
            {
                throw new Exception("Square must have a chess piece on it to get the available moves.");
            }

            List<Square> validPieceMoves = new List<Square>();

            for (int i = 0; i < MAX_ROW_SIZE; i++)
            {
                for (int j = 0; j < MAX_COLUMN_SIZE; j++)
                {
                    int destColumn = j;
                    int destRow = i;
                    int sourceColumn = startingSquare.column;
                    int sourceRow = startingSquare.row;

                    bool isNewSquareValid = startingSquare.piece.IsValidMove(sourceColumn, sourceRow, destColumn, destRow);

                    if (isNewSquareValid)
                    {
                        Square possibleSquare = new Square(destRow, destColumn);
                        validPieceMoves.Add(possibleSquare);
                    }
                }
            }

            return validPieceMoves;
        }

        public Square GetSquare(string chessNotation)
        {
            Square square = null;

            if (chessNotation.Length == 2)
            {
                char columnCoordinate = chessNotation[0];
                char rowCoordinate = chessNotation[1];

                if (int.TryParse(rowCoordinate.ToString(), out int row))
                {
                    row -= 1;
                }

                int asciiCharIndex = Convert.ToInt32(columnCoordinate);
                int column = asciiCharIndex - 65 - 32;

                bool isRowInBounds = row >= 0 && row < MAX_ROW_SIZE;
                bool isColumnInBounds = column >= 0 && column < MAX_COLUMN_SIZE;

                if (isRowInBounds && isColumnInBounds)
                {
                    square = squares[row, column];
                }
            }

            return square;
        }

        public static string ConvertToCSV(List<Square> squares)
        {
            string csvString = "";

            foreach (Square square in squares)
            {
                csvString += (square.GetDisplayCoordinates() + ",");
            }
            csvString = csvString.TrimEnd(',');

            return csvString;
        }
    }
}