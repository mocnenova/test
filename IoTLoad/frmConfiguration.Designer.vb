<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfiguration
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblHeaderRows = New System.Windows.Forms.Label()
        Me.txtHeaderRows = New System.Windows.Forms.TextBox()
        Me.lblLastRows = New System.Windows.Forms.Label()
        Me.lblShowStatus = New System.Windows.Forms.Label()
        Me.chkShowStatus = New System.Windows.Forms.CheckBox()
        Me.txtLastRows = New System.Windows.Forms.TextBox()
        Me.lblShowInput = New System.Windows.Forms.Label()
        Me.chkShowInput = New System.Windows.Forms.CheckBox()
        Me.lblShowReturns = New System.Windows.Forms.Label()
        Me.chkShowReturn = New System.Windows.Forms.CheckBox()
        Me.lblShowWarnings = New System.Windows.Forms.Label()
        Me.chkShowWarnings = New System.Windows.Forms.CheckBox()
        Me.lblShowErrors = New System.Windows.Forms.Label()
        Me.chkShowErrors = New System.Windows.Forms.CheckBox()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
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
        Me.SplitContainer1.Size = New System.Drawing.Size(452, 417)
        Me.SplitContainer1.SplitterDistance = 72
        Me.SplitContainer1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(84, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(242, 40)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "General Settings"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.IoTLoad.My.Resources.Resources.settingLarge
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox1.Location = New System.Drawing.Point(8, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(71, 71)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.Black
        Me.btnCancel.Location = New System.Drawing.Point(352, 282)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(80, 30)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.Black
        Me.btnSave.Location = New System.Drawing.Point(270, 282)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(80, 30)
        Me.btnSave.TabIndex = 7
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 24)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(428, 252)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Settings"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblHeaderRows, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtHeaderRows, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblLastRows, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblShowStatus, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.chkShowStatus, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.txtLastRows, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblShowInput, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.chkShowInput, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblShowReturns, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.chkShowReturn, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.lblShowWarnings, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.chkShowWarnings, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.lblShowErrors, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.chkShowErrors, 1, 7)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(8, 22)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 8
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(413, 224)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'lblHeaderRows
        '
        Me.lblHeaderRows.AutoSize = True
        Me.lblHeaderRows.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblHeaderRows.Location = New System.Drawing.Point(3, 1)
        Me.lblHeaderRows.Name = "lblHeaderRows"
        Me.lblHeaderRows.Size = New System.Drawing.Size(68, 30)
        Me.lblHeaderRows.TabIndex = 0
        Me.lblHeaderRows.Text = "First Row"
        '
        'txtHeaderRows
        '
        Me.txtHeaderRows.Location = New System.Drawing.Point(250, 4)
        Me.txtHeaderRows.Name = "txtHeaderRows"
        Me.txtHeaderRows.Size = New System.Drawing.Size(75, 26)
        Me.txtHeaderRows.TabIndex = 0
        '
        'lblLastRows
        '
        Me.lblLastRows.AutoSize = True
        Me.lblLastRows.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblLastRows.Location = New System.Drawing.Point(3, 31)
        Me.lblLastRows.Name = "lblLastRows"
        Me.lblLastRows.Size = New System.Drawing.Size(186, 30)
        Me.lblLastRows.TabIndex = 2
        Me.lblLastRows.Text = "Last Row (blank for all rows)"
        '
        'lblShowStatus
        '
        Me.lblShowStatus.AutoSize = True
        Me.lblShowStatus.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblShowStatus.Location = New System.Drawing.Point(3, 61)
        Me.lblShowStatus.Name = "lblShowStatus"
        Me.lblShowStatus.Size = New System.Drawing.Size(86, 30)
        Me.lblShowStatus.TabIndex = 4
        Me.lblShowStatus.Text = "Show Status"
        '
        'chkShowStatus
        '
        Me.chkShowStatus.AutoSize = True
        Me.chkShowStatus.Location = New System.Drawing.Point(250, 64)
        Me.chkShowStatus.Name = "chkShowStatus"
        Me.chkShowStatus.Size = New System.Drawing.Size(18, 17)
        Me.chkShowStatus.TabIndex = 2
        Me.chkShowStatus.UseVisualStyleBackColor = True
        '
        'txtLastRows
        '
        Me.txtLastRows.Location = New System.Drawing.Point(250, 34)
        Me.txtLastRows.Name = "txtLastRows"
        Me.txtLastRows.Size = New System.Drawing.Size(75, 26)
        Me.txtLastRows.TabIndex = 1
        '
        'lblShowInput
        '
        Me.lblShowInput.AutoSize = True
        Me.lblShowInput.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblShowInput.Location = New System.Drawing.Point(3, 91)
        Me.lblShowInput.Name = "lblShowInput"
        Me.lblShowInput.Size = New System.Drawing.Size(78, 30)
        Me.lblShowInput.TabIndex = 6
        Me.lblShowInput.Text = "Show Input"
        '
        'chkShowInput
        '
        Me.chkShowInput.AutoSize = True
        Me.chkShowInput.Location = New System.Drawing.Point(250, 94)
        Me.chkShowInput.Name = "chkShowInput"
        Me.chkShowInput.Size = New System.Drawing.Size(18, 17)
        Me.chkShowInput.TabIndex = 3
        Me.chkShowInput.UseVisualStyleBackColor = True
        '
        'lblShowReturns
        '
        Me.lblShowReturns.AutoSize = True
        Me.lblShowReturns.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblShowReturns.Location = New System.Drawing.Point(3, 121)
        Me.lblShowReturns.Name = "lblShowReturns"
        Me.lblShowReturns.Size = New System.Drawing.Size(114, 30)
        Me.lblShowReturns.TabIndex = 8
        Me.lblShowReturns.Text = "Show Return IDs"
        '
        'chkShowReturn
        '
        Me.chkShowReturn.AutoSize = True
        Me.chkShowReturn.Location = New System.Drawing.Point(250, 124)
        Me.chkShowReturn.Name = "chkShowReturn"
        Me.chkShowReturn.Size = New System.Drawing.Size(18, 17)
        Me.chkShowReturn.TabIndex = 4
        Me.chkShowReturn.UseVisualStyleBackColor = True
        '
        'lblShowWarnings
        '
        Me.lblShowWarnings.AutoSize = True
        Me.lblShowWarnings.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblShowWarnings.Location = New System.Drawing.Point(3, 151)
        Me.lblShowWarnings.Name = "lblShowWarnings"
        Me.lblShowWarnings.Size = New System.Drawing.Size(108, 30)
        Me.lblShowWarnings.TabIndex = 10
        Me.lblShowWarnings.Text = "Show Warnings"
        '
        'chkShowWarnings
        '
        Me.chkShowWarnings.AutoSize = True
        Me.chkShowWarnings.Location = New System.Drawing.Point(250, 154)
        Me.chkShowWarnings.Name = "chkShowWarnings"
        Me.chkShowWarnings.Size = New System.Drawing.Size(18, 17)
        Me.chkShowWarnings.TabIndex = 5
        Me.chkShowWarnings.UseVisualStyleBackColor = True
        '
        'lblShowErrors
        '
        Me.lblShowErrors.AutoSize = True
        Me.lblShowErrors.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblShowErrors.Location = New System.Drawing.Point(3, 181)
        Me.lblShowErrors.Name = "lblShowErrors"
        Me.lblShowErrors.Size = New System.Drawing.Size(87, 43)
        Me.lblShowErrors.TabIndex = 12
        Me.lblShowErrors.Text = "Show Errors"
        '
        'chkShowErrors
        '
        Me.chkShowErrors.AutoSize = True
        Me.chkShowErrors.Location = New System.Drawing.Point(250, 184)
        Me.chkShowErrors.Name = "chkShowErrors"
        Me.chkShowErrors.Size = New System.Drawing.Size(18, 17)
        Me.chkShowErrors.TabIndex = 6
        Me.chkShowErrors.UseVisualStyleBackColor = True
        '
        'frmConfiguration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(452, 417)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmConfiguration"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "General Settings"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblHeaderRows As System.Windows.Forms.Label
    Friend WithEvents txtHeaderRows As System.Windows.Forms.TextBox
    Friend WithEvents lblLastRows As System.Windows.Forms.Label
    Friend WithEvents lblShowStatus As System.Windows.Forms.Label
    Friend WithEvents chkShowStatus As System.Windows.Forms.CheckBox
    Friend WithEvents txtLastRows As System.Windows.Forms.TextBox
    Friend WithEvents lblShowInput As System.Windows.Forms.Label
    Friend WithEvents chkShowInput As System.Windows.Forms.CheckBox
    Friend WithEvents lblShowReturns As System.Windows.Forms.Label
    Friend WithEvents chkShowReturn As System.Windows.Forms.CheckBox
    Friend WithEvents lblShowWarnings As System.Windows.Forms.Label
    Friend WithEvents chkShowWarnings As System.Windows.Forms.CheckBox
    Friend WithEvents lblShowErrors As System.Windows.Forms.Label
    Friend WithEvents chkShowErrors As System.Windows.Forms.CheckBox
End Class
