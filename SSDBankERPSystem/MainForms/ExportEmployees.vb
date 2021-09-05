Public Class ExportEmployees

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        On Error Resume Next
        str = " Select * from Table_1 "
        GetData(0)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    str = " update employees set DepARTMENTID = " & ComboBox2.SelectedValue & "  where employeeCode = " & ds.Tables(0).Rows(i)(0) & ""
                    Execute_Command()
                Next
                MsgBox("Updated")
            End If
        End If

    End Sub

    Private Sub ComboBox1_DropDown(sender As Object, e As EventArgs) Handles ComboBox1.DropDown
        GetBranches(ComboBox1)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        On Error Resume Next
        GetDepartments(ComboBox1, ComboBox2)
    End Sub

    Private Sub ComboBox2_DropDown(sender As Object, e As EventArgs) Handles ComboBox2.DropDown
        GetDepartments(ComboBox1, ComboBox2)
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged

    End Sub
End Class