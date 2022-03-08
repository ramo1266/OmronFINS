<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MachineSetting
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
        Me.LayoutForPanels = New System.Windows.Forms.TableLayoutPanel()
        Me.Title_Panel = New System.Windows.Forms.Panel()
        Me.Title_Label = New System.Windows.Forms.Label()
        Me.Main_Panel = New System.Windows.Forms.Panel()
        Me.LayoutForPanels.SuspendLayout()
        Me.Title_Panel.SuspendLayout()
        Me.SuspendLayout()
        '
        'LayoutForPanels
        '
        Me.LayoutForPanels.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LayoutForPanels.AutoSize = True
        Me.LayoutForPanels.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.LayoutForPanels.BackColor = System.Drawing.Color.Transparent
        Me.LayoutForPanels.ColumnCount = 1
        Me.LayoutForPanels.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.LayoutForPanels.Controls.Add(Me.Title_Panel, 0, 0)
        Me.LayoutForPanels.Controls.Add(Me.Main_Panel, 0, 1)
        Me.LayoutForPanels.Location = New System.Drawing.Point(0, 0)
        Me.LayoutForPanels.Name = "LayoutForPanels"
        Me.LayoutForPanels.RowCount = 2
        Me.LayoutForPanels.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 59.0!))
        Me.LayoutForPanels.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.LayoutForPanels.Size = New System.Drawing.Size(1018, 677)
        Me.LayoutForPanels.TabIndex = 4
        '
        'Title_Panel
        '
        Me.Title_Panel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Title_Panel.AutoSize = True
        Me.Title_Panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Title_Panel.Controls.Add(Me.Title_Label)
        Me.Title_Panel.Location = New System.Drawing.Point(3, 3)
        Me.Title_Panel.Name = "Title_Panel"
        Me.Title_Panel.Size = New System.Drawing.Size(1012, 53)
        Me.Title_Panel.TabIndex = 3
        '
        'Title_Label
        '
        Me.Title_Label.AutoSize = True
        Me.Title_Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Title_Label.Location = New System.Drawing.Point(315, 6)
        Me.Title_Label.Name = "Title_Label"
        Me.Title_Label.Size = New System.Drawing.Size(305, 42)
        Me.Title_Label.TabIndex = 0
        Me.Title_Label.Text = "Machine Settings"
        Me.Title_Label.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Main_Panel
        '
        Me.Main_Panel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Main_Panel.AutoSize = True
        Me.Main_Panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Main_Panel.Location = New System.Drawing.Point(3, 62)
        Me.Main_Panel.Name = "Main_Panel"
        Me.Main_Panel.Size = New System.Drawing.Size(1012, 612)
        Me.Main_Panel.TabIndex = 4
        '
        'MachineSetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 677)
        Me.Controls.Add(Me.LayoutForPanels)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "MachineSetting"
        Me.Text = "MachineSetting"
        Me.LayoutForPanels.ResumeLayout(False)
        Me.LayoutForPanels.PerformLayout()
        Me.Title_Panel.ResumeLayout(False)
        Me.Title_Panel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LayoutForPanels As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Title_Panel As System.Windows.Forms.Panel
    Friend WithEvents Title_Label As System.Windows.Forms.Label
    Friend WithEvents Main_Panel As Panel
End Class
