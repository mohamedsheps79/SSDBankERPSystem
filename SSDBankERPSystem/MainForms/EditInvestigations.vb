Imports System.IO
Public Class EditInvestigations

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        formID = 6
        EmployeesList.TextBox2.Text = Nothing
        EmployeesList.ShowDialog()
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
            str = " Insert into Investigations values (" & EmployeeID & ",'" & TextBox5.Text.ToString & "','" & DateTimePicker3.Value.Date.ToString("MM-dd-yyyy").ToString & "', " & _
                " '" & DateTimePicker1.Value.Date.ToString("MM-dd-yyyy").ToString & "', '" & TextBox3.Text & "' ,  " & _
                " '" & DateTimePicker2.Value.Date.ToString("MM-dd-yyyy").ToString & "','" & TextBox4.Text.ToString & "'," & ComboBox1.Text & " , 0," & UserID & ",'','N'," & _
                " @arrimg1)"
            Dim cmdSQL As New System.Data.SqlClient.SqlCommand(str, cnn)
            With cmdSQL
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@arrimg1", SqlDbType.Image)).Value = arrimg1
            End With
            cmdSQL.ExecuteNonQuery()
            MsgBox("تم الحفظ")
        Else
            str = " Update Investigations SET EmployeeID = " & EmployeeID & ",InvestigationDate= '" & DateTimePicker1.Value.Date.ToString("MM-dd-yyyy").ToString & "'," & _
                          " Decision = '" & TextBox3.Text.ToString & "',DecisionDate='" & DateTimePicker2.Value.Date.ToString("MM-dd-yyyy").ToString & "',Adversary= '" & TextBox4.Text.ToString & "' " & _
                          " ,Infraction='" & TextBox5.Text.ToString & "' , InfractionDate= '" & DateTimePicker3.Value.Date.ToString("MM-dd-yyyy").ToString & "' , " & _
                          " AdversaryInterval = " & ComboBox1.Text & ", InvestigationDocument = @arrimg1 ," & _
                          " Status = 'A' , AuthorizedBy = " & UserID & " where InvestigationID = " & Employees.DataGridView7(1, r).Value & " "
            Dim cmdSQL As New System.Data.SqlClient.SqlCommand(str, cnn)
            With cmdSQL
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@arrimg1", SqlDbType.Image)).Value = arrimg1
            End With
            cmdSQL.ExecuteNonQuery()
            MsgBox("تم التصريح")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If MsgBox("هل تريد الحذف", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            str = " Delete from Investigations where InvestigationID = " & Employees.DataGridView7(1, r).Value & "   "
            Execute_Command()
            MsgBox("تم الحذف")

        Else
            Exit Sub
        End If

    End Sub

    Private Sub EditInvestigations_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        str = " Select Investigations.InvestigationID,Infraction,InfractionDate,Investigations.EmployeeID,EmployeeName,InvestigationDate,Investigations.Decision,DecisionDate,Adversary " & _
            " ,AdversaryInterval,Investigations.Status from Investigations, employees where employees.EmployeeID = Investigations.employeeID "
        GetData(0)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                Employees.DataGridView7.DataSource = ds.Tables(0)
            Else
                Employees.DataGridView7.DataSource = Nothing
            End If
        Else
            Employees.DataGridView7.DataSource = Nothing
        End If
    End Sub

    Private Sub EditInvestigations_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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