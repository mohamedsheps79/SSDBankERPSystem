Public Class EditDepartments

    Private Sub ComboBox1_DropDown(sender As Object, e As EventArgs) Handles ComboBox1.DropDown
        GetBranches(ComboBox1)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If n = 0 Then
            str = "Insert into Departments values (" & ComboBox1.SelectedValue & ", '" & TextBox2.Text.ToString & "')"
            Execute_Command()
            MsgBox("تم الحفظ")
        Else
            str = " Update Departments set BranchID = " & ComboBox1.SelectedValue & ", DepartmentName = '" & TextBox2.Text.ToString & "' where " & _
                 " DepartmentID = " & SystemSettings.DataGridView2(2, r).Value & ""
            Execute_Command()
            MsgBox("تم التعديل")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If MsgBox("هل تريد الحذف", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            str = " Delete from departments where DepartmentID = " & SystemSettings.DataGridView2(2, r).Value & ""
            Execute_Command()
            MsgBox("تم الحذف")
        Else
            Exit Sub
        End If
        
    End Sub

    Private Sub EditDepartments_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        str = " Select * from Departments"
        GetData(0)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                SystemSettings.DataGridView2.DataSource = ds.Tables(0)
            Else
                SystemSettings.DataGridView2.DataSource = Nothing
            End If
        Else
            SystemSettings.DataGridView2.DataSource = Nothing
        End If
    End Sub

    Private Sub EditDepartments_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class