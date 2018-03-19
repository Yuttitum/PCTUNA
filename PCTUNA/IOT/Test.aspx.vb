Imports System.Data.SqlClient
Imports Microsoft.AspNet.SignalR
Public Class Test
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSendData_Click(sender As Object, e As EventArgs) Handles btnSendData.Click

        Using conn As New SqlConnection(My.Settings.IOTConnectionString)
            Using comm As New SqlCommand("insert into Operation values (@EmployeeID,@LotID,1,null,GETDATE(),50,50,null)", conn)
                comm.Parameters.Add("@EmployeeID", SqlDbType.Int)
                comm.Parameters("@EmployeeID").Value = 1
                comm.Parameters.Add("@LotID", SqlDbType.Int)
                comm.Parameters("@LotID").Value = 1
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch
                End Try
            End Using
        End Using
        Dim Context As Object = GlobalHost.ConnectionManager.GetHubContext(Of ChatHub)
        Context.Clients.All.sendMessage("Update")
    End Sub
End Class