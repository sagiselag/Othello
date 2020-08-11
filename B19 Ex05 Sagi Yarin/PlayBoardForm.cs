using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Othello
{
    internal partial class PlayBoardForm : Form
    {
        private Board s_Board;

        public PlayBoardForm(Board i_board)
        {
            InitializeComponent(i_board);
        }

        private void buttonPlayTurn_Click(object sender, EventArgs e)
        {
            int col, row;
            Place place;

            col = ((Button)sender).Location.X / ((Button)sender).Width;
            row = ((Button)sender).Location.Y / ((Button)sender).Height;
            place = new Place(row, col);
            UI.PlayTurn(this, place);            
        }

        public void BoardRefresh()
        {
            int currentRow = 0, currentCol = 0;

            GameRulesAndLogic.TakeOutAvailableMoveSigns(Board);
            GameRulesAndLogic.CheckValidMoves(s_Board, Board.CurrentPlayer.Sign);

            for (currentRow = 0; currentRow < s_Board.Rows; currentRow++)
            {
                for (currentCol = 0; currentCol < s_Board.Columns; currentCol++)
                {
                    if (s_Board.PlayBoard[currentRow][currentCol] == s_Board.FirstPlayer.Sign)
                    {                        
                            setWhiteButton(m_GameBoardButtons[currentRow][currentCol]);                        
                    }
                    else if (s_Board.PlayBoard[currentRow][currentCol] == s_Board.SecondPlayer.Sign)
                    {
                        setBlackButton(m_GameBoardButtons[currentRow][currentCol]);                        
                    }
                    else if (s_Board.PlayBoard[currentRow][currentCol] == s_Board.AvilableMoveSign)
                    {
                        m_GameBoardButtons[currentRow][currentCol].BackColor = Color.LawnGreen;
                        m_GameBoardButtons[currentRow][currentCol].Enabled = true;
                    }
                    else
                    {
                        if (m_GameBoardButtons[currentRow][currentCol].BackColor == Color.LawnGreen)
                        {
                            m_GameBoardButtons[currentRow][currentCol].BackColor = Color.LightGray;
                        }

                        m_GameBoardButtons[currentRow][currentCol].Enabled = false;
                    }
                }
            }
        }

        public Board Board
        {
            get
            {
                return s_Board;
            }
        }
    }
}
