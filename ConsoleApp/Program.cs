using System;
using System.Collections.Generic;
using Chess;

namespace ConsoleApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the chess console application!");
            Console.WriteLine();

            Console.WriteLine("The application will prompt for a chess piece, and a starting position to get ");
            Console.WriteLine("the possible moves of the chess piece.");
            Console.WriteLine();

            PieceBase chessPiece = Program._GetChessPieceFromUser();
            Console.WriteLine();

            Board chessBoard = new Board();

            Square startingSquare = Program._GetStartingSquareFromUser(chessBoard);
            startingSquare.piece = chessPiece;

            List<Square> availableMoves = chessBoard.GetAvailableMoves(startingSquare);

            string availableMovesOutput = Board.ConvertToCSV(availableMoves);

            Console.WriteLine();
            Console.WriteLine("Below are the available moves for the chosen chess piece and starting position.");
            Console.WriteLine(availableMovesOutput);
        }

        private static PieceBase _GetChessPieceFromUser()
        {
            while (1 == 1)
            {
                Console.WriteLine("The available chess pieces are Rook, Queen, Bishop, and King.\n");
                Console.WriteLine("Please enter the name of the chess piece.");

                string chessPieceInput = Console.ReadLine();

                PieceBase chessPiece = PieceFactory.CreateChessPiece(chessPieceInput);

                if (chessPiece == null)
                {
                    Console.WriteLine();
                    Console.WriteLine("Chess piece '" + chessPieceInput + "' is invalid. Please Try Again!");
                    Console.WriteLine();
                }
                else
                {
                    return chessPiece;
                }
            }
        }

        private static Square _GetStartingSquareFromUser(Board chessBoard)
        {
            while (1 == 1)
            {
                Console.WriteLine("Starting positions are in chess notation, a1, a2, b2, b3, etc.");
                Console.WriteLine("The board is a standard chess board with 8 rows and 8 columns.");
                Console.WriteLine();

                Console.WriteLine("Please enter the starting position for the chess piece.");

                string startPositionInput = Console.ReadLine();

                Square startingSquare = chessBoard.GetSquare(startPositionInput);

                if (startingSquare == null)
                {
                    Console.WriteLine();
                    Console.WriteLine("Starting position '" + startPositionInput + "' is invalid. Please Try Again!");
                    Console.WriteLine();
                }
                else
                {
                    return startingSquare;
                }
            }
        }
    }
}
