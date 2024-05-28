using System.Collections.Generic;

namespace TicTacToeGameAPI.Models
{
    public class Board
    {
        public List<List<char>> Cells { get; private set; }

        public Board()
        {
            Reset();
        }

        public void Reset()
        {
            Cells = new List<List<char>>()
            {
                new List<char> { ' ', ' ', ' ' },
                new List<char> { ' ', ' ', ' ' },
                new List<char> { ' ', ' ', ' ' }
            };
        }

        public bool PlaceSymbol(int row, int col, char symbol)
        {
            if (Cells[row][col] == ' ')
            {
                Cells[row][col] = symbol;
                return true;
            }
            return false;
        }

        public bool CheckWinner(char symbol)
        {
           
            for (int i = 0; i < 3; i++)
            {
                if (Cells[i][0] == symbol && Cells[i][1] == symbol && Cells[i][2] == symbol) return true; 
                if (Cells[0][i] == symbol && Cells[1][i] == symbol && Cells[2][i] == symbol) return true; 
            }
            if (Cells[0][0] == symbol && Cells[1][1] == symbol && Cells[2][2] == symbol) return true; 
            if (Cells[0][2] == symbol && Cells[1][1] == symbol && Cells[2][0] == symbol) return true; 
            return false;
        }

        public bool IsBoardFull()
        {
            foreach (var row in Cells)
            {
                foreach (var cell in row)
                {
                    if (cell == ' ') return false;
                }
            }
            return true;
        }
    }
}
