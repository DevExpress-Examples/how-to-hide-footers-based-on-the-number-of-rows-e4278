using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace HideableGroupRowFooters
{
    public class MyGridView : GridView
    {
        public MyGridView(GridControl ownerGrid)
            : base(ownerGrid)
        {

        }

        public MyGridView()
            : base()
        {

        }

        public delegate void CustomFooterVisibleHandler(object sender, HideFooterEventArgs e);
        public event CustomFooterVisibleHandler CustomFooterVisible;
        public virtual void OnCustomFooterVisible(HideFooterEventArgs e)
        {
            if (CustomFooterVisible != null)
            {
                CustomFooterVisible(this, e);
            }

        }



        protected override string ViewName
        {
            get
            {
                return "MyGridView";
            }
        }

    }
}