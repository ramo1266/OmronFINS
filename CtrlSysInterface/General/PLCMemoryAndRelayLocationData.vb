Public Module PLCMemoryAndRelayLocationData


    'Inputs

    Public Contact As RelayInfo

    'Data Memory


    Public PLCVersion As DMInfo





    Public Structure DMInfo
        Public DMAddress As Integer
        Public NumberOfWords As Integer
        Public WindowsNames As String
        Public DecimalPlace As Integer
        Public LowerLimit As Object
        Public UpperLimit As Object
        Public SignNumber As Boolean

    End Structure

    Public Structure RelayInfo
        Public MemoryArea As String
        Public WordAddress As Integer
        Public BitAddress As Integer
    End Structure


    Public Function InitializeRelay()



        Contact.MemoryArea = "WR"
        Contact.WordAddress = 95
        Contact.BitAddress = 2

        Return True


    End Function


    Public Function InitializeDataMemory()



        PLCVersion.DMAddress = 20
        PLCVersion.NumberOfWords = 1
        PLCVersion.WindowsNames = "PLC Version"
        PLCVersion.DecimalPlace = 1
        PLCVersion.LowerLimit = 0
        PLCVersion.UpperLimit = 999999.999




        Return True




    End Function



End Module
