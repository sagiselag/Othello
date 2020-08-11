using System;
using System.Collections.Generic;
using System.Text;

namespace Othello
{
    internal class Place
    {
        private int m_Row, m_Col;

        public Place(int i_row, int i_Col)
        {
            m_Row = i_row;
            m_Col = i_Col;
        }

        public int Col
        {
            get
            {
                return m_Col;
            }

            set
            {
                m_Col = value;
            }
        }

        public int Row
        {
            get
            {
                return m_Row;
            }

            set
            {
                m_Row = value;
            }
        }
    }
}
