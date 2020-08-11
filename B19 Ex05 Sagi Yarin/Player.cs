using System;
using System.Collections.Generic;
using System.Text;

namespace Othello
{
    internal class Player
    {
        private string m_Name;
        private char m_Sign;
        private int m_Score;
        private bool m_IsComputer;
        private int m_GameWon = 0;

        public Player(string i_Name, char i_Sign, bool i_IsComputer)
        {
            m_Name = i_Name;
            m_Sign = i_Sign;
            m_Score = 2;
            m_IsComputer = i_IsComputer;
        }

        public int GameWon
        {
            get
            {
                return m_GameWon;
            }

            set
            {
                m_GameWon = value;
            }
        }

        public string Name
        {
            get
            {
                return m_Name;
            }

            set
            {
                m_Name = value;
            }
        }

        public bool IsComputer
        {
            get
            {
                return m_IsComputer;
            }
        }

        public char Sign
        {
            get
            {
                return m_Sign;
            }

            set
            {
                m_Sign = value;
            }
        }

        public int Score
        {
            get
            {
                return m_Score;
            }

            set
            {
                m_Score = value;
            }
        }
    }
}
