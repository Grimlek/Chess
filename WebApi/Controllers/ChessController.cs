using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Chess;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ChessController : ControllerBase
    {

        /// <summary>
        ///     Get the available moves for a specific chess piece at a starting position.
        /// </summary>
        /// <remarks>
        ///     Sample Request:
        ///
        ///         GET /GetAvailableMoves/rook?startingPosition=d3
        ///         
        ///     Chess Pieces: rook, queen, king, and bishop<br/>
        ///     Starting Positions are in chess notation with the standard 8x8 chess board, ex. a3, b2, c4, h8
        /// </remarks>
        /// <param name="chessPieceName" in="path" required="true" type="string"></param> 
        /// <param name="startingPosition" in="query" required="true" type="string"></param> 
        /// <returns>Returns the available chess moves in CSV format.</returns>
        /// <response code="200">Successful operation</response>  
        /// <response code="400">If the starting position is invalid.</response>  
        /// <response code="404">If the chess piece is not found.</response>  
        [HttpGet("GetAvailableMoves/{chessPieceName}")]
        public IActionResult GetAvailableMoves(string chessPieceName, [Required] string startingPosition)
        {
            PieceBase chessPiece = PieceFactory.CreateChessPiece(chessPieceName);
            if (chessPiece == null)
            {
                return NotFound("Chess piece '" + chessPieceName + "' not found.");
            }

            Board chessBoard = new Board();

            Square startingSquare = chessBoard.GetSquare(startingPosition);
            if (startingSquare == null)
            {
                return BadRequest("Starting position was not found on the chess board.");
            }

            startingSquare.piece = chessPiece;

            List<Square> availableMoves = chessBoard.GetAvailableMoves(startingSquare);

            string availableMovesOutput = Board.ConvertToCSV(availableMoves);
            string json = "{ 'availableChessMoves': '" + availableMovesOutput + "' }";

            return Ok(json);
        }
    }
}
