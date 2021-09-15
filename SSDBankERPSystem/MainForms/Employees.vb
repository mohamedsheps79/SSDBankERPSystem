Imports System.IO
Public Class Employees

    Private Sub Employees_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        str = " Select * from Employees where employeeStatus ='A' "
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

    Private Sub ToolStripComboBox3_Click(sender As Object, e As EventArgs) Handles ToolStripComboBox3.Click

    End Sub

    Private Sub ToolStripComboBox3_DropDown(sender As Object, e As EventArgs) Handles ToolStripComboBox3.DropDown
        GetBranches(ToolStripComboBox3.ComboBox)
    End Sub

    Private Sub ToolStripTextBox5_Click(sender As Object, e As EventArgs) Handles ToolStripTextBox5.Click
        ToolStripTextBox5.Text = Nothing
    End Sub

    Private Sub ToolStripTextBox5_TextChanged(sender As Object, e As EventArgs) Handles ToolStripTextBox5.TextChanged
        On Error Resume Next
        str = " Select * from Employees where EmployeeName like ('%" & ToolStripTextBox5.Text & "%')"

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

    Private Sub ToolStripComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ToolStripComboBox3.SelectedIndexChanged
        On Error GoTo fb
        GetDepartments(ToolStripComboBox3.ComboBox, ToolStripComboBox1.ComboBox)
        str = " Select * from Employees where BranchID = " & ToolStripComboBox3.ComboBox.SelectedValue & " "

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
fb:
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click

        n = 0
        EditEmployees.TextBox1.Text = Nothing
        EditEmployees.TextBox2.Text = Nothing
        EditEmployees.ComboBox1.DataSource = Nothing
        EditEmployees.ComboBox1.Items.Clear()
        EditEmployees.ComboBox2.DataSource = Nothing
        EditEmployees.ComboBox2.Items.Clear()
        EditEmployees.DateTimePicker1.Value = Date.Today
        EditEmployees.DateTimePicker2.Value = Date.Today
        EditEmployees.ComboBox3.DataSource = Nothing
        EditEmployees.ComboBox3.Items.Clear()
        EditEmployees.ComboBox4.DataSource = Nothing
        EditEmployees.ComboBox4.Items.Clear()
        EditEmployees.ComboBox5.DataSource = Nothing
        EditEmployees.ComboBox5.Items.Clear()
        EditEmployees.TextBox3.Text = Nothing
        EditEmployees.ComboBox6.Text = Nothing
        EditEmployees.TextBox8.Text = Nothing
        EditEmployees.TextBox4.Text = Nothing
        EditEmployees.TextBox5.Text = Nothing
        EditEmployees.TextBox6.Text = Nothing
        EditEmployees.TextBox7.Text = Nothing
        EditEmployees.ComboBox7.DataSource = Nothing
        EditEmployees.ComboBox7.Items.Clear()
        EditEmployees.ComboBox8.DataSource = Nothing
        EditEmployees.ComboBox8.Items.Clear()
        EditEmployees.TextBox11.Text = Nothing
        EditEmployees.TextBox12.Text = Nothing
        EditEmployees.TextBox13.Text = Nothing
        EditEmployees.ShowDialog()


    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        On Error Resume Next
        n = 1
        r = DataGridView1.CurrentCell.RowIndex
        EditEmployees.TextBox1.Text = DataGridView1(4, r).Value
        EditEmployees.TextBox2.Text = DataGridView1(5, r).Value
        GetBranches(EditEmployees.ComboBox1)
        EditEmployees.ComboBox1.SelectedValue = DataGridView1(2, r).Value
        GetDepartments(EditEmployees.ComboBox1, EditEmployees.ComboBox2)
        EditEmployees.ComboBox2.SelectedValue = DataGridView1(3, r).Value
        EditEmployees.DateTimePicker1.Value = DataGridView1(6, r).Value
        EditEmployees.DateTimePicker2.Value = DataGridView1(7, r).Value
        GetDegrees(EditEmployees.ComboBox3)
        EditEmployees.ComboBox3.SelectedValue = DataGridView1(8, r).Value
        GetRanges(EditEmployees.ComboBox4)
        EditEmployees.ComboBox4.SelectedValue = DataGridView1(9, r).Value
        GetQualifications(EditEmployees.ComboBox5)
        EditEmployees.ComboBox5.SelectedValue = DataGridView1(10, r).Value
        EditEmployees.TextBox3.Text = DataGridView1(11, r).Value
        If Trim(DataGridView1(12, r).Value.ToString) = "ذكر" Then
            EditEmployees.RadioButton1.Checked = True
        Else
            EditEmployees.RadioButton2.Checked = True
        End If

        EditEmployees.ComboBox6.Text = Trim(DataGridView1(13, r).Value.ToString)
        EditEmployees.TextBox8.Text = DataGridView1(14, r).Value
        EditEmployees.TextBox7.Text = DataGridView1(15, r).Value
        GetJobs(EditEmployees.ComboBox7)
        EditEmployees.ComboBox7.SelectedValue = DataGridView1(16, r).Value
        GetClasses(EditEmployees.ComboBox7, EditEmployees.ComboBox8)
        EditEmployees.ComboBox8.SelectedValue = DataGridView1(17, r).Value

        str = " select children,FirstName,SecondName,ThirdName,ForthName,GeneralNo,SpecialNo from employees where EmployeeID = " & Me.DataGridView1(1, r).Value & ""
        GetData(0)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                EditEmployees.TextBox10.Text = ds.Tables(0).Rows(0)(0)
                EditEmployees.TextBox11.Text = ds.Tables(0).Rows(0)(1)
                EditEmployees.TextBox4.Text = ds.Tables(0).Rows(0)(2)
                EditEmployees.TextBox5.Text = ds.Tables(0).Rows(0)(3)
                EditEmployees.TextBox6.Text = ds.Tables(0).Rows(0)(4)
                EditEmployees.TextBox12.Text = ds.Tables(0).Rows(0)(5)
                EditEmployees.TextBox13.Text = ds.Tables(0).Rows(0)(6)
            Else
                EditEmployees.TextBox10.Text = 0
            End If
        Else
            EditEmployees.TextBox10.Text = 0
        End If


        EditEmployees.ShowDialog()
    End Sub


    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        ExportEmployees.ShowDialog()
    End Sub

    Private Sub ToolStripComboBox1_Click(sender As Object, e As EventArgs) Handles ToolStripComboBox1.Click

    End Sub

    Private Sub ToolStripComboBox1_DropDown(sender As Object, e As EventArgs) Handles ToolStripComboBox1.DropDown
        On Error GoTo FB
        GetDepartments(ToolStripComboBox3.ComboBox, ToolStripComboBox1.ComboBox)
