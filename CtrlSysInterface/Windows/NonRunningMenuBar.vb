
Imports System.Threading

Public Class NonRunningMenuBar
    Private ParentWindow As MainForm
    Private NonRunningMenuBarThread As Thread

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ParentWindow = MainScreen
        NonRunningMenuBarThread = New Thread(AddressOf NonRunningMenuBarRoutine)
        NonRunningMenuBarThread.Name = "NonRunningMenuBarThread"
        NonRunningMenuBarThread.Priority = ThreadPriority.Lowest
        NonRunningMenuBarThread.Start()

    End Sub



    Public Sub NonRunningMenuBarRoutine()
        Dim UpdateOnce As Boolean = False


        Do


            Try

                If (Me.Visible) Then

                    Machine_Button.Visible = True
                    IOControl_Button.Visible = True
                    Recipe_Button.Visible = True
                    Users_Button.Visible = True





                End If

                Thread.Sleep(1300)

            Catch ex As Exception

            End Try


        Loop
    End Sub
    Private Sub Machine_Button_Click(sender As Object, e As EventArgs) Handles Machine_Button.Click
        ParentWindow.ShowMachineSettingScreen()

    End Sub

    Private Sub IOControl_Button_Click(sender As Object, e As EventArgs) Handles IOControl_Button.Click
        ParentWindow.ShowIOControlScreen()


    End Sub

    Private Sub Recipe_Button_Click(sender As Object, e As EventArgs) Handles Recipe_Button.Click
        ParentWindow.ShowRecipeScreen()

    End Sub

    Private Sub LogOff_Button_Click(sender As Object, e As EventArgs) Handles LogOff_Button.Click
        ParentWindow.ShowLoginMenuBar()


    End Sub

    Private Sub Start_Button_Click(sender As Object, e As EventArgs)
        ParentWindow.ShowPreRunScreen()

    End Sub

    Private Sub NonRunningMenuBar_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Me.Size = Main.MainScreen.Menu_Panel.Size


        Dim ButtonsCntrlList As New List(Of Control)
        ButtonsCntrlList.Add(Users_Button)
        ButtonsCntrlList.Add(Machine_Button)

        ButtonsCntrlList.Add(IOControl_Button)
        ButtonsCntrlList.Add(Recipe_Button)

        ButtonsCntrlList.Add(LogOff_Button)
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