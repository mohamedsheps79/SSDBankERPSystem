Public Class EditDocumentTypes

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If n = 0 Then
            str = "Insert into DocumentsTypes values ('" & TextBox2.Text.ToString & "')"
            Execute_Command()
            MsgBox("تم الحفظ")
        Else
            str = " Update DocumentsTypes set DocumentName = '" & TextBox2.Text.ToString & "' where " & _
                 " DocumentTypeID = " & SystemSettings.DataGridView4(1, r).Value & ""
            Execute_Command()
            MsgBox("تم التعديل")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If MsgBox("هل تريد الحذف", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            str = " Delete from DocumentsTypes where DocumentTypeID = " & SystemSettings.DataGridView4(1, r).Value & ""
            Execute_Command()
            MsgBox("تم الحذف")
        Else
            Exit Sub
        End If
    End Sub

    Private Sub EditDocumentTypes_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        On Error GoTo fb
        str = " Select * from DocumentsTypes "
        GetData(0)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                SystemSettings.DataGridView4.DataSource = ds.Tables(0)
            Else
                SystemSettings.DataGridView4.DataSource = Nothing
            End If
        Else
            SystemSettings.DataGridView4.DataSource = Nothing
        End If
fb:
    End Sub

    Private Sub EditDocumentTypes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class