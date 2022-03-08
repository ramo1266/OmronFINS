

Imports System
Imports System.Threading
Imports System.IO
Imports System.IO.Ports
Imports System.Text
Imports Microsoft.VisualBasic


Public Class SerialPort4Omron

    Private RS232 As SerialPort
    Private Const MAXRETRY As Integer = 2

    
    Private Property Parity As Parity

    '************************************************************
    ' this is the destructor
    '***************************************************************

    Protected Overrides Sub Finalize()

        RS232 = Nothing
        MyBase.Finalize()

    End Sub

    '***************************************************************
    ' this is the constructor
    '***************************************************************

    Public Sub New(ByRef PortName As String)

        RS232 = New SerialPort()

        RS232.PortName = PortName
        RS232.Parity = IO.Ports.Parity.None
        RS232.BaudRate = 9600
        RS232.StopBits = IO.Ports.StopBits.One
        RS232.DataBits = 8
        RS232.Handshake = IO.Ports.Handshake.None

        RS232.RtsEnable = False
        RS232.DtrEnable = False

        RS232.WriteBufferSize = 10000
        RS232.ReadBufferSize = 10000

        RS232.WriteTimeout = 500
        RS232.ReadTimeout = 500


    End Sub

    '***************************************************************
    ' these sets of SUB set the different values for the serial port communication
    '***************************************************************

    Public Sub SetBAUDRate(ByVal BAUD As Integer)
        RS232.BaudRate = BAUD
    End Sub
    Public Sub SetStopBits(ByVal StopBits As Integer)
        RS232.StopBits = StopBits
    End Sub
    Public Sub SetDataBits(ByVal DataBits As Integer)
        RS232.DataBits = DataBits
    End Sub
    Public Sub SetCommPort(ByVal CommPort As String)
        RS232.PortName() = CommPort
    End Sub
    Public Sub SetParity(ByVal Parity As Integer)
        RS232.Parity = Parity
    End Sub
    Public Sub SetFlowControl(ByVal Flowcontrol As Integer)
        RS232.Handshake = IO.Ports.Handshake.None
    End Sub


    '***************************************************************
    ' these sets of SUB get the different values for the serial port communication
    '***************************************************************

    Public Function GetBAUDRate() As String
        Return RS232.BaudRate
    End Function
    Public Function GetStopBits() As String
        Return RS232.StopBits

    End Function
    Public Function GetDataBits() As String
        Return RS232.DataBits
    End Function
    Public Function GetCommPort() As String
        Return RS232.PortName
    End Function
    Public Function GetParity() As String

        If (RS232.Parity = Parity.Even) Then
            Return "Even"
        End If

        If (RS232.Parity = Parity.Mark) Then
            Return "Mark"
        End If

        If (RS232.Parity = Parity.Odd) Then
            Return "Odd"
        End If

        If (RS232.Parity = Parity.None) Then
            Return "None"
        End If

        If (RS232.Parity = Parity.Even) Then
            Return "Even"
        End If

        Return "-1"

    End Function
    Public Function GetFlowControl() As String

        If (RS232.Handshake = Handshake.None) Then
            Return "None"
        End If

        If (RS232.Handshake = Handshake.RequestToSend) Then
            Return "RTS"
        End If

        If (RS232.Handshake = Handshake.RequestToSendXOnXOff) Then
            Return "RTS/XOn/XOff"
        End If

        If (RS232.Handshake = Handshake.XOnXOff) Then
            Return "XOn/XOff"
        End If

        Return "-1"


    End Function


    '***************************************************************
    ' these fuction are GENREAL for serial communication
    ' NOTE: ALL OF THESE FUNCTION RETURN A true IF IT WAS SUCCESSFUL
    '        OR A false IF THE FUNCTION FAILED.
    '***************************************************************
    Public Function IsCommPortOpen()
        Return RS232.IsOpen

    End Function

    Public Function OpenComm() As Boolean

        ' Dim IsCommOpen As Boolean = True

        While Not (RS232.IsOpen)

            Try
                ' CloseComm()
                RS232.Open()
                '  IsCommOpen = False


            Catch PortIsOpen As UnauthorizedAccessException

                Return False
            Catch PortIsOpen As InvalidOperationException
                Return False
            Catch BadSetting As ArgumentOutOfRangeException
                Return False
            Catch BadPortName As ArgumentException
                Return False
            Catch InvalidState As IOException
                Return False
            End Try

        End While

        RS232.DiscardInBuffer()
        RS232.DiscardOutBuffer()



        Return True

    End Function

    Public Function CloseComm() As Boolean
        Dim IsPortClosed As Boolean = True

        While (RS232.IsOpen)

            Try

                RS232.Close()


            Catch PortNotOpen As InvalidOperationException

                Return False

            End Try


        End While

        Return True

    End Function

    Public Function SendPacket(ByVal Packet2Send As String) As Boolean

        Dim PacketSent As Boolean = True




        While PacketSent
            Try
                RS232.DiscardInBuffer()
                RS232.DiscardOutBuffer()


                RS232.Write(Packet2Send)
                PacketSent = False

            Catch PortNotOpen As InvalidOperationException
                Return False
            Catch NothingToSend As ArgumentNullException
                Return False
            Catch TransmissionTimeout As TimeoutException
                Return False
            End Try

        End While

        Return True 'if packet is sent return 0

    End Function


    Public Function Get2EndChar(ByRef CompleteStringfromBuffer As String, ByVal EndCode As String)



        Try
            RS232.NewLine = EndCode
            CompleteStringfromBuffer = RS232.ReadLine()
            CompleteStringfromBuffer = CompleteStringfromBuffer + EndCode

        Catch OperationTimeout As TimeoutException
            Return False

        Catch InvalidOperationException As InvalidOperationException
            Return False

        End Try

        Return True


    End Function
End Class
