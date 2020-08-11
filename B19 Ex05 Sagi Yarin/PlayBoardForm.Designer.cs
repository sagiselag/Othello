using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace Othello
{
    internal partial class PlayBoardForm
    {
        private Button[][] m_GameBoardButtons;

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void boardInitialized()
        {
            int currentRow = 0, currentCol = 0;
            GameRulesAndLogic.CheckValidMoves(s_Board, s_Board.FirstPlayer.Sign);

            for (currentRow = 0; currentRow < s_Board.Rows; currentRow++)
            {
                m_GameBoardButtons[currentRow] = new System.Windows.Forms.Button[s_Board.Columns];
            }

            for (currentRow = 0; currentRow < s_Board.Rows; currentRow++)
            {
                for (currentCol = 0; currentCol < s_Board.Columns; currentCol++)
                {
                    m_GameBoardButtons[currentRow][currentCol] = new NewButton();
                    m_GameBoardButtons[currentRow][currentCol].Text = s_Board.EmptySign.ToString();
                    if(s_Board.PlayBoard[currentRow][currentCol] == s_Board.AvilableMoveSign)
                    {
                        m_GameBoardButtons[currentRow][currentCol].BackColor = Color.LawnGreen;
                        m_GameBoardButtons[currentRow][currentCol].Enabled = true;
                    }
                    else
                    {
                        m_GameBoardButtons[currentRow][currentCol].BackColor = Color.LightGray;
                        m_GameBoardButtons[currentRow][currentCol].Enabled = false;                                              
                    }
                }
            }

            setBlackButton(m_GameBoardButtons[(s_Board.Rows / 2) - 1][(s_Board.Columns / 2) - 1]);
            setWhiteButton(m_GameBoardButtons[(s_Board.Rows / 2) - 1][s_Board.Columns / 2]);
            setBlackButton(m_GameBoardButtons[s_Board.Rows / 2][s_Board.Columns / 2]);
            setWhiteButton(m_GameBoardButtons[s_Board.Rows / 2][(s_Board.Columns / 2) - 1]);
            Board.CurrentPlayer = Board.FirstPlayer;
        }

        private void setBlackButton(Button i_Button)
        {
            ////i_Button.BackColor = Color.Black;
            ////i_Button.Text = "O";

            i_Button.BackColor = Color.LightGray;
            i_Button.ForeColor = Color.White;
            i_Button.Enabled = false;
            i_Button.BackgroundImage = Properties.Resources.CoinRed;
            i_Button.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void setWhiteButton(Button i_Button)
        {
            ////i_Button.BackColor = Color.White;
            ////i_Button.Text = "O";

            i_Button.BackColor = Color.LightGray;
            i_Button.ForeColor = Color.Black;
            i_Button.Enabled = false;
            i_Button.BackgroundImage = Properties.Resources.CoinYellow;
            i_Button.BackgroundImageLayout = ImageLayout.Stretch;
        }    

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent(Board i_Board)
        {
            int currentRow = 0, currentCol = 0, topLocation = 10, leftLocation = 10, buttonWidth, buttonHeight;
            Size buttonSize;
            Padding buttonPadding = new Padding(5, 5, 5, 5);
            Font buttonFont;

            s_Board = i_Board;
            GameRulesAndLogic.CheckValidMoves(s_Board, s_Board.FirstPlayer.Sign);
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "Otello - " + s_Board.FirstPlayer.Name +"'s Turn";                        
            this.m_GameBoardButtons = new System.Windows.Forms.Button[s_Board.Rows][];
            boardInitialized();

            buttonFont = m_GameBoardButtons[s_Board.Rows / 2][s_Board.Columns / 2].Font = new Font(m_GameBoardButtons[s_Board.Rows / 2][s_Board.Columns / 2].Font.FontFamily, 15); 
            m_GameBoardButtons[s_Board.Rows / 2][s_Board.Columns / 2].Padding = buttonPadding;
            m_GameBoardButtons[s_Board.Rows / 2][s_Board.Columns / 2].AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonWidth = m_GameBoardButtons[s_Board.Rows / 2][s_Board.Columns / 2].PreferredSize.Width;
            buttonHeight = m_GameBoardButtons[s_Board.Rows / 2][s_Board.Columns / 2].PreferredSize.Height;
            buttonSize = new Size(buttonWidth, buttonHeight);            

            for (currentRow = 0; currentRow < s_Board.Rows; currentRow++)
            {
                for (currentCol = 0; currentCol < s_Board.Columns; currentCol++)
                {
                    m_GameBoardButtons[currentRow][currentCol].Size = buttonSize;
                    m_GameBoardButtons[currentRow][currentCol].Font = buttonFont;
                    m_GameBoardButtons[currentRow][currentCol].Location = new System.Drawing.Point(leftLocation + currentCol * buttonWidth, topLocation + currentRow * buttonHeight);
                    m_GameBoardButtons[currentRow][currentCol].Click += new System.EventHandler(this.buttonPlayTurn_Click);
                    this.Controls.Add(this.m_GameBoardButtons[currentRow][currentCol]);
                }
            }
            
            this.Size = new Size(this.PreferredSize.Width + 10 - (this.DefaultMargin.Vertical / 2), this.PreferredSize.Height + 10 - (this.DefaultMargin.Horizontal / 2));
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.CenterToScreen();
            this.SuspendLayout();
        }

        #endregion
    }
}