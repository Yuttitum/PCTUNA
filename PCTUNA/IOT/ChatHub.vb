Imports Microsoft.AspNet.SignalR

Public Class ChatHub
    Inherits Hub
    Public Sub JoinGroup(groupName As String)
        Groups.Add(Context.ConnectionId, groupName)
    End Sub
End Class
