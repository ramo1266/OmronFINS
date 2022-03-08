Imports System.Net.Sockets

Public Class OmronFINSEthernetCommMain

    Private MaxRetry As Integer = 5
    Private CommPortName As String
    Private OmronPLCEnthernetSyncLock As New Object


    Private FC As OmronFINSWithRouting
    Private EP As EhternetPortForOmron


  
    Public Sub New(ByRef IpAdressOfPLC As String, ByRef PortAddressOfPLC As Integer, ByRef IpAdsressOfComputer As String)

        EP = New EhternetPortForOmron(IpAdressOfPLC, PortAddressOfPLC)
        FC = New OmronFINSWithRouting(IpAdressOfPLC, IpAdsressOfComputer)

    End Sub


    Public Sub ReadMultipleNonConsectiveDataMemory(ByRef DM() As DMInfo, ByRef DMValve() As String, Optional ByRef CommandString As String = "default", Optional ByRef ReponseString As String = "default")

        Dim CompleteReadDataMemoryCommand() As Byte
        Dim RecieveReadDataMemoryResult(2000) As Byte


        Dim Retry As Integer = 0

        SyncLock OmronPLCEnthernetSyncLock

            Try
                ReDim Preserve CompleteReadDataMemoryCommand(9)
                FC.BuildFINSHeader(CompleteReadDataMemoryCommand)

                FC.BuildReadMultipleNonConsectiveDataMemoryResponse(CompleteReadDataMemoryCommand, DM)

                EP.Connect()
                EP.SendPacket(CompleteReadDataMemoryCommand)

                EP.RecievePacket(RecieveReadDataMemoryResult)
                FC.DisassembleReadMultipleNonConsectiveDataMemoryResponse(RecieveReadDataMemoryResult, DM, DMValve)


            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try


        End SyncLock


    End Sub

    Public Function ReadDataMemory(ByVal DataMemoryAddress As Integer, ByVal NumberOfWords2Read As Integer, ByRef DataMemoryValue As UInt64, Optional ByVal MemoryArea As String = "DM", Optional ByRef CommandString As String = "default", Optional ByRef ReponseString As String = "default")

        Dim CompleteReadDataMemoryCommand(17) As Byte
        Dim RecieveReadDataMemoryResult(1000) As Byte


        Dim Retry As Integer = 0

        SyncLock OmronPLCEnthernetSyncLock

            Try
                FC.BuildFINSHeader(CompleteReadDataMemoryCommand)
                FC.BuildReadDataMemoryCommand(CompleteReadDataMemoryCommand, DataMemoryAddress, NumberOfWords2Read, MemoryArea)
                EP.Connect()
                EP.SendPacket(CompleteReadDataMemoryCommand)
                EP.RecievePacket(RecieveReadDataMemoryResult)
                FC.DisassembleReadDataMemoryRespose(DataMemoryValue, RecieveReadDataMemoryResult)


            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try


        End SyncLock
        Return True

    End Function

    Public Function WriteDataMemory(ByVal DataMemoryAddress2Write As Integer, ByVal NumberOfWords2Write As Integer, ByVal DataMemoryValue2Write As UInteger, Optional ByVal MemoryArea As String = "DM", Optional ByRef CommandString As String = "default", Optional ByRef ReponseString As String = "default")

        Dim CompleteWriteDataMemoryCommand(17 + (2 * NumberOfWords2Write)) As Byte
        Dim RecieveWriteDataMemoryResult(1000) As Byte


        Dim Retry As Integer = 0

        SyncLock OmronPLCEnthernetSyncLock

            Try
                FC.BuildFINSHeader(CompleteWriteDataMemoryCommand)
                FC.BuildWriteDataMemoryCommand(CompleteWriteDataMemoryCommand, DataMemoryAddress2Write, NumberOfWords2Write, DataMemoryValue2Write, MemoryArea)
                EP.Connect()
                EP.SendPacket(CompleteWriteDataMemoryCommand)
                EP.RecievePacket(RecieveWriteDataMemoryResult)
                FC.DisassembleWriteDataMemoryResponse(RecieveWriteDataMemoryResult)
                Return True

            Catch ex As Exception
                Throw New Exception(ex.Message)
                Return False
            End Try


        End SyncLock

    End Function
    Public Sub WriteDataMemory(ByRef DM As DMInfo, ByRef DataMemoryValue2Write As UInteger, Optional ByRef CommandString As String = "default", Optional ByRef ReponseString As String = "default")

        Try
            WriteDataMemory(DM.DMAddress, DM.NumberOfWords, DataMemoryValue2Write)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try



    End Sub


    Public Sub ReadRelayState(ByVal MemoryArea As String, ByVal WordAddress As Integer, ByVal BitAddress As Integer, ByRef RelayState As Boolean, Optional ByRef CommandString As String = "default", Optional ByRef ReponseString As String = "default")
        Dim CompleteReadRelayCommand(17) As Byte
        Dim RecieveReadRelayResult(1000) As Byte


        Dim Retry As Integer = 0

        SyncLock OmronPLCEnthernetSyncLock

            Try
                FC.BuildFINSHeader(CompleteReadRelayCommand)
                FC.BuildReadRelayStateCommand(CompleteReadRelayCommand, MemoryArea, WordAddress, BitAddress)

                EP.Connect()
                EP.SendPacket(CompleteReadRelayCommand)
                EP.RecievePacket(RecieveReadRelayResult)
                FC.DisassembleReadRelayStateResponse(RecieveReadRelayResult, RelayState)


            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try


        End SyncLock
    End Sub
    Public Sub ReadRelayState(ByRef Relay As RelayInfo, ByRef RelayState As Boolean, Optional ByRef CommandString As String = "default", Optional ByRef ReponseString As String = "default")

        Try
            ReadRelayState(Relay.MemoryArea, Relay.WordAddress, Relay.BitAddress, RelayState)

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Sub


    Public Function SetOrResetRelayState(ByVal MemoryArea As String, ByVal WordAddress As Integer, ByVal BitAddress As Integer, ByVal RelayState As Boolean, Optional ByRef CommandString As String = "default", Optional ByRef ReponseString As String = "default")
        Dim CompleteSetOrResetRelayCommand(18) As Byte
        Dim RecieveSetOrResetRelayResult(1000) As Byte


        Dim Retry As Integer = 0

        SyncLock OmronPLCEnthernetSyncLock

            Try
                FC.BuildFINSHeader(CompleteSetOrResetRelayCommand)
                FC.BuildSetOrResetRelayStateCommand(CompleteSetOrResetRelayCommand, MemoryArea, WordAddress, BitAddress, RelayState)

                EP.Connect()
                EP.SendPacket(CompleteSetOrResetRelayCommand)
                EP.RecievePacket(RecieveSetOrResetRelayResult)
                FC.DisassembleSetOrResetRelayResponse(RecieveSetOrResetRelayResult)


            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try

            Return True
        End SyncLock

    End Function
    Public Function SetOrResetRelayState(ByRef Relay As RelayInfo, ByVal RelayState As Boolean, Optional ByRef CommandString As String = "default", Optional ByRef ReponseString As String = "default")
        Try
            Return SetOrResetRelayState(Relay.MemoryArea, Relay.WordAddress, Relay.BitAddress, RelayState)

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Function


End Class
