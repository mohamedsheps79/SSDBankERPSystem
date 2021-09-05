Public Class PreviewReports

    Private Sub ComboBox1_DropDown(sender As Object, e As EventArgs) Handles ComboBox1.DropDown
        GetBranches(ComboBox1)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        On Error GoTo fb
        str = " select BranchName,  BranchCode, DepartmentName ,CAST(Employees.EmployeeCode AS nvarchar)  AS EmployeeCode,CAST(BirthDate as date) as BirthDate,CAST(HireDate as date) as HireDate, Employees.EmployeeName ," & _
          " DegreeName, rangeName,QualificationName from Branches,Departments,Employees ,Degrees,Ranges, " & _
          " Qualifications where Branches.BranchID = Departments.BranchID and Branches.BranchID = Employees.BranchID " & _
          " and Departments.DepartmentID = Employees.DepartmentID and Employees.DegreeID = Degrees.DegreeID " & _
          " and Employees.RangeID = Ranges.RangeID and Employees.QualificationID = Qualifications.QualificationID  and EmployeeStatus = 'A' AND Employees.Status ='A' "
        If CheckBox1.Checked = True Then
            str = str & " and Branches.branchID = " & ComboBox1.SelectedValue
        End If
        If CheckBox2.Checked = True Then
            str = str & " and Employees.DepartmentID = " & ComboBox2.SelectedValue
        End If
        If CheckBox3.Checked = True Then
            str = str & " and Employees.DegreeID = " & ComboBox3.SelectedValue
        End If
        If CheckBox4.Checked = True Then
            str = str & " and Employees.RangeID = " & ComboBox4.SelectedValue
        End If
        If CheckBox5.Checked = True Then
            str = str & " and Employees.jobID = " & ComboBox5.SelectedValue
        End If
        If CheckBox6.Checked = True Then
            str = str & " and Employees.ClassID = " & ComboBox6.SelectedValue
        End If
        If CheckBox7.Checked = True Then
            str = str & " and Employees.QualificationID = " & ComboBox7.SelectedValue
        End If
        If CheckBox8.Checked = True Then
            str = str & " and Gender = '" & Trim(ComboBox8.Text) & "' "
        End If
        If CheckBox9.Checked = True Then
            str = str & " and ScocialStatus = '" & Trim(ComboBox9.Text) & "' "
        End If
        If CheckBox10.Checked = True Then
            str = str & " and DATEDIFF(YY,BIRTHDATE,GETDATE())>=65 "
        End If
        If CheckBox11.Checked = True Then
            str = str & " and specialization = '" & ComboBox10.Text & "' "
        End If
        If CheckBox12.Checked = True Then
            str = str & " and BirthDate " & ComboBox11.Text & " '" & DateTimePicker1.Value.Date.ToString("yyyy-MM-dd").ToString & "'"
        End If
        If CheckBox13.Checked = True Then
            str = str & " and HireDate " & ComboBox12.Text & " '" & DateTimePicker2.Value.Date.ToString("yyyy-MM-dd").ToString & "'  "
        End If
        
        str = str & " ORDER BY Employees.BranchID,Employees.DepartmentID ,Employees.jobID,Employees.DegreeID,Employees.RangeID DESC,Employees.QualificationID"
        GetData(0)
        Dim J As New EmployeesRpt
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                J.Load("EmployeesRpt.rpt")
                J.SetDataSource(ds.Tables(0))
                Me.CrystalReportViewer1.ReportSource = J
                Me.CrystalReportViewer1.Refresh()
            Else
                MsgBox("لا توجد بيانات")
                J.Load("EmployeesRpt.rpt")
                J.SetDataSource(ds.Tables(0))
                Me.CrystalReportViewer1.ReportSource = J
                Me.CrystalReportViewer1.Refresh()
            End If
        Else
            MsgBox("لا توجد بيانات")
            J.Load("EmployeesRpt.rpt")
            J.SetDataSource(ds.Tables(0))
            Me.CrystalReportViewer1.ReportSource = J
            Me.CrystalReportViewer1.Refresh()
        End If
