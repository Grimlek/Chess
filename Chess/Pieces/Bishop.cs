namespace Chess
{
    public class Bishop : PieceBase
    {

        public Bishop() : base(PieceType.BISHOP)
        {

        }

        internal override bool IsValidMove(int sourceColumn, int sourceRow, int destColumn, int destRow)
        {
            bool isDiagonalMove = this._IsDiagonalMove(sourceColumn, sourceRow, destColumn, destRow);
            bool isNotSameSquare = this._IsNotSameSquare(sourceColumn, sourceRow, destColumn, destRow);

            return isDiagonalMove && isNotSameSquare;
        }
    }
}