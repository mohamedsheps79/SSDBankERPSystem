Public Class EmployeesList

    Private Sub EmployeesList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        On Error Resume Next
        str = " Select EmployeeID,EmployeeCode,EmployeeName from employees "
        GetData(0)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                DataGridView1.DataSource = ds.Tables(0)
            Else
                DataGridView1.DataSource = Nothing
            End If
        Else
            DataGridView1.DataSource = Nothing
        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        On Error Resume Next
        str = " Select EmployeeID,EmployeeCode,EmployeeName from employees where EmployeeName like ('%" & TextBox2.Text.ToString & "%') or EmployeeCode like " & _
            " ('%" & TextBox2.Text.ToString & "%') "
        GetData(0)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                DataGridView1.DataSource = ds.Tables(0)
            Else
                DataGridView1.DataSource = Nothing
            End If
        Else
            DataGridView1.DataSource = Nothing
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
       
    End Sub

    Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView1.DoubleClick
        r1 = DataGridView1.CurrentCell.RowIndex
        EmployeeID = DataGridView1(0, r1).Value
        If formID = 1 Then
            EditEmployeesPromosions.TextBox1.Text = DataGridView1(1, r1).Value
            EditEmployeesPromosions.TextBox2.Text = DataGridView1(2, r1).Value
        ElseIf formID = 2 Then
            EditEmployeesMovements.TextBox1.Text = DataGridView1(1, r1).Value
            EditEmployeesMovements.TextBox2.Text = DataGridView1(2, r1).Value
        ElseIf formID = 3 Then
            EditEmployeesDocuments.TextBox1.Text = DataGridView1(1, r1).Value
            EditEmployeesDocuments.TextBox2.Text = DataGridView1(2, r1).Value
        ElseIf formID = 4 Then
            EditEmployeesHolidays.TextBox1.Text = DataGridView1(1, r1).Value
            EditEmployeesHolidays.TextBox2.Text = DataGridView1(2, r1).Value
        ElseIf formID = 5 Then
            EditEmployeesFinishings.TextBox1.Text = DataGridView1(1, r1).Value
            EditEmployeesFinishings.TextBox2.Text = DataGridView1(2, r1).Value
        ElseIf formID = 6 Then
            EditInvestigations.TextBox1.Text = DataGridView1(1, r1).Value
            EditInvestigations.TextBox2.Text = DataGridView1(2, r1).Value
        ElseIf formID = 7 Then
            PreviewReports.TextBox1.Text = DataGridView1(2, r1).Value
        ElseIf formID = 8 Then
            PreviewReports.TextBox2.Text = DataGridView1(2, r1).Value
        ElseIf formID = 9 Then
            PreviewReports.TextBox3.Text = DataGridView1(2, r1).Value
        ElseIf formID = 10 Then
            PreviewReports.TextBox4.Text = DataGridView1(2, r1).Value
        ElseIf formID = 11 Then
            PreviewReports.TextBox5.Text = DataGridView1(2, r1).Value
            EditEmployeePositions.TextBox1.Text = DataGridView1(1, r1).Value
            EditEmployeePositions.TextBox2.Text = DataGridView1(2, r1).Value

            On Error Resume Next
            str = "SELECT JobID,JobName from Jobs where JobID = (Select JobID FROM Employees where EmployeeID = " & EmployeeID & ") "
            GetData(0)
            If ds.Tables.Count > 0 Then
                If ds.Tables(0).Rows.Count > 0 Then
                    With EditEmployeePositions.ComboBox1
                        .DataSource = ds.Tables(0)
                        .DisplayMember = "JobName"
                        .ValueMember = "JobID"
                    End With
                Else
                    With EditEmployeePositions.ComboBox1
                        .DataSource = Nothing
                        .Items.Clear()
                    End With
                End If
            Else
                With EditEmployeePositions.ComboBox1
                    .DataSource = Nothing
                    .Items.Clear()
                End With
            End If

            str = "SELECT ClassID,ClassName from Classes where ClassID = (Select ClassID FROM Employees where EmployeeID = " & EmployeeID & ") "
            GetData(0)
            If ds.Tables.Count > 0 Then
                If ds.Tables(0).Rows.Count > 0 Then
                    With EditEmployeePositions.ComboBox2
                        .DataSource = ds.Tables(0)
                        .DisplayMember = "ClassName"
                        .ValueMember = "ClassID"
                    End With
                Else
                    With EditEmployeePositions.ComboBox2
                        .DataSource = Nothing
                        .Items.Clear()
                    End With
                End If
            Else
                With EditEmployeePositions.ComboBox2
                    .DataSource = Nothing
                    .Items.Clear()
                End With
            End If

        End If
        Me.Close()
    End Sub
End Class