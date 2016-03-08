<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.cmdStart = New System.Windows.Forms.Button()
        Me.cmdTerminate = New System.Windows.Forms.Button()
        Me.tmrPoll = New System.Windows.Forms.Timer(Me.components)
        Me.lstLog = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'cmdStart
        '
        Me.cmdStart.Location = New System.Drawing.Point(21, 143)
        Me.cmdStart.Name = "cmdStart"
        Me.cmdStart.Size = New System.Drawing.Size(156, 23)
        Me.cmdStart.TabIndex = 0
        Me.cmdStart.Text = "Start DQ Listener"
        Me.cmdStart.UseVisualStyleBackColor = True
        '
        'cmdTerminate
        '
        Me.cmdTerminate.Location = New System.Drawing.Point(249, 143)
        Me.cmdTerminate.Name = "cmdTerminate"
        Me.cmdTerminate.Size = New System.Drawing.Size(156, 23)
        Me.cmdTerminate.TabIndex = 1
        Me.cmdTerminate.Text = "Terminate DQ"
        Me.cmdTerminate.UseVisualStyleBackColor = True
        '
        'tmrPoll
        '
        Me.tmrPoll.Interval = 10000
        '
        'lstLog
        '
        Me.lstLog.FormattingEnabled = True
        Me.lstLog.ItemHeight = 17
        Me.lstLog.Location = New System.Drawing.Point(21, 11)
        Me.lstLog.Name = "lstLog"
        Me.lstLog.ScrollAlwaysVisible = True
        Me.lstLog.Size = New System.Drawing.Size(384, 123)
        Me.lstLog.TabIndex = 2
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(427, 176)
        Me.Controls.Add(Me.lstLog)
        Me.Controls.Add(Me.cmdTerminate)
        Me.Controls.Add(Me.cmdStart)
        Me.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Dublin Bikes Data Queue Listener..."
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cmdStart As Button
    Friend WithEvents cmdTerminate As Button
    Friend WithEvents tmrPoll As Timer
    Friend WithEvents lstLog As ListBox
End Class
