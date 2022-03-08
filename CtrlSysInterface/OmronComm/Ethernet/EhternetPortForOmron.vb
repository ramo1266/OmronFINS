Imports System.Net.Sockets




Public Class EhternetPortForOmron

    Private UDPClient As New UdpClient()
    Private IPAddress As String
    Private PortAddress As Integer
    Private RemoteIPInfo As System.Net.IPEndPoint


    Public Sub New(ByRef IpAdress As String, ByRef PortAddress As Integer)
        Try

            UDPClient.Client.ReceiveTimeout = 2000
            UDPClient.Client.SendTimeout = 2000


            RemoteIPInfo = New System.Net.IPEndPoint(System.Net.IPAddress.Parse(IpAdress), PortAddress)


        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Sub

    Public Sub Connect()
        Try

            UDPClient.Connect(RemoteIPInfo)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Sub

    Public Sub Disconnect()
        Try
            UDPClient.Close()
        Catch ex As Exception

        End Try

    End Sub

    Public Sub SendPacket(ByRef Data2Send() As Byte)


        Try
            UDPClient.Send(Data2Send, (Data2Send.Length))
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Sub


    Public Sub RecievePacket(ByRef Data2Recieve() As Byte)
        Try
            Data2Recieve = UDPClient.Receive(RemoteIPInfo)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub







End Class
