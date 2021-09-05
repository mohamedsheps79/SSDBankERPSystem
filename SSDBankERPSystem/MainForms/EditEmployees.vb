Public Class EditEmployees

    Private Sub ComboBox1_DropDown(sender As Object, e As EventArgs) Handles ComboBox1.DropDown
        GetBranches(ComboBox1)
    End Sub

    Private Sub ComboBox2_DropDown(sender As Object, e As EventArgs) Handles ComboBox2.DropDown
        GetDepartments(ComboBox1, ComboBox2)
    End Sub

    Private Sub ComboBox4_DropDown(sender As Object, e As EventArgs) Handles ComboBox4.DropDown
        GetRanges(ComboBox4)
    End Sub

    Private Sub ComboBox3_DropDown(sender As Object, e As EventArgs) Handles ComboBox3.DropDown
        GetDegrees(ComboBox3)
    End Sub

    Private Sub ComboBox5_DropDown(sender As Object, e As EventArgs) Handles ComboBox5.DropDown
        GetQualifications(ComboBox5)
    End Sub

    Private Sub ComboBox8_DropDown(sender As Object, e As EventArgs) Handles ComboBox8.DropDown
        GetClasses(ComboBox7, ComboBox8)
    End Sub

    Private Sub ComboBox7_DropDown(sender As Object, e As EventArgs) Handles ComboBox7.DropDown
        GetJobs(ComboBox7)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If n = 0 Then
            str = " Insert into Employees values (" & ComboBox1.SelectedValue & ", " & ComboBox2.SelectedValue & " , " & TextBox1.Text & " , '" & TextBox11.Text & " " & TextBox4.Text & " " & TextBox5.Text & " " & TextBox6.Text & "', " & _
                " '" & DateTimePicker1.Value.Date.ToString("MM-dd-yyyy").ToString & "', '" & DateTimePicker2.Value.Date.ToString("MM-dd-yyyy").ToString & "' , " & _
                " " & ComboBox3.SelectedValue & " , " & ComboBox4.SelectedValue & " , " & ComboBox5.SelectedValue & " ,'" & TextBox3.Text.ToString & "', " & _
                " '" & WhatRadioIsSelected(GroupBox1) & "', '" & ComboBox6.Text & "' , '" & TextBox8.Text & "','" & TextBox7.Text & "' ," & _
                " " & ComboBox7.SelectedValue & " , " & ComboBox8.SelectedValue & ",'A'," & TextBox10.Text & ", " & UserID & " , '','N',0,'" & TextBox11.Text.ToString & "', " & _
                " '" & TextBox4.Text.ToString & "' , '" & TextBox5.Text.ToString & "' , '" & TextBox6.Text.ToString & "','" & TextBox12.Text.ToString & "','" & TextBox13.Text.ToString & "')"
            Execute_Command()
            MsgBox("تم الحفظ")
        Else
            str = " Update Employees set BranchID = " & ComboBox1.SelectedValue & ", " & _
                  " DepartmentID= " & ComboBox2.SelectedValue & " , EmployeeCode=" & TextBox1.Text & " , " & _
                  " EmployeeName = '" & TextBox11.Text & " " & TextBox4.Text & " " & TextBox5.Text & " " & TextBox6.Text & "', " & _
                  " BirthDate = '" & DateTimePicker1.Value.Date.ToString("MM-dd-yyyy").ToString & "', HireDate='" & DateTimePicker2.Value.Date.ToString("MM-dd-yyyy").ToString & "' , " & _
                  " DegreeID= " & ComboBox3.SelectedValue & " ,RangeID= " & ComboBox4.SelectedValue & " , QualificationID =" & ComboBox5.SelectedValue & " , " & _
                  " Specialization='" & TextBox3.Text.ToString & "', " & _
                  " Gender='" & WhatRadioIsSelected(GroupBox1) & "' , ScocialStatus='" & ComboBox6.Text & "', email='" & TextBox8.Text & "', " & _
                  " PhoneNo= '" & TextBox7.Text & "' ,  JobID= " & ComboBox7.SelectedValue & " ,  " & _
                  " " & _
                  " ClassID=" & ComboBox8.SelectedValue & ", children=" & TextBox10.Text & " , EnteredBy = " & UserID & " , " & _
                  " Status = 'A' , FirstName = '" & TextBox11.Text.ToString & "' , SecondName = '" & TextBox4.Text.ToString & "' , " & _
                  " ThirdName= '" & TextBox5.Text.ToString & "' , ForthName = '" & TextBox6.Text.ToString & "' , GeneralNo = '" & TextBox12.Text.ToString & "', " & _
                  " SpecialNo = '" & TextBox13.Text.ToString & "' where  Employeeid = " & Employees.DataGridView1(1, r).Value & " "
            Execute_Command()
            MsgBox("تم التعديل")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If MsgBox("هل تريد الحذف", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            str = " Delete from Employees where EmployeeID = " & Employees.DataGridView1(1, r).Value & " "
            Execute_Command()
            MsgBox("تم التصريح")
        Else
            Exit Sub
        End If
    End Sub

    Private Sub EditEmployees_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        On Error Resume Next
        str = " Select * from Employees "
        GetData(0)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                Employees.DataGridView1.DataSource = ds.Tables(0)
            Else
                Employees.DataGridView1.DataSource = Nothing
            End If
        Else
            Employees.DataGridView1.DataSource = Nothing
        End If
    End Sub

    Shared Function TextBox9() As Object
        Throw New NotImplementedException
    End Function

    Private Sub EditEmployees_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class