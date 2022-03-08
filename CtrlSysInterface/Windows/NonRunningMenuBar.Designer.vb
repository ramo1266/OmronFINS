<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class NonRunningMenuBar
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.LogOff_Button = New System.Windows.Forms.Button()
        Me.Machine_Button = New System.Windows.Forms.Button()
        Me.IOControl_Button = New System.Windows.Forms.Button()
        Me.Recipe_Button = New System.Windows.Forms.Button()
        Me.Users_Button = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'LogOff_Button
        '
        Me.LogOff_Button.BackColor = System.Drawing.Color.Transparent
        Me.LogOff_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!)
        Me.LogOff_Button.Location = New System.Drawing.Point(876, 0)
        Me.LogOff_Button.Name = "LogOff_Button"
        Me.LogOff_Button.Size = New System.Drawing.Size(140, 61)
        Me.LogOff_Button.TabIndex = 3
        Me.LogOff_Button.Text = "LogOff"
        Me.LogOff_Button.UseVisualStyleBackColor = False
        '
        'Machine_Button
        '
        Me.Machine_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!)
        Me.Machine_Button.Location = New System.Drawing.Point(372, -2)
        Me.Machine_Button.Name = "Machine_Button"
        Me.Machine_Button.Size = New System.Drawing.Size(173, 61)
        Me.Machine_Button.TabIndex = 2
        Me.Machine_Button.Text = "Machine"
        Me.Machine_Button.UseCompatibleTextRendering = True
        Me.Machine_Button.UseVisualStyleBackColor = True
        '
        'IOControl_Button
        '
        Me.IOControl_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IOControl_Button.Location = New System.Drawing.Point(1, 0)
        Me.IOControl_Button.Name = "IOControl_Button"
        Me.IOControl_Button.Size = New System.Drawing.Size(140, 61)
        Me.IOControl_Button.TabIndex = 4
        Me.IOControl_Button.Text = "IO Control"
        Me.IOControl_Button.UseVisualStyleBackColor = True
        '
        'Recipe_Button
        '
        Me.Recipe_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Recipe_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!)
        Me.Recipe_Button.Location = New System.Drawing.Point(188, 0)
        Me.Recipe_Button.Name = "Recipe_Button"
        Me.Recipe_Button.Size = New System.Drawing.Size(149, 61)
        Me.Recipe_Button.TabIndex = 5
        Me.Recipe_Button.Text = "Recipe"
        Me.Recipe_Button.UseCompatibleTextRendering = True
        Me.Recipe_Button.UseVisualStyleBackColor = True
        '
        'Users_Button
        '
        Me.Users_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!)
        Me.Users_Button.Location = New System.Drawing.Point(723, 0)
        Me.Users_Button.Name = "Users_Button"
        Me.Users_Button.Size = New System.Drawing.Size(147, 61)
        Me.Users_Button.TabIndex = 7
        Me.Users_Button.Text = "Users"
        Me.Users_Button.UseCompatibleTextRendering = True
        Me.Users_Button.UseVisualStyleBackColor = True
        '
        'NonRunningMenuBar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1018, 61)
        Me.Controls.Add(Me.Users_Button)
        Me.Controls.Add(Me.Recipe_Button)
        Me.Controls.Add(Me.IOControl_Button)
        Me.Controls.Add(Me.LogOff_Button)
        Me.Controls.Add(Me.Machine_Button)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "NonRunningMenuBar"
        Me.Opacity = 0R
        Me.Text = "NonRunningMenuBar"
        Me.TransparencyKey = System.Drawing.Color.Transparent
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LogOff_Button As Button
    Friend WithEvents Machine_Button As Button
    Friend WithEvents IOControl_Button As Button
    Friend WithEvents Recipe_Button As Button
    Friend WithEvents Users_Button As Button
End Class
