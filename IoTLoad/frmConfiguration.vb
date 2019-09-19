Imports System.Windows.Forms

Public Class frmConfiguration
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmConfiguration_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        'Set Save button as default
        'Me.AcceptButton=btnSave
        'Get parameters from registry
        txtHeaderRows.Text = GetSetting(clsUtility.keyProductName, clsUtility.keyConfiguration, "HeaderRows", 3)
        txtLastRows.Text = GetSetting(clsUtility.keyProductName, clsUtility.keyConfiguration, "LastRow", "")
        chkShowStatus.Checked = GetSetting(clsUtility.keyProductName, clsUtility.keyConfiguration, "Status", True)
        chkShowInput.Checked = GetSetting(clsUtility.keyProductName, clsUtility.keyConfiguration, "Input", True)
        chkShowReturn.Checked = GetSetting(clsUtility.keyProductName, clsUtility.keyConfiguration, "ReturnIDs", True)
        chkShowWarnings.Checked = GetSetting(clsUtility.keyProductName, clsUtility.keyConfiguration, "Warnings", True)
        chkShowErrors.Checked = GetSetting(clsUtility.keyProductName, clsUtility.keyConfiguration, "Errors", True)
        
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'Dim aisVersion As String
        'Check number of header rows is numeric
        If IsNumeric(txtHeaderRows.Text) = False Then
            MessageBox.Show("The # of Header Rows Must Be A Number", clsUtility.dialogTitle)
            Return
        End If

        'Check last row is a number
        If Trim(txtLastRows.Text) <> "" And IsNumeric(txtLastRows.Text) = False Then
            MessageBox.Show("The Last Row Must Be A Number or Blank", clsUtility.dialogTitle)
            Return
        End If

        'aisVersion = GetSetting("ACBM", "Connection", "AIS", 0)

        'Confirm the first two rows are for headers
        ' this could be modified for older versions
        If CInt(txtHeaderRows.Text) < 2 Then
            MessageBox.Show("At Least the First Two Rows Are Reserved For Header Information", clsUtility.dialogTitle)
            Return
        End If
        'Save settings
        SaveSetting(clsUtility.keyProductName, clsUtility.keyConfiguration, "HeaderRows", txtHeaderRows.Text)
    SaveSetting (clsUtility.keyProductName, clsUtility.keyConfiguration, "LastRow", txtLastRows.Text)
    SaveSetting (clsUtility.keyProductName, clsUtility.keyConfiguration, "Status", chkShowStatus.Checked)
    SaveSetting (clsUtility.keyProductName, clsUtility.keyConfiguration, "Input", chkShowInput.Checked)
    SaveSetting (clsUtility.keyProductName, clsUtility.keyConfiguration, "ReturnIDs", chkShowReturn.Checked)
    SaveSetting (clsUtility.keyProductName, clsUtility.keyConfiguration, "Warnings", chkShowWarnings.Checked)
    SaveSetting (clsUtility.keyProductName, clsUtility.keyConfiguration, "Errors", chkShowErrors.Checked)
    me.Close()
    End Sub


End Class