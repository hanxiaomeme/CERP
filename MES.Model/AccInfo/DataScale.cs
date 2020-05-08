using System;
using System.Collections.Generic;
using System.Text;

namespace LanyunMES.Entity
{
    public class DataScale
    {
        /// <summary>
        /// ��ǰ���ݾ�����Ϣ
        /// </summary>
        public static DataScale CurrentDataScale
        {
            get
            {
                if (currentDataScale == null)
                    currentDataScale = new DataScale();
                return currentDataScale;
            }
            set
            {
                currentDataScale = value;
            }
        }
        private static DataScale currentDataScale = null;



        /// <summary>
        /// �������
        /// </summary>
        public int CHSL
        {
            get { return this.m_nCHSL; }
            set { this.m_nCHSL = value; }
        }
        private int m_nCHSL = 0;

        /// <summary>
        /// �������
        /// </summary>
        public int CHJS
        {
            get { return this.m_nCHJS; }
            set { this.m_nCHJS = value; }
        }
        private int m_nCHJS = 0;

        /// <summary>
        /// ����
        /// </summary>
        public int DJ
        {
            get { return this.m_nDJ; }
            set { this.m_nDJ = value; }
        }
        private int m_nDJ = 0;

        /// <summary>
        /// ���
        /// </summary>
        public int JE
        {
            get { return this.m_nJE; }
            set { this.m_nJE = value; }
        }
        private int m_nJE = 0;

        /// <summary>
        /// ������
        /// </summary>
        public int HSL
        {
            get { return this.m_nHSL; }
            set { this.m_nHSL = value; }
        }
        private int m_nHSL = 0;
    }
}