fb:
    End Sub

    Private Sub ComboBox2_DropDown(sender As Object, e As EventArgs) Handles ComboBox2.DropDown
        GetDepartments(ComboBox1, ComboBox2)
    End Sub

    Private Sub ComboBox3_DropDown(sender As Object, e As EventArgs) Handles ComboBox3.DropDown
        GetDegrees(ComboBox3)
    End Sub

    Private Sub ComboBox4_DropDown(sender As Object, e As EventArgs) Handles ComboBox4.DropDown
        GetRanges(ComboBox4)
    End Sub

    Private Sub ComboBox5_DropDown(sender As Object, e As EventArgs) Handles ComboBox5.DropDown
        GetJobs(ComboBox5)
    End Sub

    Private Sub ComboBox6_DropDown(sender As Object, e As EventArgs) Handles ComboBox6.DropDown
        GetClasses(ComboBox5, ComboBox6)
    End Sub

    Private Sub ComboBox7_DropDown(sender As Object, e As EventArgs) Handles ComboBox7.DropDown
        GetQualifications(ComboBox7)
    End Sub

    Private Sub ComboBox7_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox7.SelectedIndexChanged

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        checkselection(CheckBox1, ComboBox1)
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        checkselection(CheckBox2, ComboBox2)
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        checkselection(CheckBox3, ComboBox3)
    End Sub

    Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox4.CheckedChanged
        checkselection(CheckBox4, ComboBox4)
    End Sub

    Private Sub CheckBox5_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox5.CheckedChanged
        checkselection(CheckBox5, ComboBox5)
    End Sub

    Private Sub CheckBox6_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox6.CheckedChanged
        checkselection(CheckBox6, ComboBox6)
    End Sub

    Private Sub CheckBox7_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox7.CheckedChanged
        checkselection(CheckBox7, ComboBox7)
    End Sub

    Private Sub CheckBox8_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox8.CheckedChanged
        checkselection(CheckBox8, ComboBox8)
    End Sub

    Private Sub CheckBox9_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox9.CheckedChanged
        checkselection(CheckBox9, ComboBox9)
    End Sub

    Private Sub CheckBox10_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox10.CheckedChanged

    End Sub

    Private Sub ComboBox10_DropDown(sender As Object, e As EventArgs) Handles ComboBox10.DropDown
        str = " select distinct(specialization) as specialization from Employees"
        GetData(0)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                With ComboBox10
                    .DataSource = ds.Tables(0)
                    .DisplayMember = "specialization"
                End With
            Else
                With ComboBox10
                    .DataSource = Nothing
                    .Items.Clear()
                End With
            End If
        Else
            With ComboBox10
                .DataSource = Nothing
                .Items.Clear()
            End With
        End If
    End Sub

    Private Sub ComboBox10_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox10.SelectedIndexChanged

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub CheckBox12_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox12.CheckedChanged
        If CheckBox12.Checked = True Then
            DateTimePicker1.Enabled = True
            ComboBox11.Enabled = True
        Else
            DateTimePicker1.Enabled = False
            ComboBox11.Enabled = False
        End If
    End Sub

    Private Sub CheckBox11_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox11.CheckedChanged
        checkselection(CheckBox12, ComboBox10)
    End Sub

    Private Sub CheckBox13_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox13.CheckedChanged
        If CheckBox13.Checked = True Then
            DateTimePicker2.Enabled = True
            ComboBox12.Enabled = True
        Else
            DateTimePicker2.Enabled = False
            ComboBox12.Enabled = False
        End If
    End Sub

    Private Sub TextBox1_Click(sender As Object, e As EventArgs) Handles TextBox1.Click
        TextBox1.Text = Nothing
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub CheckBox14_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox14.CheckedChanged
        If CheckBox14.Checked = True Then
            Button3.Enabled = True
        Else
            Button3.Enabled = False
        End If
    End Sub

    Private Sub ComboBox23_DropDown(sender As Object, e As EventArgs) Handles ComboBox23.DropDown
        GetBranches(ComboBox23)
    End Sub

    Private Sub ComboBox23_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox23.SelectedIndexChanged
        On Error Resume Next
        GetDepartments(ComboBox23, ComboBox22)
    End Sub

    Private Sub ComboBox22_DropDown(sender As Object, e As EventArgs) Handles ComboBox22.DropDown
        GetDepartments(ComboBox23, ComboBox22)
    End Sub

    Private Sub ComboBox22_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox22.SelectedIndexChanged

    End Sub

    Private Sub ComboBox21_DropDown(sender As Object, e As EventArgs) Handles ComboBox21.DropDown
        GetDegrees(ComboBox21)
    End Sub

    Private Sub ComboBox21_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox21.SelectedIndexChanged

    End Sub

    Private Sub ComboBox20_DropDown(sender As Object, e As EventArgs) Handles ComboBox20.DropDown
        GetRanges(ComboBox20)
    End Sub

    Private Sub ComboBox20_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox20.SelectedIndexChanged

    End Sub

    Private Sub ComboBox19_DropDown(sender As Object, e As EventArgs) Handles ComboBox19.DropDown
        GetJobs(ComboBox19)
    End Sub

    Private Sub ComboBox19_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox19.SelectedIndexChanged
        On Error Resume Next
        GetClasses(ComboBox19, ComboBox18)
    End Sub

    Private Sub ComboBox18_DropDown(sender As Object, e As EventArgs) Handles ComboBox18.DropDown
        GetClasses(ComboBox19, ComboBox18)
    End Sub

    Private Sub ComboBox18_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox18.SelectedIndexChanged

    End Sub

    Private Sub ComboBox17_DropDown(sender As Object, e As EventArgs) Handles ComboBox17.DropDown
        GetQualifications(ComboBox17)
    End Sub

    Private Sub ComboBox17_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox17.SelectedIndexChanged

    End Sub

    Private Sub ComboBox14_DropDown(sender As Object, e As EventArgs) Handles ComboBox14.DropDown
        str = " select distinct(specialization) as specialization from Employees"
        GetData(0)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                With ComboBox14
                    .DataSource = ds.Tables(0)
                    .DisplayMember = "specialization"
                End With
            Else
                With ComboBox14
                    .DataSource = Nothing
                    .Items.Clear()
                End With
            End If
        Else
            With ComboBox14
                .DataSource = Nothing
                .Items.Clear()
            End With
        End If
    End Sub

    Private Sub ComboBox14_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox14.SelectedIndexChanged

    End Sub

    Private Sub CheckBox26_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox26.CheckedChanged
        checkselection(CheckBox26, ComboBox23)
    End Sub

    Private Sub CheckBox25_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox25.CheckedChanged
        checkselection(CheckBox25, ComboBox22)
    End Sub

    Private Sub CheckBox24_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox24.CheckedChanged
        checkselection(CheckBox24, ComboBox21)
    End Sub

    Private Sub CheckBox23_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox23.CheckedChanged
        checkselection(CheckBox23, ComboBox20)
    End Sub

    Private Sub CheckBox22_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox22.CheckedChanged
        checkselection(CheckBox22, ComboBox19)
    End Sub

    Private Sub CheckBox21_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox21.CheckedChanged
        checkselection(CheckBox21, ComboBox18)
    End Sub

    Private Sub CheckBox20_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox20.CheckedChanged
        checkselection(CheckBox20, ComboBox17)
    End Sub

    Private Sub CheckBox19_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox19.CheckedChanged
        checkselection(CheckBox19, ComboBox16)
    End Sub

    Private Sub CheckBox18_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox18.CheckedChanged
        checkselection(CheckBox18, ComboBox15)
    End Sub

    Private Sub CheckBox16_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox16.CheckedChanged
        checkselection(CheckBox16, ComboBox14)
    End Sub

    Private Sub CheckBox15_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox15.CheckedChanged
        If CheckBox15.Checked = True Then
            DateTimePicker3.Enabled = True
            ComboBox13.Enabled = True
        Else
            DateTimePicker3.Enabled = False
            ComboBox13.Enabled = False
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        formID = 7
        EmployeesList.TextBox2.Text = Nothing
        EmployeesList.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        On Error GoTo fb
        str = " Select EmployeeName ,B1.BranchName AS Branch1,B2.BranchName Branch2,D1.DepartmentName AS Department1 , D2.DepartmentName AS Department2," & _
              " CLASSNAME, MoveDate from Employees, Branches B1, Branches B2,Departments D1,Departments D2,Classes , EmployeesMovements WHERE " & _
              " Employees.ClassID = Classes.ClassID And Employees.EmployeeID = EmployeesMovements.EmployeeID AND " & _
              " EmployeesMovements.FromBranchID = B1.BranchID AND EmployeesMovements.BranchID = B2.BranchID AND EmployeesMovements.FromDepartmentID = D1.DepartmentID AND " & _
              " EmployeesMovements.DepartmentID = D2.DepartmentID and EmployeeStatus = 'A' AND Employees.Status ='A' AND EmployeesMovements.Status ='A'"
        If CheckBox26.Checked = True Then
            str = str & " and Employees.branchID = " & ComboBox23.SelectedValue
        End If
        If CheckBox25.Checked = True Then
            str = str & " and Employees.DepartmentID = " & ComboBox22.SelectedValue
        End If
        If CheckBox24.Checked = True Then
            str = str & " and Employees.DegreeID = " & ComboBox21.SelectedValue
        End If
        If CheckBox23.Checked = True Then
            str = str & " and Employees.RangeID = " & ComboBox20.SelectedValue
        End If
        If CheckBox22.Checked = True Then
            str = str & " and Employees.jobID = " & ComboBox19.SelectedValue
        End If
        If CheckBox21.Checked = True Then
            str = str & " and Employees.ClassID = " & ComboBox18.SelectedValue
        End If
        If CheckBox20.Checked = True Then
            str = str & " and Employees.QualificationID = " & ComboBox17.SelectedValue
        End If
        If CheckBox19.Checked = True Then
            str = str & " and Gender = '" & Trim(ComboBox16.Text) & "' "
        End If
        If CheckBox18.Checked = True Then
            str = str & " and ScocialStatus = '" & Trim(ComboBox15.Text) & "' "
        End If
        If CheckBox16.Checked = True Then
            str = str & " and specialization = '" & ComboBox14.Text & "' "
        End If
        If CheckBox15.Checked = True Then
            str = str & " and moveDate " & ComboBox13.Text & " '" & DateTimePicker3.Value.Date.ToString("yyyy-MM-dd").ToString & "'"
        End If
        If CheckBox14.Checked = True Then
            str = str & " and employeeName = '" & TextBox1.Text.ToString & "' "
        End If
        str = str & " ORDER BY moveDate"
        GetData(0)
        Dim J As New MovementsReport
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                J.Load("MovementsReport.rpt")
                J.SetDataSource(ds.Tables(0))
                Me.CrystalReportViewer2.ReportSource = J
                Me.CrystalReportViewer2.Refresh()
            Else
                MsgBox("لا توجد بيانات")
                J.Load("MovementsReport.rpt")
                J.SetDataSource(ds.Tables(0))
                Me.CrystalReportViewer2.ReportSource = J
                Me.CrystalReportViewer2.Refresh()
            End If
        Else
            MsgBox("لا توجد بيانات")
            J.Load("MovementsReport.rpt")
            J.SetDataSource(ds.Tables(0))
            Me.CrystalReportViewer2.ReportSource = J
            Me.CrystalReportViewer2.Refresh()
        End If
