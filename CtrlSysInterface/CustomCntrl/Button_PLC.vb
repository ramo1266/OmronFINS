Imports System.ComponentModel

Public Class Button_PLC

    Dim MemoryArea As Integer
    Dim Word As Integer
    Dim Bit As Integer
    Dim Bit1 As Integer



    <Category("PLC")>
    Property MemoryArea_Code() As Integer
        Get
            Return MemoryArea

        End Get
        Set(ByVal value As Integer)
            MemoryArea = value
        End Set
    End Property

    <Category("PLC")>
    Property Word_Address() As Integer
        Get
            Return Word

        End Get
        Set(ByVal value As Integer)
            Word = value
        End Set
    End Property
    <Category("PLC")>
    Property Bit_Address() As Integer
        Get
            Return Bit

        End Get
        Set(ByVal value As Integer)
            Bit = value
        End Set
    End Property

    <Category("PLC")>
    Property Bit1_Address() As Integer
        Get
            Return Bit1

        End Get
        Set(ByVal value As Integer)
            Bit1 = value
        End Set
    End Property

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
