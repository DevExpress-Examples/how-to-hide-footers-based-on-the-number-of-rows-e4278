Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Namespace HideableGroupRowFooters
	Public Class MyGridView
		Inherits GridView

		Public Sub New(ByVal ownerGrid As GridControl)
			MyBase.New(ownerGrid)

		End Sub

		Public Sub New()
			MyBase.New()

		End Sub

		Public Delegate Sub CustomFooterVisibleHandler(ByVal sender As Object, ByVal e As HideFooterEventArgs)
		Public Event CustomFooterVisible As CustomFooterVisibleHandler
		Public Overridable Sub OnCustomFooterVisible(ByVal e As HideFooterEventArgs)
			RaiseEvent CustomFooterVisible(Me, e)

		End Sub



		Protected Overrides ReadOnly Property ViewName() As String
			Get
				Return "MyGridView"
			End Get
		End Property

	End Class
End Namespace