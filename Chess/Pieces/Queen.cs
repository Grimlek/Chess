namespace Chess
{
    public class Queen : PieceBase
    {

        public Queen() : base(PieceType.QUEEN)
        {

        }

        internal override bool IsValidMove(int sourceColumn, int sourceRow, int destColumn, int destRow)
        {
            bool isDiagonalMove = this._IsDiagonalMove(sourceColumn, sourceRow, destColumn, destRow);
            bool isVerticalMove = this._IsVerticalMove(sourceColumn, sourceRow, destColumn, destRow);
            bool isHorizontalMove = this._IsHorizontalMove(sourceColumn, sourceRow, destColumn, destRow);

            bool isNotSameSquare = this._IsNotSameSquare(sourceColumn, sourceRow, destColumn, destRow);

            return (isDiagonalMove || isVerticalMove || isHorizontalMove) && isNotSameSquare;
        }
    }
}