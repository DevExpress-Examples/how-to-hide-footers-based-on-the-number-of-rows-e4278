Imports System
Imports System.Collections.Generic


Namespace HideableGroupRowFooters
	Public Class HideFooterEventArgs
		Inherits EventArgs

'INSTANT VB NOTE: The variable childRowsCount was renamed since Visual Basic does not allow variables and other class members to have the same name:
		Private childRowsCount_Renamed As Integer
'INSTANT VB NOTE: The variable footerVisible was renamed since Visual Basic does not allow variables and other class members to have the same name:
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
