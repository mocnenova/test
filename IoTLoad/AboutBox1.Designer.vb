<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AboutBox1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AboutBox1))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtEMail = New System.Windows.Forms.TextBox()
        Me.lblEMail = New System.Windows.Forms.Label()
        Me.lblLicenseExpiry = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtLicenseKey = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtEMail)
        Me.GroupBox1.Controls.Add(Me.lblEMail)
        Me.GroupBox1.Controls.Add(Me.lblLicenseExpiry)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtLicenseKey)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(1, 138)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(612, 132)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "I have a License Key"
        '
        'txtEMail
        '
        Me.txtEMail.Location = New System.Drawing.Point(175, 26)
        Me.txtEMail.Name = "txtEMail"
        Me.txtEMail.Size = New System.Drawing.Size(426, 27)
        Me.txtEMail.TabIndex = 3
        '
        'lblEMail
        '
        Me.lblEMail.AutoSize = True
        Me.lblEMail.Location = New System.Drawing.Point(9, 32)
        Me.lblEMail.Name = "lblEMail"
        Me.lblEMail.Size = New System.Drawing.Size(160, 21)
        Me.lblEMail.TabIndex = 4
        Me.lblEMail.Text = "Enter E-Mail Address:"
        '
        'lblLicenseExpiry
        '
        Me.lblLicenseExpiry.AutoSize = True
        Me.lblLicenseExpiry.Location = New System.Drawing.Point(176, 99)
        Me.lblLicenseExpiry.Name = "lblLicenseExpiry"
        Me.lblLicenseExpiry.Size = New System.Drawing.Size(0, 21)
        Me.lblLicenseExpiry.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 99)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 21)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Expires On:"
        '
        'txtLicenseKey
        '
        Me.txtLicenseKey.Location = New System.Drawing.Point(175, 63)
        Me.txtLicenseKey.Name = "txtLicenseKey"
        Me.txtLicenseKey.Size = New System.Drawing.Size(426, 27)
        Me.txtLicenseKey.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(135, 21)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Enter License Key:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.LinkLabel2)
        Me.GroupBox2.Controls.Add(Me.LinkLabel1)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(1, 276)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(612, 116)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "I need a License Key"
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Location = New System.Drawing.Point(78, 82)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(194, 21)
        Me.LinkLabel2.TabIndex = 4
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "sales@acbmsolutions.com"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(78, 30)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(232, 21)
        Me.LinkLabel1.TabIndex = 3
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "http://www.acbmsolutions.com"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(25, 21)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "or"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 82)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 21)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "E-Mail:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 21)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Website:"
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.Black
        Me.btnCancel.Location = New System.Drawing.Point(533, 400)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(80, 30)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnOk
        '
        Me.btnOk.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.ForeColor = System.Drawing.Color.Black
        Me.btnOk.Location = New System.Drawing.Point(451, 400)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(80, 30)
        Me.btnOk.TabIndex = 6
        Me.btnOk.Text = "OK"
        Me.btnOk.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Location = New System.Drawing.Point(187, 7)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(427, 132)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "JDExcelerator"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 98)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(292, 21)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "ACBM Solutions LLC, All Rights Reserved."
        Me.Label7.UseMnemonic = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 66)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 21)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "© 2017"
        Me.Label6.UseMnemonic = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 35)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(106, 21)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Version: 3.2.2"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(8, 10)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(169, 128)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 8
        Me.PictureBox1.TabStop = False
        '
        'AboutBox1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(627, 439)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AboutBox1"
        Me.Padding = New System.Windows.Forms.Padding(10)
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "About"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtLicenseKey As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblLicenseExpiry As System.Windows.Forms.Label
    Friend WithEvents txtEMail As System.Windows.Forms.TextBox
    Friend WithEvents lblEMail As System.Windows.Forms.Label
End Class
