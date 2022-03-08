<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RecipeMenuBar
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
        Me.RecipeRemove_Button = New System.Windows.Forms.Button()
        Me.Done_Button = New System.Windows.Forms.Button()
        Me.RecipeAdd_Button = New System.Windows.Forms.Button()
        Me.RecipeModify_Button = New System.Windows.Forms.Button()
        Me.RecipeTransfer_Button = New System.Windows.Forms.Button()
        Me.RecipeCopy_Button = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'RecipeRemove_Button
        '
        Me.RecipeRemove_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!)
        Me.RecipeRemove_Button.Location = New System.Drawing.Point(146, 0)
        Me.RecipeRemove_Button.Name = "RecipeRemove_Button"
        Me.RecipeRemove_Button.Size = New System.Drawing.Size(140, 61)
        Me.RecipeRemove_Button.TabIndex = 5
        Me.RecipeRemove_Button.Text = "Remove"
        Me.RecipeRemove_Button.UseVisualStyleBackColor = True
        '
        'Done_Button
        '
        Me.Done_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!)
        Me.Done_Button.Location = New System.Drawing.Point(878, 0)
        Me.Done_Button.Name = "Done_Button"
        Me.Done_Button.Size = New System.Drawing.Size(140, 61)
        Me.Done_Button.TabIndex = 4
        Me.Done_Button.Text = "Done"
        Me.Done_Button.UseVisualStyleBackColor = True
        '
        'RecipeAdd_Button
        '
        Me.RecipeAdd_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!)
        Me.RecipeAdd_Button.Location = New System.Drawing.Point(0, 0)
        Me.RecipeAdd_Button.Name = "RecipeAdd_Button"
        Me.RecipeAdd_Button.Size = New System.Drawing.Size(140, 61)
        Me.RecipeAdd_Button.TabIndex = 3
        Me.RecipeAdd_Button.Text = "Add"
        Me.RecipeAdd_Button.UseVisualStyleBackColor = True
        '
        'RecipeModify_Button
        '
        Me.RecipeModify_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!)
        Me.RecipeModify_Button.Location = New System.Drawing.Point(438, 0)
        Me.RecipeModify_Button.Name = "RecipeModify_Button"
        Me.RecipeModify_Button.Size = New System.Drawing.Size(140, 61)
        Me.RecipeModify_Button.TabIndex = 6
        Me.RecipeModify_Button.Text = "Save"
        Me.RecipeModify_Button.UseVisualStyleBackColor = True
        '
        'RecipeTransfer_Button
        '
        Me.RecipeTransfer_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!)
        Me.RecipeTransfer_Button.Location = New System.Drawing.Point(584, 0)
        Me.RecipeTransfer_Button.Name = "RecipeTransfer_Button"
        Me.RecipeTransfer_Button.Size = New System.Drawing.Size(180, 61)
        Me.RecipeTransfer_Button.TabIndex = 7
        Me.RecipeTransfer_Button.Text = "Push to PLC"
        Me.RecipeTransfer_Button.UseVisualStyleBackColor = True
        '
        'RecipeCopy_Button
        '
        Me.RecipeCopy_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!)
        Me.RecipeCopy_Button.Location = New System.Drawing.Point(292, 0)
        Me.RecipeCopy_Button.Name = "RecipeCopy_Button"
        Me.RecipeCopy_Button.Size = New System.Drawing.Size(140, 61)
        Me.RecipeCopy_Button.TabIndex = 8
        Me.RecipeCopy_Button.Text = "Copy"
        Me.RecipeCopy_Button.UseVisualStyleBackColor = True
        '
        'RecipeMenuBar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 61)
        Me.Controls.Add(Me.RecipeCopy_Button)
        Me.Controls.Add(Me.RecipeTransfer_Button)
        Me.Controls.Add(Me.RecipeModify_Button)
        Me.Controls.Add(Me.RecipeRemove_Button)
        Me.Controls.Add(Me.Done_Button)
        Me.Controls.Add(Me.RecipeAdd_Button)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "RecipeMenuBar"
        Me.Text = "RecipeMenuBar"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RecipeRemove_Button As System.Windows.Forms.Button
    Friend WithEvents Done_Button As System.Windows.Forms.Button
    Friend WithEvents RecipeAdd_Button As System.Windows.Forms.Button
    Friend WithEvents RecipeModify_Button As System.Windows.Forms.Button
    Friend WithEvents RecipeTransfer_Button As System.Windows.Forms.Button
    Friend WithEvents RecipeCopy_Button As System.Windows.Forms.Button
End Class
