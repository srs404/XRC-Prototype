<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class leylock
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(leylock))
        Me.locker = New System.Windows.Forms.Timer(Me.components)
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'locker
        '
        Me.locker.Enabled = True
        Me.locker.Interval = 2000
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.18182!, System.Drawing.FontStyle.Bold)
        Me.TextBox1.Location = New System.Drawing.Point(0, 393)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(800, 57)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'leylock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.ControlBox = False
        Me.Controls.Add(Me.TextBox1)
        Me.Cursor = System.Windows.Forms.Cursors.No
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MinimizeBox = False
        Me.Name = "leylock"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LeyLock"
        Me.TopMost = True
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents locker As Timer
    Friend WithEvents TextBox1 As TextBox
End Class
