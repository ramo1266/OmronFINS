Imports System.Threading

Public Class IOControl

    Private UpdateIOControlThread As Thread





    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UpdateIOControlThread = New Thread(AddressOf UpdateIOControl)
        UpdateIOControlThread.Name = "UpdateIOControlThread"
        UpdateIOControlThread.Priority = ThreadPriority.Lowest

        System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False

        UpdateIOControlThread.Start()


    End Sub




    Public Sub UpdateIOControl()
        Dim UpdateOnce As Boolean = False

        Do
            Try

                If (Me.Visible) Then
                    Thread.Sleep(100)

                    If (UpdateOnce = False) Then

                        UpdateOnce = True

                    Else
                        Thread.Sleep(300)


                    End If

                Else
                    UpdateOnce = False
                    Thread.Sleep(300)
                End If






            Catch ex As Exception

            End Try


        Loop
    End Sub





    Private Sub IOControl_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Me.Size = Main.MainScreen.Window_Panel.Size

    End Sub







End Class
