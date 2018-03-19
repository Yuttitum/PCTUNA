Public Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Dim currentDate = Date.Now.AddHours(-8).ToString("yyyy-MM-dd")
        Dim resultData = Database.IOTExecute("select case when sum(Output) is null then 0 else sum(Output) end as result from Operation where EndDate >= '" & currentDate & "'")
        If resultData.Rows.Count <> 0 Then
            lbActual.Text = resultData.Rows(0).Item("result").ToString
        Else
            lbActual.Text = 0
        End If
        Dim planData = Database.IOTExecute("select DailyPlan from ControlValue where ProductID = 1 and ProcessID = 1")
        If planData.Rows.Count <> 0 Then
            lbPlan.Text = planData.Rows(0).Item("DailyPlan").ToString
        Else
            lbPlan.Text = 0
        End If
    End Sub

    Private Sub _Default_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        ScriptManager.RegisterStartupScript(upActual, Me.GetType(), "UpdateData", "updateData(" & lbPlan.Text & "," & lbActual.Text & ");", True)
    End Sub
End Class