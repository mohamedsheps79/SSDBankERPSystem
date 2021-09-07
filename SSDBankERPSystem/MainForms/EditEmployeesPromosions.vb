Imports System.IO
Public Class EditEmployeesPromosions

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


        Connection()
        If n = 0 Then
            str = " Insert into EmployeesPromotions values (" & EmployeeID & ", " & ComboBox1.SelectedValue & " , " & ComboBox2.SelectedValue & ", " &
               " '" & DateTimePicker1.Value.Date.ToString("MM-dd-yyyy").ToString & "', '" & ComboBox3.Text & "', " &
               " '" & TextBox3.Text.ToString & "'," & UserID & ",'','N', '" & TextBox4.Text & "' ,'" & DateTimePicker2.Value.Date.ToString("MM-dd-yyyy").ToString & "', " &
               " @arrimg1)"
            Dim cmdSQL As New System.Data.SqlClient.SqlCommand(str, cnn)
            With cmdSQL
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@arrimg1", SqlDbType.Image)).Value = arrimg1
            End With
            cmdSQL.ExecuteNonQuery()

            cnn.Close()
            MsgBox("تمت الحفظ  ")

        Else
            str = " Update EmployeesPromotions SET  EmployeeID = " & EmployeeID & ",DegreeID= " & ComboBox1.SelectedValue & " , RangeID =" & ComboBox2.SelectedValue & ", " &
                          " PromoteDate = '" & DateTimePicker1.Value.Date.ToString("MM-dd-yyyy").ToString & "',PromoteType = '" & ComboBox3.Text & "', " &
                          " Remarks = '" & TextBox3.Text.ToString & "',Status = 'A' , AuthorizedBy = " & UserID & ",DecisionNo = '" & TextBox4.Text & "' ,  " &
                          " DecisionDate = '" & DateTimePicker1.Value.Date.ToString("MM-dd-yyyy").ToString & "', MovementDocument = @arrimg1 " &
                          " where PromoteID = " & Employees.DataGridView2(1, r).Value & " "
            Dim cmdSQL As New System.Data.SqlClient.SqlCommand(str, cnn)
            With cmdSQL
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@arrimg1", SqlDbType.Image)).Value = arrimg1
            End With
            cmdSQL.ExecuteNonQuery()
            MsgBox("تم التعديل")
            cnn.Close()
        End If
        Connection()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If MsgBox("هل تريد الحذف", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            str = " Delete from EmployeesPromotions where PromoteID = " & Employees.DataGridView2(1, r).Value & "  "
            Execute_Command()
            MsgBox("تم الحذف")
        Else
            Exit Sub
        End If

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        formID = 1
        EmployeesList.TextBox2.Text = Nothing
        EmployeesList.ShowDialog()
    End Sub

    Private Sub ComboBox1_DropDown(sender As Object, e As EventArgs) Handles ComboBox1.DropDown
        GetDegrees(ComboBox1)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub ComboBox2_DropDown(sender As Object, e As EventArgs) Handles ComboBox2.DropDown
        GetRanges(ComboBox2)
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged

    End Sub

    Private Sub EditEmployeesPromosions_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        str = " Select EmployeeName,PromoteID,EmployeesPromotions.EmployeeID,EmployeesPromotions.DegreeID,EmployeesPromotions.RangeID,PromoteDate,PromoteType,Remarks,EmployeesPromotions.Status  " & _
           " from employees inner join EmployeesPromotions on (EmployeesPromotions.employeeid = employees.employeeid)"
        GetData(0)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                Employees.DataGridView2.DataSource = ds.Tables(0)
            Else
                Employees.DataGridView2.DataSource = Nothing
            End If
        Else
            Employees.DataGridView2.DataSource = Nothing
        End If
    End Sub

    Private Sub EditEmployeesPromosions_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class