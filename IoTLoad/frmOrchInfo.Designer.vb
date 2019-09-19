<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOrchInfo
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbOrchestrations = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtOrchDesc = New System.Windows.Forms.TextBox()
        Me.chkRefreshWorksheet = New System.Windows.Forms.CheckBox()
        Me.lblOchestration = New System.Windows.Forms.Label()
        Me.lblHeaderDetail = New System.Windows.Forms.Label()
        Me.chkHeaderDetail = New System.Windows.Forms.CheckBox()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.PictureBox1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnCancel)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnSave)
        Me.SplitContainer1.Panel2.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Size = New System.Drawing.Size(446, 376)
        Me.SplitContainer1.SplitterDistance = 93
        Me.SplitContainer1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(119, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(261, 40)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Orchestration Info"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.IoTLoad.My.Resources.Resources.OrchestrationLarge
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox1.Location = New System.Drawing.Point(12, 7)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(73, 71)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.Black
        Me.btnCancel.Location = New System.Drawing.Point(359, 239)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(80, 30)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.Black
        Me.btnSave.Location = New System.Drawing.Point(277, 239)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(80, 30)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblHeaderDetail)
        Me.GroupBox1.Controls.Add(Me.chkHeaderDetail)
        Me.GroupBox1.Controls.Add(Me.cmbOrchestrations)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtOrchDesc)
        Me.GroupBox1.Controls.Add(Me.chkRefreshWorksheet)
        Me.GroupBox1.Controls.Add(Me.lblOchestration)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(421, 227)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'cmbOrchestrations
        '
        Me.cmbOrchestrations.FormattingEnabled = True
        Me.cmbOrchestrations.Location = New System.Drawing.Point(116, 42)
        Me.cmbOrchestrations.MaxDropDownItems = 20
        Me.cmbOrchestrations.Name = "cmbOrchestrations"
        Me.cmbOrchestrations.Size = New System.Drawing.Size(276, 28)
        Me.cmbOrchestrations.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(130, 22)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Refresh worksheet:"
        '
        'txtOrchDesc
        '
        Me.txtOrchDesc.Location = New System.Drawing.Point(116, 73)
        Me.txtOrchDesc.Multiline = True
        Me.txtOrchDesc.Name = "txtOrchDesc"
        Me.txtOrchDesc.Size = New System.Drawing.Size(276, 140)
        Me.txtOrchDesc.TabIndex = 1
        '
        'chkRefreshWorksheet
        '
        Me.chkRefreshWorksheet.AutoSize = True
        Me.chkRefreshWorksheet.Location = New System.Drawing.Point(142, 18)
        Me.chkRefreshWorksheet.Name = "chkRefreshWorksheet"
        Me.chkRefreshWorksheet.Size = New System.Drawing.Size(18, 17)
        Me.chkRefreshWorksheet.TabIndex = 1
        Me.chkRefreshWorksheet.UseVisualStyleBackColor = True
        '
        'lblOchestration
        '
        Me.lblOchestration.AutoSize = True
        Me.lblOchestration.Location = New System.Drawing.Point(6, 46)
        Me.lblOchestration.Name = "lblOchestration"
        Me.lblOchestration.Size = New System.Drawing.Size(94, 22)
        Me.lblOchestration.TabIndex = 0
        Me.lblOchestration.Text = "Orchestration"
        '
        'lblHeaderDetail
        '
        Me.lblHeaderDetail.AutoSize = True
        Me.lblHeaderDetail.Location = New System.Drawing.Point(223, 15)
        Me.lblHeaderDetail.Name = "lblHeaderDetail"
        Me.lblHeaderDetail.Size = New System.Drawing.Size(100, 22)
        Me.lblHeaderDetail.TabIndex = 7
        Me.lblHeaderDetail.Text = "Header/Detail:"
        '
        'chkHeaderDetail
        '
        Me.chkHeaderDetail.AutoSize = True
        Me.chkHeaderDetail.Location = New System.Drawing.Point(326, 18)
        Me.chkHeaderDetail.Name = "chkHeaderDetail"
        Me.chkHeaderDetail.Size = New System.Drawing.Size(18, 17)
        Me.chkHeaderDetail.TabIndex = 6
        Me.chkHeaderDetail.UseVisualStyleBackColor = True
        '
        'frmOrchInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(446, 376)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmOrchInfo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Orchestration Info Window"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtOrchDesc As System.Windows.Forms.TextBox
    Friend WithEvents chkRefreshWorksheet As System.Windows.Forms.CheckBox
    Friend WithEvents lblOchestration As System.Windows.Forms.Label
    Friend WithEvents cmbOrchestrations As System.Windows.Forms.ComboBox
    Friend WithEvents lblHeaderDetail As System.Windows.Forms.Label
    Friend WithEvents chkHeaderDetail As System.Windows.Forms.CheckBox
End Class
