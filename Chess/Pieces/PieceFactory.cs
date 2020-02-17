namespace Chess
{
    public class PieceFactory
    {
        public static PieceBase CreateChessPiece(string chessPieceName)
        {
            PieceBase chessPiece = null;

            switch (chessPieceName.ToLower())
            {
                case "rook":
                    chessPiece = new Rook();
                    break;
                case "queen":
                    chessPiece = new Queen();
                    break;
                case "bishop":
                    chessPiece = new Bishop();
                    break;
                case "king":
                    chessPiece = new King();
                    break;
            }

            return chessPiece;
        }
    }
}
