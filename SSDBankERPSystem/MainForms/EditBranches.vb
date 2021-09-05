Public Class EditBranches

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If n = 0 Then
            str = " iNSERT INTO Branches values ('" & TextBox1.Text.ToString & "','" & TextBox2.Text.ToString & "')"
            Execute_Command()
            MsgBox("تم الحفظ")
        Else
            str = " Update Branches set BranchCode = '" & TextBox1.Text.ToString & "' ,BranchName = '" & TextBox2.Text.ToString & "' " & _
                " where BranchID =" & SystemSettings.DataGridView1(1, r).Value & "   "
            Execute_Command()
            MsgBox("تم التعديل")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If MsgBox("هل تريد الحذف", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            str = " Delete from Branches where BranchID =" & SystemSettings.DataGridView1(1, r).Value & ""
            Execute_Command()
            MsgBox("تم الحذف")
        Else
            Exit Sub
        End If
       
    End Sub

    Private Sub EditBranches_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        str = " Select * from Branches"
        GetData(0)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                SystemSettings.DataGridView1.DataSource = ds.Tables(0)
            Else
                SystemSettings.DataGridView1.DataSource = Nothing
            End If
        Else
            SystemSettings.DataGridView1.DataSource = Nothing
        End If
    End Sub

    Private Sub EditBranches_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class