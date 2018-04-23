Imports System.Drawing
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports System.Diagnostics

Namespace HideableGroupRowFooters

	Public Class MyGridViewInfo
		Inherits GridViewInfo

		Public Sub New(ByVal gridView As MyGridView)
			MyBase.New(gridView)
		End Sub

		Protected Overrides Sub CalcRowFooterInfo(ByVal ri As GridRowInfo, ByVal row As GridRow, ByVal nextRow As GridRow)
			Dim height As Integer = ri.RowFooters.RowFootersHeight
			If height = 0 Then
				Return
			End If

			Dim isShowCurrentFooter As Boolean = IsShowCurrentRowFooter(ri)
			Dim startLevel As Integer = ri.Level
			Dim footerRowHandle As Integer = ri.RowHandle

			If (Not ri.IsGroupRow) OrElse (Not isShowCurrentFooter) Then
				footerRowHandle = View.GetParentRowHandle(footerRowHandle)
			End If

			If Not isShowCurrentFooter Then
				startLevel -= 1
			End If

			Dim top As Integer = ri.TotalBounds.Bottom - height - ri.RowSeparatorBounds.Height
			Dim left As Integer = ri.IndentRect.Right - (If((Not isShowCurrentFooter), LevelIndent, 0))
			ri.RowFooters.Bounds = New Rectangle(left, top, ri.DataBounds.Right - left, height)

			Dim n As Integer = 0
			Do While n < ri.RowFooters.RowFooterCount

				Dim some As Boolean = NeedHideFooter(row.VisibleIndex+1, startLevel)

				If Not some Then
					startLevel -= 1
					left -= LevelIndent
					ri.RowFooters.RowFooterCount += 1
					footerRowHandle = View.GetParentRowHandle(footerRowHandle)

					n += 1
					Continue Do
				End If

				Dim fi As New GridRowFooterInfo()
				ri.RowFooters.Add(fi)
				fi.RowHandle = footerRowHandle
				fi.Bounds = ri.Bounds
				fi.Level = startLevel
				fi.Bounds.Y = top
				fi.Bounds.X = left
				fi.Bounds.Width = ri.DataBounds.Right - fi.Bounds.Left
				fi.Bounds.Height = GroupFooterHeight
				top += fi.Bounds.Height

				If Not ri.IndicatorRect.IsEmpty Then
					fi.IndicatorRect = ri.IndicatorRect
					fi.IndicatorRect.Y = fi.Bounds.Y
					fi.IndicatorRect.Height = fi.Bounds.Height
				End If

				If View.OptionsView.ShowHorizontalLines <> DevExpress.Utils.DefaultBoolean.False Then
					ri.AddRowLineInfo(fi.Bounds.Left, fi.Bounds.Bottom - 1, fi.Bounds.Width, 1, PaintAppearance.HorzLine)
					fi.Bounds.Height -= 1
				End If

				CalcRowCellsFooterInfo(fi, ri)
				footerRowHandle = View.GetParentRowHandle(footerRowHandle)
				startLevel -= 1
				left -= LevelIndent
				n += 1
			Loop
		End Sub

		Public Overrides Function GetRowFooterCount(ByVal rowHandle As Integer, ByVal rowVisibleIndex As Integer, ByVal isExpanded As Boolean) As Integer
			Dim initialVisibleFootersCount As Integer = MyBase.GetRowFooterCount(rowHandle, rowVisibleIndex, isExpanded)
			Dim visibleFootersCount As Integer = initialVisibleFootersCount

			Dim footerRowHandle As Integer = rowHandle
			For i As Integer = 0 To initialVisibleFootersCount - 1
				Dim some As Boolean = NeedHideFooter(rowVisibleIndex+1, View.GetRowLevel(footerRowHandle))

				If Not some Then
					visibleFootersCount -= 1
				End If

				footerRowHandle = View.GetParentRowHandle(footerRowHandle)
			Next i

			Return visibleFootersCount
		End Function
		Public Function NeedHideFooter(ByVal rowHandle As Integer, ByVal footerLevel As Integer) As Boolean
			CurentFooterLevel = 0
			CalcFooterLevels(rowHandle)
			If rowHandle <> Integer.MinValue + 1 AndAlso rowHandle<0 Then
				Return (HidingGroupFooters(rowHandle, footerLevel))
			End If


			CurentFooterLevel = 0
			LastGroupRowHandle = 0
			GetLastGroupRow()
			CalcFooterLevels(LastGroupRowHandle)
			Return (HidingGroupFooters(LastGroupRowHandle, footerLevel))

		End Function

		Private Sub RaiseHideGroupFooter(ByVal args As HideFooterEventArgs)
            Dim aView As MyGridView = TryCast(View, MyGridView)
            If aView IsNot Nothing Then
                aView.OnCustomFooterVisible(args)
            End If

		End Sub


		Private CurentFooterLevel As Integer
		Private LastGroupRowHandle As Integer
		Public Sub GetLastGroupRow()
			Dim k As Integer = 0
			Do
				k -= 1
				If View.IsValidRowHandle(k) Then
					If View.IsGroupRow(k) Then
						LastGroupRowHandle = k
					End If
				End If


			Loop While View.IsValidRowHandle(k)
		End Sub


		Public Function HidingGroupFooters(ByVal rowHandle As Integer, ByVal footerLevel As Integer) As Boolean

			If rowHandle = -2147483648 Then
				Return True
			End If

			Dim args As New HideFooterEventArgs(View.GetChildRowCount(rowHandle))
			RaiseHideGroupFooter(args)
			If CurentFooterLevel = footerLevel Then
				Return args.FooterVisible
			End If
			Dim n As Integer = View.GetParentRowHandle(rowHandle)
			If n < 0 AndAlso n <> -2147473648 Then
				CurentFooterLevel -= 1
			  Return HidingGroupFooters(n,footerLevel)
			End If
			Return True

		End Function

		Public Sub CalcFooterLevels(ByVal rowHandle As Integer)
			CurentFooterLevel += 1
			Dim n As Integer = View.GetParentRowHandle(rowHandle)
			If n < 0 AndAlso n <> -2147483648 Then
				CalcFooterLevels(n)
			End If

		End Sub
	End Class
End Namespace
