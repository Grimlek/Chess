using System;

namespace Chess
{
    public abstract class PieceBase
    {

        public readonly PieceType pieceType; 


        public PieceBase(PieceType pieceType)
        {
            this.pieceType = pieceType;
        }


        internal abstract bool IsValidMove(int sourceColumn, int sourceRow, int destColumn, int destRow);


        protected bool _IsDiagonalMove(int sourceColumn, int sourceRow, int destColumn, int destRow)
        {
            bool isDiagonalMove = Math.Abs(destColumn - sourceColumn) == Math.Abs(destRow - sourceRow);
            return isDiagonalMove;
        }

        protected bool _IsVerticalMove(int sourceColumn, int sourceRow, int destColumn, int destRow)
        {
            bool isVerticalMove = sourceColumn == destColumn && sourceRow != destRow;
            return isVerticalMove;
        }

        protected bool _IsHorizontalMove(int sourceColumn, int sourceRow, int destColumn, int destRow)
        {
            bool isHorizontalMove = sourceRow == destRow && sourceColumn != destColumn;
            return isHorizontalMove;
        }

        protected bool _IsNotSameSquare(int sourceColumn, int sourceRow, int destColumn, int destRow)
        {
            bool isNotSameSquare = sourceColumn != destColumn || sourceRow != destRow;
            return isNotSameSquare;
        }
    }
}
