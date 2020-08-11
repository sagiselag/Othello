using System;
using System.Collections.Generic;
using System.Text;

namespace Othello
{
    internal class Board
    {
        private const bool v_m_IsComputer = true;
        private static int s_Columns, s_Rows;
        private static char[][] s_Board;
        private readonly char r_AvilableMoveSign;
        private readonly char r_EmptySign;        
        private Player m_FirstPlayer = new Player("Yellow", 'X', !v_m_IsComputer);
        private Player m_SecondPlayer;
        private Player m_CurrentPlayer;
        private bool m_Computer = true;

        public Board(int i_BoardSize, char i_AvilableMoveSign, char i_EmptySign, string PlayerType)
        {
            s_Rows = s_Columns = i_BoardSize;
            r_AvilableMoveSign = i_AvilableMoveSign;
            r_EmptySign = i_EmptySign;
            m_Computer = PlayerType == "Computer";
            m_SecondPlayer = new Player("Red", 'O', m_Computer);
            boardInitialized();
        }

        public Player CurrentPlayer
        {
            get
            {
                return m_CurrentPlayer;
            }

            set
            {
                m_CurrentPlayer = value;
            }
        }

        public Player FirstPlayer
        {
            get
            {
                return m_FirstPlayer;
            }
        }

        public Player SecondPlayer
        {
            get
            {
                return m_SecondPlayer;
            }
        }

        public bool TwoPlayers
        {
            get
            {
                return !m_Computer;
            }

            set
            {
                m_Computer = !value;
            }
        }

        public int Columns
        {
            get
            {
                return s_Columns;
            }
        }

        public int Rows
        {
            get
            {
                return s_Rows;
            }
        }

        public char[][] PlayBoard
        {
            get
            {
                return s_Board;
            }

            set
            {
                s_Board = value;
            }
        }

        public char AvilableMoveSign
        {
            get
            {
                return r_AvilableMoveSign;
            }
        }

        public char EmptySign
        {
            get
            {
                return r_EmptySign;
            }
        }

        private void boardInitialized()
        {
            int currentRow = 0, currentCol = 0;
            s_Board = new char[s_Rows][];

            for (currentRow = 0; currentRow < s_Rows; currentRow++)
            {
                s_Board[currentRow] = new char[s_Columns];
            }

            for (currentRow = 0; currentRow < s_Rows; currentRow++)
            {
                for (currentCol = 0; currentCol < s_Columns; currentCol++)
                {
                    s_Board[currentRow][currentCol] = r_EmptySign;
                }
            }

            s_Board[(s_Rows / 2) - 1][(s_Columns / 2) - 1] = 'O';
            s_Board[(s_Rows / 2) - 1][s_Columns / 2] = 'X';
            s_Board[s_Rows / 2][s_Columns / 2] = 'O';
            s_Board[s_Rows / 2][(s_Columns / 2) - 1] = 'X';
        }
    }
}
