Public Class OmronHostlinkFinsSerialCommMain

    Private HL As HostLink
    Private FC As OmronFINSCommand
    Private SP As SerialPort4Omron
    Private MaxRetry As Integer = 5
    Private CommPortName As String
    Private OmronPLCSyncLock As New Object



    Public Sub New(ByRef PortName As String)

        CommPortName = PortName
        HL = New HostLink
        FC = New OmronFINSCommand
        SP = New SerialPort4Omron(CommPortName)

    End Sub

    Public Sub InitializeOnce()

        'HL = New HostLink
        'FC = New OmronFINSCommand
        'SP = New SerialPort4Omron(CommPortName)


    End Sub


    Public Function ReadMultipleNonConsectiveDataMemory(ByRef DM() As DMInfo, ByRef DMValve() As String, Optional ByRef CommandString As String = "default", Optional ByRef ReponseString As String = "default")

        Dim HostLinkHeader As String
        Dim HostLinkFCS As String
        Dim HostLinkTerminator As String

        Dim FINSDataMemoryReadCmd As String
        Dim FINSRecievePacket As String



        Dim CompleteReadDataMemoryCommand As String
        Dim RecieveReadDataMemoryResult As String


        Dim Retry As Integer = 0

        SyncLock OmronPLCSyncLock
            While True
                Try



                If (SP.OpenComm() = False) Then
                    'MsgBox("Failed to Open Serial Port", MsgBoxStyle.OkCancel, "Error")

                    Throw New Exception("Failed to Open Serial Port - Read Data Memory -" + " " + SP.GetCommPort.ToString)
                    SP.CloseComm()
                    Exit Function
                End If



                HL.BuildHostLinkHeader(HostLinkHeader)

                FC.BuildReadMultipleNonConsectiveDataMemoryResponse(FINSDataMemoryReadCmd, DM)

                CompleteReadDataMemoryCommand = HostLinkHeader + FINSDataMemoryReadCmd

                HL.BuildHostLinkFCSData(CompleteReadDataMemoryCommand, HostLinkFCS)

                HL.BuildHostLinkTerminator(HostLinkTerminator)

                CompleteReadDataMemoryCommand = CompleteReadDataMemoryCommand + HostLinkFCS + HostLinkTerminator

                CommandString = CompleteReadDataMemoryCommand


                SP.SendPacket(CompleteReadDataMemoryCommand)

                If (SP.Get2EndChar(RecieveReadDataMemoryResult, Chr(13).ToString) = False) Then

                    'MsgBox("Error Getting Repsonse From Omron PLC.", MsgBoxStyle.OkOnly, "Error")

                    Throw New Exception("Error Getting Repsonse From Omron PLC." + " " + SP.GetCommPort.ToString)
                    SP.CloseComm()
                    'Return False
                    Exit Function
                End If



                ReponseString = RecieveReadDataMemoryResult

                If (HL.DisassembleHostLinkPacket(FINSRecievePacket, ReponseString) = False) Then


                    ' MsgBox("Failed to Disassemble Read Data Memory Recieve Packet", MsgBoxStyle.OkOnly, "Error") 

                    Throw New Exception("Failed to Disassemble Read Data Memory Recieve Packet" + " " + SP.GetCommPort.ToString)

                    'Return False
                    Exit Function
                End If





                    If (FC.DisassembleReadMultipleNonConsectiveDataMemoryResponse(FINSRecievePacket, DM, DMValve) = False) Then

                        ' MsgBox("Failed to Retrieve Data Memory Value", MsgBoxStyle.OkOnly, "Error") 

                        Throw New Exception("Failed to Retrieve Data Memory Value" + " " + SP.GetCommPort.ToString)

                        'Return False
                        Exit Function
                    End If

                    SP.CloseComm()
                    Exit While




                Catch ex As Exception

                SP.CloseComm()
                Retry = Retry + 1
                    System.Threading.Thread.Sleep(500)


                    If (Retry > MaxRetry) Then

                    Throw New Exception(ex.Message)
                        SP.CloseComm()


                        Exit Function
                End If

            End Try

            End While







        End SyncLock


    End Function


    Public Function ReadDataMemory(ByVal DataMemoryAddress As Integer, ByVal NumberOfWords2Read As Integer, ByRef DataMemoryValue As UInt64, Optional ByRef CommandString As String = "default", Optional ByRef ReponseString As String = "default") As Boolean

        Dim HostLinkHeader As String
        Dim HostLinkFCS As String
        Dim HostLinkTerminator As String

        Dim FINSDataMemoryReadCmd As String
        Dim FINSRecievePacket As String

        Dim CompleteReadDataMemoryCommand As String
        Dim RecieveReadDataMemoryResult As String


        Dim Retry As Integer = 0

        SyncLock OmronPLCSyncLock

            While True



                Try


                    'HL = New HostLink
                    'FC = New OmronFINSCommand
                    'SP = New SerialPort4Omron(CommPort)


                    If (SP.OpenComm() = False) Then
                        'MsgBox("Failed to Open Serial Port", MsgBoxStyle.OkCancel, "Error")

                        Throw New Exception("Failed to Open Serial Port - Read Data Memory -" + " " + SP.GetCommPort.ToString)
                        SP.CloseComm()
                        Exit Function
                    End If


                    HL.BuildHostLinkHeader(HostLinkHeader)

                    FC.BuildReadDataMemoryCommand(FINSDataMemoryReadCmd, DataMemoryAddress, NumberOfWords2Read)

                    CompleteReadDataMemoryCommand = HostLinkHeader + FINSDataMemoryReadCmd

                    HL.BuildHostLinkFCSData(CompleteReadDataMemoryCommand, HostLinkFCS)

                    HL.BuildHostLinkTerminator(HostLinkTerminator)

                    CompleteReadDataMemoryCommand = CompleteReadDataMemoryCommand + HostLinkFCS + HostLinkTerminator

                    CommandString = CompleteReadDataMemoryCommand


                    SP.SendPacket(CompleteReadDataMemoryCommand)

                    RecieveReadDataMemoryResult = ""

                    If (SP.Get2EndChar(RecieveReadDataMemoryResult, Chr(13).ToString) = False) Then

                        'MsgBox("Error Getting Repsonse From Omron PLC.", MsgBoxStyle.OkOnly, "Error")

                        Throw New Exception("Error Getting Repsonse From Omron PLC." + " " + SP.GetCommPort.ToString)
                        SP.CloseComm()
                        'Return False
                        Exit Function
                    End If



                    ReponseString = RecieveReadDataMemoryResult

                    If (HL.DisassembleHostLinkPacket(FINSRecievePacket, ReponseString) = False) Then


                        ' MsgBox("Failed to Disassemble Read Data Memory Recieve Packet", MsgBoxStyle.OkOnly, "Error") 

                        Throw New Exception("Failed to Disassemble Read Data Memory Recieve Packet" + " " + SP.GetCommPort.ToString)

                        'Return False
                        Exit Function
                    End If

                    If (FC.DisassembleReadDataMemoryRespose(DataMemoryValue, FINSRecievePacket) = False) Then

                        ' MsgBox("Failed to Retrieve Data Memory Value", MsgBoxStyle.OkOnly, "Error") 

                        Throw New Exception("Failed to Retrieve Data Memory Value" + " " + SP.GetCommPort.ToString)

                        'Return False
                        Exit Function
                    End If

                    SP.CloseComm()


                    Exit While


                Catch ex As Exception

                    SP.CloseComm()
                    Retry = Retry + 1


                    If (Retry > MaxRetry) Then

                        Throw New Exception(ex.Message)


                        Exit Function
                    End If

                End Try



            End While

            Return True

        End SyncLock

    End Function

    Public Function WriteDataMemory(ByVal DataMemoryAddress2Write As Integer, ByVal NumberOfWords2Write As Integer, ByVal DataMemoryValue2Write As UInteger, Optional ByRef CommandString As String = "default", Optional ByRef ReponseString As String = "default") As Boolean




        Dim HostLinkHeader As String
        Dim HostLinkFCS As String
        Dim HostLinkTerminator As String

        Dim FINSDataMemoryWriteCmd As String
        Dim FINSRecievePacket As String

        Dim CompleteWriteDataMemoryCommand As String
        Dim RecieveWriteDataMemoryResult As String
        Dim Retry As Integer = 0


        'HL = New HostLink
        'FC = New OmronFINSCommand
        'SP = New SerialPort4Omron(CommPort)
        SyncLock OmronPLCSyncLock
            While True



                Try


                    If (SP.OpenComm() = False) Then
                        'MsgBox("Failed to Open Serial Port", MsgBoxStyle.OkCancel, "Error")

                        Throw New Exception("Failed to Open Serial Port - Write Data Memory -" + " " + SP.GetCommPort.ToString)
                        SP.CloseComm()
                        Exit Function
                    End If



                    HL.BuildHostLinkHeader(HostLinkHeader)

                    FC.BuildWriteDataMemoryCommand(FINSDataMemoryWriteCmd, DataMemoryAddress2Write, NumberOfWords2Write, DataMemoryValue2Write)

                    CompleteWriteDataMemoryCommand = HostLinkHeader + FINSDataMemoryWriteCmd

                    HL.BuildHostLinkFCSData(CompleteWriteDataMemoryCommand, HostLinkFCS)

                    HL.BuildHostLinkTerminator(HostLinkTerminator)

                    CompleteWriteDataMemoryCommand = CompleteWriteDataMemoryCommand + HostLinkFCS + HostLinkTerminator

                    CommandString = CompleteWriteDataMemoryCommand

                    SP.SendPacket(CompleteWriteDataMemoryCommand)

                    RecieveWriteDataMemoryResult = ""

                    If (SP.Get2EndChar(RecieveWriteDataMemoryResult, Chr(13).ToString) = False) Then


                        'MsgBox("Error Getting Repsonse From Omron PLC.", MsgBoxStyle.OkOnly, "Error") 

                        Throw New Exception("Error Getting Repsonse From Omron PLC." + " " + SP.GetCommPort.ToString)
                        SP.CloseComm()

                        Exit Function
                    End If



                    ReponseString = RecieveWriteDataMemoryResult


                    If (HL.DisassembleHostLinkPacket(FINSRecievePacket, RecieveWriteDataMemoryResult) = False) Then

                        ' MsgBox("Failed to Disassemble Write Data Memory Recieve Packet", MsgBoxStyle.OkOnly, "Error") 

                        Throw New Exception("Failed to Disassemble Write Data Memory Recieve Packet" + " " + SP.GetCommPort.ToString)

                        SP.CloseComm()
                        Exit Function
                    End If

                    If (FC.DisassembleWriteDataMemoryResponse(FINSRecievePacket) = False) Then

                        ' MsgBox("Failed to Verify Write Data Memory Response", MsgBoxStyle.OkOnly, "Error") 

                        Throw New Exception("Failed to Verify Write Data Memory Response" + " " + SP.GetCommPort.ToString)

                        SP.CloseComm()
                        Exit Function
                    End If




                    SP.CloseComm()

                    Exit While


                Catch ex As Exception

                    SP.CloseComm()
                    Retry = Retry + 1


                    If (Retry > MaxRetry) Then

                        Throw New Exception(ex.Message)


                        Exit Function
                    End If

                End Try



            End While

            Return True
            Return True
        End SyncLock


    End Function

    Public Function WriteDataMemory(ByRef DM As DMInfo, ByRef DataMemoryValue2Write As UInteger, Optional ByRef CommandString As String = "default", Optional ByRef ReponseString As String = "default") As Boolean




        Dim HostLinkHeader As String
        Dim HostLinkFCS As String
        Dim HostLinkTerminator As String

        Dim FINSDataMemoryWriteCmd As String
        Dim FINSRecievePacket As String

        Dim CompleteWriteDataMemoryCommand As String
        Dim RecieveWriteDataMemoryResult As String
        Dim Retry As Integer = 0


        'HL = New HostLink
        'FC = New OmronFINSCommand
        'SP = New SerialPort4Omron(CommPort)
        SyncLock OmronPLCSyncLock

            Dim DataMemoryAddress2Write As Integer = DM.DMAddress
            Dim NumberOfWords2Write As Integer = DM.NumberOfWords



            While True



                Try


                    If (SP.OpenComm() = False) Then
                        'MsgBox("Failed to Open Serial Port", MsgBoxStyle.OkCancel, "Error")

                        Throw New Exception("Failed to Open Serial Port - Write Data Memory -" + " " + SP.GetCommPort.ToString)
                        SP.CloseComm()
                        Exit Function
                    End If



                    HL.BuildHostLinkHeader(HostLinkHeader)

                    FC.BuildWriteDataMemoryCommand(FINSDataMemoryWriteCmd, DataMemoryAddress2Write, NumberOfWords2Write, DataMemoryValue2Write)

                    CompleteWriteDataMemoryCommand = HostLinkHeader + FINSDataMemoryWriteCmd

                    HL.BuildHostLinkFCSData(CompleteWriteDataMemoryCommand, HostLinkFCS)

                    HL.BuildHostLinkTerminator(HostLinkTerminator)

                    CompleteWriteDataMemoryCommand = CompleteWriteDataMemoryCommand + HostLinkFCS + HostLinkTerminator

                    CommandString = CompleteWriteDataMemoryCommand

                    SP.SendPacket(CompleteWriteDataMemoryCommand)

                    RecieveWriteDataMemoryResult = ""

                    If (SP.Get2EndChar(RecieveWriteDataMemoryResult, Chr(13).ToString) = False) Then


                        'MsgBox("Error Getting Repsonse From Omron PLC.", MsgBoxStyle.OkOnly, "Error") 

                        Throw New Exception("Error Getting Repsonse From Omron PLC." + " " + SP.GetCommPort.ToString)
                        SP.CloseComm()

                        Exit Function
                    End If



                    ReponseString = RecieveWriteDataMemoryResult


                    If (HL.DisassembleHostLinkPacket(FINSRecievePacket, RecieveWriteDataMemoryResult) = False) Then

                        ' MsgBox("Failed to Disassemble Write Data Memory Recieve Packet", MsgBoxStyle.OkOnly, "Error") 

                        Throw New Exception("Failed to Disassemble Write Data Memory Recieve Packet" + " " + SP.GetCommPort.ToString)

                        SP.CloseComm()
                        Exit Function
                    End If

                    If (FC.DisassembleWriteDataMemoryResponse(FINSRecievePacket) = False) Then

                        ' MsgBox("Failed to Verify Write Data Memory Response", MsgBoxStyle.OkOnly, "Error") 

                        Throw New Exception("Failed to Verify Write Data Memory Response" + " " + SP.GetCommPort.ToString)

                        SP.CloseComm()
                        Exit Function
                    End If




                    SP.CloseComm()

                    Exit While


                Catch ex As Exception

                    SP.CloseComm()
                    Retry = Retry + 1


                    If (Retry > MaxRetry) Then

                        Throw New Exception(ex.Message)


                        Exit Function
                    End If

                End Try



            End While

            Return True
            Return True
        End SyncLock


    End Function

    Public Function ReadRelayState(ByVal MemoryArea As String, ByVal WordAddress As Integer, ByVal BitAddress As Integer, ByRef RelayState As Boolean, Optional ByRef CommandString As String = "default", Optional ByRef ReponseString As String = "default") As Boolean

        Dim HostLinkHeader As String
        Dim HostLinkFCS As String
        Dim HostLinkTerminator As String

        Dim FINSReadRelayCmd As String
        Dim FINSRecievePacket As String

        Dim CompleteReadRelayCommand As String
        Dim RecieveReadRelayResult As String

        Dim Retry As Integer = 0

        'HL = New HostLink
        'FC = New OmronFINSCommand
        'SP = New SerialPort4Omron(CommPort)
        SyncLock OmronPLCSyncLock

            While True



                Try

                    If (SP.OpenComm() = False) Then
                        'MsgBox("Failed to Open Serial Port", MsgBoxStyle.OkCancel, "Error")

                        Throw New Exception("Failed to Open Serial Port - Read Relay state -" + " " + SP.GetCommPort.ToString)
                        SP.CloseComm()
                        Exit Function
                    End If


                    HL.BuildHostLinkHeader(HostLinkHeader)

                    If (FC.BuildReadRelayStateCommand(FINSReadRelayCmd, MemoryArea, WordAddress, BitAddress) = False) Then

                        ' MsgBox("Failed to Build Read Relay State Command", MsgBoxStyle.OkOnly, "Error") 

                        Throw New Exception("Failed to Build Read Relay State Command" + " " + SP.GetCommPort.ToString)
                        SP.CloseComm()

                    End If

                    CompleteReadRelayCommand = HostLinkHeader + FINSReadRelayCmd

                    HL.BuildHostLinkFCSData(CompleteReadRelayCommand, HostLinkFCS)

                    HL.BuildHostLinkTerminator(HostLinkTerminator)

                    CompleteReadRelayCommand = CompleteReadRelayCommand + HostLinkFCS + HostLinkTerminator

                    CommandString = CompleteReadRelayCommand

                    If (SP.OpenComm() = False) Then

                        'MsgBox("Failed to Open Serial Port", MsgBoxStyle.OkCancel, "Error") 

                        Throw New Exception("Failed to Open Serial Port" + " " + SP.GetCommPort.ToString)

                    End If

                    SP.SendPacket(CompleteReadRelayCommand)

                    RecieveReadRelayResult = ""

                    If (SP.Get2EndChar(RecieveReadRelayResult, Chr(13).ToString) = False) Then


                        'MsgBox("Error Getting Repsonse From Omron PLC.", MsgBoxStyle.OkOnly, "Error") 

                        Throw New Exception("Error Getting Repsonse From Omron PLC." + " " + SP.GetCommPort.ToString)
                        SP.CloseComm()

                    End If

                    SP.CloseComm()

                    ReponseString = RecieveReadRelayResult

                    If (HL.DisassembleHostLinkPacket(FINSRecievePacket, RecieveReadRelayResult) = False) Then

                        'MsgBox("Failed to Disassemble Write Data Memory Recieve Packet.", MsgBoxStyle.OkOnly, "Error") 

                        Throw New Exception("Failed to Disassemble Write Data Memory Recieve Packet." + " " + SP.GetCommPort.ToString)

                    End If

                    If (FC.DisassembleReadRelayStateResponse(FINSRecievePacket, RelayState) = False) Then

                        'MsgBox("Failed to Get Relay State.", MsgBoxStyle.OkOnly, "Error") 

                        Throw New Exception("Failed to Get Relay State." + " " + SP.GetCommPort.ToString)

                    End If

                    Exit While


                Catch ex As Exception

                    SP.CloseComm()
                    Retry = Retry + 1


                    If (Retry > MaxRetry) Then

                        Throw New Exception(ex.Message)


                        Exit Function
                    End If

                End Try



            End While

            Return True

        End SyncLock
    End Function

    Public Function ReadRelayState(ByRef Relay As RelayInfo, ByRef RelayState As Boolean, Optional ByRef CommandString As String = "default", Optional ByRef ReponseString As String = "default") As Boolean

        Dim HostLinkHeader As String
        Dim HostLinkFCS As String
        Dim HostLinkTerminator As String

        Dim FINSReadRelayCmd As String
        Dim FINSRecievePacket As String

        Dim CompleteReadRelayCommand As String
        Dim RecieveReadRelayResult As String

        Dim Retry As Integer = 0

        'HL = New HostLink
        'FC = New OmronFINSCommand
        'SP = New SerialPort4Omron(CommPort)
        SyncLock OmronPLCSyncLock

            Dim MemoryArea As String = Relay.MemoryArea
            Dim WordAddress As Integer = Relay.WordAddress
            Dim BitAddress As Integer = Relay.BitAddress



            While True



                Try

                    If (SP.OpenComm() = False) Then
                        'MsgBox("Failed to Open Serial Port", MsgBoxStyle.OkCancel, "Error")

                        Throw New Exception("Failed to Open Serial Port - Read Relay state -" + " " + SP.GetCommPort.ToString)
                        SP.CloseComm()
                        Exit Function
                    End If


                    HL.BuildHostLinkHeader(HostLinkHeader)

                    If (FC.BuildReadRelayStateCommand(FINSReadRelayCmd, MemoryArea, WordAddress, BitAddress) = False) Then

                        ' MsgBox("Failed to Build Read Relay State Command", MsgBoxStyle.OkOnly, "Error") 

                        Throw New Exception("Failed to Build Read Relay State Command" + " " + SP.GetCommPort.ToString)
                        SP.CloseComm()

                    End If

                    CompleteReadRelayCommand = HostLinkHeader + FINSReadRelayCmd

                    HL.BuildHostLinkFCSData(CompleteReadRelayCommand, HostLinkFCS)

                    HL.BuildHostLinkTerminator(HostLinkTerminator)

                    CompleteReadRelayCommand = CompleteReadRelayCommand + HostLinkFCS + HostLinkTerminator

                    CommandString = CompleteReadRelayCommand

                    If (SP.OpenComm() = False) Then

                        'MsgBox("Failed to Open Serial Port", MsgBoxStyle.OkCancel, "Error") 

                        Throw New Exception("Failed to Open Serial Port" + " " + SP.GetCommPort.ToString)

                    End If

                    SP.SendPacket(CompleteReadRelayCommand)

                    RecieveReadRelayResult = ""

                    If (SP.Get2EndChar(RecieveReadRelayResult, Chr(13).ToString) = False) Then


                        'MsgBox("Error Getting Repsonse From Omron PLC.", MsgBoxStyle.OkOnly, "Error") 

                        Throw New Exception("Error Getting Repsonse From Omron PLC." + " " + SP.GetCommPort.ToString)
                        SP.CloseComm()

                    End If

                    SP.CloseComm()

                    ReponseString = RecieveReadRelayResult

                    If (HL.DisassembleHostLinkPacket(FINSRecievePacket, RecieveReadRelayResult) = False) Then

                        'MsgBox("Failed to Disassemble Write Data Memory Recieve Packet.", MsgBoxStyle.OkOnly, "Error") 

                        Throw New Exception("Failed to Disassemble Write Data Memory Recieve Packet." + " " + SP.GetCommPort.ToString)

                    End If

                    If (FC.DisassembleReadRelayStateResponse(FINSRecievePacket, RelayState) = False) Then

                        'MsgBox("Failed to Get Relay State.", MsgBoxStyle.OkOnly, "Error") 

                        Throw New Exception("Failed to Get Relay State." + " " + SP.GetCommPort.ToString)

                    End If

                    Exit While


                Catch ex As Exception

                    SP.CloseComm()
                    Retry = Retry + 1


                    If (Retry > MaxRetry) Then

                        Throw New Exception(ex.Message)


                        Exit Function
                    End If

                End Try



            End While

            Return True

        End SyncLock
    End Function

    Public Function SetOrResetRelayState(ByVal MemoryArea As String, ByVal WordAddress As Integer, ByVal BitAddress As Integer, ByVal RelayState As Boolean, Optional ByRef CommandString As String = "default", Optional ByRef ReponseString As String = "default") As Boolean

        Dim HostLinkHeader As String
        Dim HostLinkFCS As String
        Dim HostLinkTerminator As String

        Dim FINSSetOrResetRelayCmd As String
        Dim FINSRecievePacket As String

        Dim CompleteSetOrResetRelayCommand As String
        Dim RecieveSetOrResetRelayResult As String

        Dim Retry As Integer = 0


        SyncLock OmronPLCSyncLock


            'HL = New HostLink
            'FC = New OmronFINSCommand
            'SP = New SerialPort4Omron(CommPort)

            While True



                Try



                    If (SP.OpenComm() = False) Then
                        'MsgBox("Failed to Open Serial Port", MsgBoxStyle.OkCancel, "Error")

                        Throw New Exception("Failed to Open Serial Port - Set or Reset Relay state -" + " " + SP.GetCommPort.ToString)
                        SP.CloseComm()
                        Exit Function
                    End If


                    HL.BuildHostLinkHeader(HostLinkHeader)

                    If (FC.BuildSetOrResetRelayStateCommand(FINSSetOrResetRelayCmd, MemoryArea, WordAddress, BitAddress, RelayState) = False) Then

                        ' MsgBox("Failed to Build Set Or Reset Relay State Command", MsgBoxStyle.OkOnly, "Error") 

                        Throw New Exception("Failed to Build Set Or Reset Relay State Command" + " " + SP.GetCommPort.ToString)
                        SP.CloseComm()

                        Exit Function
                    End If

                    CompleteSetOrResetRelayCommand = HostLinkHeader + FINSSetOrResetRelayCmd

                    HL.BuildHostLinkFCSData(CompleteSetOrResetRelayCommand, HostLinkFCS)

                    HL.BuildHostLinkTerminator(HostLinkTerminator)

                    CompleteSetOrResetRelayCommand = CompleteSetOrResetRelayCommand + HostLinkFCS + HostLinkTerminator

                    CommandString = CompleteSetOrResetRelayCommand



                    SP.SendPacket(CompleteSetOrResetRelayCommand)

                    RecieveSetOrResetRelayResult = ""

                    If (SP.Get2EndChar(RecieveSetOrResetRelayResult, Chr(13).ToString) = False) Then


                        'MsgBox("Error Getting Repsonse From Omron PLC.", MsgBoxStyle.OkOnly, "Error") 

                        Throw New Exception("Error Getting Repsonse From Omron PLC." + " " + SP.GetCommPort.ToString)
                        SP.CloseComm()

                        Exit Function

                    End If


                    ReponseString = RecieveSetOrResetRelayResult

                    If (HL.DisassembleHostLinkPacket(FINSRecievePacket, RecieveSetOrResetRelayResult) = False) Then

                        'MsgBox("Failed to Disassemble Set or Reset Relay Recieve Packet.", MsgBoxStyle.OkOnly, "Error") 

                        Throw New Exception("Failed to Disassemble Set or Reset Relay Recieve Packet." + " " + SP.GetCommPort.ToString)
                        SP.CloseComm()

                        Exit Function
                    End If

                    If (FC.DisassembleSetOrResetRelayResponse(FINSRecievePacket) = False) Then

                        'MsgBox("Failed to Set or Reset Relay State.", MsgBoxStyle.OkOnly, "Error") 

                        Throw New Exception("Failed to Set or Reset Relay State." + " " + SP.GetCommPort.ToString)
                        SP.CloseComm()

                        Exit Function
                    End If

                    SP.CloseComm()

                    Exit While


                Catch ex As Exception

                    SP.CloseComm()
                    Retry = Retry + 1


                    If (Retry > MaxRetry) Then

                        Throw New Exception(ex.Message)


                        Exit Function
                    End If

                End Try



            End While

            Return True

        End SyncLock
    End Function

    Public Function SetOrResetRelayState(ByRef Relay As RelayInfo, ByVal RelayState As Boolean, Optional ByRef CommandString As String = "default", Optional ByRef ReponseString As String = "default") As Boolean

        Dim HostLinkHeader As String
        Dim HostLinkFCS As String
        Dim HostLinkTerminator As String

        Dim FINSSetOrResetRelayCmd As String
        Dim FINSRecievePacket As String

        Dim CompleteSetOrResetRelayCommand As String
        Dim RecieveSetOrResetRelayResult As String

        Dim Retry As Integer = 0


        SyncLock OmronPLCSyncLock


            Dim MemoryArea As String = Relay.MemoryArea
            Dim WordAddress As Integer = Relay.WordAddress
            Dim BitAddress As Integer = Relay.BitAddress

            'HL = New HostLink
            'FC = New OmronFINSCommand
            'SP = New SerialPort4Omron(CommPort)

            While True



                Try



                    If (SP.OpenComm() = False) Then
                        'MsgBox("Failed to Open Serial Port", MsgBoxStyle.OkCancel, "Error")

                        Throw New Exception("Failed to Open Serial Port - Set or Reset Relay state -" + " " + SP.GetCommPort.ToString)
                        SP.CloseComm()
                        Exit Function
                    End If


                    HL.BuildHostLinkHeader(HostLinkHeader)

                    If (FC.BuildSetOrResetRelayStateCommand(FINSSetOrResetRelayCmd, MemoryArea, WordAddress, BitAddress, RelayState) = False) Then

                        ' MsgBox("Failed to Build Set Or Reset Relay State Command", MsgBoxStyle.OkOnly, "Error") 

                        Throw New Exception("Failed to Build Set Or Reset Relay State Command" + " " + SP.GetCommPort.ToString)
                        SP.CloseComm()

                        Exit Function
                    End If

                    CompleteSetOrResetRelayCommand = HostLinkHeader + FINSSetOrResetRelayCmd

                    HL.BuildHostLinkFCSData(CompleteSetOrResetRelayCommand, HostLinkFCS)

                    HL.BuildHostLinkTerminator(HostLinkTerminator)

                    CompleteSetOrResetRelayCommand = CompleteSetOrResetRelayCommand + HostLinkFCS + HostLinkTerminator

                    CommandString = CompleteSetOrResetRelayCommand



                    SP.SendPacket(CompleteSetOrResetRelayCommand)

                    RecieveSetOrResetRelayResult = ""

                    If (SP.Get2EndChar(RecieveSetOrResetRelayResult, Chr(13).ToString) = False) Then


                        'MsgBox("Error Getting Repsonse From Omron PLC.", MsgBoxStyle.OkOnly, "Error") 

                        Throw New Exception("Error Getting Repsonse From Omron PLC." + " " + SP.GetCommPort.ToString)
                        SP.CloseComm()

                        Exit Function

                    End If


                    ReponseString = RecieveSetOrResetRelayResult

                    If (HL.DisassembleHostLinkPacket(FINSRecievePacket, RecieveSetOrResetRelayResult) = False) Then

                        'MsgBox("Failed to Disassemble Set or Reset Relay Recieve Packet.", MsgBoxStyle.OkOnly, "Error") 

                        Throw New Exception("Failed to Disassemble Set or Reset Relay Recieve Packet." + " " + SP.GetCommPort.ToString)
                        SP.CloseComm()

                        Exit Function
                    End If

                    If (FC.DisassembleSetOrResetRelayResponse(FINSRecievePacket) = False) Then

                        'MsgBox("Failed to Set or Reset Relay State.", MsgBoxStyle.OkOnly, "Error") 

                        Throw New Exception("Failed to Set or Reset Relay State." + " " + SP.GetCommPort.ToString)
                        SP.CloseComm()

                        Exit Function
                    End If

                    SP.CloseComm()

                    Exit While


                Catch ex As Exception

                    SP.CloseComm()
                    Retry = Retry + 1


                    If (Retry > MaxRetry) Then

                        Throw New Exception(ex.Message)


                        Exit Function
                    End If

                End Try



            End While

            Return True

        End SyncLock
    End Function


End Class

