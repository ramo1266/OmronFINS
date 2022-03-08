Public Class RunningMenuBar




    Private Sub ExitRunScreen_Button_Click(sender As Object, e As EventArgs) Handles ExitRunScreen_Button.Click
        MainScreen.ShowNonRunningMenuBar()
        MainScreen.HideAllScreens()

    End Sub








End Class