FB:
    End Sub

    Private Sub ToolStripComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ToolStripComboBox1.SelectedIndexChanged
        On Error Resume Next
        str = " Select * from Employees where DepartmentID = " & ToolStripComboBox1.ComboBox.SelectedValue & " "

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

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        n = 0
        EditEmployeesPromosions.TextBox1.Text = Nothing
        EditEmployeesPromosions.TextBox2.Text = Nothing
        EditEmployeesPromosions.ComboBox1.DataSource = Nothing
        EditEmployeesPromosions.ComboBox1.Items.Clear()
        EditEmployeesPromosions.ComboBox2.DataSource = Nothing
        EditEmployeesPromosions.ComboBox2.Items.Clear()
        EditEmployeesPromosions.DateTimePicker1.Value = Date.Today
        EditEmployeesPromosions.TextBox3.Text = Nothing
        EditEmployeesPromosions.TextBox4.Text = Nothing
        EditEmployeesPromosions.DateTimePicker2.Value = Date.Today
        EditEmployeesPromosions.PictureBox1.Image = My.Resources.Document
        EditEmployeesPromosions.ShowDialog()
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        'On Error Resume Next
        n = 1
        r = DataGridView2.CurrentCell.RowIndex
        EmployeeID = DataGridView2(2, r).Value
        str = " Select EmployeeCode from employees where EmployeeID = " & DataGridView2(2, r).Value
        GetData(0)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                EditEmployeesPromosions.TextBox1.Text = ds.Tables(0).Rows(0)(0)
            Else
                EditEmployeesPromosions.TextBox1.Text = Nothing
            End If
        Else
            EditEmployeesPromosions.TextBox1.Text = Nothing
        End If
        EditEmployeesPromosions.TextBox2.Text = DataGridView2(3, r).Value
        GetDegrees(EditEmployeesPromosions.ComboBox1)
        EditEmployeesPromosions.ComboBox1.SelectedValue = DataGridView2(4, r).Value
        GetRanges(EditEmployeesPromosions.ComboBox2)
        EditEmployeesPromosions.ComboBox2.SelectedValue = DataGridView2(5, r).Value
        EditEmployeesPromosions.DateTimePicker1.Value = DataGridView2(6, r).Value
        EditEmployeesPromosions.ComboBox3.Text = Trim(DataGridView2(7, r).Value)
        EditEmployeesPromosions.TextBox3.Text = DataGridView2(8, r).Value
        str = " Select DecisionNo,DecisionDate,PromoteDocument from EmployeesPromotions where EmployeeID = " & DataGridView2(2, r).Value & " and PromoteID= " & DataGridView2(1, r).Value
        GetData(0)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                EditEmployeesPromosions.TextBox4.Text = ds.Tables(0).Rows(0)(0)
                Dim data As Byte() = DirectCast(ds.Tables(0).Rows(0)("PromoteDocument"), Byte())
                Dim ms As New MemoryStream(data)
                EditEmployeesPromosions.PictureBox1.Image = Image.FromStream(ms)
                EditEmployeesPromosions.DateTimePicker2.Value = ds.Tables(0).Rows(0)("DecisionDate")
            Else
                EditEmployeesPromosions.TextBox4.Text = Nothing
            End If
        Else
            EditEmployeesPromosions.TextBox4.Text = Nothing
        End If
        EditEmployeesPromosions.ShowDialog()
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 0 Then
            str = " Select * from Employees"
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
        ElseIf TabControl1.SelectedIndex = 1 Then
            str = " Select EmployeeName,PromoteID,EmployeesPromotions.EmployeeID,EmployeesPromotions.DegreeID,EmployeesPromotions.RangeID,PromoteDate,PromoteType,Remarks,EmployeesPromotions.Status  " & _
               " from employees inner join EmployeesPromotions on (EmployeesPromotions.employeeid = employees.employeeid)"
            GetData(0)
            If ds.Tables.Count > 0 Then
                If ds.Tables(0).Rows.Count > 0 Then
                    DataGridView2.DataSource = ds.Tables(0)
                Else
                    DataGridView2.DataSource = Nothing
                End If
            Else
                DataGridView2.DataSource = Nothing
            End If
        ElseIf TabControl1.SelectedIndex = 2 Then
            str = " Select EmployeeName,MoveID,EmployeesMovements.EmployeeID,EmployeesMovements.BranchID,EmployeesMovements.DepartmentID, " & _
                      " MoveDate, Remarks, BranchName, DepartmentName,EmployeesMovements.ClassID,EmployeesMovements.Status from employees inner join EmployeesMovements  on " & _
                      " (EmployeesMovements.employeeid = employees.employeeid) inner join DepartmentS on (Employees.DepartmentID = DepaRtments.DepartmentID) " & _
                      " INNER JOIN Branches on (Departments.BranchID = Branches.BranchID)"
            GetData(0)
            If ds.Tables.Count > 0 Then
                If ds.Tables(0).Rows.Count > 0 Then
                    DataGridView3.DataSource = ds.Tables(0)
                Else
                    DataGridView3.DataSource = Nothing
                End If
            Else
                DataGridView3.DataSource = Nothing
            End If
        ElseIf TabControl1.SelectedIndex = 3 Then
            str = " select Employees.EmployeeID , Employees.EmployeeName , EmployeesDocuments.DocumentID, DocumentName,EmployeeDocumentID," & _
               " DocumentContent,Remarks,EmployeesDocuments.Status from Employees inner join EmployeesDocuments on (EmployeesDocuments.EmployeeID = Employees.EmployeeID ) " & _
               " inner join DocumentsTypes on (EmployeesDocuments.DocumentID = DocumentsTypes.DocumentTypeID ) "
            GetData(0)
            If ds.Tables.Count > 0 Then
                If ds.Tables(0).Rows.Count > 0 Then
                    DataGridView4.DataSource = ds.Tables(0)
                Else
                    DataGridView4.DataSource = Nothing
                End If
            Else
                DataGridView4.DataSource = Nothing
            End If
        ElseIf TabControl1.SelectedIndex = 4 Then
            str = " select Employees.EmployeeID , Employees.EmployeeName , EmployeeHolidayID,HolidayName,EmployeesHolidays.HolidayTypeID,  " & _
                    " EmployeesHolidays.HolidayBeginDate, HolidayEndDate ,EmployeesHolidays.Status from Employees,EmployeesHolidays,HolidaysTypes where " & _
                    " (EmployeesHolidays.EmployeeID = Employees.EmployeeID )  and (EmployeesHolidays.HolidayTypeID = HolidaysTypes.HolidayTypeID ) "
            GetData(0)
            If ds.Tables.Count > 0 Then
                If ds.Tables(0).Rows.Count > 0 Then
                    DataGridView5.DataSource = ds.Tables(0)
                Else
                    DataGridView5.DataSource = Nothing
                End If
            Else
                DataGridView5.DataSource = Nothing
            End If
        ElseIf TabControl1.SelectedIndex = 5 Then

            str = " select Employees.EmployeeID , Employees.EmployeeName , EmployeeFinishingID,FinishingTypeName,EmployeeFinishings.FinishingTypeID,EmployeeFinishings.FinishingDate,Remarks " & _
           ",EmployeeFinishings.Status from Employees,EmployeeFinishings,FinishingTypes where (EmployeeFinishings.EmployeeID = Employees.EmployeeID ) " & _
           " and (EmployeeFinishings.FinishingTypeID = FinishingTypes.FinishingTypeID ) "
            GetData(0)
            If ds.Tables.Count > 0 Then
                If ds.Tables(0).Rows.Count > 0 Then
                    DataGridView6.DataSource = ds.Tables(0)
                Else
                    DataGridView6.DataSource = Nothing
                End If
            Else
                DataGridView6.DataSource = Nothing
            End If
        ElseIf TabControl1.SelectedIndex = 6 Then
            str = " Select Investigations.InvestigationID,Infraction,InfractionDate,Investigations.EmployeeID,EmployeeName,InvestigationDate,Investigations.Decision,DecisionDate,Adversary " & _
                       " ,AdversaryInterval,Investigations.Status from Investigations, employees where employees.EmployeeID = Investigations.employeeID "
            GetData(0)
            If ds.Tables.Count > 0 Then
                If ds.Tables(0).Rows.Count > 0 Then
                    DataGridView7.DataSource = ds.Tables(0)
                Else
                    DataGridView7.DataSource = Nothing
                End If
            Else
                DataGridView7.DataSource = Nothing
            End If
        ElseIf TabControl1.SelectedIndex = 7 Then
            str = " Select EmployeePositions.positionID,EmployeePositions.EmployeeID,FromJobID,J1.JobName JobName1,EmployeePositions.JobID, J2.JobName as JobName2,FromClassID,C1.className as className1, " & _
                  " EmployeePositions.ClassID,C2.className as className2 ,PositionDate,EmployeeName,EmployeePositions.Status " & _
                  " from  EmployeePositions,Employees, Jobs j1, jobs j2,Classes C1,Classes C2 WHERE " & _
                  " Employees.EmployeeID = EmployeePositions.EmployeeID AND" & _
                  " EmployeePositions.FromJobID = J1.JOBID AND EmployeePositions.JobID = J2.JobID AND EmployeePositions.FromClassID = C1.ClassID AND " & _
                  " EmployeePositions.ClassID = C2.ClassID AND J1.JOBID = C1.JOBID AND J2.JOBID = C2.JOBID "
            GetData(0)
            If ds.Tables.Count > 0 Then
                If ds.Tables(0).Rows.Count > 0 Then
                    DataGridView8.DataSource = ds.Tables(0)
                Else
                    DataGridView8.DataSource = Nothing
                End If
            Else
                DataGridView8.DataSource = Nothing
            End If
        ElseIf TabControl1.SelectedIndex = 8 Then
            str = " Select EmployeesTrainings.TrainingID,EmployeesTrainings.EmployeeID,TrainingName,EmployeeName,BeginDate,EndDate,TrainingPlace,DecisionNo " & _
                       " ,DecisionDate,DecisionDocument from EmployeesTrainings, employees where employees.EmployeeID = EmployeesTrainings.employeeID "
            GetData(0)
            If ds.Tables.Count > 0 Then
                If ds.Tables(0).Rows.Count > 0 Then
                    DataGridView9.DataSource = ds.Tables(0)
                Else
                    DataGridView9.DataSource = Nothing
                End If
            Else
                DataGridView9.DataSource = Nothing
            End If
        ElseIf TabControl1.SelectedIndex = 9 Then
            str = " Select EmployeesQualifications.EmployeeQualificationID,EmployeesQualifications.EmployeeID,EmployeesQualifications.QualID AS QualID,IssueDate," & _
                " EmployeeName,Country, Country,City,Institute,Faculty,EmployeesQualifications.Specialization,QualificationName from EmployeesQualifications, employees,Qualifications " & _
                " where Employees.EmployeeID = EmployeesQualifications.employeeID And Qualifications.QualificationID = EmployeesQualifications.QualID "
            GetData(0)
            If ds.Tables.Count > 0 Then
                If ds.Tables(0).Rows.Count > 0 Then
                    DataGridView10.DataSource = ds.Tables(0)
                Else
                    DataGridView10.DataSource = Nothing
                End If
            Else
                DataGridView10.DataSource = Nothing
            End If
        End If
    End Sub

    Private Sub ToolStripTextBox2_Click(sender As Object, e As EventArgs) Handles ToolStripTextBox2.Click
        ToolStripTextBox2.Text = Nothing
    End Sub

    Private Sub ToolStripTextBox2_TextChanged(sender As Object, e As EventArgs) Handles ToolStripTextBox2.TextChanged
        On Error Resume Next
        str = " Select EmployeeName,PromoteID,EmployeesPromotions.EmployeeID,EmployeesPromotions.DegreeID,EmployeesPromotions.RangeID,PromoteDate,PromoteType,Remarks,EmployeesPromotions.Status  " & _
                  " from employees inner join EmployeesPromotions on (EmployeesPromotions.employeeid = employees.employeeid) where " & _
                  " EmployeeName like ('%" & ToolStripTextBox2.Text.ToString & "%') or EmployeeCode = " & ToolStripTextBox2.Text.ToString & " "
        GetData(0)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                DataGridView2.DataSource = ds.Tables(0)
            Else
                DataGridView2.DataSource = Nothing
            End If
        Else
            DataGridView2.DataSource = Nothing
        End If
    End Sub

    Private Sub DataGridView3_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView3.CellContentClick
        n = 1
        r = DataGridView3.CurrentCell.RowIndex
        EmployeeID = DataGridView3(2, r).Value
        str = " Select EmployeeCode from employees where EmployeeID = " & DataGridView3(2, r).Value
        GetData(0)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                EditEmployeesMovements.TextBox1.Text = ds.Tables(0).Rows(0)(0)
            Else
                EditEmployeesMovements.TextBox1.Text = Nothing
            End If
        Else
            EditEmployeesMovements.TextBox1.Text = Nothing
        End If
        EditEmployeesMovements.TextBox2.Text = DataGridView3(3, r).Value
        GetBranches(EditEmployeesMovements.ComboBox1)
        EditEmployeesMovements.ComboBox1.SelectedValue = DataGridView3(8, r).Value
        GetDepartments(EditEmployeesMovements.ComboBox1, EditEmployeesMovements.ComboBox2)
        EditEmployeesMovements.ComboBox2.SelectedValue = DataGridView3(9, r).Value

        str = "SELECT BranchID,BranchName from Branches where BranchID = (Select BranchID FROM Employees where EmployeeID = " & EmployeeID & ") "
        GetData(0)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                With EditEmployeesMovements.ComboBox4
                    .DataSource = ds.Tables(0)
                    .DisplayMember = "BranchName"
                    .ValueMember = "BranchID"
                End With
            Else
                With EditEmployeesMovements.ComboBox4
                    .DataSource = Nothing
                    .Items.Clear()
                End With
            End If
        Else
            With EditEmployeesMovements.ComboBox4
                .DataSource = Nothing
                .Items.Clear()
            End With
        End If

        str = "SELECT DepartmentID,DepartmentName from Departments where DepartmentID = (Select DepartmentID FROM Employees where EmployeeID = " & EmployeeID & ") "
        GetData(0)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                With EditEmployeesMovements.ComboBox5
                    .DataSource = ds.Tables(0)
                    .DisplayMember = "DepartmentName"
                    .ValueMember = "DepartmentID"
                End With
            Else
                With EditEmployeesMovements.ComboBox5
                    .DataSource = Nothing
                    .Items.Clear()
                End With
            End If
        Else
            With EditEmployeesMovements.ComboBox5
                .DataSource = Nothing
                .Items.Clear()
            End With
        End If


        EditEmployeesMovements.DateTimePicker1.Value = DataGridView3(6, r).Value
        EditEmployeesMovements.TextBox3.Text = DataGridView3(7, r).Value

        str = " Select ClassID, ClassName from Classes where JobID = (Select jobID From Employees where EmployeeID = " & DataGridView3(2, r).Value & " )"
        GetData(0)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                With EditEmployeesMovements.ComboBox3
                    .DataSource = ds.Tables(0)
                    .DisplayMember = "ClassName"
                    .ValueMember = "ClassID"
                End With
            Else
                With EditEmployeesMovements.ComboBox3
                    .DataSource = Nothing
                    .Items.Clear()
                End With
            End If
        Else
            With EditEmployeesMovements.ComboBox3
                .DataSource = Nothing
                .Items.Clear()
            End With
        End If
        EditEmployeesMovements.ComboBox3.SelectedValue = DataGridView3(10, r).Value

        str = " Select DecisionNo,DecisionDate,MovementDocument from EmployeesMovements where EmployeeID = " & DataGridView3(2, r).Value & " and " & _
            " MoveID = " & DataGridView3(1, r).Value & ""
        GetData(0)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                EditEmployeesMovements.TextBox4.Text = ds.Tables(0).Rows(0)(0)
                Dim data As Byte() = DirectCast(ds.Tables(0).Rows(0)("MovementDocument"), Byte())
                Dim ms As New MemoryStream(data)
                EditEmployeesMovements.PictureBox1.Image = Image.FromStream(ms)
                EditEmployeesMovements.DateTimePicker2.Value = ds.Tables(0).Rows(0)("DecisionDate")
            Else
                EditEmployeesPromosions.TextBox4.Text = Nothing
            End If
        Else
            EditEmployeesPromosions.TextBox4.Text = Nothing
        End If

        EditEmployeesMovements.ShowDialog()
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        n = 0
        EditEmployeesMovements.TextBox1.Text = Nothing
        EditEmployeesMovements.TextBox2.Text = Nothing
        EditEmployeesMovements.TextBox3.Text = Nothing
        EditEmployeesMovements.ComboBox1.DataSource = Nothing
        EditEmployeesMovements.ComboBox1.Items.Clear()
        EditEmployeesMovements.ComboBox2.DataSource = Nothing
        EditEmployeesMovements.ComboBox2.Items.Clear()
        EditEmployeesMovements.ComboBox3.DataSource = Nothing
        EditEmployeesMovements.ComboBox3.Items.Clear()
        EditEmployeesMovements.DateTimePicker1.Value = Date.Today
        EditEmployeesMovements.TextBox4.Text = Nothing
        EditEmployeesMovements.DateTimePicker2.Value = Date.Today
        EditEmployeesMovements.PictureBox1.Image = My.Resources.Document
        EditEmployeesMovements.ShowDialog()

    End Sub

    Private Sub ToolStripTextBox3_Click(sender As Object, e As EventArgs) Handles ToolStripTextBox3.Click
        ToolStripTextBox3.Text = Nothing
    End Sub

    Private Sub ToolStripTextBox3_TextChanged(sender As Object, e As EventArgs) Handles ToolStripTextBox3.TextChanged
        On Error Resume Next

        str = " Select EmployeeName,MoveID,EmployeesMovements.EmployeeID,EmployeesMovements.BranchID,EmployeesMovements.DepartmentID, " & _
                  " MoveDate, Remarks, BranchName, DepartmentName,EmployeesMovements.ClassID,EmployeesMovements.Status from employees inner join EmployeesMovements  on " & _
                  " (EmployeesMovements.employeeid = employees.employeeid) inner join DepartmentS on (Employees.DepartmentID = DepaRtments.DepartmentID) " & _
                  " INNER JOIN Branches on (Departments.BranchID = Branches.BranchID) WHERE EmployeeName LIKE ('%" & ToolStripTextBox3.Text.ToString & "%') " & _
                  " or EmployeeCode = '" & ToolStripTextBox3.Text.ToString & "'"
        GetData(0)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                DataGridView3.DataSource = ds.Tables(0)
            Else
                DataGridView3.DataSource = Nothing
            End If
        Else
            DataGridView3.DataSource = Nothing
        End If
    End Sub

    Private Sub ToolStripTextBox4_Click(sender As Object, e As EventArgs) Handles ToolStripTextBox4.Click
        ToolStripTextBox4.Text = Nothing

    End Sub

    Private Sub ToolStripTextBox4_TextChanged(sender As Object, e As EventArgs) Handles ToolStripTextBox4.TextChanged
        On Error Resume Next
        str = " select Employees.EmployeeID , Employees.EmployeeName , EmployeesDocuments.DocumentID, DocumentName,EmployeeDocumentID," & _
             " DocumentContent,Remarks,EmployeesDocuments.Status from Employees inner join EmployeesDocuments on (EmployeesDocuments.EmployeeID = Employees.EmployeeID ) " & _
             " inner join DocumentsTypes on (EmployeesDocuments.DocumentID = DocumentsTypes.DocumentTypeID ) where employeeName like ('%" & ToolStripTextBox4.Text & "%') " & _
             " or EmployeeCode = '" & ToolStripTextBox4.Text & "'"
        GetData(0)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                DataGridView4.DataSource = ds.Tables(0)
            Else
                DataGridView4.DataSource = Nothing
            End If
        Else
            DataGridView4.DataSource = Nothing
        End If
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        n = 0
        EditEmployeesDocuments.TextBox1.Text = Nothing
        EditEmployeesDocuments.TextBox2.Text = Nothing
        EditEmployeesDocuments.TextBox3.Text = Nothing
        EditEmployeesDocuments.ComboBox1.DataSource = Nothing
        EditEmployeesDocuments.ComboBox1.Items.Clear()
        EditEmployeesDocuments.ShowDialog()

    End Sub

    Private Sub DataGridView4_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView4.CellContentClick

        n = 1
        r = DataGridView4.CurrentCell.RowIndex
        EmployeeID = DataGridView4(2, r).Value
        str = " Select EmployeeCode from employees where EmployeeID = " & DataGridView4(2, r).Value
        GetData(0)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                EditEmployeesDocuments.TextBox1.Text = ds.Tables(0).Rows(0)(0)
            Else
                EditEmployeesDocuments.TextBox1.Text = Nothing
            End If
        Else
            EditEmployeesDocuments.TextBox1.Text = Nothing
        End If
        EditEmployeesDocuments.TextBox2.Text = DataGridView4(3, r).Value
        GetDocumentsTypes(EditEmployeesDocuments.ComboBox1)
        EditEmployeesDocuments.ComboBox1.SelectedValue = DataGridView4(4, r).Value
        Dim data As Byte() = DataGridView4(6, r).Value
        Dim Stream = New MemoryStream(data)
        EditEmployeesDocuments.PictureBox1.Image = Image.FromStream(Stream)
        EditEmployeesDocuments.TextBox3.Text = DataGridView4(7, r).Value
        EditEmployeesDocuments.ShowDialog()
    End Sub

    Private Sub ToolStripComboBox2_Click(sender As Object, e As EventArgs) Handles ToolStripComboBox2.Click

    End Sub

    Private Sub ToolStripComboBox2_DropDown(sender As Object, e As EventArgs) Handles ToolStripComboBox2.DropDown
        GetHolidaysTypes(ToolStripComboBox2.ComboBox)
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        n = 0
        EditEmployeesHolidays.TextBox1.Text = Nothing
        EditEmployeesHolidays.TextBox2.Text = Nothing
        EditEmployeesHolidays.ComboBox1.DataSource = Nothing
        EditEmployeesHolidays.ComboBox1.Items.Clear()
        EditEmployeesHolidays.DateTimePicker1.Value = Date.Today
        EditEmployeesHolidays.DateTimePicker2.Value = Date.Today
        EditEmployeesHolidays.ShowDialog()
    End Sub

    Private Sub DataGridView5_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView5.CellContentClick
        n = 1
        r = DataGridView5.CurrentCell.RowIndex
        EmployeeID = DataGridView5(2, r).Value
        str = " Select EmployeeCode from employees where EmployeeID = " & DataGridView5(2, r).Value
        GetData(0)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                EditEmployeesHolidays.TextBox1.Text = ds.Tables(0).Rows(0)(0)
            Else
                EditEmployeesHolidays.TextBox1.Text = Nothing
            End If
        Else
            EditEmployeesHolidays.TextBox1.Text = Nothing
        End If
        EditEmployeesHolidays.TextBox2.Text = DataGridView5(3, r).Value
        GetHolidaysTypes(EditEmployeesHolidays.ComboBox1)
        EditEmployeesHolidays.ComboBox1.SelectedValue = DataGridView5(4, r).Value
        EditEmployeesHolidays.DateTimePicker1.Value = DataGridView5(6, r).Value
        EditEmployeesHolidays.DateTimePicker2.Value = DataGridView5(7, r).Value
        EditEmployeesHolidays.ShowDialog()
    End Sub

    Private Sub ToolStripTextBox1_Click(sender As Object, e As EventArgs) Handles ToolStripTextBox1.Click
        ToolStripTextBox1.Text = Nothing
    End Sub

    Private Sub ToolStripTextBox1_TextChanged(sender As Object, e As EventArgs) Handles ToolStripTextBox1.TextChanged
        On Error Resume Next
        str = " select Employees.EmployeeID , Employees.EmployeeName , EmployeeHolidayID,HolidayName,EmployeesHolidays.HolidayTypeID,EmployeesHolidays.HolidayBeginDate,HolidayEndDate " & _
            " ,EmployeesHolidays.Status from Employees,EmployeesHolidays,HolidaysTypes where (EmployeesHolidays.EmployeeID = Employees.EmployeeID ) " & _
            " and (EmployeesHolidays.HolidayTypeID = HolidaysTypes.HolidayTypeID ) and (Employees.EmployeeName like ('%" & ToolStripTextBox1.Text.ToString & "%') " & _
                " or EmployeeCode = '" & ToolStripTextBox1.Text.ToString & "' )"

        GetData(0)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                DataGridView5.DataSource = ds.Tables(0)
            Else
                DataGridView5.DataSource = Nothing
            End If
        Else
            DataGridView5.DataSource = Nothing
        End If
    End Sub

    Private Sub ToolStripComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ToolStripComboBox2.SelectedIndexChanged
        On Error Resume Next
        str = " select Employees.EmployeeID , Employees.EmployeeName , EmployeeHolidayID,HolidayName,EmployeesHolidays.HolidayTypeID,EmployeesHolidays.HolidayBeginDate,HolidayEndDate " & _
                " from Employees,EmployeesHolidays,HolidaysTypes where (EmployeesHolidays.EmployeeID = Employees.EmployeeID ) " & _
                " and (EmployeesHolidays.HolidayTypeID = HolidaysTypes.HolidayTypeID ) and EmployeesHolidays.HolidayTypeID = " & ToolStripComboBox2.ComboBox.SelectedValue & ""
        GetData(0)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                DataGridView5.DataSource = ds.Tables(0)
            Else
                DataGridView5.DataSource = Nothing
            End If
        Else
            DataGridView5.DataSource = Nothing
        End If
    End Sub

    Private Sub ToolStripComboBox4_DropDown(sender As Object, e As EventArgs) Handles ToolStripComboBox4.DropDown
        GetFinishingTypes(ToolStripComboBox4.ComboBox)
    End Sub

    Private Sub ToolStripTextBox6_Click(sender As Object, e As EventArgs) Handles ToolStripTextBox6.Click
        ToolStripTextBox6.TextBox.Text = Nothing
    End Sub

    Private Sub ToolStripTextBox6_TextChanged(sender As Object, e As EventArgs) Handles ToolStripTextBox6.TextChanged
        On Error Resume Next

        str = " select Employees.EmployeeID , Employees.EmployeeName , EmployeeFinishingID,FinishingTypeName,EmployeeFinishings.FinishingTypeID,EmployeeFinishings.FinishingDate,Remarks " & _
           ",EmployeeFinishings.Status from Employees,EmployeeFinishings,FinishingTypes where (EmployeeFinishings.EmployeeID = Employees.EmployeeID ) " & _
           " and (EmployeeFinishings.FinishingTypeID = FinishingTypes.FinishingTypeID ) and ( Employees.EmployeeName like ('%" & ToolStripTextBox6.Text.ToString & "%')" & _
                " or EmployeeCode = '" & ToolStripTextBox6.Text.ToString & "') "

        GetData(0)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                DataGridView6.DataSource = ds.Tables(0)
            Else
                DataGridView6.DataSource = Nothing
            End If
        Else
            DataGridView6.DataSource = Nothing
        End If
    End Sub

    Private Sub ToolStripComboBox4_Click(sender As Object, e As EventArgs) Handles ToolStripComboBox4.Click

    End Sub

    Private Sub ToolStripComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ToolStripComboBox4.SelectedIndexChanged
        On Error Resume Next

        str = " select Employees.EmployeeID , Employees.EmployeeName , EmployeeFinishingID,FinishingTypeName,EmployeeFinishings.FinishingTypeID,EmployeeFinishings.FinishingDate,Remarks " & _
           ",EmployeeFinishings.Status from Employees,EmployeeFinishings,FinishingTypes where (EmployeeFinishings.EmployeeID = Employees.EmployeeID ) " & _
           " and (EmployeeFinishings.FinishingTypeID = FinishingTypes.FinishingTypeID ) and ( Employees.EmployeeName like ('%" & ToolStripTextBox6.Text.ToString & "%')" & _
                " or EmployeeCode = '" & ToolStripTextBox6.Text.ToString & "') and EmployeeFinishings.FinishingTypeID = " & ToolStripComboBox4.ComboBox.SelectedValue & ""

        GetData(0)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                DataGridView6.DataSource = ds.Tables(0)
            Else
                DataGridView6.DataSource = Nothing
            End If
        Else
            DataGridView6.DataSource = Nothing
        End If
    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        n = 0
        EditEmployeesFinishings.TextBox1.Text = Nothing
        EditEmployeesFinishings.TextBox2.Text = Nothing
        EditEmployeesFinishings.ComboBox1.DataSource = Nothing
        EditEmployeesFinishings.ComboBox1.Items.Clear()
        EditEmployeesFinishings.DateTimePicker1.Value = Date.Today
        EditEmployeesFinishings.TextBox3.Text = Nothing
        EditEmployeesFinishings.TextBox4.Text = Nothing
        EditEmployeesFinishings.DateTimePicker2.Value = Date.Today
        EditEmployeesFinishings.PictureBox1.Image = My.Resources.Document
        EditEmployeesFinishings.ShowDialog()

    End Sub

    Private Sub DataGridView6_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView6.CellContentClick

        n = 1
        r = DataGridView6.CurrentCell.RowIndex
        EmployeeID = DataGridView6(2, r).Value
        str = " Select EmployeeCode from employees where EmployeeID = " & DataGridView6(2, r).Value
        GetData(0)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                EditEmployeesFinishings.TextBox1.Text = ds.Tables(0).Rows(0)(0)
            Else
                EditEmployeesFinishings.TextBox1.Text = Nothing
            End If
        Else
            EditEmployeesFinishings.TextBox1.Text = Nothing
        End If
        EditEmployeesFinishings.TextBox2.Text = DataGridView6(3, r).Value
        GetFinishingTypes(EditEmployeesFinishings.ComboBox1)
        EditEmployeesFinishings.ComboBox1.SelectedValue = DataGridView6(4, r).Value
        EditEmployeesFinishings.DateTimePicker1.Value = DataGridView6(6, r).Value
        EditEmployeesFinishings.TextBox3.Text = DataGridView6(7, r).Value

        str = " Select DecisionNo,DecisionDate,FinishingDocument from EmployeeFinishings where EmployeeID = " & DataGridView6(2, r).Value & " and " & _
            " EmployeeFinishingID = " & DataGridView6(1, r).Value & ""
        GetData(0)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                EditEmployeesFinishings.TextBox4.Text = ds.Tables(0).Rows(0)(0)
                Dim data As Byte() = DirectCast(ds.Tables(0).Rows(0)("FinishingDocument"), Byte())
                Dim ms As New MemoryStream(data)
                EditEmployeesFinishings.PictureBox1.Image = Image.FromStream(ms)
                EditEmployeesFinishings.DateTimePicker2.Value = ds.Tables(0).Rows(0)("DecisionDate")
            Else
                EditEmployeesFinishings.TextBox4.Text = Nothing
            End If
        Else
            EditEmployeesFinishings.TextBox4.Text = Nothing
        End If

        EditEmployeesFinishings.ShowDialog()
    End Sub

    Private Sub ToolStripTextBox7_Click(sender As Object, e As EventArgs) Handles ToolStripTextBox7.Click
        ToolStripTextBox7.Text = Nothing
    End Sub

    Private Sub ToolStripTextBox7_TextChanged(sender As Object, e As EventArgs) Handles ToolStripTextBox7.TextChanged
        On Error Resume Next
        str = " Select Investigations.InvestigationID,Infraction,InfractionDate,Investigations.EmployeeID,EmployeeName,InvestigationDate,Investigations.Decision,DecisionDate,Adversary " &
            " ,AdversaryInterval,Investigations.Status from Investigations, employees where employees.EmployeeID = Investigations.employeeID AND ( EmployeeName like ('%" & ToolStripTextBox7.Text & "%' )" &
            " or EmployeeCode = '" & ToolStripTextBox5.Text.ToString & "' )"
        GetData(0)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                DataGridView7.DataSource = ds.Tables(0)
            Else
                DataGridView7.DataSource = Nothing
            End If
        Else
            DataGridView7.DataSource = Nothing
        End If
    End Sub

    Private Sub DataGridView7_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView7.CellContentClick
        n = 1
        r = DataGridView7.CurrentCell.RowIndex
        EmployeeID = DataGridView7(2, r).Value
        str = " Select EmployeeCode from employees where EmployeeID = " & DataGridView7(2, r).Value
        GetData(0)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                EditInvestigations.TextBox1.Text = ds.Tables(0).Rows(0)(0)
            Else
                EditInvestigations.TextBox1.Text = Nothing
            End If
        Else
            EditInvestigations.TextBox1.Text = Nothing
        End If
        EditInvestigations.TextBox2.Text = DataGridView7(3, r).Value
        EditInvestigations.TextBox5.Text = DataGridView7(4, r).Value
        EditInvestigations.DateTimePicker3.Value = DataGridView7(5, r).Value
        EditInvestigations.DateTimePicker1.Value = DataGridView7(6, r).Value
        EditInvestigations.TextBox3.Text = DataGridView7(7, r).Value
        EditInvestigations.DateTimePicker2.Value = DataGridView7(8, r).Value
        EditInvestigations.TextBox4.Text = DataGridView7(9, r).Value
        EditInvestigations.ComboBox1.Text = DataGridView7(10, r).Value

        str = " Select InvestigationDocument from Investigations where EmployeeID = " & DataGridView7(2, r).Value & " and " &
           " InvestigationID = " & DataGridView7(1, r).Value & ""
        GetData(0)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                Dim data As Byte() = DirectCast(ds.Tables(0).Rows(0)("InvestigationDocument"), Byte())
                Dim ms As New MemoryStream(data)
                EditInvestigations.PictureBox1.Image = Image.FromStream(ms)
            Else
                EditInvestigations.PictureBox1.Image = My.Resources.Document
            End If
        Else
            EditInvestigations.PictureBox1.Image = My.Resources.Document
        End If

        EditInvestigations.ShowDialog()
    End Sub

    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click

        n = 0
        EditInvestigations.TextBox1.Text = Nothing
        EditInvestigations.TextBox2.Text = Nothing
        EditInvestigations.DateTimePicker1.Value = Date.Today
        EditInvestigations.DateTimePicker2.Value = Date.Today
        EditInvestigations.TextBox3.Text = Nothing
        EditInvestigations.TextBox4.Text = Nothing
        EditInvestigations.TextBox5.Text = Nothing
        EditInvestigations.PictureBox1.Image = My.Resources.Document
        EditInvestigations.ShowDialog()


    End Sub

    Private Sub ToolStripTextBox8_Click(sender As Object, e As EventArgs) Handles ToolStripTextBox8.Click
        ToolStripTextBox8.Text = Nothing
    End Sub

    Private Sub ToolStripTextBox8_TextChanged(sender As Object, e As EventArgs) Handles ToolStripTextBox8.TextChanged
        On Error Resume Next

        str = " Select EmployeePositions.positionID,EmployeePositions.EmployeeID,FromJobID,J1.JobName JobName1,EmployeePositions.JobID, J2.JobName as JobName2,FromClassID,C1.className as className1, " &
              " EmployeePositions.ClassID,C2.className as className2 ,PositionDate,EmployeeName,EmployeePositions.Status " &
              " from  EmployeePositions,Employees, Jobs j1, jobs j2,Classes C1,Classes C2 WHERE " &
              " Employees.EmployeeID = EmployeePositions.EmployeeID AND" &
              " EmployeePositions.FromJobID = J1.JOBID AND EmployeePositions.JobID = J2.JobID AND EmployeePositions.FromClassID = C1.ClassID AND " &
              " EmployeePositions.ClassID = C2.ClassID AND J1.JOBID = C1.JOBID AND J2.JOBID = C2.JOBID AND (EmployeeName like ('%" & ToolStripTextBox8.TextBox.Text.ToString & "%') or " &
                " EmployeeCode = '" & ToolStripTextBox8.TextBox.Text.ToString & "')"

        GetData(0)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                DataGridView8.DataSource = ds.Tables(0)
            Else
                DataGridView8.DataSource = Nothing
            End If
        Else
            DataGridView8.DataSource = Nothing
        End If
    End Sub

    Private Sub DataGridView8_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView8.CellContentClick

        n = 1
        r = DataGridView8.CurrentCell.RowIndex
        EmployeeID = DataGridView8(2, r).Value
        str = " Select EmployeeCode from employees where EmployeeID = " & DataGridView8(2, r).Value
        GetData(0)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                EditEmployeePositions.TextBox1.Text = ds.Tables(0).Rows(0)(0)
            Else
                EditEmployeePositions.TextBox1.Text = Nothing
            End If
        Else
            EditEmployeePositions.TextBox1.Text = Nothing
        End If
        EditEmployeePositions.TextBox2.Text = DataGridView8(3, r).Value
        GetJobs(EditEmployeePositions.ComboBox1)
        EditEmployeePositions.ComboBox1.SelectedValue = DataGridView8(4, r).Value
        GetClasses(EditEmployeePositions.ComboBox1, EditEmployeePositions.ComboBox2)
        EditEmployeePositions.ComboBox2.SelectedValue = DataGridView8(8, r).Value
        GetJobs(EditEmployeePositions.ComboBox3)
        EditEmployeePositions.ComboBox3.SelectedValue = DataGridView8(6, r).Value
        GetClasses(EditEmployeePositions.ComboBox3, EditEmployeePositions.ComboBox4)
        EditEmployeePositions.ComboBox4.SelectedValue = DataGridView8(10, r).Value
        EditEmployeePositions.DateTimePicker1.Value = DataGridView8(12, r).Value

        str = " Select DecisionNo,DecisionDate,PositionDocument from EmployeePositions where EmployeeID = " & DataGridView8(2, r).Value & " and " &
          " positionID = " & DataGridView8(1, r).Value & ""
        GetData(0)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                EditEmployeePositions.TextBox4.Text = ds.Tables(0).Rows(0)(0)
                Dim data As Byte() = DirectCast(ds.Tables(0).Rows(0)(2), Byte())
                Dim ms As New MemoryStream(data)
                EditEmployeePositions.PictureBox1.Image = Image.FromStream(ms)
                EditEmployeePositions.DateTimePicker2.Value = ds.Tables(0).Rows(0)(1)
            Else
                EditEmployeePositions.PictureBox1.Image = My.Resources.Document
            End If
        Else
            EditEmployeePositions.PictureBox1.Image = My.Resources.Document
        End If

        EditEmployeePositions.ShowDialog()
    End Sub

    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs) Handles ToolStripButton9.Click
        n = 0
        EditEmployeePositions.TextBox1.Text = Nothing
        EditEmployeePositions.TextBox2.Text = Nothing
        EditEmployeePositions.ComboBox1.DataSource = Nothing
        EditEmployeePositions.ComboBox1.Items.Clear()
        EditEmployeePositions.ComboBox2.DataSource = Nothing
        EditEmployeePositions.ComboBox2.Items.Clear()
        EditEmployeePositions.ComboBox3.DataSource = Nothing
        EditEmployeePositions.ComboBox3.Items.Clear()
        EditEmployeePositions.ComboBox4.DataSource = Nothing
        EditEmployeePositions.ComboBox4.Items.Clear()
        EditEmployeePositions.DateTimePicker1.Value = Date.Today
        EditEmployeePositions.TextBox4.Text = Nothing
        EditEmployeePositions.DateTimePicker2.Value = Date.Today
        EditEmployeePositions.PictureBox1.Image = My.Resources.Document
        EditEmployeePositions.ShowDialog()

    End Sub

    Private Sub DataGridView9_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView9.CellContentClick

        n = 1
        r = DataGridView9.CurrentCell.RowIndex
        EmployeeID = DataGridView9(2, r).Value
        str = " Select EmployeeCode from employees where EmployeeID = " & DataGridView9(2, r).Value
        GetData(0)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                EditEmployeesTrainings.TextBox1.Text = ds.Tables(0).Rows(0)(0)
            Else
                EditEmployeesTrainings.TextBox1.Text = Nothing
            End If
        Else
            EditEmployeesTrainings.TextBox1.Text = Nothing
        End If

        EditEmployeesTrainings.TextBox2.Text = DataGridView9(3, r).Value
        EditEmployeesTrainings.TextBox4.Text = DataGridView9(4, r).Value
        EditEmployeesTrainings.DateTimePicker1.Value = DataGridView9(5, r).Value
        EditEmployeesTrainings.DateTimePicker2.Value = DataGridView9(6, r).Value
        EditEmployeesTrainings.TextBox5.Text = DataGridView9(7, r).Value
        EditEmployeesTrainings.TextBox6.Text = DataGridView9(8, r).Value
        EditEmployeesTrainings.DateTimePicker3.Value = DataGridView9(9, r).Value
        Dim data As Byte() = DirectCast(DataGridView9(10, r).Value, Byte())
        Dim ms As New MemoryStream(data)
        EditEmployeesTrainings.PictureBox1.Image = Image.FromStream(ms)
        EditEmployeesTrainings.ShowDialog()
    End Sub

    Private Sub ToolStripButton10_Click(sender As Object, e As EventArgs) Handles ToolStripButton10.Click
        n = 0
        EditEmployeesTrainings.TextBox1.Text = Nothing
        EditEmployeesTrainings.TextBox2.Text = Nothing
        EditEmployeesTrainings.TextBox4.Text = Nothing
        EditEmployeesTrainings.TextBox5.Text = Nothing
        EditEmployeesTrainings.TextBox6.Text = Nothing
        EditEmployeesTrainings.DateTimePicker1.Value = Date.Today
        EditEmployeesTrainings.DateTimePicker2.Value = Date.Today
        EditEmployeesTrainings.DateTimePicker3.Value = Date.Today
        EditEmployeesTrainings.PictureBox1.Image = My.Resources.Document
        EditEmployeesTrainings.ShowDialog()
    End Sub

    Private Sub ToolStripTextBox9_Click(sender As Object, e As EventArgs) Handles ToolStripTextBox9.Click
       
    End Sub

    Private Sub ToolStripTextBox10_Click(sender As Object, e As EventArgs) Handles ToolStripTextBox10.Click

    End Sub

    Private Sub ToolStripTextBox10_TextChanged(sender As Object, e As EventArgs) Handles ToolStripTextBox10.TextChanged
        On Error Resume Next
        str = " Select EmployeesQualifications.EmployeeQualificationID,EmployeesQualifications.EmployeeID,EmployeesQualifications.QualID AS QualID,IssueDate," & _
                  " EmployeeName,Country, Country,City,Institute,Faculty,EmployeesQualifications.Specialization,QualificationName from EmployeesQualifications, employees,Qualifications " & _
                  " where Employees.EmployeeID = EmployeesQualifications.employeeID And Qualifications.QualificationID = EmployeesQualifications.QualID " & _
                   " and ( EmployeeName like ('%" & ToolStripTextBox10.Text.ToString & "%') or EmployeeCode like " & _
                   " ('%" & ToolStripTextBox10.Text.ToString & "%') )"
        GetData(0)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                DataGridView10.DataSource = ds.Tables(0)
            Else
                DataGridView10.DataSource = Nothing
            End If
        Else
            DataGridView10.DataSource = Nothing
        End If
    End Sub

    Private Sub ToolStripTextBox9_TextChanged(sender As Object, e As EventArgs) Handles ToolStripTextBox9.TextChanged
        On Error Resume Next
        str = " Select EmployeesTrainings.TrainingID,EmployeesTrainings.EmployeeID,TrainingName,EmployeeName,BeginDate,EndDate,TrainingPlace,DecisionNo " & _
                      " ,DecisionDate,DecisionDocument from EmployeesTrainings, employees where employees.EmployeeID = EmployeesTrainings.employeeID " & _
                      " and ( EmployeeName like ('%" & ToolStripTextBox9.Text.ToString & "%') or EmployeeCode like " & _
            " ('%" & ToolStripTextBox9.Text.ToString & "%') )"
        GetData(0)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                DataGridView9.DataSource = ds.Tables(0)
            Else
                DataGridView9.DataSource = Nothing
            End If
        Else
            DataGridView9.DataSource = Nothing
        End If
    End Sub

    Private Sub ToolStripButton11_Click(sender As Object, e As EventArgs) Handles ToolStripButton11.Click
        n = 0
        EditEmployeesQualifications.TextBox1.Text = Nothing
        EditEmployeesQualifications.TextBox2.Text = Nothing
        EditEmployeesQualifications.TextBox3.Text = Nothing
        EditEmployeesQualifications.TextBox4.Text = Nothing
        EditEmployeesQualifications.TextBox5.Text = Nothing
        EditEmployeesQualifications.TextBox6.Text = Nothing
        EditEmployeesQualifications.TextBox7.Text = Nothing
        EditEmployeesQualifications.ComboBox1.DataSource = Nothing
        EditEmployeesQualifications.ComboBox1.Items.Clear()
        EditEmployeesQualifications.DateTimePicker1.Value = Date.Today
        EditEmployeesQualifications.ShowDialog()
    End Sub

    Private Sub DataGridView10_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView10.CellContentClick
        n = 1
        r = DataGridView10.CurrentCell.RowIndex
        EmployeeID = DataGridView10(2, r).Value
        str = " Select EmployeeCode from employees where EmployeeID = " & DataGridView10(2, r).Value
        GetData(0)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                EditEmployeesQualifications.TextBox1.Text = ds.Tables(0).Rows(0)(0)
            Else
                EditEmployeesQualifications.TextBox1.Text = Nothing
            End If
        Else
            EditEmployeesQualifications.TextBox1.Text = Nothing
        End If
        EditEmployeesQualifications.TextBox2.Text = DataGridView10(3, r).Value
        GetQualifications(EditEmployeesQualifications.ComboBox1)
        EditEmployeesQualifications.ComboBox1.SelectedValue = DataGridView10(4, r).Value
        EditEmployeesQualifications.DateTimePicker1.Value = DataGridView10(6, r).Value
        EditEmployeesQualifications.TextBox3.Text = DataGridView10(7, r).Value
        EditEmployeesQualifications.TextBox4.Text = DataGridView10(8, r).Value
        EditEmployeesQualifications.TextBox5.Text = DataGridView10(9, r).Value
        EditEmployeesQualifications.TextBox6.Text = DataGridView10(10, r).Value
        EditEmployeesQualifications.TextBox7.Text = DataGridView10(11, r).Value
        EditEmployeesQualifications.ShowDialog()
    End Sub
End Class