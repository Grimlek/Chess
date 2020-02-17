using System;
using System.Collections.Generic;
using Chess;
using NUnit.Framework;

namespace ChessTests
{
    [TestFixture]
    public class BoardTests
    {

        private Board chessBoard = new Board();


        [Test]
        public void AllAvailableBishopMovesAreValid()
        {
            Square bishopStartSquare = new Square(3, 3, new Bishop());

            string expectedChessMoves = "a1,g1,b2,f2,c3,e3,c5,e5,b6,f6,a7,g7,h8";

            List<Square> availableChessMoves = chessBoard.GetAvailableMoves(bishopStartSquare);
            string availableChessMovesFound = Board.ConvertToCSV(availableChessMoves);

            Assert.IsFalse(availableChessMoves.Count == 0, "No available moves were found");
            Assert.AreEqual(availableChessMovesFound, expectedChessMoves, "Expected and found chess moves were not equal.");
        }

        [Test]
        public void AllAvailableRookMovesAreValid()
        {
            Square rookStartSquare = new Square(3, 3, new Rook());

            string expectedChessMoves = "d1,d2,d3,a4,b4,c4,e4,f4,g4,h4,d5,d6,d7,d8";

            List<Square> availableChessMoves = chessBoard.GetAvailableMoves(rookStartSquare);
            string availableChessMovesFound = Board.ConvertToCSV(availableChessMoves);

            Assert.IsFalse(availableChessMoves.Count == 0, "No available moves were found");
            Assert.AreEqual(availableChessMovesFound, expectedChessMoves, "Expected and found chess moves were not equal.");
        }

        [Test]
        public void AllAvailableQueenMovesAreValid()
        {
            Square queenStartSquare = new Square(3, 3, new Queen());

            string expectedChessMoves = "a1,d1,g1,b2,d2,f2,c3,d3,e3,a4,b4,c4,e4,f4,g4,h4,c5,d5,e5,b6,d6,f6,a7,d7,g7,d8,h8";

            List<Square> availableChessMoves = chessBoard.GetAvailableMoves(queenStartSquare);
            string availableChessMovesFound = Board.ConvertToCSV(availableChessMoves);

            Assert.IsFalse(availableChessMoves.Count == 0, "No available moves were found");
            Assert.AreEqual(availableChessMovesFound, expectedChessMoves, "Expected and found chess moves were not equal.");
        }

        [Test]
        public void AllAvailableKingMovesAreValid()
        {
            Square kingStartSquare = new Square(3, 3, new King());

            string expectedChessMoves = "c3,d3,e3,c4,e4,c5,d5,e5";

            List<Square> availableChessMoves = chessBoard.GetAvailableMoves(kingStartSquare);
            string availableChessMovesFound = Board.ConvertToCSV(availableChessMoves);

            Assert.IsFalse(availableChessMoves.Count == 0, "No available moves were found");
            Assert.AreEqual(availableChessMovesFound, expectedChessMoves, "Expected and found chess moves were not equal.");
        }

        [Test]
        public void StartingSquareHasNoChessPiece()
        {
            Square startingSquare = new Square(1, 0);

            Exception ex = Assert.Throws<Exception>(() => chessBoard.GetAvailableMoves(startingSquare));

            Assert.That(ex.Message == "Square must have a chess piece on it to get the available moves.");
        }

        [Test]
        public void GetSquareInvalid()
        {
            string chessNotation = "asdf";

            Square square = chessBoard.GetSquare(chessNotation);

            Assert.IsNull(square);
        }

        [Test]
        public void GetSquareIsValid()
        {
            string chessNotation = "d3";

            Square square = chessBoard.GetSquare(chessNotation);

            Assert.IsNotNull(square);
        }
    }
}