
Option Explicit On


Imports System
Imports System.IO



Public Module Main



    Public EthernetTestComm As OmronFINSEthernetCommMain




    Public AppWriteLock As New Object
    Public ProcWriteLock As New Object
    Public TestFailureWriteLock As New Object
    Public SessionLogWriteLock As New Object


    Public MainScreen As MainForm
    Public MachineSettingScreen As MachineSetting
    Public IOControlScreen As IOControl
    Public RecipeSettingScreen As RecipeSetting
    Public AboutScreen As About
    Public PreRunScreen As PreRun
    Public RunScreen As Run



    Public LogInMenuBarScreen As LoginMenuBar
    Public NonRunningMenuBarScreen As NonRunningMenuBar
    Public RecipeMenuBarScreen As RecipeMenuBar
    Public RunningMenuBarScreen As RunningMenuBar


    Public OSK As OSKeyboard
    Public OSKSecure As OSKeyboardSecure
    Public OSNKeypad As OSNumberKeyPad


    Public SessionLogFileName As String


    Function startup() As Boolean
        Try
            EthernetTestComm = New OmronFINSEthernetCommMain("192.168.250.1", 9600, "192.168.250.99")




            PLCMemoryAndRelayLocationData.InitializeDataMemory()
            PLCMemoryAndRelayLocationData.InitializeRelay()
            ProgramRuntimeVariables.InitializeRuntimeVariables()

        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.OkOnly)
            Application.Exit()

        End Try

        Return True

    End Function












#Region "OSK"
    Public Function GetDataFromOSK(ByVal LabelName As String) As String

        Dim i As OSKeyboard
        Dim Temp As String = ""


        i = New OSKeyboard(LabelName)

        If (i.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            Temp = i.TextBox.Text
            Return Temp

        End If
        i.Dispose()

        Return Temp



    End Function
    Public Function GetDataFromOSKSecure(ByVal LabelName As String) As String

        Dim i As OSKeyboardSecure
        Dim Temp As String = ""


        i = New OSKeyboardSecure(LabelName)

        If (i.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            Temp = i.TextBox.Text
            Return Temp

        End If
        i.Dispose()

        Return Temp



    End Function
    Public Function GetDataFromOSNKP(ByVal LabelName As String) As String

        Dim i As OSNumberKeyPad
        Dim Temp As String = ""


        i = New OSNumberKeyPad(LabelName)

        If (i.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            Temp = i.TextBox.Text
            Return Temp

        End If
        i.Dispose()

        Return Temp

    End Function

#End Region


#Region "Log File Control "
    Public Function WriteLogForSession(ByRef SessionName As String, ByRef ErrorMessage As String, Optional ByRef OmitTimestamp As Boolean = False) As Boolean

        SyncLock SessionLogWriteLock

            Dim ProcessLogWriter As System.IO.StreamWriter

                Dim CurrentDay As String
                Dim CurrentMonth As String
                Dim CurrentYear As String
                Dim CurrentTime As String
                Dim CurrentDate As String
                Dim ErrorMessageToBeWritten As String
                Dim TimeFormat As String

                TimeFormat = "HH:mm"
                CurrentDate = Date.Now
                CurrentTime = DateTime.Now.ToString(TimeFormat)
                If OmitTimestamp Then
                    ErrorMessageToBeWritten = "           " + ErrorMessage
                Else
                    ErrorMessageToBeWritten = CurrentTime + "      " + ErrorMessage
                End If




                Try

                    ProcessLogWriter = FileIO.FileSystem.OpenTextFileWriter(SessionName, 1)

                    ProcessLogWriter.WriteLine(ErrorMessageToBeWritten)

                    ProcessLogWriter.Close()


                Catch ex As Exception

                    MsgBox("Error Writing Session Log.", MsgBoxStyle.OkOnly, "Session Log File")

                End Try

        End SyncLock
    End Function
    Public Function WriteLogForApplicationError(ByRef ErrorMessage As String) As Boolean

        SyncLock AppWriteLock


            Dim AppLogWriter As System.IO.StreamWriter

            Dim CurrentDay As String
            Dim CurrentMonth As String
            Dim CurrentYear As String
            Dim CurrentTime As String
            Dim CurrentDate As String
            Dim ErrorMessageToBeWritten As String

            CurrentDate = Date.Now

            ErrorMessageToBeWritten = CurrentDate + " " + ErrorMessage



            Try

                AppLogWriter = FileIO.FileSystem.OpenTextFileWriter(".\ApplicationError.log", 1)

                AppLogWriter.WriteLine(ErrorMessageToBeWritten)

                AppLogWriter.Close()


            Catch ex As Exception

                MsgBox("Error Write Application Log File.", MsgBoxStyle.OkOnly, "Application Log File")

            End Try
        End SyncLock
    End Function
    Public Function WriteLogForProcessError(ByRef ErrorMessage As String) As Boolean

        SyncLock ProcWriteLock


            Dim ProcessLogWriter As System.IO.StreamWriter

            Dim CurrentDay As String
            Dim CurrentMonth As String
            Dim CurrentYear As String
            Dim CurrentTime As String
            Dim CurrentDate As String
            Dim ErrorMessageToBeWritten As String

            CurrentDate = Date.Now

            ErrorMessageToBeWritten = CurrentDate + " " + ErrorMessage

            WriteLogForSession(SessionLogFileName, ErrorMessage)

            Try

                ProcessLogWriter = FileIO.FileSystem.OpenTextFileWriter(".\ProcessError.log", 1)

                ProcessLogWriter.WriteLine(ErrorMessageToBeWritten)

                ProcessLogWriter.Close()


            Catch ex As Exception

                MsgBox("Error Write Process Log File.", MsgBoxStyle.OkOnly, "Application Log File")

            End Try

        End SyncLock
    End Function

#End Region

#Region "misc"





#End Region






End Module
