Public Class Login

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Connection()
        str = " Select UserID, UserName,UserPassword , UserType,MainUserType from Users where UserName = '" & TextBox1.Text.ToString & "' and UserPassword = '" & TextBox2.Text.ToString & "'"
        GetData(0)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                UserID = ds.Tables(0).Rows(0)(0)
                UserName = ds.Tables(0).Rows(0)(1)
                UserPassword = ds.Tables(0).Rows(0)(2)
                UserType = ds.Tables(0).Rows(0)(3)
                MainUserName = ds.Tables(0).Rows(0)(4)

                Home.Text = UserName

                Home.Show()
                'str = " select DATEDIFF(DD,decisiondate,getdate())- AdversaryInterval*365,EmployeeName,DATEADD(year,AdversaryInterval,decisiondate ) from Investigations,Employees WHERE " & _
                '      " Employees.EmployeeID = Investigations.EmployeeID And AnouncementStatus = 0 "
                'GetData(0)
                'If ds.Tables.Count > 0 Then
                '    If ds.Tables(0).Rows.Count > 0 Then
                '        If ds.Tables(0).Rows(0)(0) <= 7 Then
                '            MsgBox("توجد إشعارات جديدة الرجاء مراجعتها وإجراء اللازم", MsgBoxStyle.Exclamation)
                '            Home.ToolStripButton4.Text = ds.Tables(0).Rows.Count + 2
                '            Home.ToolStripButton4.Enabled = True
                '        End If
                '    End If
                'End If

                Me.Hide()
            Else
                MsgBox("Invalid Username or Password")
            End If
        Else
            MsgBox("Invalid Username or Password")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        End
    End Sub
End Class