fb:
    End Sub

    Private Sub ComboBox34_DropDown(sender As Object, e As EventArgs) Handles ComboBox34.DropDown
        GetBranches(ComboBox34)
    End Sub

    Private Sub ComboBox34_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox34.SelectedIndexChanged
        On Error GoTo fb
        GetDepartments(ComboBox34, ComboBox33)
fb:
    End Sub

    Private Sub ComboBox33_DropDown(sender As Object, e As EventArgs) Handles ComboBox33.DropDown
        GetDepartments(ComboBox34, ComboBox33)
    End Sub

    Private Sub ComboBox33_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox33.SelectedIndexChanged

    End Sub

    Private Sub ComboBox32_DropDown(sender As Object, e As EventArgs) Handles ComboBox32.DropDown
        GetDegrees(ComboBox32)
    End Sub

    Private Sub ComboBox32_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox32.SelectedIndexChanged

    End Sub

    Private Sub ComboBox31_DropDown(sender As Object, e As EventArgs) Handles ComboBox31.DropDown
        GetRanges(ComboBox31)
    End Sub

    Private Sub ComboBox31_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox31.SelectedIndexChanged

    End Sub

    Private Sub ComboBox30_DropDown(sender As Object, e As EventArgs) Handles ComboBox30.DropDown
        GetJobs(ComboBox30)
    End Sub

    Private Sub ComboBox30_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox30.SelectedIndexChanged
        On Error GoTo fb
        GetClasses(ComboBox30, ComboBox29)
