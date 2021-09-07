Imports System.IO
Public Class EditEmployeePositions

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        formID = 11
        EmployeesList.TextBox2.Text = Nothing
        EmployeesList.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If MsgBox("هل تريد الحذف", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            str = " Delete from EmployeePositions where positionID = " & Employees.DataGridView8(1, r).Value & "  "
            Execute_Command()
            MsgBox("تم الحذف")
        Else


        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim ms1 As New MemoryStream()
        Dim arrimg1() As Byte
        Dim arrfilename1() As String = Split(Fname1, "\")
        If Fname1 = Nothing Then
            PictureBox1.Image = My.Resources.Document
            PictureBox1.Image.Save(ms1, PictureBox1.Image.RawFormat)
            arrimg1 = ms1.GetBuffer
            ms1.Close()
        Else
            Array.Reverse(arrfilename1)
            PictureBox1.Image.Save(ms1, PictureBox1.Image.RawFormat)
            arrimg1 = ms1.GetBuffer
            ms1.Close()
        End If

        If n = 0 Then
            str = " Insert into EmployeePositions values (" & EmployeeID & "," & ComboBox1.SelectedValue & " , " & ComboBox3.SelectedValue & " , " & _
                " " & ComboBox2.SelectedValue & " ," & ComboBox4.SelectedValue & ",'" & DateTimePicker1.Value.Date.ToString("MM-dd-yyyy").ToString & "'," & UserID & ",'','N', " & _
                " '" & TextBox4.Text & "' , '" & DateTimePicker1.Value.Date.ToString("MM-dd-yyyy").ToString & "',@arrimg1)"
            Dim cmdSQL As New System.Data.SqlClient.SqlCommand(str, cnn)
            With cmdSQL
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@arrimg1", SqlDbType.Image)).Value = arrimg1
            End With
            cmdSQL.ExecuteNonQuery()
            MsgBox("تم الحفظ")
        Else
            str = " Update EmployeePositions SET EmployeeID = " & EmployeeID & ",FromJobID = " & ComboBox1.SelectedValue & " ,JobID= " & ComboBox3.SelectedValue & ", " & _
                  " FromClassID = " & ComboBox2.SelectedValue & " ,ClassID =" & ComboBox4.SelectedValue & ", DecisionNo = '" & TextBox4.Text & "', " & _
                  " PositionDate = '" & DateTimePicker1.Value.Date.ToString("MM-dd-yyyy").ToString & "',Status = 'A' ,  " & _
                  " AuthorizedBy = " & UserID & " , DecisionDate = '" & DateTimePicker1.Value.Date.ToString("MM-dd-yyyy").ToString & "', " & _
                  " PositionDocument = @arrimg1 where positionID = " & Employees.DataGridView8(1, r).Value & " "
            Dim cmdSQL As New System.Data.SqlClient.SqlCommand(str, cnn)
            With cmdSQL
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@arrimg1", SqlDbType.Image)).Value = arrimg1
            End With
            cmdSQL.ExecuteNonQuery()
            MsgBox("تم التعديل")
        End If
    End Sub

    Private Sub ComboBox4_DropDown(sender As Object, e As EventArgs) Handles ComboBox4.DropDown
        GetClasses(ComboBox3, ComboBox4)
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged

    End Sub

    Private Sub ComboBox1_DropDown(sender As Object, e As EventArgs) Handles ComboBox1.DropDown
        GetJobs(ComboBox1)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub ComboBox3_DropDown(sender As Object, e As EventArgs) Handles ComboBox3.DropDown
        GetJobs(ComboBox3)
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged

    End Sub

    Private Sub ComboBox2_DropDown(sender As Object, e As EventArgs) Handles ComboBox2.DropDown
        GetClasses(ComboBox1, ComboBox2)
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged

    End Sub

    Private Sub EditEmployeePositions_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        On Error Resume Next
        str = " Select EmployeePositions.positionID,EmployeePositions.EmployeeID,FromJobID,J1.JobName JobName1,EmployeePositions.JobID, J2.JobName as JobName2,FromClassID,C1.className as className1, " & _
          " EmployeePositions.ClassID,C2.className as className2 ,PositionDate,EmployeeName,EmployeePositions.Status " & _
          " from  EmployeePositions,Employees, Jobs j1, jobs j2,Classes C1,Classes C2 WHERE " & _
          " Employees.EmployeeID = EmployeePositions.EmployeeID AND" & _
          " EmployeePositions.FromJobID = J1.JOBID AND EmployeePositions.JobID = J2.JobID AND EmployeePositions.FromClassID = C1.ClassID AND " & _
          " EmployeePositions.ClassID = C2.ClassID AND J1.JOBID = C1.JOBID AND J2.JOBID = C2.JOBID "
        GetData(0)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                Employees.DataGridView8.DataSource = ds.Tables(0)
            Else
                Employees.DataGridView8.DataSource = Nothing
            End If
        Else
            Employees.DataGridView8.DataSource = Nothing
        End If
    End Sub

    Private Sub EditEmployeePositions_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
            Dim m() As String = Split(OpenFileDialog1.FileName, "\")
            Array.Reverse(m)
            Fname1 = m(0)
        Else
            Exit Sub
        End If
    End Sub
End Class