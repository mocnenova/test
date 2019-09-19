Imports System.Windows.Forms

Public Class frmConnectionSettings
    Private ServicePoint as New clsServicePoints
    Dim oGlobal as New clsGlobal
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmConnectionSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'populate the connection settings with the existing connection information

        Me.BringToFront()
        'set default button
        ' Me.AcceptButton=btnTest

        txtServerName.Focus()
        txtServerName.Text = GetSetting(clsUtility.keyProductName, clsUtility.keyConnection, clsUtility.keyServer, "")
        txtPort.Text = GetSetting(clsUtility.keyProductName, clsUtility.keyConnection, clsUtility.keyPort, 0)
        oGlobal._authorizationUsername = GetSetting(clsUtility.keyProductName, clsUtility.keyConnection, clsUtility.keyAuthorizationUser, "")
        oGlobal._authorizationPassword = GetSetting(clsUtility.keyProductName, clsUtility.keyConnection, clsUtility.keyAuthorizationPassword, "")
        'If authorization key is valid
        'retrieve the username and password from the authorization key
        'decode base 64
        If oGlobal._authorizationUsername <> "" Then
            Dim owrapperUser As New Simple3Des(clsUtility.UserKey)
            txtUserName.Text = owrapperUser.DecryptData(oGlobal._authorizationUsername)
            Dim owrapperPassword As New Simple3Des(clsUtility.PasswordKey)
            txtPassword.Text = owrapperPassword.DecryptData(oGlobal._authorizationPassword)
        End If
    End Sub

    Private Sub btnTest_Click(sender As Object, e As EventArgs) Handles btnTest.Click
        'test if the AIS server is valid and available

        'check if the server name is populated
        If String.IsNullOrEmpty(txtServerName.Text) Then
            MessageBox.Show("Server name cannot be left empty",clsUtility.dialogTitle)
            txtServerName.Focus()
            Return
        End If

        'check if the port is populated
        If String.IsNullOrEmpty(txtPort.Text) Then
            MessageBox.Show("Port cannot be left empty", clsUtility.dialogTitle)
            txtPort.Focus()
            Return
        End If

        'check if the user name is populated
        'this is not yet validated
        If String.IsNullOrEmpty(txtUserName.Text) Then
            MessageBox.Show("Username cannot be left empty", clsUtility.dialogTitle)
            txtUserName.Focus()
            Return
        End If

        'check if the password is populated
        'this is not yet validated
        If String.IsNullOrEmpty(txtPassword.Text) Then
            MessageBox.Show("Password cannot be left empty",clsUtility.dialogTitle)
            txtPassword.Focus()
            Return
        End If

        'Encrypt user and password
        Dim oEncryptUser as new Simple3Des(clsUtility.UserKey)
        oGlobal._authorizationUsername=oEncryptUser.EncryptData(txtUserName.Text)
        dim oEncryptPassword as new Simple3Des(clsUtility.PasswordKey)
        oGlobal._authorizationPassword=oEncryptPassword.EncryptData(txtPassword.Text)
        If ServicePoint.testConnection(txtServerName.Text.ToString(),txtPort.Text.ToString(),oGlobal._authorizationUsername,oGlobal._authorizationPassword)=True Then
            MessageBox.Show("Test Successful!",clsUtility.dialogTitle)
        Else 
            MessageBox.Show("Test Failed",clsUtility.dialogTitle)
            Return
        End If

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'test if the AIS server is valid and available

        'check if the server name is populated
        If String.IsNullOrEmpty(txtServerName.Text) Then
            MessageBox.Show("Server name cannot be left empty", clsUtility.dialogTitle)
            txtServerName.Focus()
            Return
        End If

        'check if the port is populated
        If String.IsNullOrEmpty(txtPort.Text) Then
            MessageBox.Show("Port cannot be left empty", clsUtility.dialogTitle)
            txtPort.Focus()
            Return
        End If

        'check if the user name is populated
        'this is not yet validated
        If String.IsNullOrEmpty(txtUserName.Text) Then
            MessageBox.Show("Username cannot be left empty", clsUtility.dialogTitle)
            txtUserName.Focus()
            Return
        End If

        'check if the password is populated
        'this is not yet validated
        If String.IsNullOrEmpty(txtPassword.Text) Then
            MessageBox.Show("Password cannot be left empty", clsUtility.dialogTitle)
            txtPassword.Focus()
            Return
        End If

        'Encrypt user
        Dim oEncryptUser As New Simple3Des(clsUtility.UserKey)
        oGlobal._authorizationUsername = oEncryptUser.EncryptData(txtUserName.Text)
        'Encrypt Password
        Dim oEncryptPassword As New Simple3Des(clsUtility.PasswordKey)
        oGlobal._authorizationPassword = oEncryptPassword.EncryptData(txtPassword.Text)
        'Encrypt authorization key
        Dim oEncryptauthorization As Byte()
        oEncryptauthorization = Encoding.UTF8.GetBytes(txtUserName.Text + ":" + txtPassword.Text)
        oGlobal._authorization = Convert.ToBase64String(oEncryptauthorization)

        'Test Connection with the server and Save settings if success
        If ServicePoint.testConnection(txtServerName.Text.ToString(), txtPort.Text.ToString(), oGlobal._authorizationUsername, oGlobal._authorizationPassword) = True Then
            SaveSetting(clsUtility.keyProductName, clsUtility.keyConnection, clsUtility.keyAIS, clsUtility.aisVersion)
            SaveSetting(clsUtility.keyProductName, clsUtility.keyConnection, clsUtility.keyServer, txtServerName.Text)
            SaveSetting(clsUtility.keyProductName, clsUtility.keyConnection, clsUtility.keyPort, txtPort.Text)
            SaveSetting(clsUtility.keyProductName, clsUtility.keyConnection, clsUtility.keyAuthorizationUser, oGlobal._authorizationUsername)
            SaveSetting(clsUtility.keyProductName, clsUtility.keyConnection, clsUtility.keyAuthorizationPassword, oGlobal._authorizationPassword)
            SaveSetting(clsUtility.keyProductName, clsUtility.keyConnection, clsUtility.keyAuthorization, oGlobal._authorization)
            MessageBox.Show("Save Successfull!", clsUtility.dialogTitle)
        Else
            MessageBox.Show("Test Failed", clsUtility.dialogTitle)
            Return
        End If
        'Close form
        Me.Close()
    End Sub
End Class