fb:
    End Sub

    Private Sub ComboBox29_DropDown(sender As Object, e As EventArgs) Handles ComboBox29.DropDown
        GetClasses(ComboBox30, ComboBox29)
    End Sub

    Private Sub ComboBox29_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox29.SelectedIndexChanged

    End Sub

    Private Sub ComboBox28_DropDown(sender As Object, e As EventArgs) Handles ComboBox28.DropDown
        GetQualifications(ComboBox28)
    End Sub

    Private Sub ComboBox28_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox28.SelectedIndexChanged

    End Sub

    Private Sub ComboBox27_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox27.SelectedIndexChanged

    End Sub

    Private Sub ComboBox25_DropDown(sender As Object, e As EventArgs) Handles ComboBox25.DropDown
        str = " select distinct(specialization) as specialization from Employees"
        GetData(0)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                With ComboBox25
                    .DataSource = ds.Tables(0)
                    .DisplayMember = "specialization"
                End With
            Else
                With ComboBox25
                    .DataSource = Nothing
                    .Items.Clear()
                End With
            End If
        Else
            With ComboBox25
                .DataSource = Nothing
                .Items.Clear()
            End With
        End If
    End Sub

    Private Sub ComboBox25_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox25.SelectedIndexChanged

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        formID = 8
        EmployeesList.TextBox2.Text = Nothing
        EmployeesList.ShowDialog()
    End Sub

    Private Sub CheckBox37_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox37.CheckedChanged
        checkselection(CheckBox37, ComboBox34)
    End Sub

    Private Sub CheckBox36_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox36.CheckedChanged
        checkselection(CheckBox36, ComboBox33)
    End Sub

    Private Sub CheckBox35_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox35.CheckedChanged
        checkselection(CheckBox35, ComboBox32)
    End Sub

    Private Sub CheckBox34_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox34.CheckedChanged
        checkselection(CheckBox34, ComboBox31)
    End Sub

    Private Sub CheckBox33_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox33.CheckedChanged
        checkselection(CheckBox33, ComboBox30)
    End Sub

    Private Sub CheckBox32_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox32.CheckedChanged
        checkselection(CheckBox32, ComboBox29)
    End Sub

    Private Sub CheckBox31_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox31.CheckedChanged
        checkselection(CheckBox31, ComboBox28)
    End Sub

    Private Sub CheckBox30_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox30.CheckedChanged
        checkselection(CheckBox30, ComboBox27)
    End Sub

    Private Sub CheckBox29_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox29.CheckedChanged
        checkselection(CheckBox29, ComboBox26)
    End Sub

    Private Sub CheckBox28_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox28.CheckedChanged
        checkselection(CheckBox28, ComboBox25)
    End Sub

    Private Sub CheckBox27_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox27.CheckedChanged
        If CheckBox27.Checked = True Then
            DateTimePicker4.Enabled = True
            ComboBox24.Enabled = True
        Else
            DateTimePicker4.Enabled = False
            ComboBox24.Enabled = False
        End If
    End Sub

    Private Sub CheckBox17_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox17.CheckedChanged
        If CheckBox17.Checked = True Then
            Button4.Enabled = True
        Else
            Button4.Enabled = False
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        On Error GoTo fb
        str = " Select EmployeeName,degreeName ,RangeName ,PromoteDate ,PromoteType from Employees , Degrees ,Ranges , EmployeesPromotions where  " & _
              " Employees.EmployeeID = EmployeesPromotions.EmployeeID and " & _
              " Degrees.DegreeID = EmployeesPromotions.DegreeID and Ranges.RangeID = EmployeesPromotions.RangeID  and EmployeeStatus = 'A' " & _
              " AND Employees.Status ='A' AND EmployeesPromotions.Status ='A'"
        If CheckBox37.Checked = True Then
            str = str & " and Employees.branchID = " & ComboBox34.SelectedValue
        End If
        If CheckBox36.Checked = True Then
            str = str & " and Employees.DepartmentID = " & ComboBox33.SelectedValue
        End If
        If CheckBox35.Checked = True Then
            str = str & " and Employees.DegreeID = " & ComboBox32.SelectedValue
        End If
        If CheckBox34.Checked = True Then
            str = str & " and Employees.RangeID = " & ComboBox31.SelectedValue
        End If
        If CheckBox33.Checked = True Then
            str = str & " and Employees.jobID = " & ComboBox30.SelectedValue
        End If
        If CheckBox32.Checked = True Then
            str = str & " and Employees.ClassID = " & ComboBox29.SelectedValue
        End If
        If CheckBox31.Checked = True Then
            str = str & " and Employees.QualificationID = " & ComboBox28.SelectedValue
        End If
        If CheckBox30.Checked = True Then
            str = str & " and Gender = '" & Trim(ComboBox27.Text) & "' "
        End If
        If CheckBox29.Checked = True Then
            str = str & " and ScocialStatus = '" & Trim(ComboBox26.Text) & "' "
        End If
        If CheckBox28.Checked = True Then
            str = str & " and specialization = '" & ComboBox25.Text & "' "
        End If
        If CheckBox27.Checked = True Then
            str = str & " and PromoteDate " & ComboBox24.Text & " '" & DateTimePicker4.Value.Date.ToString("yyyy-MM-dd").ToString & "'"
        End If
        If CheckBox17.Checked = True Then
            str = str & " and employeeName = '" & TextBox2.Text.ToString & "' "
        End If
        If CheckBox38.Checked = True Then
            str = str & " and PromoteType ='" & ComboBox35.Text.ToString & "' "
        End If
        str = str & " ORDER BY PromoteDate"
        GetData(0)
        Dim J As New PromosionReport
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                J.Load("PromosionReport.rpt")
                J.SetDataSource(ds.Tables(0))
                Me.CrystalReportViewer3.ReportSource = J
                Me.CrystalReportViewer3.Refresh()
            Else
                MsgBox("لا توجد بيانات")
                J.Load("PromosionReport.rpt")
                J.SetDataSource(ds.Tables(0))
                Me.CrystalReportViewer3.ReportSource = J
                Me.CrystalReportViewer3.Refresh()
            End If
        Else
            MsgBox("لا توجد بيانات")
            J.Load("PromosionReport.rpt")
            J.SetDataSource(ds.Tables(0))
            Me.CrystalReportViewer3.ReportSource = J
            Me.CrystalReportViewer3.Refresh()
        End If
