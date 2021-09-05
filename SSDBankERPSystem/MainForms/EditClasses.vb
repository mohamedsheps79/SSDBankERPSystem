Public Class EditClasses

    Private Sub ComboBox1_DropDown(sender As Object, e As EventArgs) Handles ComboBox1.DropDown
        GetJobs(ComboBox1)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If n = 0 Then
            str = " iNSERT INTO Classes values (" & ComboBox1.SelectedValue & " , '" & TextBox2.Text & "')"
            Execute_Command()
            MsgBox(" تم الحفظ")
        Else
            str = " Update Classes set jobID = " & ComboBox1.SelectedValue & ", ClassName = '" & TextBox2.Text & "' where " & _
                " ClassID = " & SystemSettings.DataGridView3(2, r).Value & ""
            Execute_Command()
            MsgBox("تم التعديل")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If MsgBox("هل تريد الحذف", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            str = " Delete from Classes where ClassID = " & SystemSettings.DataGridView3(2, r).Value & ""
            Execute_Command()
            MsgBox("تم الحذف")
        Else
            Exit Sub
        End If
    End Sub

    Private Sub EditClasses_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        str = " Select * from Classes"
        GetData(0)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                SystemSettings.DataGridView3.DataSource = ds.Tables(0)
            Else
                SystemSettings.DataGridView3.DataSource = Nothing
            End If
        Else
            SystemSettings.DataGridView3.DataSource = Nothing
        End If
    End Sub

    Private Sub EditClasses_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class