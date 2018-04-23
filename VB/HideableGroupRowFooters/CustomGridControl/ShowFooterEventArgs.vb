Imports System

Namespace HideableGroupRowFooters
	Public Delegate Sub ShowGroupFooterEventHandler(ByVal sender As Object, ByVal e As ShowGroupFooterEventArgs)

	Public Class ShowGroupFooterEventArgs
		Inherits EventArgs

'INSTANT VB NOTE: The variable footerLevel was renamed since Visual Basic does not allow variables and other class members to have the same name:
		Private footerLevel_Renamed As Integer
		Private footerVisible As Boolean
'INSTANT VB NOTE: The variable handle was renamed since Visual Basic does not allow variables and other class members to have the same name:
		Private handle_Renamed As Integer

		Public Sub New(ByVal aFooterLevel As Integer, ByVal aHandle As Integer)
			MyBase.New()
			footerVisible = True
			footerLevel_Renamed = aFooterLevel
			handle_Renamed = aHandle
		End Sub

		Public ReadOnly Property FooterLevel() As Integer
			Get
				Return footerLevel_Renamed
			End Get
		End Property

		Public Property Visible() As Boolean
			Get
				Return footerVisible
			End Get
			Set(ByVal value As Boolean)
				footerVisible = value
			End Set
		End Property
		Public ReadOnly Property Handle() As Integer
			Get
				Return handle_Renamed
			End Get


		End Property
	End Class
End Namespace
