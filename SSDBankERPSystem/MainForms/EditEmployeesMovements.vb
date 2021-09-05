Public Class EditEmployeesMovements

    Private Sub ComboBox1_DropDown(sender As Object, e As EventArgs) Handles ComboBox1.DropDown
        GetBranches(ComboBox1)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        On Error GoTo fb
        GetDepartments(ComboBox1, ComboBox2)
fb:
    End Sub

    Private Sub ComboBox2_DropDown(sender As Object, e As EventArgs) Handles ComboBox2.DropDown
        GetDepartments(ComboBox1, ComboBox2)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        formID = 2
        EmployeesList.TextBox2.Text = Nothing
        EmployeesList.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If n = 0 Then
            str = " Insert into EmployeesMovements values (" & EmployeeID & "," & ComboBox4.SelectedValue & " , " & ComboBox1.SelectedValue & " , " & _
                " " & ComboBox5.SelectedValue & " ," & ComboBox2.SelectedValue & ", " & ComboBox3.SelectedValue & " , " & _
                " '" & DateTimePicker1.Value.Date.ToString("MM-dd-yyyy").ToString & "','" & TextBox3.Text.ToString & "'," & UserID & ",'','N')"
            Execute_Command()

            str = " Update Employees set BranchID = " & ComboBox1.SelectedValue & ",DepartmentID= " & ComboBox2.SelectedValue & " " & _
                  ", ClassID=" & ComboBox3.SelectedValue & "  where EmployeeID = " & EmployeeID & " "
            Execute_Command()

            MsgBox("تم الحفظ")
        Else
            str = " Update EmployeesMovements SET EmployeeID = " & EmployeeID & ",fromBranchID = " & ComboBox4.SelectedValue & " ,BranchID= " & ComboBox1.SelectedValue & ", " & _
        " FromDepartmentID = " & ComboBox5.SelectedValue & " ,DepartmentID =" & ComboBox2.SelectedValue & ", " & _
        " MoveDate = '" & DateTimePicker1.Value.Date.ToString("MM-dd-yyyy").ToString & "', ClassID = " & ComboBox3.SelectedValue & " , " & _
        " Remarks = '" & TextBox3.Text.ToString & "' , Status = 'A' , AuthorizedBy = " & UserID & " where MoveID = " & Employees.DataGridView3(1, r).Value & " "
            Execute_Command()

            str = " Update Employees set BranchID = " & ComboBox1.SelectedValue & ",DepartmentID= " & ComboBox2.SelectedValue & " " & _
         ", ClassID=" & ComboBox3.SelectedValue & "  where EmployeeID = " & EmployeeID & " "
            Execute_Command()

            MsgBox("تم التعديل")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If MsgBox("هل تريد الحذف", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            str = " Delete from EmployeesMovements where MoveID = " & Employees.DataGridView3(1, r).Value & ""
            Execute_Command()
            MsgBox("تم الحذف")
        Else
            Exit Sub
        End If

    End Sub

    Private Sub EditEmployeesMovements_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        str = " Select EmployeeName,MoveID,EmployeesMovements.EmployeeID,EmployeesMovements.BranchID,EmployeesMovements.DepartmentID, " & _
                  " MoveDate, Remarks, BranchName, DepartmentName,EmployeesMovements.ClassID,EmployeesMovements.Status from employees inner join EmployeesMovements  on " & _
                  " (EmployeesMovements.employeeid = employees.employeeid) inner join DepartmentS on (Employees.DepartmentID = DepaRtments.DepartmentID) " & _
                  " INNER JOIN Branches on (Departments.BranchID = Branches.BranchID)"
        GetData(0)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                Employees.DataGridView3.DataSource = ds.Tables(0)
            Else
                Employees.DataGridView3.DataSource = Nothing
            End If
        Else
            Employees.DataGridView3.DataSource = Nothing
        End If
    End Sub

    Private Sub EditEmployeesMovements_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ComboBox3_DropDown(sender As Object, e As EventArgs) Handles ComboBox3.DropDown
        str = " Select ClassID, ClassName from Classes where JobID = (Select jobID From Employees where EmployeeID = " & EmployeeID & " )"
        GetData(0)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                With ComboBox3
                    .DataSource = ds.Tables(0)
                    .DisplayMember = "ClassName"
                    .ValueMember = "ClassID"
                End With
            Else
                With ComboBox3
                    .DataSource = Nothing
                    .Items.Clear()
                End With
            End If
        Else
            With ComboBox3
                .DataSource = Nothing
                .Items.Clear()
            End With
        End If
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        On Error Resume Next
        str = "SELECT BranchID,BranchName from Branches where BranchID = (Select BranchID FROM Employees where EmployeeID = " & EmployeeID & ") "
        GetData(0)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                With ComboBox4
                    .DataSource = ds.Tables(0)
                    .DisplayMember = "BranchName"
                    .ValueMember = "BranchID"
                End With
            Else
                With ComboBox4
                    .DataSource = Nothing
                    .Items.Clear()
                End With
            End If
        Else
            With ComboBox4
                .DataSource = Nothing
                .Items.Clear()
            End With
        End If

        str = "SELECT DepartmentID,DepartmentName from Departments where DepartmentID = (Select DepartmentID FROM Employees where EmployeeID = " & EmployeeID & ") "
        GetData(0)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                With ComboBox5
                    .DataSource = ds.Tables(0)
                    .DisplayMember = "DepartmentName"
                    .ValueMember = "DepartmentID"
                End With
            Else
                With ComboBox5
                    .DataSource = Nothing
                    .Items.Clear()
                End With
            End If
        Else
            With ComboBox5
                .DataSource = Nothing
                .Items.Clear()
            End With
        End If

    End Sub
End Class