fb:
    End Sub

    Private Sub CheckBox38_CheckedChanged(sender As Object, e As EventArgs)
        checkselection(CheckBox38, ComboBox35)
    End Sub

    Private Sub ComboBox47_DropDown(sender As Object, e As EventArgs) Handles ComboBox47.DropDown
        GetBranches(ComboBox47)
    End Sub

    Private Sub ComboBox47_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox47.SelectedIndexChanged
        On Error Resume Next
        GetDepartments(ComboBox47, ComboBox46)
    End Sub

    Private Sub ComboBox46_DropDown(sender As Object, e As EventArgs) Handles ComboBox46.DropDown
        GetDepartments(ComboBox47, ComboBox46)
    End Sub

    Private Sub ComboBox46_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox46.SelectedIndexChanged

    End Sub

    Private Sub ComboBox45_DropDown(sender As Object, e As EventArgs) Handles ComboBox45.DropDown
        GetDegrees(ComboBox45)
    End Sub

    Private Sub ComboBox45_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox45.SelectedIndexChanged

    End Sub

    Private Sub ComboBox44_DropDown(sender As Object, e As EventArgs) Handles ComboBox44.DropDown
        GetRanges(ComboBox44)
    End Sub

    Private Sub ComboBox44_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox44.SelectedIndexChanged

    End Sub

    Private Sub ComboBox43_DropDown(sender As Object, e As EventArgs) Handles ComboBox43.DropDown
        GetJobs(ComboBox43)
    End Sub

    Private Sub ComboBox43_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox43.SelectedIndexChanged
        On Error Resume Next
        GetClasses(ComboBox43, ComboBox42)
    End Sub

    Private Sub ComboBox42_DropDown(sender As Object, e As EventArgs) Handles ComboBox42.DropDown
        GetClasses(ComboBox43, ComboBox42)
    End Sub

    Private Sub ComboBox42_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox42.SelectedIndexChanged

    End Sub

    Private Sub ComboBox41_DropDown(sender As Object, e As EventArgs) Handles ComboBox41.DropDown
        GetQualifications(ComboBox41)
    End Sub

    Private Sub ComboBox41_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox41.SelectedIndexChanged

    End Sub

    Private Sub ComboBox38_DropDown(sender As Object, e As EventArgs) Handles ComboBox38.DropDown
        str = " select distinct(specialization) as specialization from Employees"
        GetData(0)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                With ComboBox38
                    .DataSource = ds.Tables(0)
                    .DisplayMember = "specialization"
                End With
            Else
                With ComboBox38
                    .DataSource = Nothing
                    .Items.Clear()
                End With
            End If
        Else
            With ComboBox38
                .DataSource = Nothing
                .Items.Clear()
            End With
        End If
    End Sub

    Private Sub ComboBox38_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox38.SelectedIndexChanged

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        formID = 9
        EmployeesList.TextBox2.Text = Nothing
        EmployeesList.ShowDialog()
    End Sub

    Private Sub CheckBox51_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox51.CheckedChanged
        checkselection(CheckBox51, ComboBox47)
    End Sub

    Private Sub CheckBox50_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox50.CheckedChanged
        checkselection(CheckBox50, ComboBox46)
    End Sub

    Private Sub CheckBox49_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox49.CheckedChanged
        checkselection(CheckBox49, ComboBox45)
    End Sub

    Private Sub CheckBox48_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox48.CheckedChanged
        checkselection(CheckBox48, ComboBox44)
    End Sub

    Private Sub CheckBox47_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox47.CheckedChanged
        checkselection(CheckBox47, ComboBox43)
    End Sub

    Private Sub CheckBox46_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox46.CheckedChanged
        checkselection(CheckBox46, ComboBox42)
    End Sub

    Private Sub CheckBox45_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox45.CheckedChanged
        checkselection(CheckBox45, ComboBox41)
    End Sub

    Private Sub CheckBox44_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox44.CheckedChanged
        checkselection(CheckBox44, ComboBox40)
    End Sub

    Private Sub CheckBox43_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox43.CheckedChanged
        checkselection(CheckBox43, ComboBox39)
    End Sub

    Private Sub CheckBox42_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox42.CheckedChanged
        checkselection(CheckBox42, ComboBox38)
    End Sub

    Private Sub CheckBox39_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox39.CheckedChanged
        checkselection(CheckBox39, ComboBox36)
    End Sub

    Private Sub CheckBox41_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox41.CheckedChanged
        If CheckBox41.Checked = True Then
            DateTimePicker5.Enabled = True
            ComboBox37.Enabled = True
        Else
            DateTimePicker5.Enabled = False
            ComboBox37.Enabled = False
        End If
    End Sub

    Private Sub CheckBox40_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox40.CheckedChanged
        If CheckBox40.Checked = True Then
            Button6.Enabled = True
        Else
            Button6.Enabled = False
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        On Error GoTo fb
        str = " Select EmployeeName,HolidayName ,HolidayBeginDate,HolidayEndDate,DepartmentName,DATEDIFF(dd,HolidayBeginDate,HolidayEndDate) as daydiff from Employees ,Departments, HolidaysTypes , EmployeesHolidays   where " & _
              " Employees.EmployeeID = EmployeesHolidays.EmployeeID and HolidaysTypes.HolidayTypeID = EmployeesHolidays.EmployeeHolidayID and EmployeeStatus = 'A'  " & _
              " and Employees.DepartmentID = Departments.DepartmentID AND Employees.Status ='A' AND EmployeesHolidays.Status ='A' "
        If CheckBox51.Checked = True Then
            str = str & " and Employees.branchID = " & ComboBox47.SelectedValue
        End If
        If CheckBox50.Checked = True Then
            str = str & " and Employees.DepartmentID = " & ComboBox46.SelectedValue
        End If
        If CheckBox49.Checked = True Then
            str = str & " and Employees.DegreeID = " & ComboBox45.SelectedValue
        End If
        If CheckBox48.Checked = True Then
            str = str & " and Employees.RangeID = " & ComboBox44.SelectedValue
        End If
        If CheckBox47.Checked = True Then
            str = str & " and Employees.jobID = " & ComboBox43.SelectedValue
        End If
        If CheckBox46.Checked = True Then
            str = str & " and Employees.ClassID = " & ComboBox42.SelectedValue
        End If
        If CheckBox45.Checked = True Then
            str = str & " and Employees.QualificationID = " & ComboBox41.SelectedValue
        End If
        If CheckBox44.Checked = True Then
            str = str & " and Gender = '" & Trim(ComboBox40.Text) & "' "
        End If
        If CheckBox43.Checked = True Then
            str = str & " and ScocialStatus = '" & Trim(ComboBox39.Text) & "' "
        End If
        If CheckBox42.Checked = True Then
            str = str & " and specialization = '" & ComboBox38.Text & "' "
        End If
        
        If CheckBox39.Checked = True Then
            str = str & " and HolidayTypeID =" & ComboBox36.SelectedValue & " "
        End If
        If CheckBox41.Checked = True Then
            str = str & " and HolidayBeginDate " & ComboBox37.Text & " '" & DateTimePicker5.Value.Date.ToString("yyyy-MM-dd").ToString & "'"
        End If
        If CheckBox40.Checked = True Then
            str = str & " and employeeName = '" & TextBox3.Text.ToString & "' "
        End If
       
        str = str & " ORDER BY HolidayBeginDate"
        GetData(0)
        Dim J As New HolidaysReport
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                J.Load("HolidaysReport.rpt")
                J.SetDataSource(ds.Tables(0))
                Me.CrystalReportViewer4.ReportSource = J
                Me.CrystalReportViewer4.Refresh()
            Else
                MsgBox("لا توجد بيانات")
                J.Load("HolidaysReport.rpt")
                J.SetDataSource(ds.Tables(0))
                Me.CrystalReportViewer4.ReportSource = J
                Me.CrystalReportViewer4.Refresh()
            End If
        Else
            MsgBox("لا توجد بيانات")
            J.Load("HolidaysReport.rpt")
            J.SetDataSource(ds.Tables(0))
            Me.CrystalReportViewer4.ReportSource = J
            Me.CrystalReportViewer4.Refresh()
        End If
