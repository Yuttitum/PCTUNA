Imports System.Web
Imports System.Data.SqlClient
Imports System.Data
Imports System.Security.Cryptography
Public Class Database
    Implements IHttpModule

    Private WithEvents _context As HttpApplication

    ''' <summary>
    '''  You will need to configure this module in the Web.config file of your
    '''  web and register it with IIS before being able to use it. For more information
    '''  see the following link: http://go.microsoft.com/?linkid=8101007
    ''' </summary>
#Region "IHttpModule Members"

    Public Sub Dispose() Implements IHttpModule.Dispose

        ' Clean-up code here

    End Sub

    Public Sub Init(ByVal context As HttpApplication) Implements IHttpModule.Init
        _context = context
    End Sub

#End Region

    Public Sub OnLogRequest(ByVal source As Object, ByVal e As EventArgs) Handles _context.LogRequest

        ' Handles the LogRequest event to provide a custom logging 
        ' implementation for it

    End Sub
    Public Shared Function IOTExecute(queryString As String) As DataTable
        Dim resault As DataTable = New DataTable
        Using con As New SqlConnection(My.Settings.IOTConnectionString)
            con.Open()
            Dim cmd = New SqlCommand(queryString, con)
            Dim data = New SqlDataAdapter(cmd)
            data.Fill(resault)
        End Using
        Return resault
    End Function
    Public Shared Function IOTExecuteNoData(queryString As String) As Integer
        Dim resault As Integer
        Using con As New SqlConnection(My.Settings.IOTConnectionString)
            con.Open()
            Dim cmd = New SqlCommand(queryString, con)
            resault = cmd.ExecuteNonQuery()
        End Using
        Return resault
    End Function

End Class
