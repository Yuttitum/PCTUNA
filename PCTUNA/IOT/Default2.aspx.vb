Public Class Default2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

    End Sub

    Private Sub _Default_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        'Dim sum = Database.IOTExecute("select sum(Output) as Output from Operation")
        'If sum.Rows.Count <> 0 Then
        Dim num1 As Double = (CInt(Math.Ceiling(Rnd() * 100)) + 1) / 100.0
        Dim num2 As Double = (CInt(Math.Ceiling(Rnd() * 100)) + 1) / 100.0
        Dim num3 As Double = (CInt(Math.Ceiling(Rnd() * 100)) + 1) / 100.0
        ScriptManager.RegisterStartupScript(upOperationRate, Me.GetType(), "operationRate", "operationRate(" & num1.ToString & ");", True)
        ScriptManager.RegisterStartupScript(upOperationRate, Me.GetType(), "progress", "progress(" & num2.ToString & ");", True)
        ScriptManager.RegisterStartupScript(upOperationRate, Me.GetType(), "forecast", "forecast(" & num3.ToString & ");", True)
        'End If
    End Sub

End Class