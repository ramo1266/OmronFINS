<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class About
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.CntrlOn_Button = New System.Windows.Forms.Button()
        Me.CntrlOff_Button = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(121, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(454, 37)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Testing Version for Ethernet "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(45, 81)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(213, 37)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "HMI Version:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(356, 81)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(176, 37)
        Me.Label14.TabIndex = 13
        Me.Label14.Text = "0.1 alpha4"
        '
        'CntrlOn_Button
        '
        Me.CntrlOn_Button.Location = New System.Drawing.Point(52, 614)
        Me.CntrlOn_Button.Name = "CntrlOn_Button"
        Me.CntrlOn_Button.Size = New System.Drawing.Size(179, 49)
        Me.CntrlOn_Button.TabIndex = 20
        Me.CntrlOn_Button.Text = "Cntrl On"
        Me.CntrlOn_Button.UseVisualStyleBackColor = True
        '
        'CntrlOff_Button
        '
        Me.CntrlOff_Button.Location = New System.Drawing.Point(250, 614)
        Me.CntrlOff_Button.Name = "CntrlOff_Button"
        Me.CntrlOff_Button.Size = New System.Drawing.Size(179, 49)
        Me.CntrlOff_Button.TabIndex = 21
        Me.CntrlOff_Button.Text = "Cntrl Off"
        Me.CntrlOff_Button.UseVisualStyleBackColor = True
        '
        'About
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(947, 696)
        Me.Controls.Add(Me.CntrlOff_Button)
        Me.Controls.Add(Me.CntrlOn_Button)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "About"
        Me.Text = "About"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents CntrlOn_Button As Button
    Friend WithEvents CntrlOff_Button As Button
End Class
