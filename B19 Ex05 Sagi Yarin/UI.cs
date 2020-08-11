using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Othello
{
    internal class UI
    {
        private const string k_NewGameSign = "Y";
        private const string k_EndGameSign = "Q";
        private const char k_AvilableMoveSign = '~';
        private const char k_EmptySign = ' ';
        private Random m_rnd = new Random();

        public static void NewGame()
        {
            OthelloGameSettings gameSettings = new OthelloGameSettings();
            PlayBoardForm playBoard;
            Board board;

            gameSettings.ShowDialog();
            board = new Board(gameSettings.BoardSize, k_AvilableMoveSign, k_EmptySign, gameSettings.PlayerType);
            playBoard = new PlayBoardForm(board);
            playBoard.ShowDialog();
        }

        public static void NewGame(PlayBoardForm i_PlayBoard)
        {
            OthelloGameSettings gameSettings = new OthelloGameSettings();
            PlayBoardForm playBoard;
            Board board;

            gameSettings.ShowDialog();
            board = new Board(gameSettings.BoardSize, k_AvilableMoveSign, k_EmptySign, gameSettings.PlayerType);
            playBoard = new PlayBoardForm(board);
            if (playBoard.Board.SecondPlayer.IsComputer == i_PlayBoard.Board.SecondPlayer.IsComputer)
            {
                playBoard.Board.FirstPlayer.GameWon = i_PlayBoard.Board.FirstPlayer.GameWon;
                playBoard.Board.SecondPlayer.GameWon = i_PlayBoard.Board.SecondPlayer.GameWon;
            }
                        
            playBoard.ShowDialog();
        }

        private static void gameOver(PlayBoardForm i_PlayBoard)
        {
            string winnerName;
            int winnerScore, loserScore, winnerGameWon, loserGameWon;
            string msg;

            if (i_PlayBoard.Board.FirstPlayer.Score == i_PlayBoard.Board.SecondPlayer.Score)
            {
                winnerName = "It's a draw";
                msg = string.Format(
    @"
It's a draw !!
Would you like another round?");
            }
            else
            {
                if (i_PlayBoard.Board.FirstPlayer.Score > i_PlayBoard.Board.SecondPlayer.Score)
                {
                    winnerName = i_PlayBoard.Board.FirstPlayer.Name;
                    winnerScore = i_PlayBoard.Board.FirstPlayer.Score;
                    loserScore = i_PlayBoard.Board.SecondPlayer.Score;
                    i_PlayBoard.Board.FirstPlayer.GameWon++;
                    winnerGameWon = i_PlayBoard.Board.FirstPlayer.GameWon;
                    loserGameWon = i_PlayBoard.Board.SecondPlayer.GameWon;
                }
                else
                {
                    winnerName = i_PlayBoard.Board.SecondPlayer.Name;
                    winnerScore = i_PlayBoard.Board.SecondPlayer.Score;
                    loserScore = i_PlayBoard.Board.FirstPlayer.Score;
                    i_PlayBoard.Board.SecondPlayer.GameWon++;
                    winnerGameWon = i_PlayBoard.Board.SecondPlayer.GameWon;
                    loserGameWon = i_PlayBoard.Board.FirstPlayer.GameWon;
                }

                msg = string.Format(
                    @"
{0} Won!! ({1}/{2}) ({3}/{4})
Would you like another round?
",
        winnerName,
        winnerScore,
        loserScore,
        winnerGameWon,
        loserGameWon);
            }            

            if (MessageBox.Show(msg, "Othello", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                i_PlayBoard.Hide();
                NewGame(i_PlayBoard);
            }
            else
            {
                Application.Exit();
            }            
        }

        public static void PlayTurn(PlayBoardForm i_PlayBoardForm, Place i_NextMove)
        {
            bool legalMove = true;
            Place selectedOptionToPlay;
            Player opponentPlayer = GameRulesAndLogic.GetOpponentPlayer(i_PlayBoardForm.Board);
            
            if (!i_PlayBoardForm.Board.CurrentPlayer.IsComputer)
            {
                legalMove = GameRulesAndLogic.CheckValidMoves(i_PlayBoardForm.Board, i_PlayBoardForm.Board.CurrentPlayer.Sign);
                if (legalMove)
                {
                    i_PlayBoardForm.Text = "Otello - " + i_PlayBoardForm.Board.CurrentPlayer.Name + "'s Turn";
                    GameRulesAndLogic.CheckAndMakeMove(i_PlayBoardForm.Board, i_NextMove, i_PlayBoardForm.Board.CurrentPlayer.Sign);
                }
                else
                {
                    MessageBox.Show(string.Format(
                        @"
                    There is no availbale move for {0}
                    The turn is going to opponent
                    Press enter to continue", 
                    i_PlayBoardForm.Board.CurrentPlayer.Name));
                }

                GameRulesAndLogic.ChangeCuurentPlayer(i_PlayBoardForm.Board);
                opponentPlayer = GameRulesAndLogic.GetOpponentPlayer(i_PlayBoardForm.Board);
                if (!i_PlayBoardForm.Board.CurrentPlayer.IsComputer && !opponentPlayer.IsComputer && legalMove)
                {
                    i_PlayBoardForm.Text = "Otello - " + i_PlayBoardForm.Board.CurrentPlayer.Name + "'s Turn";                    
                }
                
                i_PlayBoardForm.BoardRefresh();
            }          

            if (i_PlayBoardForm.Board.CurrentPlayer.IsComputer)
            {
                if (GameRulesAndLogic.CheckValidMoves(i_PlayBoardForm.Board, i_PlayBoardForm.Board.CurrentPlayer.Sign))
                {
                    selectedOptionToPlay = GameRulesAndLogic.ComputerRandomeMove(i_PlayBoardForm.Board);
                    i_NextMove = selectedOptionToPlay;
                    GameRulesAndLogic.CheckAndMakeMove(i_PlayBoardForm.Board, i_NextMove, i_PlayBoardForm.Board.CurrentPlayer.Sign);
                    GameRulesAndLogic.ChangeCuurentPlayer(i_PlayBoardForm.Board);
                    opponentPlayer = GameRulesAndLogic.GetOpponentPlayer(i_PlayBoardForm.Board);
                    i_PlayBoardForm.BoardRefresh();
                }
            }

            if (!GameRulesAndLogic.ThereIsAvailableMovementsOnBoard(i_PlayBoardForm.Board))
            {
                if (GameRulesAndLogic.BoardISNotFull(i_PlayBoardForm.Board))
                {
                    MessageBox.Show(@"                                    
                                There is no availbale move for both players

                                Press enter to continue");
                    gameOver(i_PlayBoardForm);
                }
                else
                {
                    gameOver(i_PlayBoardForm);
                }
            }

            if (!GameRulesAndLogic.CheckValidMoves(i_PlayBoardForm.Board, i_PlayBoardForm.Board.CurrentPlayer.Sign))
            {
                MessageBox.Show(string.Format(
                    @"
                There is no availbale move for {0}
                The turn is going to opponent
                Press enter to continue", 
                i_PlayBoardForm.Board.CurrentPlayer.Name));
                GameRulesAndLogic.ChangeCuurentPlayer(i_PlayBoardForm.Board);
                opponentPlayer = GameRulesAndLogic.GetOpponentPlayer(i_PlayBoardForm.Board);
                if (!i_PlayBoardForm.Board.CurrentPlayer.IsComputer && !opponentPlayer.IsComputer && legalMove)
                {
                    i_PlayBoardForm.Text = "Otello - " + i_PlayBoardForm.Board.CurrentPlayer.Name + "'s Turn";
                }

                i_PlayBoardForm.BoardRefresh();
            }

            if (i_PlayBoardForm.Board.CurrentPlayer.IsComputer)
            {
                PlayTurn(i_PlayBoardForm, GameRulesAndLogic.ComputerRandomeMove(i_PlayBoardForm.Board));
            }
        }       
    }
}   