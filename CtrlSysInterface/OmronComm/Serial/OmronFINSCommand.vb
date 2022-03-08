Public Class OmronFINSCommand


    Public Function BuildReadMultipleNonConsectiveDataMemoryResponse(ByRef ReadDMCmd As String, ByRef DMInfo() As DMInfo) As Boolean
        Dim CommandCode As String
        Dim MemoryAreaCode As String
        Dim BeginningAddress As String


        Try
            CommandCode = "01" + "04" ' command code to read Data Memory
            MemoryAreaCode = "82"

            ReadDMCmd = CommandCode



            For Each DM As DMInfo In DMInfo
                For i As Integer = 1 To DM.NumberOfWords

                    BeginningAddress = Hex(DM.DMAddress + (i - 1))
                    BeginningAddress = BeginningAddress + "00"

                    If (CheckLenghtAndPrefixZero(BeginningAddress, 6) = False) Then
                        Return False
                        Exit Function
                    End If

                    ReadDMCmd = ReadDMCmd + MemoryAreaCode + BeginningAddress
                Next


            Next

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
  

        Return True

    End Function

    Public Function DisassembleReadMultipleNonConsectiveDataMemoryResponse(ByVal ReadDMResponse As String, ByRef DMInfo() As DMInfo, ByRef ReadDMValue() As String) As Boolean

        Dim CommandCode As String
        Dim EndCode As String
        Dim Data As String
        Dim a As Double

        CommandCode = ReadDMResponse.Substring(0, 4)
        ReadDMResponse = ReadDMResponse.Substring(4)

        EndCode = ReadDMResponse.Substring(0, 4)
        ReadDMResponse = ReadDMResponse.Substring(4)


        'Check Command Code
        If (Not (CommandCode = "0104")) Then
            Throw New Exception("Multiple Read: Command Code is Not 0104 it is : " + CommandCode)
            Return False
            Exit Function
        End If


        If (Not (EndCode = "0000")) Then
            Throw New Exception("Multiple Read: End Code is Not 0000 it is : " + EndCode)
            Return False
            Exit Function
        End If

        Dim ind As Integer = 0

        Try

            For Each DM As DMInfo In DMInfo

                Data = ""

                If (DM.NumberOfWords = 0) Then
                    Exit For
                End If

                For i As Integer = 1 To DM.NumberOfWords

                    ReadDMResponse = ReadDMResponse.Substring(2)
                    Data = Data + ReadDMResponse.Substring(0, 4)
                    ReadDMResponse = ReadDMResponse.Substring(4)

                Next

                ReOrderDataMemoryValue(Data)
                ReadDMValue(ind) = CDbl("&H" & Data).ToString

                ind += 1



            Next

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try





        Return True

    End Function




    Public Function BuildReadDataMemoryCommand(ByRef ReadDMCmd As String, ByVal DataMemoryAddress As Integer, ByVal NumOfWords2Rd As Integer, Optional ByVal MemoryArea As String = "DM") As Boolean


        Dim CommandCode As String
        Dim MemoryAreaCode As String
        Dim BeginningAddress As String
        Dim NumberOfItem As String




        CommandCode = "01" + "01" ' command code to read Data Memory
        'MemoryAreaCode = "82"
        If (SelectMemoryAreaCode(MemoryAreaCode, MemoryArea) = False) Then
            Return False
            Exit Function
        End If

        BeginningAddress = Hex(DataMemoryAddress)
        BeginningAddress = BeginningAddress + "00"

        If (CheckLenghtAndPrefixZero(BeginningAddress, 6) = False) Then
            Return False
            Exit Function
        End If

        NumberOfItem = Hex(NumOfWords2Rd)

        If (CheckLenghtAndPrefixZero(NumberOfItem, 4) = False) Then
            Return False
            Exit Function
        End If



        ReadDMCmd = CommandCode + MemoryAreaCode + BeginningAddress + NumberOfItem

        Return True

    End Function

    Public Function DisassembleReadDataMemoryRespose(ByRef ReadDMValue As UInt64, ByVal ReadDMResponse As String) As Boolean

        Dim CommandCode As String
        Dim EndCode As String
        Dim Data As String
        Dim a As Double

        CommandCode = ReadDMResponse.Substring(0, 4)
        ReadDMResponse = ReadDMResponse.Substring(4)

        EndCode = ReadDMResponse.Substring(0, 4)
        ReadDMResponse = ReadDMResponse.Substring(4)

        Data = ReadDMResponse.Substring(0)

        'Check Command Code
        If (Not (CommandCode = "0101")) Then
            Return False
            Exit Function
        End If


        If (Not (EndCode = "0000")) Then
            Return False
            Exit Function
        End If

        ReOrderDataMemoryValue(Data)

        a = CDbl("&H" & Data)

        ReadDMValue = a
        Return True

    End Function

    Public Function BuildWriteDataMemoryCommand(ByRef WriteDMCmd As String, ByVal DataMemoryAddress As Integer, ByVal NumberOfDataMemory2Write2 As Integer, ByVal Number2Write2DataMemory As UInteger, Optional ByVal MemoryArea As String = "DM") As Boolean


        Dim CommandCode As String
        Dim MemoryAreaCode As String
        Dim BeginningAddress As String
        Dim NumberOfItem As String
        Dim Number2WriteInHex As String



        CommandCode = "01" + "02" ' command code to Write Data Memory
        ' MemoryAreaCode = "82" ' Memory Code Write to Data Memory Word

        If (SelectMemoryAreaCode(MemoryAreaCode, MemoryArea) = False) Then
            Return False
            Exit Function
        End If

        BeginningAddress = Hex(DataMemoryAddress) ' convert the Decimal Data Memory Address to Hex
        BeginningAddress = BeginningAddress + "00" ' Append "00" descrides the bit Position in the Data Memory

        If (CheckLenghtAndPrefixZero(BeginningAddress, 6) = False) Then
            Return False
            Exit Function
        End If



        NumberOfItem = Hex(NumberOfDataMemory2Write2)

        If (CheckLenghtAndPrefixZero(NumberOfItem, 4) = False) Then
            Return False
            Exit Function
        End If


        Number2WriteInHex = Hex(Number2Write2DataMemory)
        'Number2WriteInHex = Hex()

        If (CheckLenghtAndPrefixZero(Number2WriteInHex, (NumberOfDataMemory2Write2 * 4)) = False) Then
            Return False
            Exit Function
        End If

        If (NumberOfDataMemory2Write2 <= 2) Then

            ReOrderDataMemoryValue(Number2WriteInHex)

        End If

        WriteDMCmd = CommandCode + MemoryAreaCode + BeginningAddress + NumberOfItem + Number2WriteInHex

        Return True

    End Function

    Public Function DisassembleWriteDataMemoryResponse(ByVal WriteDMRespose As String) As Boolean


        Dim CommandCode As String
        Dim EndCode As String


        CommandCode = WriteDMRespose.Substring(0, 4)
        WriteDMRespose = WriteDMRespose.Substring(4)

        EndCode = WriteDMRespose.Substring(0, 4)
        WriteDMRespose = WriteDMRespose.Substring(4)


        'Check Command Code
        If (Not (CommandCode = "0102")) Then
            Return False
            Exit Function
        End If


        If (Not (EndCode = "0000")) Then
            Return False
            Exit Function
        End If


        Return True

    End Function

    Public Function BuildReadRelayStateCommand(ByRef ReadRelayCmd As String, ByVal MemoryArea As String, ByVal WordAddress As Integer, ByVal BitAddress As Integer) As Boolean



        Dim CommandCode As String
        Dim MemoryAreaCodeInHex As String
        Dim WordAddessInHex As String
        Dim BitAddressInHex As String
        Dim CompleteAddressInHex As String
        Dim NumberOfItem As String




        CommandCode = "01" + "01" ' command code to read Data Memory

        If (SelectMemoryAreaCode(MemoryAreaCodeInHex, MemoryArea) = False) Then
            Return False
            Exit Function
        End If


        WordAddessInHex = Hex(WordAddress)
        BitAddressInHex = Hex(BitAddress)


        If (CheckLenghtAndPrefixZero(BitAddressInHex, 2) = False) Then
            Return False
            Exit Function
        End If



        CompleteAddressInHex = WordAddessInHex + BitAddressInHex

        If (CheckLenghtAndPrefixZero(CompleteAddressInHex, 6) = False) Then
            Return False
            Exit Function
        End If

        NumberOfItem = Hex(1)

        If (CheckLenghtAndPrefixZero(NumberOfItem, 4) = False) Then
            Return False
            Exit Function
        End If



        ReadRelayCmd = CommandCode + MemoryAreaCodeInHex + CompleteAddressInHex + NumberOfItem

        Return True




    End Function

    Public Function DisassembleReadRelayStateResponse(ByVal ReadRelayResponse As String, ByRef RelayState As Boolean) As Boolean

        Dim CommandCode As String
        Dim EndCode As String
        Dim Data As String
        Dim a As Double

        CommandCode = ReadRelayResponse.Substring(0, 4)
        ReadRelayResponse = ReadRelayResponse.Substring(4)

        EndCode = ReadRelayResponse.Substring(0, 4)
        ReadRelayResponse = ReadRelayResponse.Substring(4)

        Data = ReadRelayResponse.Substring(0)

        'Check Command Code
        If (Not (CommandCode = "0101")) Then
            Return False
            Exit Function
        End If


        If (Not (EndCode = "0000")) Then
            Return False
            Exit Function
        End If

        If (Data = "00") Then
            RelayState = False

        Else
            RelayState = True

        End If

        Return True


    End Function

    Public Function BuildSetOrResetRelayStateCommand(ByRef SetOrResetRelayCmd As String, ByVal MemoryArea As String, ByVal WordAddress As Integer, ByVal BitAddress As Integer, ByVal BitState As Boolean) As Boolean


        Dim CommandCode As String
        Dim MemoryAreaCodeInHex As String
        Dim WordAddessInHex As String
        Dim BitAddressInHex As String
        Dim CompleteAddressInHex As String
        Dim NumberOfItem As String
        Dim BitStateInHex As String

        CommandCode = "01" + "02" ' command code to Write Data Memory

        If (SelectMemoryAreaCode(MemoryAreaCodeInHex, MemoryArea) = False) Then
            Return False
            Exit Function
        End If


        WordAddessInHex = Hex(WordAddress)
        BitAddressInHex = Hex(BitAddress)


        If (CheckLenghtAndPrefixZero(BitAddressInHex, 2) = False) Then
            Return False
            Exit Function
        End If



        CompleteAddressInHex = WordAddessInHex + BitAddressInHex

        If (CheckLenghtAndPrefixZero(CompleteAddressInHex, 6) = False) Then
            Return False
            Exit Function
        End If

        NumberOfItem = Hex(1)

        If (CheckLenghtAndPrefixZero(NumberOfItem, 4) = False) Then
            Return False
            Exit Function
        End If

        If (BitState = True) Then

            BitStateInHex = "01"

        Else

            BitStateInHex = "00"

        End If


        SetOrResetRelayCmd = CommandCode + MemoryAreaCodeInHex + CompleteAddressInHex + NumberOfItem + BitStateInHex

        Return True

    End Function

    Public Function DisassembleSetOrResetRelayResponse(ByVal WriteRelayStateResponse As String) As Boolean

        Dim CommandCode As String
        Dim EndCode As String

        CommandCode = WriteRelayStateResponse.Substring(0, 4)
        WriteRelayStateResponse = WriteRelayStateResponse.Substring(4)

        EndCode = WriteRelayStateResponse.Substring(0, 4)
        WriteRelayStateResponse = WriteRelayStateResponse.Substring(4)

        'Check Command Code
        If (Not (CommandCode = "0102")) Then
            Return False
            Exit Function
        End If


        If (Not (EndCode = "0000")) Then
            Return False
            Exit Function
        End If

        Return True



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

    Private Function SelectMemoryAreaCode(ByRef MemoryAreaHexCode As String, ByVal MemoryArea As String)

        Select Case MemoryArea.ToUpper


            Case "DM"
                MemoryAreaHexCode = "82"
                Return True
                Exit Function

            Case "CIO"

                MemoryAreaHexCode = "30"
                Return True
                Exit Function

            Case "WR"

                MemoryAreaHexCode = "31"
                Return True
                Exit Function

            Case "HR"

                MemoryAreaHexCode = "32"
                Return True
                Exit Function

            Case "AR"

                MemoryAreaHexCode = "33"
                Return True
                Exit Function



        End Select

        Return False

    End Function

    Private Function ReOrderDataMemoryValue(ByRef Value4DataMemory As String)

        Dim OrginalValue As String
        Dim Iternation As Integer

        OrginalValue = Value4DataMemory

        Value4DataMemory = ""

        For Iternation = ((OrginalValue.Length) / 4) To 1 Step -1

            Value4DataMemory = Value4DataMemory + OrginalValue.Substring((OrginalValue.Length - 4), 4)
            OrginalValue = OrginalValue.Remove((OrginalValue.Length - 4), 4)

        Next



        Return True

    End Function

End Class
