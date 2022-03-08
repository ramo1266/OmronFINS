


Imports System.ComponentModel

Public Class Label_PLC


    Dim DataMemory_Address As Integer
    Dim DataMemory_Type As String
    <Category("PLC")>
    Property DM_Address() As Integer
        Get
            Return DataMemory_Address

        End Get
        Set(ByVal value As Integer)
            DataMemory_Address = value
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
