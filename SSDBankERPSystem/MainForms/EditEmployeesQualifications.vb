Imports System.IO
Public Class EditEmployeesQualifications

    Private Sub ComboBox1_DropDown(sender As Object, e As EventArgs) Handles ComboBox1.DropDown
        GetQualifications(ComboBox1)
    End Sub

    Private Sub EditEmployeesQualifications_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        str = " Select EmployeesQualifications.EmployeeQualificationID,EmployeesQualifications.EmployeeID,EmployeesQualifications.QualID AS QualID,IssueDate," & _
               " EmployeeName,Country, Country,City,Institute,Faculty,EmployeesQualifications.Specialization,QualificationName from EmployeesQualifications, employees,Qualifications " & _
               " where Employees.EmployeeID = EmployeesQualifications.employeeID And Qualifications.QualificationID = EmployeesQualifications.QualID "
        GetData(0)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                Employees.DataGridView10.DataSource = ds.Tables(0)
            Else
                Employees.DataGridView10.DataSource = Nothing
            End If
        Else
            Employees.DataGridView10.DataSource = Nothing
        End If
    End Sub

    Private Sub EditEmployeesQualifications_Load(sender As Object, e As EventArgs) Handles MyBase.Load
       
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        formID = 13
        EmployeesList.TextBox2.Text = Nothing
        EmployeesList.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If n = 0 Then
            str = " Insert into EmployeesQualifications values (" & EmployeeID & "," & ComboBox1.SelectedValue & " ,'" & DateTimePicker1.Value.Date.ToString("MM-dd-yyyy").ToString & "', " & _
                " '" & TextBox3.Text & "' ,'" & TextBox4.Text & "' , '" & TextBox5.Text & "' ,'" & TextBox6.Text & "','" & TextBox7.Text & "')"
            Execute_Command()
            MsgBox("تم الحفظ")
        Else
            str = " Update EmployeesQualifications SET EmployeeID= " & EmployeeID & ", QualID = " & ComboBox1.SelectedValue & " , " & _
                " IssueDate= '" & DateTimePicker1.Value.Date.ToString("MM-dd-yyyy").ToString & "',Country = '" & TextBox3.Text & "' , " & _
                " City='" & TextBox4.Text & "' , Institute= '" & TextBox5.Text & "' ,Faculty= '" & TextBox6.Text & "',Specialization = '" & TextBox7.Text & "' " & _
                " where EmployeeQualificationID = " & Employees.DataGridView10(1, r).Value & " "
            Execute_Command()
            MsgBox("تم التعديل")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If MsgBox("هل تريد الحذف", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            str = " Delete from EmployeesQualifications where EmployeeQualificationID = " & Employees.DataGridView10(1, r).Value & "  "
            Execute_Command()
            MsgBox("تم الحذف")
        Else
            Exit Sub
        End If
    End Sub
End Class