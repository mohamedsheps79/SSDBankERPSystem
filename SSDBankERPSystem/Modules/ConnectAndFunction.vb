Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.Drawing2D
Imports Microsoft.VisualBasic
Imports System.Data.OleDb
Module ConnectAndFunction
    Public frm As Form
    Public AccessFileName As String = "E:\Database2.accdb"
    Public Function GetGraphicsOpject(ByVal w As Int16, ByVal h As Int16)
        Dim bmp As Bitmap
        bmp = New Bitmap(w, h)
        Dim G As Graphics = Graphics.FromImage(bmp)
        Dim r As New Rectangle(0, 0, w, h)
        Dim startColor As Color = Color.SkyBlue
        Dim EndColor As Color = Color.SkyBlue
        Dim LGBrush As New System.Drawing.Drawing2D.LinearGradientBrush(r, startColor, EndColor, LinearGradientMode.Vertical)
        G.FillRectangle(LGBrush, New Rectangle(0, 0, w, h))
        Return bmp
    End Function
    Public Sub Connection()
        Try
            cnn = New SqlConnection
            'cnn.ConnectionString = "Data Source=.;Initial Catalog=EmployeesCardDB;Integrated Security=True"
            'cnn.ConnectionString = "Data Source=HP;Initial Catalog=hrDB;User ID=sa; Password=sheps79"
            cnn.ConnectionString = "Data Source=.;Initial Catalog=hrDB;User ID=sa; Password=saam"

            cnn.Open()
        Catch ex As Exception
            MsgBox(" مشكلة في الشبكة ، لا يمكن الوصول الى قاعدة البيانات ", MsgBoxStyle.Exclamation, "خطأ في الاتصال ")
            End
        End Try
    End Sub

    Public Sub Execute_Command()
        cmd = New SqlCommand(str, cnn)
        cmd.ExecuteNonQuery()
    End Sub
    Public Sub GetData(ByVal TableName As String)
        On Error GoTo fn
        adb = New SqlDataAdapter(str, cnn)
        ds = New DataSet
        adb.Fill(ds, TableName)
fn:
    End Sub

    Public Sub AccessConnection()
        Try
            AccessCon = New OleDbConnection
            AccessCon.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dell\Desktop\Database21.accdb"
            AccessCon.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
            End
        End Try
    End Sub
    Public Sub AccessGetData(ByVal TableName As String)
        On Error GoTo fn
        AccessAdapter = New OleDbDataAdapter(AccessStr, AccessCon)
        AccessDS = New DataSet
        AccessAdapter.Fill(AccessDS, TableName)
fn:
    End Sub
    Public Sub GetData2(ByVal TableName As String)
        On Error GoTo fn
        adb = New SqlDataAdapter(str, cnn)
        ds2 = New DataSet
        adb.Fill(ds2, TableName)
fn:
    End Sub
    Public Sub GetData3(ByVal TableName As String)
        On Error GoTo fn
        adb = New SqlDataAdapter(str, cnn)
        ds3 = New DataSet
        adb.Fill(ds3, TableName)
