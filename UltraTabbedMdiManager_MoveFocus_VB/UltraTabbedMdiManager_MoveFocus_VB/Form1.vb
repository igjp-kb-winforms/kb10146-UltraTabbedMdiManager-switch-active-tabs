Imports System.Drawing.Imaging
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form1
	Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		'MDI 子フォームのコンテナーとするプロパティ設定
		IsMdiContainer = True
		'フォームでキーイベントを捕捉するためのプロパティ設定
		KeyPreview = True

		Dim i As Integer
		For i = 1 To 5
			Dim myForm As New SampleChildForm()
			myForm.MdiParent = Me
			myForm.Text = "Child Form" & i.ToString()
			myForm.Show()
		Next i
	End Sub

	Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
		Dim tabs = Me.UltraTabbedMdiManager1.TabGroups(0).Tabs
		Dim activeTab = Me.UltraTabbedMdiManager1.ActiveTab

		'Home 押下時に、先頭タブをアクティブ化する。
		If e.KeyData = Keys.Home Then
			tabs(0).Activate()
		End If

		'End 押下時に、最終タブをアクティブ化する。
		If e.KeyData = Keys.End Then
			tabs(tabs.Count - 1).Activate()
		End If

		'PageUp 押下時に、アクティブタブを次に移動する。
		If e.KeyData = Keys.PageUp Then
			'最終タブがアクティブタブの場合、先頭タブをアクティブ化する。
			If activeTab.Index = tabs.Count - 1 Then
				tabs(0).Activate()
			Else
				tabs(activeTab.Index + 1).Activate()
			End If
		End If

		'PageDown 押下時に、アクティブタブを前に移動する。
		If e.KeyData = Keys.PageDown Then
			'先頭タブがアクティブタブの場合、最終タブをアクティブ化する。
			If activeTab.Index = 0 Then
				tabs(tabs.Count - 1).Activate()
			Else
				tabs(activeTab.Index - 1).Activate()
			End If
		End If
	End Sub
End Class
