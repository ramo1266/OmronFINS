Public Class HostLink


    Public Function BuildHostLinkHeader(ByRef HostLinkerHeader As String) As Boolean

        Dim Prefix As String
        Dim UnitNumber As String
        Dim HeaderCode As String
        Dim ResponseWaitTime As String
        Dim InfoCntrlField As String
        Dim RSV As String
        Dim GatewayCnt As String
        Dim DestNetworkAdd As String
        Dim DestNodeAdd As String
        Dim DestUnitAdd As String
        Dim SourceNetworkAdd As String
        Dim SourceNodeAdd As String
        Dim SourceUnitAdd As String
        Dim SourceID As String


        Prefix = "@"
        UnitNumber = "00"
        HeaderCode = "FA"
        ResponseWaitTime = "0" ' times 10msec
        InfoCntrlField = "00"
        RSV = "00"
        GatewayCnt = "07"
        DestNetworkAdd = "00"
        DestNodeAdd = "00"
        DestUnitAdd = "00"
        SourceNetworkAdd = "00"
        SourceNodeAdd = "00"
        SourceUnitAdd = "00"
        SourceID = "00"

        'HostLinkerHeader = Prefix + UnitNumber + HeaderCode + ResponseWaitTime + InfoCntrlField + RSV + GatewayCnt + DestNetworkAdd + DestNodeAdd +DestUnitAdd + SourceNetworkAdd + SourceNodeAdd + SourceUnitAdd + SourceID

        HostLinkerHeader = Prefix + UnitNumber + HeaderCode + ResponseWaitTime + InfoCntrlField + DestUnitAdd + SourceUnitAdd + SourceID

        Return True


    End Function

    Public Function BuildHostLinkFCSData(ByVal CommandString As String, ByRef FCSData As String) As Boolean

        Dim FCSCheckSum As Integer
        Dim NumberOfCar As Integer
        Dim Index As Integer


        FCSCheckSum = 0



        NumberOfCar = CommandString.Length


        For Index = 1 To (NumberOfCar) Step 1

            FCSCheckSum = FCSCheckSum Xor Asc(Mid(CommandString, Index, 1))

        Next Index


        FCSData = Hex(FCSCheckSum)

        If (CheckLenghtAndPrefixZero(FCSData, 2) = False) Then

            Return False
            Exit Function

        End If


        Return True

    End Function

    Public Function BuildHostLinkTerminator(ByRef HostLinkTerminator As String) As Boolean


        HostLinkTerminator = "*" + Chr(13).ToString

        Return True

    End Function

    Public Function DisassembleHostLinkPacket(ByRef FINSPacket As String, ByVal ResponsePacket As String) As Boolean

        Dim FCSDataFromResponsePacket As String
        Dim FCSData2TestAgainst As String

        Try
            ' check the Packet length (minimum packet length is 27)
            ' CPU unit durectly connected to the HOST COMPUTER

            If (ResponsePacket.Length < 27) Then
                Return False
                Exit Function
            End If

            ' lets remove the terminator from the packet
            ResponsePacket = ResponsePacket.Remove((ResponsePacket.Length - 2), 2)

            'let remove the FCSData from the packet and store it
            FCSDataFromResponsePacket = ResponsePacket.Substring((ResponsePacket.Length - 2), 2)
            ResponsePacket = ResponsePacket.Remove((ResponsePacket.Length - 2), 2)

            BuildHostLinkFCSData(ResponsePacket, FCSData2TestAgainst)

            ' test the FCS checksum
            If (Not (FCSData2TestAgainst = FCSDataFromResponsePacket)) Then
                Return False
                Exit Function

            End If

            'Now let remove Host Link Header

            FINSPacket = ResponsePacket.Substring(15)

            Return True
            Exit Function

        Catch ex As Exception
            Throw New Exception(ex.Message)

        End Try
        
    End Function

    Private Function CheckLenghtAndPrefixZero(ByRef String2Check As String, ByVal LengthOfString As Integer) As Boolean

        ' this section is used to check the lenght the 
        Dim LenghtOfBeginningAddress As String

        LenghtOfBeginningAddress = String2Check.Length()

        If (LenghtOfBeginningAddress > LengthOfString) Then
            Return False
            Exit Function
        End If

        If (LenghtOfBeginningAddress < LengthOfString) Then
            Dim index As Integer



            For index = (LenghtOfBeginningAddress + 1) To LengthOfString Step 1

                String2Check = "0" + String2Check

            Next index

        End If

        Return True


    End Function

End Class
