using System;
using System.Collections.Generic;


namespace HideableGroupRowFooters
{
    public class HideFooterEventArgs : EventArgs
    {
        private int childRowsCount;
        private bool footerVisible;

        public HideFooterEventArgs(int aChildRowsCount)
            : base()
        {
            footerVisible = true;
            childRowsCount = aChildRowsCount;
        }

        public bool FooterVisible
        {
            get
            {
                return footerVisible;
            }
            set { footerVisible = value; }
        }


        public int ChildRowsCount
        {
            get
            {
                return childRowsCount;
            }


        }
    }
}
