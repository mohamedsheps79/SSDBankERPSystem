Imports System.IO
Public Class EditEmployeesTrainings

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
            str = " Insert into EmployeesTrainings values (" & EmployeeID & ",'" & TextBox4.Text & "','" & DateTimePicker1.Value.Date.ToString("MM-dd-yyyy").ToString & "', " & _
                " '" & DateTimePicker2.Value.Date.ToString("MM-dd-yyyy").ToString & "', '" & TextBox5.Text & "' ," & _
                " '" & TextBox6.Text & "' , '" & DateTimePicker3.Value.Date.ToString("MM-dd-yyyy").ToString & "' ,  @arrimg1)"
            Dim cmdSQL As New System.Data.SqlClient.SqlCommand(str, cnn)
            With cmdSQL
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@arrimg1", SqlDbType.Image)).Value = arrimg1
            End With
            cmdSQL.ExecuteNonQuery()
            MsgBox("تم الحفظ")
        Else
            Dim data As Byte() = DirectCast(Employees.DataGridView9(10, r).Value, Byte())
            Dim ms As New MemoryStream(data)
            Me.PictureBox1.Image = Image.FromStream(ms)
            PictureBox1.Image.Save(ms1, PictureBox1.Image.RawFormat)
            arrimg1 = ms1.GetBuffer
            ms1.Close()
            str = " Update EmployeesTrainings SET EmployeeID= " & EmployeeID & ",TrainingName='" & TextBox4.Text & "' " & _
                " ,BeginDate = '" & DateTimePicker1.Value.Date.ToString("MM-dd-yyyy").ToString & "', " & _
                " EndDate = '" & DateTimePicker2.Value.Date.ToString("MM-dd-yyyy").ToString & "', TrainingPlace = '" & TextBox5.Text & "' ," & _
                " DecisionNo = '" & TextBox6.Text & "' , DecisionDate = '" & DateTimePicker3.Value.Date.ToString("MM-dd-yyyy").ToString & "' , " & _
                " DecisionDocument = @arrimg1 where TrainingID = " & Employees.DataGridView9(1, r).Value & " "
            Dim cmdSQL As New System.Data.SqlClient.SqlCommand(str, cnn)
            With cmdSQL
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@arrimg1", SqlDbType.Image)).Value = arrimg1
            End With
            cmdSQL.ExecuteNonQuery()
            MsgBox("تم التعديل")
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        formID = 12
        EmployeesList.TextBox2.Text = Nothing
        EmployeesList.ShowDialog()
    End Sub

    Private Sub EditEmployeesTrainings_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        str = " Select EmployeesTrainings.TrainingID,EmployeesTrainings.EmployeeID,TrainingName,EmployeeName,BeginDate,EndDate,TrainingPlace,DecisionNo " & _
                      " ,DecisionDate,DecisionDocument from EmployeesTrainings, employees where employees.EmployeeID = EmployeesTrainings.employeeID "
        GetData(0)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                Employees.DataGridView9.DataSource = ds.Tables(0)
            Else
                Employees.DataGridView9.DataSource = Nothing
            End If
        Else
            Employees.DataGridView9.DataSource = Nothing
        End If
    End Sub

    Private Sub EditEmployeesTrainings_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If MsgBox("هل تريد الحذف", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            str = " Delete from EmployeesTrainings where TrainingID = " & Employees.DataGridView9(1, r).Value & "  "
            Execute_Command()
            MsgBox("تم الحذف")
        Else
            Exit Sub
        End If
    End Sub
End Class