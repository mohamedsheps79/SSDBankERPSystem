Public Class EditEmployeesPromosions

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If n = 0 Then
            str = " Insert into EmployeesPromotions values (" & EmployeeID & ", " & ComboBox1.SelectedValue & " , " & ComboBox2.SelectedValue & ", " & _
               " '" & DateTimePicker1.Value.Date.ToString("MM-dd-yyyy").ToString & "', '" & ComboBox3.Text & "','" & TextBox3.Text.ToString & "'," & UserID & ",'','N')"
            Execute_Command()
            MsgBox("تم الحفظ")
        Else
            str = " Update EmployeesPromotions SET  EmployeeID = " & EmployeeID & ",DegreeID= " & ComboBox1.SelectedValue & " , RangeID =" & ComboBox2.SelectedValue & ", " & _
                          " PromoteDate = '" & DateTimePicker1.Value.Date.ToString("MM-dd-yyyy").ToString & "',PromoteType = '" & ComboBox3.Text & "', " & _
                          " Remarks = '" & TextBox3.Text.ToString & "',Status = 'A' , AuthorizedBy = " & UserID & " where PromoteID = " & Employees.DataGridView2(1, r).Value & " "
            Execute_Command()
            MsgBox("تم التعديل")

        End If
            
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If MsgBox("هل تريد الحذف", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            str = " Delete from EmployeesPromotions where PromoteID = " & Employees.DataGridView2(1, r).Value & "  "
            Execute_Command()
            MsgBox("تم الحذف")
        Else
            Exit Sub
        End If

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        str = " Select EmployeeName from Employees where EmployeeName Like ('%" & TextBox2.Text.ToString & "%')"
        GetData(0)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                Me.TextBox2.Text = ds.Tables(0).Rows(0)(0)
            Else
                Me.TextBox2.Text = Nothing
            End If
        Else
            Me.TextBox2.Text = Nothing
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        formID = 1
        EmployeesList.TextBox2.Text = Nothing
        EmployeesList.ShowDialog()
    End Sub

    Private Sub ComboBox1_DropDown(sender As Object, e As EventArgs) Handles ComboBox1.DropDown
        GetDegrees(ComboBox1)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub ComboBox2_DropDown(sender As Object, e As EventArgs) Handles ComboBox2.DropDown
        GetRanges(ComboBox2)
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged

    End Sub

    Private Sub EditEmployeesPromosions_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        str = " Select EmployeeName,PromoteID,EmployeesPromotions.EmployeeID,EmployeesPromotions.DegreeID,EmployeesPromotions.RangeID,PromoteDate,PromoteType,Remarks,EmployeesPromotions.Status  " & _
           " from employees inner join EmployeesPromotions on (EmployeesPromotions.employeeid = employees.employeeid)"
        GetData(0)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                Employees.DataGridView2.DataSource = ds.Tables(0)
            Else
                Employees.DataGridView2.DataSource = Nothing
            End If
        Else
            Employees.DataGridView2.DataSource = Nothing
        End If
    End Sub

    Private Sub EditEmployeesPromosions_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    
End Class