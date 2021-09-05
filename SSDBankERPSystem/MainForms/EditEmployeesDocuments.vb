Imports System.IO
Public Class EditEmployeesDocuments

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        formID = 3
        EmployeesList.TextBox2.Text = Nothing
        EmployeesList.ShowDialog()
    End Sub

    Private Sub ComboBox1_DropDown(sender As Object, e As EventArgs) Handles ComboBox1.DropDown
        GetDocumentsTypes(ComboBox1)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim arrfilename1() As String = Split(Fname1, "\")
        Array.Reverse(arrfilename1)
        Dim ms1 As New MemoryStream()
        PictureBox1.Image.Save(ms1, PictureBox1.Image.RawFormat)
        Dim arrimg1() As Byte = ms1.GetBuffer
        ms1.Close()
        Connection()
        If n = 0 Then
            str = " Insert into EmployeesDocuments values (" & EmployeeID & ", " & ComboBox1.SelectedValue & " , @arrimg1 , '" & TextBox3.Text.ToString & "'," & UserID & ",'','N')"
            Dim cmdSQL As New System.Data.SqlClient.SqlCommand(str, cnn)
            With cmdSQL
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@arrimg1", SqlDbType.Image)).Value = arrimg1
            End With
            cmdSQL.ExecuteNonQuery()

            cnn.Close()
            MsgBox("تمت الحفظ  ")
           
        Else
            str = " Update EmployeesDocuments set EmployeeID = " & EmployeeID & " , DocumentID = " & ComboBox1.SelectedValue & " , DocumentContent =@arrimg1, " & _
                  " Remarks = '" & TextBox3.Text & "', Status = 'A' , AuthorizedBy = " & UserID & "  where EmployeeDocumentID = " & Employees.DataGridView4(1, r).Value & " "
            Dim cmdSQL As New System.Data.SqlClient.SqlCommand(str, cnn)
            With cmdSQL
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@arrimg1", SqlDbType.Image)).Value = arrimg1
            End With
            cmdSQL.ExecuteNonQuery()
            MsgBox("تم التعديل")
            cnn.Close()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Connection()
        If MsgBox("هل تريد الحذف", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            str = " Delete from EmployeesDocuments  where EmployeeDocumentID = " & Employees.DataGridView4(1, r).Value & " "
            Execute_Command()
            MsgBox("تم الحذف")
        Else
       
        End If

    End Sub

    Private Sub EditEmployeesDocuments_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        On Error Resume Next
        str = " select Employees.EmployeeID , Employees.EmployeeName , PendingEmployeesDocuments.DocumentID, DocumentName,EmployeeDocumentID," & _
               " DocumentContent,Remarks,PendingEmployeesDocuments.Status from Employees inner join PendingEmployeesDocuments on (PendingEmployeesDocuments.EmployeeID = Employees.EmployeeID ) " & _
               " inner join DocumentsTypes on (PendingEmployeesDocuments.DocumentID = DocumentsTypes.DocumentTypeID )
        GetData(0)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                Employees.DataGridView4.DataSource = ds.Tables(0)
            Else
                Employees.DataGridView4.DataSource = Nothing
            End If
        Else
            Employees.DataGridView4.DataSource = Nothing
        End If
    End Sub

    Private Sub EditEmployeesDocuments_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class