Imports System.Threading

Public Class MachineSetting
    Private UpdateMachineSetttingThread As Thread

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UpdateMachineSetttingThread = New Thread(AddressOf UpdateMachineSettting)
        UpdateMachineSetttingThread.Name = "UpdateMachineSetttingThread"
        UpdateMachineSetttingThread.Priority = ThreadPriority.Lowest

        UpdateMachineSetttingThread.Start()

    End Sub





    Public Sub UpdateMachineSettting()
        Dim UpdateOnce As Boolean = False
        Dim ErrorNum As Integer
        Do
            If (Me.Visible) Then


                If (UpdateOnce = False) Then

                    UpdateOnce = True

                End If


                If (Not (ErrorNum = 0)) Then
                Else
                End If

                Thread.Sleep(100)

            Else

                UpdateOnce = False
                Thread.Sleep(100)
            End If



        Loop


    End Sub


    Private Sub MachineSetting_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint

        Me.Size = Main.MainScreen.Window_Panel.Size


        Dim loc As Point
        loc.X = Me.Title_Panel.Width / 2 - Me.Title_Label.Size.Width / 2
        loc.Y = 0
        Title_Label.Location = loc

        'Dim loc As Point
        'loc.X = Math.Abs(Me.Size.Width / 2 - Main.MainScreen.Window_Panel.Width / 2)
        'loc.Y = Math.Abs(Me.Size.Height / 2 - Main.MainScreen.Window_Panel.Height / 2)
        'Me.Location = loc
    End Sub
End Class