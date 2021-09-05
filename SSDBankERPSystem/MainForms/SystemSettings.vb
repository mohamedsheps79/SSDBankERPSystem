Public Class SystemSettings

    Private Sub SystemSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        str = " Select * from Branches"
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

    Private Sub ToolStripTextBox1_Click(sender As Object, e As EventArgs) Handles ToolStripTextBox1.Click
        ToolStripTextBox1.Text = Nothing
    End Sub

    Private Sub ToolStripTextBox1_TextChanged(sender As Object, e As EventArgs) Handles ToolStripTextBox1.TextChanged
        On Error Resume Next
        str = " Select * from Branches WHERE BranchName like ('%" & ToolStripTextBox1.Text.ToString & "%') "
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

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        n = 0
        EditBranches.TextBox1.Text = Nothing
        EditBranches.TextBox2.Text = Nothing
        EditBranches.ShowDialog()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        n = 1
        r = DataGridView1.CurrentCell.RowIndex
        EditBranches.TextBox1.Text = DataGridView1(2, r).Value.ToString
        EditBranches.TextBox2.Text = DataGridView1(3, r).Value.ToString
        EditBranches.ShowDialog()
    End Sub

    Private Sub ToolStripComboBox1_Click(sender As Object, e As EventArgs) Handles ToolStripComboBox1.Click

    End Sub

    Private Sub ToolStripComboBox1_DropDown(sender As Object, e As EventArgs) Handles ToolStripComboBox1.DropDown
        GetBranches(ToolStripComboBox1.ComboBox)
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 0 Then
            str = " Select * from Branches"
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
            str = " Select * from Departments"
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
            str = " Select * from Classes"
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
            str = " Select * from DocumentsTypes"
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
        End If
    End Sub

    Private Sub ToolStripComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ToolStripComboBox1.SelectedIndexChanged
        On Error GoTo fb
        str = " Select * from Departments where BranchID = " & ToolStripComboBox1.ComboBox.SelectedValue & " "
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
fb:
    End Sub

    Private Sub ToolStripTextBox2_Click(sender As Object, e As EventArgs) Handles ToolStripTextBox2.Click
        ToolStripTextBox2.Text = Nothing
    End Sub

    Private Sub ToolStripTextBox2_TextChanged(sender As Object, e As EventArgs) Handles ToolStripTextBox2.TextChanged
        On Error Resume Next
        str = " Select * from Departments where DepartmentName like ('%" & ToolStripTextBox2.Text.ToString & "%')"
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

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        n = 0
        EditDepartments.ComboBox1.DataSource = Nothing
        EditDepartments.ComboBox1.Items.Clear()
        EditDepartments.TextBox2.Text = Nothing
        EditDepartments.ShowDialog()
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        n = 1
        r = DataGridView2.CurrentCell.RowIndex
        GetBranches(EditDepartments.ComboBox1)
        EditDepartments.ComboBox1.SelectedValue = DataGridView2(1, r).Value
        EditDepartments.TextBox2.Text = DataGridView2(3, r).Value.ToString
        EditDepartments.ShowDialog()

    End Sub

    Private Sub ToolStripComboBox2_Click(sender As Object, e As EventArgs) Handles ToolStripComboBox2.Click

    End Sub

    Private Sub ToolStripComboBox2_DropDown(sender As Object, e As EventArgs) Handles ToolStripComboBox2.DropDown
        GetJobs(ToolStripComboBox2.ComboBox)
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        n = 0
        EditClasses.ComboBox1.DataSource = Nothing
        EditClasses.ComboBox1.Items.Clear()
        EditClasses.TextBox2.Text = Nothing
        EditClasses.ShowDialog()
    End Sub

    Private Sub DataGridView3_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView3.CellContentClick
        n = 1
        r = DataGridView3.CurrentCell.RowIndex
        GetJobs(EditClasses.ComboBox1)
        EditClasses.ComboBox1.SelectedValue = DataGridView3(1, r).Value
        EditClasses.TextBox2.Text = DataGridView3(3, r).Value.ToString
        EditClasses.ShowDialog()
    End Sub

    Private Sub ToolStripTextBox3_Click(sender As Object, e As EventArgs) Handles ToolStripTextBox3.Click
        ToolStripTextBox3.Text = Nothing
    End Sub

    Private Sub ToolStripTextBox3_TextChanged(sender As Object, e As EventArgs) Handles ToolStripTextBox3.TextChanged
        On Error GoTo fb
        str = " Select * from Classes where ClassName like ('%" & ToolStripTextBox3.Text.ToString & "%')"
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
fb:
    End Sub

    Private Sub ToolStripComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ToolStripComboBox2.SelectedIndexChanged
        On Error GoTo fb
        str = " Select * from Classes where jobid = " & ToolStripComboBox2.ComboBox.SelectedValue & " "
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
fb:
    End Sub

    Private Sub ToolStripTextBox4_Click(sender As Object, e As EventArgs) Handles ToolStripTextBox4.Click
        ToolStripButton4.Text = Nothing
    End Sub

    Private Sub ToolStripTextBox4_TextChanged(sender As Object, e As EventArgs) Handles ToolStripTextBox4.TextChanged
        On Error GoTo fb
        str = " Select * from DocumentsTypes where DocumentName = " & ToolStripTextBox4.Text.ToString & " "
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
fb:
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        n = 0
        EditDocumentTypes.TextBox2.Text = Nothing
        EditDocumentTypes.ShowDialog()
    End Sub

    Private Sub DataGridView4_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView4.CellContentClick
        n = 1
        r = DataGridView4.CurrentCell.RowIndex
        EditDocumentTypes.TextBox2.Text = DataGridView4(2, r).Value.ToString
        EditDocumentTypes.ShowDialog()
    End Sub
End Class