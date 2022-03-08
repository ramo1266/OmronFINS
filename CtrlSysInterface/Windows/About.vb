Public Class About


    Private Sub About_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim loc As Point
        loc.X = Math.Abs(Me.Size.Width / 2 - Main.MainScreen.Window_Panel.Width / 2)
        loc.Y = Math.Abs(Me.Size.Height / 2 - Main.MainScreen.Window_Panel.Height / 2)
        Me.Location = loc
    End Sub
End Class