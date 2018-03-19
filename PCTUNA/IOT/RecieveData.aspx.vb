Imports System.Data.SqlClient
Imports Microsoft.AspNet.SignalR
Public Class RecieveData
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Request.QueryString("EmpRFID") IsNot Nothing And Request.QueryString("CarrierRFID") IsNot Nothing) Then
            Dim data1 = Database.IOTExecute("select EmployeeID from EmpRFID where RFID = '" & Request.QueryString("EmpRFID") & "'")
            Dim data2 = Database.IOTExecute("select ID,ProductID from Lot inner join CarrierRFID on Lot.CarrierID = CarrierRFID.CarrierID and RFID = '" & Request.QueryString("CarrierRFID") & "'")
            If data1.Rows.Count <> 0 And data2.Rows.Count <> 0 Then
                Dim productData = Database.IOTExecute("select Piece from Product where ID = '" & data2.Rows(0).Item("ProductID").ToString & "'")
                Dim productPiece As Int16
                If productData.Rows.Count <> 0 Then
                    productPiece = productData.Rows(0).Item("Piece")
                Else
                    productPiece = 50
                End If
                Using conn As New SqlConnection(My.Settings.IOTConnectionString)
                    Using comm As New SqlCommand("insert into Operation values (@EmployeeID,@LotID,1,null,GETDATE()," & productPiece & "," & productPiece & ",null)", conn)
                        comm.Parameters.Add("@EmployeeID", SqlDbType.Int)
                        comm.Parameters("@EmployeeID").Value = data1.Rows(0).Item("EmployeeID")
                        comm.Parameters.Add("@LotID", SqlDbType.Int)
                        comm.Parameters("@LotID").Value = data2.Rows(0).Item("ID")
                        Try
                            conn.Open()
                            comm.ExecuteNonQuery()
                        Catch
                        End Try
                    End Using
                End Using
                Dim Context As Object = GlobalHost.ConnectionManager.GetHubContext(Of ChatHub)
                Context.Clients.All.sendMessage("Update")
                lbResult.Text = "Success"
            Else
                lbResult.Text = "Fail"
            End If
        Else
            lbResult.Text = "Fail"
        End If
    End Sub

End Class