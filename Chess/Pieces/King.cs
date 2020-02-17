using System;

namespace Chess
{
    public class King : PieceBase
    {

        public King() : base(PieceType.KING)
        {

        }

        internal override bool IsValidMove(int sourceColumn, int sourceRow, int destColumn, int destRow)
        {
            bool isDiagonalMove = this._IsDiagonalMove(sourceColumn, sourceRow, destColumn, destRow);
            bool isVerticalMove = this._IsVerticalMove(sourceColumn, sourceRow, destColumn, destRow);
            bool isHorizontalMove = this._IsHorizontalMove(sourceColumn, sourceRow, destColumn, destRow);
            bool isNotSameSquare = this._IsNotSameSquare(sourceColumn, sourceRow, destColumn, destRow);

            bool isRowMoveOne = Math.Abs(sourceRow - destRow) == 1;
            bool isColumnMoveOne = Math.Abs(sourceColumn - destColumn) == 1;

            return (isDiagonalMove || isVerticalMove || isHorizontalMove)
                   && (isRowMoveOne || isColumnMoveOne)
                   && isNotSameSquare;
        }
    }
}
