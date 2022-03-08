Public Class OmronFINSWithRouting

    Dim ICF As Byte ' DisPlays Frame Information
    Dim RSV As Byte ' Reserved By System
    Dim GCT As Byte ' Permissible Number Of Gateways
    Dim DNA As Byte ' Destination Network Address
    Dim DA1 As Byte ' Destination Node Address
    Dim DA2 As Byte ' Destination unit Address
    Dim SNA As Byte ' Source Network Address
    Dim SA1 As Byte ' Source Node Address
    Dim SA2 As Byte ' Source unit Address
    Dim SID As Byte ' Service ID

    Dim FC As OmronFINSCommand


    Public Sub New(ByRef IpAdressOfPLC As String, ByRef IpAdsressOfComputer As String)
        Dim ipadd As System.Net.IPAddress

        Try
            FC = New OmronFINSCommand

            ICF = &H80
            RSV = &H0
            GCT = &H2

            DNA = &H0
            ipadd = System.Net.IPAddress.Parse(IpAdressOfPLC)
            DA1 = ipadd.GetAddressBytes(3)
            DA2 = &H0

            SNA = &H0
            ipadd = System.Net.IPAddress.Parse(IpAdsressOfComputer)
            SA1 = ipadd.GetAddressBytes(3)
            SA2 = &H0

            SID = &HA

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try






    End Sub

    Private Sub ConvertString2ByteHex(ByRef DMCmd As String, ByRef Header() As Byte)

        Dim String2HexValue As String
        Dim EndCount As Integer = 0

        Try
            EndCount = ((DMCmd.Length / 2) + 10) - 1

            For i As Integer = 10 To EndCount Step 1
                String2HexValue = DMCmd.Substring((i - 10) * 2, 2)
                Header(i) = Convert.ToInt32(String2HexValue, 16)
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Sub
    Private Sub FormatHexValueToString(ByRef ReadDMResponse() As Byte, ByRef ReadDMResponseS As String)
        Dim temp As String

        Try
            For Each i As Byte In ReadDMResponse
                temp = Hex(i)
                If (temp.Length = 2) Then
                    ReadDMResponseS = ReadDMResponseS + temp
                Else
                    ReadDMResponseS = ReadDMResponseS + "0" + temp
                End If

            Next

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Sub

    Public Sub BuildFINSHeader(ByRef Header() As Byte)

        Header(0) = ICF
        Header(1) = RSV
        Header(2) = GCT
        Header(3) = DNA
        Header(4) = DA1
        Header(5) = DA2
        Header(6) = SNA
        Header(7) = SA1
        Header(8) = SA2
        Header(9) = SID


    End Sub

    Public Function BuildReadDataMemoryCommand(ByRef Header() As Byte, ByVal DataMemoryAddress As Integer, ByVal NumOfWords2Rd As Integer, Optional ByVal MemoryArea As String = "DM") As Boolean

        Dim ReadDMCmd As String

        Try
            FC.BuildReadDataMemoryCommand(ReadDMCmd, DataMemoryAddress, NumOfWords2Rd, MemoryArea)
            ConvertString2ByteHex(ReadDMCmd, Header)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try


        Return True

    End Function

    Public Function DisassembleReadDataMemoryRespose(ByRef ReadDMValue As UInt64, ByVal ReadDMResponse() As Byte) As Boolean
        Dim ReadDMResponseS As String
        Dim temp As String

        Try
            FormatHexValueToString(ReadDMResponse, ReadDMResponseS)
            ReadDMResponseS = ReadDMResponseS.Substring(20)
            FC.DisassembleReadDataMemoryRespose(ReadDMValue, ReadDMResponseS)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

        Return True

    End Function

    Public Function BuildWriteDataMemoryCommand(ByRef Header() As Byte, ByVal DataMemoryAddress As Integer, ByVal NumberOfDataMemory2Write2 As Integer, ByVal Number2Write2DataMemory As UInteger, Optional ByVal MemoryArea As String = "DM") As Boolean



        Dim WriteDMCmd As String
        Dim String2HexValue As String

        Try
            FC.BuildWriteDataMemoryCommand(WriteDMCmd, DataMemoryAddress, NumberOfDataMemory2Write2, Number2Write2DataMemory, MemoryArea)
            ConvertString2ByteHex(WriteDMCmd, Header)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try


        Return True



    End Function

    Public Function DisassembleWriteDataMemoryResponse(ByVal WriteDMResponse() As Byte) As Boolean
        Dim WriteDMResponseS As String

        Try
            FormatHexValueToString(WriteDMResponse, WriteDMResponseS)
            'lets remove the header info
            ' WriteDMResponseS = WriteDMResponseS.Substring(20, 20)
            Dim temp As String = WriteDMResponseS.Substring(20, (WriteDMResponseS.Length - 20))
            FC.DisassembleWriteDataMemoryResponse(temp)

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
     
        Return True


    End Function

    Public Function BuildReadRelayStateCommand(ByRef Header() As Byte, ByVal MemoryArea As String, ByVal WordAddress As Integer, ByVal BitAddress As Integer) As Boolean

        Dim ReadRelayCmd As String
        Dim String2HexValue As String

        Try
            FC.BuildReadRelayStateCommand(ReadRelayCmd, MemoryArea, WordAddress, BitAddress)
            ConvertString2ByteHex(ReadRelayCmd, Header)

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

        Return True

    End Function

    Public Function DisassembleReadRelayStateResponse(ByVal ReadRelayResponse() As Byte, ByRef RelayState As Boolean) As Boolean


        Dim ReadRelayResponseS As String

        Try
            FormatHexValueToString(ReadRelayResponse, ReadRelayResponseS)
            Dim temp As String = ReadRelayResponseS.Substring(20, (ReadRelayResponseS.Length - 20))
            FC.DisassembleReadRelayStateResponse(temp, RelayState)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

   

        Return True

    End Function

    Public Function BuildSetOrResetRelayStateCommand(ByRef Header() As Byte, ByVal MemoryArea As String, ByVal WordAddress As Integer, ByVal BitAddress As Integer, ByVal BitState As Boolean) As Boolean

        Dim SetOrResetRelayCmd As String
        Dim String2HexValue As String

        Try
            FC.BuildSetOrResetRelayStateCommand(SetOrResetRelayCmd, MemoryArea, WordAddress, BitAddress, BitState)
            ConvertString2ByteHex(SetOrResetRelayCmd, Header)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

        Return True
    End Function

    Public Function DisassembleSetOrResetRelayResponse(ByVal WriteRelayStateResponse() As Byte) As Boolean

        Dim WriteRelayStateResponseS As String

        Try
            FormatHexValueToString(WriteRelayStateResponse, WriteRelayStateResponseS)
            FC.DisassembleSetOrResetRelayResponse(WriteRelayStateResponseS)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

      


        Return True




    End Function

    Public Function BuildReadMultipleNonConsectiveDataMemoryResponse(ByRef Header() As Byte, ByRef DMInfo() As DMInfo)
        Dim ReadDMCmd As String

        Try
            FC.BuildReadMultipleNonConsectiveDataMemoryResponse(ReadDMCmd, DMInfo)

            ReDim Preserve Header(9 + (ReadDMCmd.Length / 2)) ' making it the right length 

            ConvertString2ByteHex(ReadDMCmd, Header)

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try


        Return True

    End Function

    Public Function DisassembleReadMultipleNonConsectiveDataMemoryResponse(ByRef ReadDMResponse() As Byte, ByRef DMinfo() As DMInfo, ByRef DMValve() As String)

        Dim ReadDMResponseS As String

        Try
            FormatHexValueToString(ReadDMResponse, ReadDMResponseS)
            ReadDMResponseS = ReadDMResponseS.Substring(20)
            FC.DisassembleReadMultipleNonConsectiveDataMemoryResponse(ReadDMResponseS, DMinfo, DMValve)

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try


        Return True


    End Function



End Class
