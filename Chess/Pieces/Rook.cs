namespace Chess
{
    public class Rook : PieceBase
    {

        public Rook() : base(PieceType.ROOK)
        {

        }

        internal override bool IsValidMove(int sourceColumn, int sourceRow, int destColumn, int destRow)
        {
            bool isVerticalMove = this._IsVerticalMove(sourceColumn, sourceRow, destColumn, destRow);
            bool isHorizontalMove = this._IsHorizontalMove(sourceColumn, sourceRow, destColumn, destRow);
            bool isNotSameSquare = this._IsNotSameSquare(sourceColumn, sourceRow, destColumn, destRow);

            return (isVerticalMove || isHorizontalMove) && isNotSameSquare;
        }
    }
}
