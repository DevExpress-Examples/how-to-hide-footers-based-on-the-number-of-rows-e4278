Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Registrator
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Base.ViewInfo

Namespace HideableGroupRowFooters
	Public Class MyGridInfoRegistrator
		Inherits GridInfoRegistrator

		Public Overrides Function CreateView(ByVal grid As GridControl) As BaseView
			Return New MyGridView(TryCast(grid, GridControl))
		End Function
		Public Overrides Function CreateViewInfo(ByVal view As BaseView) As BaseViewInfo
			Return New MyGridViewInfo(CType(view, MyGridView))
		End Function

		Public Overrides ReadOnly Property ViewName() As String
			Get
				Return "MyGridView"
			End Get
		End Property
	End Class
End Namespace
