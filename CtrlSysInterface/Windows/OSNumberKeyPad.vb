Public Class OSNumberKeyPad

    Dim label As String

    Public Overloads Function ShowDialog(ByVal labelName As String) As String


        MyBase.ShowDialog()
        Return TextBox.Text



    End Function

    Public Sub New(ByVal LabelName As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        TextBox.Clear()
        Label1.Text = LabelName

    End Sub


    Private Sub Send_Key_To_Control(ByVal k As String)


        TextBox.Text += k


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Send_Key_To_Control(Button1.Text)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Send_Key_To_Control(Button2.Text)

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Send_Key_To_Control(Button3.Text)

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Send_Key_To_Control(Button4.Text)

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Send_Key_To_Control(Button5.Text)

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Send_Key_To_Control(Button6.Text)

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Send_Key_To_Control(Button7.Text)

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Send_Key_To_Control(Button8.Text)

    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Send_Key_To_Control(Button9.Text)

    End Sub


    Private Sub ButtonPeriod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPeriod.Click
        Send_Key_To_Control(ButtonPeriod.Text)

    End Sub

    Private Sub OSNumberKeyPad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button0.Click
        Send_Key_To_Control(Button0.Text)
    End Sub






    Private Sub ButtonEnter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEnter.Click

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()


    End Sub

    Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub ButtonDash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDash.Click

        If (TextBox.Text = Nothing) Then

            TextBox.Text = "-"
        Else

            If Not (TextBox.Text.Chars(0) = "-") Then

                Dim temp As String

                temp = TextBox.Text
                TextBox.Text = ""
                TextBox.Text = "-" + temp

            Else

                TextBox.Text = TextBox.Text.Remove(0, 1)


            End If

        End If



    End Sub
    Private Sub TextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox.KeyPress
        If (e.KeyChar = vbCr) Then
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()

        End If
    End Sub
End Class