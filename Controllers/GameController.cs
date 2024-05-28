using Microsoft.AspNetCore.Mvc;
using TicTacToeGameAPI.Models;

namespace TicTacToegameAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private static TicTacToe _game = new TicTacToe();

        [HttpGet("board")]
        public ActionResult GetBoard()
        {
            return Ok(_game.Board.Cells);
        }

        [HttpPost("move")]
        public ActionResult MakeMove([FromQuery] int position)
        {
            int row = (position - 1) / 3;
            int col = (position - 1) % 3;
            if (_game.PlaceSymbol(row, col))
            {
                if (_game.Board.CheckWinner(_game.CurrentPlayer))
                {
                    return Ok(new { Message = $"Player {_game.CurrentPlayer} wins!" });
                }
                else if (_game.Board.IsBoardFull())
                {
                    return Ok(new { Message = "It's a draw!" });
                }
                else
                {
                    _game.SwitchPlayer();
                    return Ok(new { Message = "Move accepted", NextPlayer = _game.CurrentPlayer });
                }
            }
            else
            {
                return BadRequest("Invalid move. Try again.");
            }
        }

        [HttpPost("reset")]
        public ActionResult ResetGame()
        {
            _game = new TicTacToe();
            return Ok("Game has been reset.");
        }
    }
}