fb:
    End Sub

    Private Sub ComboBox36_DropDown(sender As Object, e As EventArgs) Handles ComboBox36.DropDown
        GetHolidaysTypes(ComboBox36)
    End Sub

    Private Sub ComboBox36_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox36.SelectedIndexChanged

    End Sub

    Private Sub ComboBox59_DropDown(sender As Object, e As EventArgs) Handles ComboBox59.DropDown
        GetBranches(ComboBox59)
    End Sub

    Private Sub ComboBox59_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox59.SelectedIndexChanged
        On Error Resume Next
        GetDepartments(ComboBox59, ComboBox58)
    End Sub

    Private Sub ComboBox58_DropDown(sender As Object, e As EventArgs) Handles ComboBox58.DropDown
        GetDepartments(ComboBox59, ComboBox58)
    End Sub

    Private Sub ComboBox58_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox58.SelectedIndexChanged

    End Sub

    Private Sub ComboBox57_DropDown(sender As Object, e As EventArgs) Handles ComboBox57.DropDown
        GetDegrees(ComboBox57)
    End Sub

    Private Sub ComboBox57_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox57.SelectedIndexChanged

    End Sub

    Private Sub ComboBox56_DropDown(sender As Object, e As EventArgs) Handles ComboBox56.DropDown
        GetRanges(ComboBox56)
    End Sub

    Private Sub ComboBox56_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox56.SelectedIndexChanged

    End Sub

    Private Sub ComboBox55_DropDown(sender As Object, e As EventArgs) Handles ComboBox55.DropDown
        GetJobs(ComboBox55)
    End Sub

    Private Sub ComboBox55_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox55.SelectedIndexChanged
        On Error Resume Next
        GetClasses(ComboBox55, ComboBox54)
    End Sub

    Private Sub ComboBox54_DropDown(sender As Object, e As EventArgs) Handles ComboBox54.DropDown
        GetClasses(ComboBox55, ComboBox54)
    End Sub

    Private Sub ComboBox54_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox54.SelectedIndexChanged

    End Sub

    Private Sub ComboBox53_DropDown(sender As Object, e As EventArgs) Handles ComboBox53.DropDown
        GetQualifications(ComboBox53)
    End Sub

    Private Sub ComboBox53_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox53.SelectedIndexChanged

    End Sub

    Private Sub ComboBox50_DropDown(sender As Object, e As EventArgs) Handles ComboBox50.DropDown
        str = " select distinct(specialization) as specialization from Employees"
        GetData(0)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                With ComboBox50
                    .DataSource = ds.Tables(0)
                    .DisplayMember = "specialization"
                End With
            Else
                With ComboBox50
                    .DataSource = Nothing
                    .Items.Clear()
                End With
            End If
        Else
            With ComboBox50
                .DataSource = Nothing
                .Items.Clear()
            End With
        End If
    End Sub

    Private Sub ComboBox50_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox50.SelectedIndexChanged

    End Sub

    Private Sub ComboBox48_DropDown(sender As Object, e As EventArgs) Handles ComboBox48.DropDown
        GetFinishingTypes(ComboBox48)
    End Sub

    Private Sub ComboBox48_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox48.SelectedIndexChanged

    End Sub

    Private Sub CheckBox64_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox64.CheckedChanged
        checkselection(CheckBox64, ComboBox59)
    End Sub

    Private Sub CheckBox63_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox63.CheckedChanged
        checkselection(CheckBox63, ComboBox58)
    End Sub

    Private Sub CheckBox62_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox62.CheckedChanged
        checkselection(CheckBox62, ComboBox57)
    End Sub

    Private Sub CheckBox61_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox61.CheckedChanged
        checkselection(CheckBox61, ComboBox56)
    End Sub

    Private Sub CheckBox60_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox60.CheckedChanged
        checkselection(CheckBox60, ComboBox55)
    End Sub

    Private Sub CheckBox59_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox59.CheckedChanged
        checkselection(CheckBox59, ComboBox54)
    End Sub

    Private Sub CheckBox58_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox58.CheckedChanged
        checkselection(CheckBox58, ComboBox53)
    End Sub

    Private Sub CheckBox57_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox57.CheckedChanged
        checkselection(CheckBox57, ComboBox52)
    End Sub

    Private Sub CheckBox56_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox56.CheckedChanged
        checkselection(CheckBox56, ComboBox51)
    End Sub

    Private Sub CheckBox55_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox55.CheckedChanged
        checkselection(CheckBox55, ComboBox50)
    End Sub

    Private Sub CheckBox52_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox52.CheckedChanged
        checkselection(CheckBox52, ComboBox48)
    End Sub

    Private Sub CheckBox54_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox54.CheckedChanged
        If CheckBox54.Checked = True Then
            DateTimePicker6.Enabled = True
            ComboBox49.Enabled = True
        Else
            DateTimePicker6.Enabled = False
            ComboBox49.Enabled = False
        End If
    End Sub

    Private Sub CheckBox53_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox53.CheckedChanged
        If CheckBox53.Checked = True Then
            Button8.Enabled = True
        Else
            Button8.Enabled = False
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        On Error GoTo fb
        str = " Select EmployeeName,FinishingTypeName ,FinishingDate ,Remarks,DepartmentName   from Employees , FinishingTypes , EmployeeFinishings,departments  where " & _
             "  Employees.EmployeeID = EmployeeFinishings.EmployeeID And FinishingTypes.FinishingTypeID = EmployeeFinishings.FinishingTypeID " & _
             " and Employees.DepartmentID = Departments.DepartmentID AND Employees.Status ='A' AND EmployeeFinishings.Status ='A' "
        If CheckBox64.Checked = True Then
            str = str & " and Employees.branchID = " & ComboBox59.SelectedValue
        End If
        If CheckBox63.Checked = True Then
            str = str & " and Employees.DepartmentID = " & ComboBox58.SelectedValue
        End If
        If CheckBox62.Checked = True Then
            str = str & " and Employees.DegreeID = " & ComboBox57.SelectedValue
        End If
        If CheckBox61.Checked = True Then
            str = str & " and Employees.RangeID = " & ComboBox56.SelectedValue
        End If
        If CheckBox60.Checked = True Then
            str = str & " and Employees.jobID = " & ComboBox55.SelectedValue
        End If
        If CheckBox59.Checked = True Then
            str = str & " and Employees.ClassID = " & ComboBox54.SelectedValue
        End If
        If CheckBox58.Checked = True Then
            str = str & " and Employees.QualificationID = " & ComboBox53.SelectedValue
        End If
        If CheckBox57.Checked = True Then
            str = str & " and Gender = '" & Trim(ComboBox52.Text) & "' "
        End If
        If CheckBox56.Checked = True Then
            str = str & " and ScocialStatus = '" & Trim(ComboBox51.Text) & "' "
        End If
        If CheckBox55.Checked = True Then
            str = str & " and specialization = '" & ComboBox50.Text & "' "
        End If

        If CheckBox52.Checked = True Then
            str = str & " and FinishingTypeID =" & ComboBox48.SelectedValue & " "
        End If
        If CheckBox54.Checked = True Then
            str = str & " and FinishingDate " & ComboBox49.Text & " '" & DateTimePicker6.Value.Date.ToString("yyyy-MM-dd").ToString & "'"
        End If
        If CheckBox53.Checked = True Then
            str = str & " and employeeName = '" & TextBox4.Text.ToString & "' "
        End If

        str = str & " ORDER BY FinishingDate "
        GetData(0)
        Dim J As New FininshingsReport
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                J.Load("FininshingsReport.rpt")
                J.SetDataSource(ds.Tables(0))
                Me.CrystalReportViewer5.ReportSource = J
                Me.CrystalReportViewer5.Refresh()
            Else
                MsgBox("لا توجد بيانات")
                J.Load("FininshingsReport.rpt")
                J.SetDataSource(ds.Tables(0))
                Me.CrystalReportViewer5.ReportSource = J
                Me.CrystalReportViewer5.Refresh()
            End If
        Else
            MsgBox("لا توجد بيانات")
            J.Load("FininshingsReport.rpt")
            J.SetDataSource(ds.Tables(0))
            Me.CrystalReportViewer5.ReportSource = J
            Me.CrystalReportViewer5.Refresh()
        End If
