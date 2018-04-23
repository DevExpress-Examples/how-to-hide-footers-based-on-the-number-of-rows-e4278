using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Registrator;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Base.ViewInfo;

namespace HideableGroupRowFooters
{
	public class MyGridInfoRegistrator : GridInfoRegistrator
	{
		public override BaseView CreateView(GridControl grid)
		{
			return new MyGridView(grid as GridControl);
		}
		public override BaseViewInfo CreateViewInfo(BaseView view)
		{
			return new MyGridViewInfo((MyGridView)view);
		}

		public override string ViewName
		{
			get
			{
				return "MyGridView";
			}
		}
	}
}
