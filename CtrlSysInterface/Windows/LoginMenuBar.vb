Public Class LoginMenuBar
    Private ParentWindows As MainForm

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ParentWindows = MainScreen

    End Sub



    Private Sub Login_Button_Click(sender As Object, e As EventArgs) Handles Login_Button.Click

        ParentWindows.ShowNonRunningMenuBar()





    End Sub

    Private Sub Exit_Button_Click(sender As Object, e As EventArgs) Handles Exit_Button.Click
        Application.Exit()
        Do While True
            Try
                End
            Catch ex As Exception
            End Try
        Loop
    End Sub

    Private Sub About_Button_Click(sender As Object, e As EventArgs) Handles About_Button.Click
        ParentWindows.ShowAboutScreen()

    End Sub

    Private Sub LoginMenuBar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub LoginMenuBar_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Me.Size = Main.MainScreen.Menu_Panel.Size


        Dim ButtonsCntrlList As New List(Of Control)
        ButtonsCntrlList.Add(Login_Button)
        ButtonsCntrlList.Add(About_Button)
        ButtonsCntrlList.Add(Exit_Button)
        Dim i = 0
        For Each b In ButtonsCntrlList

            Dim Siz As Drawing.Size
            Siz.Width = (Me.Size.Width / (ButtonsCntrlList.Count))
            Siz.Height = Me.Size.Height
            b.Size = Siz

            Dim loc As Point
            loc.X = ((Me.Size.Width * i) / ButtonsCntrlList.Count)
            loc.Y = 0
            b.Location = loc
            i += 1
        Next


    End Sub
End Class