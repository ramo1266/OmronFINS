Imports System.ComponentModel

Public Class TextBox_PLC
    ' Inherits System.Windows.Forms.UserControl
    Implements System.ComponentModel.IComponent

    Dim DataMemory_Address As Integer
    Dim DataMemory_Type As String


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    <Category("PLC")>
    Property DM_Address() As Integer
        Get
            Return DataMemory_Address

        End Get
        Set(ByVal value As Integer)
            DataMemory_Address = value
        End Set
    End Property


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
