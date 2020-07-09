<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class InterfaceWindow
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
      Me.SuspendLayout()
      '
      'InterfaceWindow
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.Color.Black
      Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
      Me.ClientSize = New System.Drawing.Size(423, 395)
      Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.KeyPreview = True
      Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me.Name = "InterfaceWindow"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.ResumeLayout(False)

   End Sub
End Class