fb:
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        formID = 10
        EmployeesList.TextBox2.Text = Nothing
        EmployeesList.ShowDialog()
    End Sub

    Private Sub ComboBox71_DropDown(sender As Object, e As EventArgs) Handles ComboBox71.DropDown
        GetBranches(ComboBox71)
    End Sub

    Private Sub ComboBox71_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox71.SelectedIndexChanged
        On Error Resume Next
        GetDepartments(ComboBox71, ComboBox70)
    End Sub

    Private Sub ComboBox70_DropDown(sender As Object, e As EventArgs) Handles ComboBox70.DropDown
        GetDepartments(ComboBox71, ComboBox70)
    End Sub

    Private Sub ComboBox70_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox70.SelectedIndexChanged

    End Sub

    Private Sub ComboBox69_DropDown(sender As Object, e As EventArgs) Handles ComboBox69.DropDown
        GetDegrees(ComboBox69)
    End Sub

    Private Sub ComboBox69_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox69.SelectedIndexChanged

    End Sub

    Private Sub ComboBox68_DropDown(sender As Object, e As EventArgs) Handles ComboBox68.DropDown
        GetRanges(ComboBox68)
    End Sub

    Private Sub ComboBox68_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox68.SelectedIndexChanged

    End Sub

    Private Sub ComboBox67_DropDown(sender As Object, e As EventArgs) Handles ComboBox67.DropDown
        GetJobs(ComboBox67)
    End Sub

    Private Sub ComboBox67_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox67.SelectedIndexChanged
        On Error Resume Next
        GetClasses(ComboBox67, ComboBox66)
    End Sub

    Private Sub ComboBox66_DropDown(sender As Object, e As EventArgs) Handles ComboBox66.DropDown
        GetClasses(ComboBox67, ComboBox66)
    End Sub

    Private Sub ComboBox66_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox66.SelectedIndexChanged

    End Sub

    Private Sub ComboBox65_DropDown(sender As Object, e As EventArgs) Handles ComboBox65.DropDown
        GetQualifications(ComboBox65)
    End Sub

    Private Sub ComboBox65_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox65.SelectedIndexChanged

    End Sub

    Private Sub ComboBox62_DropDown(sender As Object, e As EventArgs) Handles ComboBox62.DropDown
        str = " select distinct(specialization) as specialization from Employees"
        GetData(0)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                With ComboBox62
                    .DataSource = ds.Tables(0)
                    .DisplayMember = "specialization"
                End With
            Else
                With ComboBox62
                    .DataSource = Nothing
                    .Items.Clear()
                End With
            End If
        Else
            With ComboBox62
                .DataSource = Nothing
                .Items.Clear()
            End With
        End If
    End Sub

    Private Sub ComboBox62_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox62.SelectedIndexChanged

    End Sub

    Private Sub CheckBox77_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox77.CheckedChanged
        checkselection(CheckBox77, ComboBox71)
    End Sub

    Private Sub CheckBox76_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox76.CheckedChanged
        checkselection(CheckBox76, ComboBox70)
    End Sub

    Private Sub CheckBox75_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox75.CheckedChanged
        checkselection(CheckBox75, ComboBox69)
    End Sub

    Private Sub CheckBox74_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox74.CheckedChanged
        checkselection(CheckBox74, ComboBox68)
    End Sub

    Private Sub CheckBox73_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox73.CheckedChanged
        checkselection(CheckBox73, ComboBox67)
    End Sub

    Private Sub CheckBox72_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox72.CheckedChanged
        checkselection(CheckBox72, ComboBox66)
    End Sub

    Private Sub CheckBox71_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox71.CheckedChanged
        checkselection(CheckBox71, ComboBox65)
    End Sub

    Private Sub CheckBox70_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox70.CheckedChanged
        checkselection(CheckBox70, ComboBox64)
    End Sub

    Private Sub CheckBox69_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox69.CheckedChanged
        checkselection(CheckBox69, ComboBox63)
    End Sub

    Private Sub CheckBox68_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox68.CheckedChanged
        checkselection(CheckBox68, ComboBox62)
    End Sub

    Private Sub CheckBox67_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox67.CheckedChanged
        If CheckBox67.Checked = True Then
            DateTimePicker7.Enabled = True
            ComboBox61.Enabled = True
        Else
            DateTimePicker7.Enabled = False
            ComboBox61.Enabled = False
        End If
    End Sub

    Private Sub CheckBox66_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox66.CheckedChanged
        If CheckBox66.Checked = True Then
            Button10.Enabled = True
        Else
            Button10.Enabled = False
        End If
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        On Error GoTo fb
        str = " Select Infraction,InfractionDate,EmployeeName,InvestigationDate ,Decision ,DecisionDate,Adversary,DepartmentName from Employees , Investigations ,Departments   where " & _
              " Employees.EmployeeID = Investigations.EmployeeID and Employees.DepartmentID = Departments.DepartmentID AND Employees.Status ='A' AND Investigations.Status ='A' "
        If CheckBox77.Checked = True Then
            str = str & " and Employees.branchID = " & ComboBox71.SelectedValue
        End If
        If CheckBox76.Checked = True Then
            str = str & " and Employees.DepartmentID = " & ComboBox70.SelectedValue
        End If
        If CheckBox75.Checked = True Then
            str = str & " and Employees.DegreeID = " & ComboBox69.SelectedValue
        End If
        If CheckBox74.Checked = True Then
            str = str & " and Employees.RangeID = " & ComboBox68.SelectedValue
        End If
        If CheckBox73.Checked = True Then
            str = str & " and Employees.jobID = " & ComboBox67.SelectedValue
        End If
        If CheckBox72.Checked = True Then
            str = str & " and Employees.ClassID = " & ComboBox66.SelectedValue
        End If
        If CheckBox71.Checked = True Then
            str = str & " and Employees.QualificationID = " & ComboBox65.SelectedValue
        End If
        If CheckBox70.Checked = True Then
            str = str & " and Gender = '" & Trim(ComboBox64.Text) & "' "
        End If
        If CheckBox69.Checked = True Then
            str = str & " and ScocialStatus = '" & Trim(ComboBox63.Text) & "' "
        End If
        If CheckBox68.Checked = True Then
            str = str & " and specialization = '" & ComboBox62.Text & "' "
        End If
        If CheckBox67.Checked = True Then
            str = str & " and (InvestigationDate " & ComboBox61.Text & " '" & DateTimePicker7.Value.Date.ToString("yyyy-MM-dd").ToString & "' or " & _
                        " DecisionDate " & ComboBox61.Text & " '" & DateTimePicker7.Value.Date.ToString("yyyy-MM-dd").ToString & "')"
        End If
        If CheckBox66.Checked = True Then
            str = str & " and employeeName = '" & TextBox5.Text.ToString & "' "
        End If

        str = str & " ORDER BY InvestigationDate "
        GetData(0)
        Dim J As New InvestigationsReport
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                J.Load("InvestigationsReport.rpt")
                J.SetDataSource(ds.Tables(0))
                Me.CrystalReportViewer6.ReportSource = J
                Me.CrystalReportViewer6.Refresh()
            Else
                MsgBox("لا توجد بيانات")
                J.Load("InvestigationsReport.rpt")
                J.SetDataSource(ds.Tables(0))
                Me.CrystalReportViewer6.ReportSource = J
                Me.CrystalReportViewer6.Refresh()
            End If
        Else
            MsgBox("لا توجد بيانات")
            J.Load("InvestigationsReport.rpt")
            J.SetDataSource(ds.Tables(0))
            Me.CrystalReportViewer6.ReportSource = J
            Me.CrystalReportViewer6.Refresh()
        End If
fb:
    End Sub


    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        formID = 11
        EmployeesList.TextBox2.Text = Nothing
        EmployeesList.ShowDialog()
    End Sub

   
    Private Sub Button12_Click(sender As Object, e As EventArgs)
        formID = 12
        EmployeesList.TextBox2.Text = Nothing
        EmployeesList.ShowDialog()
    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs)

    End Sub
End Class