fn:
    End Sub

    Public Sub checkselection(ByVal ch As CheckBox, ByVal combo As ComboBox)
        If ch.Checked = True Then
            combo.Enabled = True
        Else
            combo.Enabled = False
        End If
    End Sub
    Public Function WhatRadioIsSelected(ByVal grp As GroupBox) As String
        Dim rbtn As RadioButton
        Dim rbtnName As String = String.Empty
        Try
            Dim ctl As Control
            For Each ctl In grp.Controls
                If TypeOf ctl Is RadioButton Then
                    rbtn = DirectCast(ctl, RadioButton)
                    If rbtn.Checked Then
                        rbtnName = rbtn.Text
                        Exit For
                    End If
                End If
            Next
        Catch ex As Exception
            Dim stackframe As New Diagnostics.StackFrame(1)
            Throw New Exception("An error occurred in routine, '" & stackframe.GetMethod.ReflectedType.Name & "." & System.Reflection.MethodInfo.GetCurrentMethod.Name & "'." & Environment.NewLine & "  Message was: '" & ex.Message & "'")
        End Try
        Return rbtnName
    End Function


    Public Function getcheck(ByVal ch As CheckBox) As String
        Dim sp = ch.Checked
        Dim r As String
        If sp = True Then
            r = ch.Text
        Else
            r = "0"
        End If
        Return r
    End Function

    Public Sub showform(ByVal a As Form)
        On Error Resume Next
        If frm Is Nothing Then
        Else
            frm.Close()
        End If
        frm = a
        frm.MdiParent = Home
        frm.Show()
    End Sub
    Public Sub GetBranches(combo As ComboBox)
        str = " Select BranchID,BranchName from Branches"
        GetData(0)
        If ds.Tables(0).Rows.Count > 0 Then
            With combo
                .DataSource = ds.Tables(0)
                .DisplayMember = "BranchName"
                .ValueMember = "BranchID"
            End With
        Else
            With combo
                .DataSource = Nothing
                .Items.Clear()
            End With
        End If
    End Sub
    Public Sub GetDepartments(BranchComb As ComboBox, DeptComb As ComboBox)
        str = " Select DepartmentID,DepartmentName from Departments where BranchID =" & BranchComb.SelectedValue & " "
        GetData(0)
        If ds.Tables(0).Rows.Count > 0 Then
            With DeptComb
                .DataSource = ds.Tables(0)
                .DisplayMember = "DepartmentName"
                .ValueMember = "DepartmentID"
            End With
        Else
            With DeptComb
                .DataSource = Nothing
                .Items.Clear()
            End With
        End If
    End Sub
    Public Sub GetJobs(JobhComb As ComboBox)
        str = " Select * from jobs "
        GetData(0)
        If ds.Tables(0).Rows.Count > 0 Then
            With JobhComb
                .DataSource = ds.Tables(0)
                .DisplayMember = "JobName"
                .ValueMember = "JobID"
            End With
        Else
            With JobhComb
                .DataSource = Nothing
                .Items.Clear()
            End With
        End If
    End Sub

    Public Sub GetClasses(JobComb As ComboBox, ClassComb As ComboBox)
        str = " Select ClassID,ClassName from Classes where JobID =" & JobComb.SelectedValue & " "
        GetData(0)
        If ds.Tables(0).Rows.Count > 0 Then
            With ClassComb
                .DataSource = ds.Tables(0)
                .DisplayMember = "ClassName"
                .ValueMember = "ClassID"
            End With
        Else
            With ClassComb
                .DataSource = Nothing
                .Items.Clear()
            End With
        End If
    End Sub

    Public Sub GetDocumentsTypes(DocumentTypesComb As ComboBox)
        str = " Select DocumentTypeID,DocumentName from DocumentsTypes "
        GetData(0)
        If ds.Tables(0).Rows.Count > 0 Then
            With DocumentTypesComb
                .DataSource = ds.Tables(0)
                .DisplayMember = "DocumentName"
                .ValueMember = "DocumentTypeID"
            End With
        Else
            With DocumentTypesComb
                .DataSource = Nothing
                .Items.Clear()
            End With
        End If
    End Sub

    Public Sub GetDegrees(DegreesComb As ComboBox)
        str = " Select DegreeID,DegreeName from Degrees "
        GetData(0)
        If ds.Tables(0).Rows.Count > 0 Then
            With DegreesComb
                .DataSource = ds.Tables(0)
                .DisplayMember = "DegreeName"
                .ValueMember = "DegreeID"
            End With
        Else
            With DegreesComb
                .DataSource = Nothing
                .Items.Clear()
            End With
        End If
    End Sub

    Public Sub GetRanges(RangeComb As ComboBox)
        str = " Select RangeID,RangeName from Ranges  "
        GetData(0)
        If ds.Tables(0).Rows.Count > 0 Then
            With RangeComb
                .DataSource = ds.Tables(0)
                .DisplayMember = "RangeName"
                .ValueMember = "RangeID"
            End With
        Else
            With RangeComb
                .DataSource = Nothing
                .Items.Clear()
            End With
        End If
    End Sub


    Public Sub GetQualifications(QualificationComb As ComboBox)
        str = " Select * from Qualifications "
        GetData(0)
        If ds.Tables(0).Rows.Count > 0 Then
            With QualificationComb
                .DataSource = ds.Tables(0)
                .DisplayMember = "QualificationName"
                .ValueMember = "QualificationID"
            End With
        Else
            With QualificationComb
                .DataSource = Nothing
                .Items.Clear()
            End With
        End If
    End Sub

    Public Sub GetFinishingTypes(Comb As ComboBox)
        str = " Select * from FinishingTypes "
        GetData(0)
        If ds.Tables(0).Rows.Count > 0 Then
            With Comb
                .DataSource = ds.Tables(0)
                .DisplayMember = "FinishingTypeName"
                .ValueMember = "FinishingTypeID"
            End With
        Else
            With Comb
                .DataSource = Nothing
                .Items.Clear()
            End With
        End If
    End Sub
    

    Public Sub GetHolidaysTypes(Comb As ComboBox)
        str = " Select * from HolidaysTypes "
        GetData(0)
        If ds.Tables(0).Rows.Count > 0 Then
            With Comb
                .DataSource = ds.Tables(0)
                .DisplayMember = "HolidayName"
                .ValueMember = "HolidayTypeID"
            End With
        Else
            With Comb
                .DataSource = Nothing
                .Items.Clear()
            End With
        End If
    End Sub


    Public Function addrowsandcolumns(ByVal nrow As Integer, ByVal ncolumn As Integer, ByVal dgv As DataGridView) As DataTable
        ' On Error Resume Next
        dtsource.Rows.Clear()
        dtsource.Columns.Clear()
        For i As Integer = 0 To ncolumn - 1
            dtsource.Columns.Add(i.ToString)
        Next
        For j As Integer = 0 To nrow - 1
            On Error Resume Next
            Dim dr As DataRow = dtsource.NewRow
            dr(j) = ""
            dtsource.Rows.Add(dr)
        Next
        Return dtsource
    End Function
End Module

