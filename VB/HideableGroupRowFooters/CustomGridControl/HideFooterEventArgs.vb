Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic


Namespace HideableGroupRowFooters
	Public Class HideFooterEventArgs
		Inherits EventArgs
		Private childRowsCount_Renamed As Integer
		Private footerVisible_Renamed As Boolean

		Public Sub New(ByVal aChildRowsCount As Integer)
			MyBase.New()
			footerVisible_Renamed = True
			childRowsCount_Renamed = aChildRowsCount
		End Sub

		Public Property FooterVisible() As Boolean
			Get
				Return footerVisible_Renamed
			End Get
			Set(ByVal value As Boolean)
				footerVisible_Renamed = value
			End Set
		End Property


		Public ReadOnly Property ChildRowsCount() As Integer
			Get
				Return childRowsCount_Renamed
			End Get


		End Property
	End Class
End Namespace
