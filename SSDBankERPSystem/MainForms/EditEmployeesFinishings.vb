Public Class EditEmployeesFinishings

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        formID = 5
        EmployeesList.TextBox2.Text = Nothing
        EmployeesList.ShowDialog()
    End Sub

    Private Sub ComboBox1_DropDown(sender As Object, e As EventArgs) Handles ComboBox1.DropDown
        GetFinishingTypes(ComboBox1)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If n = 0 Then
            str = " Insert into EmployeeFinishings values (" & EmployeeID & ", " & ComboBox1.SelectedValue & " ,  " & _
                " '" & DateTimePicker1.Value.Date.ToString("MM-dd-yyyy").ToString & "','" & TextBox3.Text.ToString & "'," & UserID & ",'','N')"
            Execute_Command()

            str = " Update Employees set EmployeeStatus = 'S' where EmployeeID = " & EmployeeID & ""
            Execute_Command()

            MsgBox("تم الحفظ")
        Else
            str = " Update EmployeeFinishings SET EmployeeID = " & EmployeeID & ",FinishingTypeID= " & ComboBox1.SelectedValue & " ,FinishingDate = " & _
                          " '" & DateTimePicker1.Value.Date.ToString("MM-dd-yyyy").ToString & "',Remarks= '" & TextBox3.Text.ToString & "', " & _
                          " Status = 'A' , AuthorizedBy = " & UserID & " where EmployeeFinishingID = " & Employees.DataGridView6(1, r).Value & " "
            Execute_Command()

            str = " Update Employees set EmployeeStatus = 'S' where EmployeeID = " & EmployeeID & ""
            Execute_Command()

            MsgBox("تم التعديل")

        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If MsgBox("هل تريد الحذف", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            str = " Delete from EmployeeFinishings where EmployeeFinishingID = " & Employees.DataGridView6(1, r).Value & " "
            Execute_Command()
            MsgBox("تم الحذف")
        Else
            Exit Sub
        End If
       
    End Sub

    Private Sub EditEmployeesFinishings_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        On Error Resume Next

        str = " select Employees.EmployeeID , Employees.EmployeeName , EmployeeFinishingID,FinishingTypeName,EmployeeFinishings.FinishingTypeID,EmployeeFinishings.FinishingDate,Remarks " & _
       ",EmployeeFinishings.Status from Employees,EmployeeFinishings,FinishingTypes where (EmployeeFinishings.EmployeeID = Employees.EmployeeID ) " & _
       " and (EmployeeFinishings.FinishingTypeID = FinishingTypes.FinishingTypeID )  "
        GetData(0)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                Employees.DataGridView6.DataSource = ds.Tables(0)
            Else
                Employees.DataGridView6.DataSource = Nothing
            End If
        Else
            Employees.DataGridView6.DataSource = Nothing
        End If
    End Sub

    Private Sub EditEmployeesFinishings_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class