<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RunningMenuBar
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ExitRunScreen_Button = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'ExitRunScreen_Button
        '
        Me.ExitRunScreen_Button.BackColor = System.Drawing.SystemColors.Control
        Me.ExitRunScreen_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!)
        Me.ExitRunScreen_Button.Location = New System.Drawing.Point(720, 0)
        Me.ExitRunScreen_Button.Name = "ExitRunScreen_Button"
        Me.ExitRunScreen_Button.Size = New System.Drawing.Size(133, 61)
        Me.ExitRunScreen_Button.TabIndex = 14
        Me.ExitRunScreen_Button.Text = "Exit"
        Me.ExitRunScreen_Button.UseVisualStyleBackColor = False
        '
        'RunningMenuBar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 61)
        Me.Controls.Add(Me.ExitRunScreen_Button)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "RunningMenuBar"
        Me.Text = "RunningMenuBar"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ExitRunScreen_Button As Button
    Friend WithEvents Timer1 As Timer
End Class
