Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Forms
Imports System.Data
Imports DevExpress.Data
Imports DevExpress.XtraGrid
Imports System.Diagnostics
Imports DevExpress.XtraEditors

Namespace HideableGroupRowFooters
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
			AddHandler myGridView1.CustomFooterVisible, AddressOf myGridView1_CustomFooterVisible
		End Sub

		Private Sub myGridView1_CustomFooterVisible(ByVal sender As Object, ByVal e As HideFooterEventArgs)
			If checkEdit1.Checked Then
				If e.ChildRowsCount = 1 Then
					e.FooterVisible = False
				End If
			End If
		End Sub






		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			Dim table As DataTable = CreateTable(30)
			myGridControl1.DataSource = table
			GroupColumns()
			SetSummaryItems()
		End Sub

		Private Function CreateTable(ByVal RowCount As Integer) As DataTable
			Dim tbl As New DataTable()
			tbl.Columns.Add("Category", GetType(String))
			tbl.Columns.Add("Vendor", GetType(String))
			tbl.Columns.Add("Model", GetType(String))
			tbl.Columns.Add("HasSmth", GetType(String))
			tbl.Columns.Add("NumOfSmth", GetType(Integer))

			For i As Integer = 0 To RowCount - 1
				Dim r As Integer = New Random(i).Next(0, 10)
				Dim hasSmth As String = If(r <= 5, "Yes", "No")

				r = New Random(i).Next(0, 10)
				Dim cat As String = If(r <= 5, "Cat1", "Cat2")

				r = New Random(i).Next(0, 4)
				tbl.Rows.Add(New Object() { cat, String.Format("Vendor {0}", r), String.Format("Model {0}", i), hasSmth, i })
			Next i

			Return tbl
		End Function

		Private Sub GroupColumns()

			myGridView1.Columns("Category").Group()
			myGridView1.Columns("Vendor").Group()
			myGridView1.Columns("HasSmth").Group()

			myGridView1.ExpandAllGroups()
		End Sub

		Private Sub SetSummaryItems()
			Dim item As New GridGroupSummaryItem()
			item.FieldName = "Model"
			item.SummaryType = DevExpress.Data.SummaryItemType.Count
			item.ShowInGroupColumnFooter = myGridView1.Columns("Model")
			myGridView1.GroupSummary.Add(item)

			Dim item1 As New GridGroupSummaryItem()
			item1.FieldName = "NumOfSmth"
			item1.DisplayFormat = "{0:f3}"
			item1.SummaryType = DevExpress.Data.SummaryItemType.Average
			item1.ShowInGroupColumnFooter = myGridView1.Columns("NumOfSmth")
			myGridView1.GroupSummary.Add(item1)
		End Sub


		Private Sub checkEdit1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles checkEdit1.CheckedChanged
			myGridView1.LayoutChanged()
		End Sub

	End Class
End Namespace

