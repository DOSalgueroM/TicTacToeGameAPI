using System;

namespace TicTacToeGameAPI.Models
{
    public class TicTacToe
    {
        public Board Board { get; private set; }
        public char CurrentPlayer { get; private set; }

        public TicTacToe()
        {
            Board = new Board();
            CurrentPlayer = 'X';
        }

        public bool PlaceSymbol(int row, int col)
        {
            return Board.PlaceSymbol(row, col, CurrentPlayer);
        }

        public void SwitchPlayer()
        {
            CurrentPlayer = (CurrentPlayer == 'X') ? 'O' : 'X';
        }
    }
}

