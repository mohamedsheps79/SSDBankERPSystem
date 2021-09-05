Imports System.Data
Imports System.Data.SqlClient
Imports System.Threading
Imports System.Data.OleDb
Module variables
    Public cnn As New SqlConnection
    Public cmd As SqlCommand
    Public reader As SqlDataReader
    Public str As String
    Public s As String
    Public x As String
    Public ds As DataSet
    Public ds2 As DataSet
    Public adb As SqlDataAdapter
    Public AccessStr As String
    Public AccessCon As OleDbConnection
    Public AccessAdapter As OleDbDataAdapter
    Public AccessCmd As OleDbCommand
    Public AccessDS As DataSet
    Public machineName As String
    Public RptNo As Integer
    Public MeetID
    Public projectID
    Public Fname1 As String
    Public Fname2 As String
    Public sp As Integer
    Public n As Integer
    Public No As Integer
    Public emp As Integer
    Public bmap As Image
    Public r As Integer
    Public r1 As Integer
    Public User_No As Integer
    Public Fname As String
    Public UniversityID As Integer
    Public ProgramID As Integer
    Public SemesterHours As Integer
    Public CSemesterHours As Integer
    Public SemesterPoints As Double
    Public CSemesterPoints As Double
    Public Gpa As Double
    Public Cgpa As Double
    Public Pcgpa As Double
    Public Ppcgpa As Double
    Public Status As String
    Public dtsource As New DataTable
    Public rowcount As Integer
    Public columnCount As Integer
    Public subjectCount As Integer
    Public ds3 As DataSet
    Public EmployeeID As Integer
    Public formID As Integer
    Public UserID As Integer
    Public UserType As String
    Public UserName As String
    Public MainUserName As String
    Public UserPassword As String
End Module
