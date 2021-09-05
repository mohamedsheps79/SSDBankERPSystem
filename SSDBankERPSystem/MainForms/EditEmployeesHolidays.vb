Public Class EditEmployeesHolidays

    Private Sub ComboBox1_DropDown(sender As Object, e As EventArgs) Handles ComboBox1.DropDown
        GetHolidaysTypes(ComboBox1)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        formID = 4
        EmployeesList.TextBox2.Text = Nothing
        EmployeesList.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If n = 0 Then
            str = " Insert into EmployeesHolidays values (" & EmployeeID & ", " & ComboBox1.SelectedValue & " ,  " & _
                " '" & DateTimePicker1.Value.Date.ToString("MM-dd-yyyy").ToString & "','" & DateTimePicker2.Value.Date.ToString("MM-dd-yyyy").ToString & "'," & UserID & ",'','N')"
            Execute_Command()

            MsgBox("تم الحفظ")
        Else
            str = " Update EmployeesHolidays SET EmployeeID = " & EmployeeID & ",HolidayTypeID= " & ComboBox1.SelectedValue & " ,HolidayBeginDate = " & _
                  " '" & DateTimePicker1.Value.Date.ToString("MM-dd-yyyy").ToString & "',HolidayEndDate= '" & DateTimePicker2.Value.Date.ToString("MM-dd-yyyy").ToString & "', " & _
                  " Status = 'A' , AuthorizedBy = " & UserID & " where EmployeeHolidayID = " & Employees.DataGridView5(1, r).Value & " "
            Execute_Command()
            MsgBox("تم التعديل")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If MsgBox("هل تريد الحذف", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            str = " Delete from EmployeesHolidays where EmployeeHolidayID = " & Employees.DataGridView5(1, r).Value & "  "
            Execute_Command()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub EditEmployeesHolidays_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        str = " select Employees.EmployeeID , Employees.EmployeeName , EmployeeHolidayID,HolidayName,EmployeesHolidays.HolidayTypeID,EmployeesHolidays.HolidayBeginDate,HolidayEndDate " & _
            " ,EmployeesHolidays.Status from Employees,EmployeesHolidays,HolidaysTypes where (EmployeesHolidays.EmployeeID = Employees.EmployeeID ) " & _
            " and (EmployeesHolidays.HolidayTypeID = HolidaysTypes.HolidayTypeID ) "
        GetData(0)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                Employees.DataGridView5.DataSource = ds.Tables(0)
            Else
                Employees.DataGridView5.DataSource = Nothing
            End If
        Else
            Employees.DataGridView5.DataSource = Nothing
        End If
    End Sub

    Private Sub EditEmployeesHolidays_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class