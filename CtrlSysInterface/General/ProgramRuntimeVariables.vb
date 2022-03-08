Module ProgramRuntimeVariables

    Public Structure RuntimeVariable
        Public WindowsNames As String
        Public DecimalPlace As Integer
        Public LowerLimit As Object
        Public UpperLimit As Object
        Public Data As Object
        Public SignedNumber As Boolean
    End Structure



    Public Function InitializeRuntimeVariables()


        Return True

    End Function


End Module
