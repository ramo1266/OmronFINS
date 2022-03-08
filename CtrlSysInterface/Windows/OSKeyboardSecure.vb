Public Class OSKeyboardSecure

    Private IsDone As Boolean
    Private shift_locked As Boolean
    Private Sub OSKeyboard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ShiftOff()

    End Sub

    Public Sub New(ByVal LabelName As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        TextBox.Clear()
        SelectedTextName_Label.Text = LabelName

    End Sub

    Protected Overrides Sub Finalize()



        MyBase.Finalize()
    End Sub




    Private Sub Button0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button0.Click
        Send_Key_To_Control(Button0.Text)

    End Sub

    Private Sub Send_Key_To_Control(ByVal k As String)


        Try

            Select Case k
                Case "{BACKSPACE}"
                    TextBox.Text = TextBox.Text.Remove(TextBox.Text.Length - 1, 1)

                Case "{TAB}"
                    TextBox.Text = TextBox.Text + "     "

                Case Else
                    TextBox.Text += k               'send keystroke
            End Select


        Catch ex As Exception

        End Try

    End Sub


    Private Sub ButtonEnter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEnter.Click

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()


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

    Private Sub ButtonA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonA.Click
        Send_Key_To_Control(ButtonA.Text)

    End Sub

    Private Sub ButtonB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonB.Click
        Send_Key_To_Control(ButtonB.Text)

    End Sub

    Private Sub ButtonC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonC.Click
        Send_Key_To_Control(ButtonC.Text)

    End Sub

    Private Sub ButtonD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonD.Click
        Send_Key_To_Control(ButtonD.Text)

    End Sub

    Private Sub ButtonE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonE.Click
        Send_Key_To_Control(ButtonE.Text)

    End Sub

    Private Sub ButtonF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonF.Click
        Send_Key_To_Control(ButtonF.Text)

    End Sub

    Private Sub ButtonG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonG.Click
        Send_Key_To_Control(ButtonG.Text)

    End Sub

    Private Sub ButtonH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonH.Click
        Send_Key_To_Control(ButtonH.Text)

    End Sub

    Private Sub ButtonI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonI.Click
        Send_Key_To_Control(ButtonI.Text)

    End Sub

    Private Sub ButtonJ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonJ.Click
        Send_Key_To_Control(ButtonJ.Text)

    End Sub

    Private Sub ButtonK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonK.Click
        Send_Key_To_Control(ButtonK.Text)

    End Sub

    Private Sub ButtonL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonL.Click
        Send_Key_To_Control(ButtonL.Text)

    End Sub

    Private Sub ButtonM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonM.Click
        Send_Key_To_Control(ButtonM.Text)

    End Sub

    Private Sub ButtonN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonN.Click
        Send_Key_To_Control(ButtonN.Text)

    End Sub

    Private Sub ButtonO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonO.Click
        Send_Key_To_Control(ButtonO.Text)

    End Sub

    Private Sub ButtonP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonP.Click
        Send_Key_To_Control(ButtonP.Text)

    End Sub

    Private Sub ButtonQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonQ.Click
        Send_Key_To_Control(ButtonQ.Text)

    End Sub

    Private Sub ButtonR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonR.Click
        Send_Key_To_Control(ButtonR.Text)

    End Sub

    Private Sub ButtonS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonS.Click
        Send_Key_To_Control(ButtonS.Text)

    End Sub

    Private Sub ButtonT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonT.Click
        Send_Key_To_Control(ButtonT.Text)

    End Sub

    Private Sub ButtonU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonU.Click
        Send_Key_To_Control(ButtonU.Text)

    End Sub

    Private Sub ButtonV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonV.Click
        Send_Key_To_Control(ButtonV.Text)

    End Sub

    Private Sub ButtonW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonW.Click
        Send_Key_To_Control(ButtonW.Text)

    End Sub

    Private Sub ButtonX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX.Click
        Send_Key_To_Control(ButtonX.Text)

    End Sub

    Private Sub ButtonY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonY.Click
        Send_Key_To_Control(ButtonY.Text)

    End Sub

    Private Sub ButtonZ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonZ.Click
        Send_Key_To_Control(ButtonZ.Text)

    End Sub

    Private Sub ButtonBackspace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBackspace.Click
        Send_Key_To_Control("{BACKSPACE}")

    End Sub


    Private Sub ButtonShift_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonShift.Click
        If Not shift_locked Then
            '--- Set shift on
            ShiftOn()
        Else
            '--- Set shift off
            ShiftOff()
        End If


    End Sub
    Private Sub ShiftOn()
        '--- Show shift on (upper case)
        shift_locked = True                 'set keyboard shift locked
        ButtonShift.ForeColor = Color.LightSkyBlue   'show shift key Red when locked
        '--- Set button text for shift on
        ButtonA.Text = "A"
        ButtonB.Text = "B"
        ButtonC.Text = "C"
        ButtonD.Text = "D"
        ButtonE.Text = "E"
        ButtonF.Text = "F"
        ButtonG.Text = "G"
        ButtonH.Text = "H"
        ButtonI.Text = "I"
        ButtonJ.Text = "J"
        ButtonK.Text = "K"
        ButtonL.Text = "L"
        ButtonM.Text = "M"
        ButtonN.Text = "N"
        ButtonO.Text = "O"
        ButtonP.Text = "P"
        ButtonQ.Text = "Q"
        ButtonR.Text = "R"
        ButtonS.Text = "S"
        ButtonT.Text = "T"
        ButtonU.Text = "U"
        ButtonV.Text = "V"
        ButtonW.Text = "W"
        ButtonX.Text = "X"
        ButtonY.Text = "Y"
        ButtonZ.Text = "Z"
        '--- Set number keys
        Button0.Text = ")"
        Button1.Text = "!"
        Button2.Text = "@"
        Button3.Text = "#"
        Button4.Text = "$"
        Button5.Text = "%"
        Button6.Text = "^"
        Button7.Text = "&&"
        Button8.Text = "*"
        Button9.Text = "("
        '--- Set special chars keys
        ButtonAccent.Text = "~"
        ButtonDash.Text = "_"
        ButtonEquals.Text = "+"
        ButtonLeftBracket.Text = "{"
        ButtonRightBracket.Text = "}"
        ButtonBackslash.Text = "|"
        ButtonSemicolon.Text = ":"
        ButtonApostrophe.Text = Chr(34) 'double quote
        ButtonComma.Text = "<"
        ButtonPeriod.Text = ">"
        ButtonSlash.Text = "?"

    End Sub
    Private Sub ShiftOff()
        '--- Show shift off (lower case)
        shift_locked = False  'set shift off
        ButtonShift.ForeColor = Color.Black
        '--- Set button text for shift on
        ButtonA.Text = "a"
        ButtonB.Text = "b"
        ButtonC.Text = "c"
        ButtonD.Text = "d"
        ButtonE.Text = "e"
        ButtonF.Text = "f"
        ButtonG.Text = "g"
        ButtonH.Text = "h"
        ButtonI.Text = "i"
        ButtonJ.Text = "j"
        ButtonK.Text = "k"
        ButtonL.Text = "l"
        ButtonM.Text = "m"
        ButtonN.Text = "n"
        ButtonO.Text = "o"
        ButtonP.Text = "p"
        ButtonQ.Text = "q"
        ButtonR.Text = "r"
        ButtonS.Text = "s"
        ButtonT.Text = "t"
        ButtonU.Text = "u"
        ButtonV.Text = "v"
        ButtonW.Text = "w"
        ButtonX.Text = "x"
        ButtonY.Text = "y"
        ButtonZ.Text = "z"
        '--- Set number keys
        Button0.Text = "0"
        Button1.Text = "1"
        Button2.Text = "2"
        Button3.Text = "3"
        Button4.Text = "4"
        Button5.Text = "5"
        Button6.Text = "6"
        Button7.Text = "7"
        Button8.Text = "8"
        Button9.Text = "9"
        '--- Set special chars keys
        ButtonAccent.Text = "`"
        ButtonDash.Text = "-"
        ButtonEquals.Text = "="
        ButtonLeftBracket.Text = "["
        ButtonRightBracket.Text = "]"
        ButtonBackslash.Text = "\"
        ButtonSemicolon.Text = ";"
        ButtonApostrophe.Text = "'"
        ButtonComma.Text = ","
        ButtonPeriod.Text = "."
        ButtonSlash.Text = "/"

    End Sub

    Private Sub ButtonDash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDash.Click
        Send_Key_To_Control(ButtonDash.Text)

    End Sub

    Private Sub ButtonEquals_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEquals.Click
        Send_Key_To_Control(ButtonEquals.Text)

    End Sub

    Private Sub ButtonAccent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAccent.Click
        Send_Key_To_Control(ButtonAccent.Text)

    End Sub

    Private Sub ButtonLeftBracket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonLeftBracket.Click
        Send_Key_To_Control(ButtonLeftBracket.Text)

    End Sub

    Private Sub ButtonRightBracket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRightBracket.Click
        Send_Key_To_Control(ButtonRightBracket.Text)

    End Sub

    Private Sub ButtonBackslash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBackslash.Click
        Send_Key_To_Control(ButtonBackslash.Text)

    End Sub

    Private Sub ButtonSemicolon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSemicolon.Click
        Send_Key_To_Control(ButtonSemicolon.Text)

    End Sub

    Private Sub ButtonApostrophe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonApostrophe.Click
        Send_Key_To_Control(ButtonApostrophe.Text)

    End Sub

    Private Sub ButtonComma_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonComma.Click
        Send_Key_To_Control(ButtonComma.Text)

    End Sub

    Private Sub ButtonPeriod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPeriod.Click
        Send_Key_To_Control(ButtonPeriod.Text)

    End Sub

    Private Sub ButtonSlash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSlash.Click
        Send_Key_To_Control(ButtonSlash.Text)

    End Sub

    Private Sub ButtonTab_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTab.Click

        Send_Key_To_Control("{TAB}")

    End Sub

    Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub ButtonSpace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSpace.Click
        Send_Key_To_Control(" ")
    End Sub
    Private Sub TextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox.KeyPress
        If (e.KeyChar = vbCr) Then
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()

        End If
    End Sub
End Class