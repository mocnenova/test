Imports System.Windows.Forms

Public NotInheritable Class AboutBox1

    Private Sub AboutBox1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Validating License
        'Load the email, license key, and expiration from the registry
        Try
            clsUtility.expiration = GetSetting(clsUtility.keyProductName, clsUtility.keyConnection, clsUtility.keyExpiration, "")
            txtEMail.Text = GetSetting(clsUtility.keyProductName, clsUtility.keyConnection, clsUtility.keyValidEMail, "")
            txtLicenseKey.Text = GetSetting(clsUtility.keyProductName, clsUtility.keyConnection, clsUtility.keyValidLicense, "")
            lblLicenseExpiry.Text = clsUtility.expiration
        Catch ex As Exception
            clsUtility.expiration = String.Empty
            Return
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        'Sub to check that the license key is valid
        'Confirm the license key and the e-mail address are populated
        If String.IsNullOrEmpty(txtLicenseKey.Text) Or String.IsNullOrEmpty(txtEMail.Text) Then
            MessageBox.Show("Please provide a valid E-Mail and license key.", clsUtility.dialogTitle)
            txtLicenseKey.Focus()
            Return
        End If
        'Save E-Mail and License Keys
        SaveSetting(clsUtility.keyProductName, clsUtility.keyConnection, clsUtility.keyValidEMail, txtEMail.Text)
        SaveSetting(clsUtility.keyProductName, clsUtility.keyConnection, clsUtility.keyValidLicense, txtLicenseKey.Text)
        'Validate License key from server
        Dim ServicePoint As New clsServicePoints
        'If invalid license then inform user
        If ServicePoint.checkLicense("Register") = False Then
            MessageBox.Show("Please provide a valid license key.", clsUtility.dialogTitle)
            txtLicenseKey.Focus()
            Return
        End If

        Me.Close()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.LinkLabel1.LinkVisited = True
        System.Diagnostics.Process.Start(LinkLabel1.Text)
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Me.LinkLabel1.LinkVisited = True
        System.Diagnostics.Process.Start("mailto:" & LinkLabel2.Text)
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub
End Class
