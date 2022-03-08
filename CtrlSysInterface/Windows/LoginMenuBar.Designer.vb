<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoginMenuBar
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
        Me.Login_Button = New System.Windows.Forms.Button()
        Me.Exit_Button = New System.Windows.Forms.Button()
        Me.About_Button = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Login_Button
        '
        Me.Login_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!)
        Me.Login_Button.Location = New System.Drawing.Point(0, 0)
        Me.Login_Button.Name = "Login_Button"
        Me.Login_Button.Size = New System.Drawing.Size(140, 61)
        Me.Login_Button.TabIndex = 0
        Me.Login_Button.Text = "LogIn"
        Me.Login_Button.UseVisualStyleBackColor = True
        '
        'Exit_Button
        '
        Me.Exit_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Exit_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!)
        Me.Exit_Button.Location = New System.Drawing.Point(878, 0)
        Me.Exit_Button.Name = "Exit_Button"
        Me.Exit_Button.Size = New System.Drawing.Size(140, 61)
        Me.Exit_Button.TabIndex = 1
        Me.Exit_Button.Text = "Exit"
        Me.Exit_Button.UseVisualStyleBackColor = True
        '
        'About_Button
        '
        Me.About_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!)
        Me.About_Button.Location = New System.Drawing.Point(411, 0)
        Me.About_Button.Name = "About_Button"
        Me.About_Button.Size = New System.Drawing.Size(140, 61)
        Me.About_Button.TabIndex = 2
        Me.About_Button.Text = "About"
        Me.About_Button.UseVisualStyleBackColor = True
        '
        'LoginMenuBar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 61)
        Me.Controls.Add(Me.About_Button)
        Me.Controls.Add(Me.Exit_Button)
        Me.Controls.Add(Me.Login_Button)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "LoginMenuBar"
        Me.Text = "LoginMenuBar"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Login_Button As Button
    Friend WithEvents Exit_Button As Button
    Friend WithEvents About_Button As System.Windows.Forms.Button
End Class
