using System;

namespace HideableGroupRowFooters
{
	public delegate void ShowGroupFooterEventHandler(object sender, ShowGroupFooterEventArgs e);

	public class ShowGroupFooterEventArgs : EventArgs
	{
		private int footerLevel;
        private bool footerVisible;
        private int handle;

		public ShowGroupFooterEventArgs(int aFooterLevel,int aHandle)
			: base()
		{
			footerVisible = true;
			footerLevel = aFooterLevel;
            handle = aHandle;
		}

		public int FooterLevel
		{
			get
			{
				return footerLevel;
			}
		}

        public bool Visible
        {
            get
            {
                return footerVisible;
            }
            set
            {
                footerVisible = value;
            }
        }
        public int Handle
        {
            get
            {
                return handle;
            }
        
        
        }
	}
}
