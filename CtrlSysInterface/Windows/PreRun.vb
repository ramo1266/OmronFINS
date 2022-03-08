Imports System.Threading


Public Class PreRun
    Private PreRunScreenThread As Thread
    Private SecurtyLevel2UseDrillersFunction As Integer = 1
    Public LotNumber As String
    Private WaitForResultThread As Thread
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        PreRunScreenThread = New Thread(AddressOf UpdatePreRunScreen)
        PreRunScreenThread.Name = "UpdatePreRunScreenThread"
        PreRunScreenThread.Priority = ThreadPriority.Lowest

        ' Add any initialization after the InitializeComponent() call.
        PreRunScreenThread.Start()

    End Sub


    Public Sub UpdatePreRunScreen()

        Dim UpdateOnce As Boolean = False
        Do
            If (Me.Visible) Then


                If (UpdateOnce = False) Then





                    UpdateOnce = True
                Else



                    Thread.Sleep(300)
                End If
            Else

                UpdateOnce = False
                Thread.Sleep(300)
            End If
        Loop
    End Sub
    '







End Class