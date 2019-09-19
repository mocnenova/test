Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports Newtonsoft.Json.Linq
Imports WinHttp

Public Class frmOrchInfo
    'Global Variables to store properties like name, desc etc.
    Private oGlobal As New clsGlobal
    Private orchestrations As OrchestrationsInfo
    Dim listOrchestrations As New List(Of OrchestrationsInfo)


    Private Sub frmOrchInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Check expiration key
        'Try
        '    clsUtility.expiration = GetSetting(clsUtility.keyProductName, clsUtility.keyConnection, clsUtility.keyExpiration, "")
        'Catch ex As Exception
        '    clsUtility.expiration=String.Empty
        '    Return
        'End Try
        'If Not String.IsNullOrEmpty(clsUtility.expiration) Then
        '    dim isLicenseValid as String=GetSetting(clsUtility.keyProductName,clsUtility.keyConnection,clsUtility.keyValidLicense,"")
        '    If isLicenseValid="Invalid" Then
        '        MessageBox.Show(clsUtility.licenseKeyMessage + clsUtility.expiration) 
        '        Me.Close()   
        '    End If
        'End If

        Me.BringToFront()
        Me.AcceptButton=btnSave
        Dim authorization As String
        Dim server As String
        Dim port As String
        Dim aisVersion As String
        Dim discoverResults As String
        Dim tempOrchestrations As List(Of String)
        Dim orchName As String
        dim oxlApp as Excel.Application
        oxlApp=Globals.ThisAddIn.Application
        Dim oWorkbook As Excel.Workbook
        oWorkbook =oxlApp.ActiveWorkbook
        Dim oWorkSheet As Excel.Worksheet
        oWorkSheet =oWorkbook.ActiveSheet
        oWorkSheet.Unprotect()
        oWorkSheet.Cells.Locked=false
        Dim objHTTP As WinHttpRequest
        Dim URL As String

        'Read Information from registry
        server = GetSetting(clsUtility.keyProductName, clsUtility.keyConnection, clsUtility.keyServer, "")
        port = GetSetting(clsUtility.keyProductName, clsUtility.keyConnection, clsUtility.keyPort, 0)
        aisVersion = GetSetting(clsUtility.keyProductName, clsUtility.keyConnection, clsUtility.keyAIS, 0)
        authorization = GetSetting(clsUtility.keyProductName, clsUtility.keyConnection, clsUtility.keyAuthorization, "")

        'Validate authorization key
        If authorization<>"" Then
            'Validate version
            ' If aisVersion > "9.2.0.0" Or aisVersion = "" Then
            URL = "http://" + server + ":" + port + "/jderest/discover"
                objHTTP = New WinHttpRequest()
                objHTTP.Open("GET", URL, False)
                objHTTP.SetRequestHeader("Accept", clsUtility.contentType)
                objHTTP.SetRequestHeader("Authorization", "Basic " + authorization)
                cmbOrchestrations.Text = ""
                txtOrchDesc.Enabled = True
                chkRefreshWorksheet.Visible = True
                chkRefreshWorksheet.Checked = True
                Try
                    objHTTP.Send()
                    'check server response status
                    If objHTTP.Status = 200 Then
                        discoverResults = objHTTP.ResponseText
                        tempOrchestrations = oGlobal.parseJSON(discoverResults)
                        cmbOrchestrations.Items.Clear()
                        'Loop to populate name, desc, inputs
                        For j = 0 To tempOrchestrations.Count - 1
                            orchName = oGlobal.getJSONKey(tempOrchestrations(j), "name", ",")
                            cmbOrchestrations.Items.Add(orchName)
                            orchestrations.name = orchName
                            orchestrations.desc = oGlobal.getJSONKey(tempOrchestrations(j), "description", ",")
                            orchestrations.input = "[" + oGlobal.getJSONKey(tempOrchestrations(j), "inputs", "]") + "]"
                            listOrchestrations.Add(orchestrations)
                        Next j
                    Else
                        MessageBox.Show("HTTP " + CStr(objHTTP.Status) + " " + CStr(objHTTP.StatusText), clsUtility.dialogTitle)
                    End If
                    objHTTP = Nothing
                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString())
                    Return
                End Try
            'Else
            'cmbOrchestrations.Text = GetSetting(clsUtility.keyProductName, clsUtility.keyConnection, "Orchestration", "")
            'txtOrchDesc.Enabled = False
            'chkRefreshWorksheet.Visible = False
            'chkRefreshWorksheet.Checked = False
            'End If
        End If
End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub cmbOrchestrations_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOrchestrations.SelectedIndexChanged
        Try
            'check Require
            For Each item As OrchestrationsInfo In listOrchestrations
                If item.name=cmbOrchestrations.Text Then
                    txtOrchDesc.Text=item.desc
                End If
            Next
        Catch ex As Exception
            Return
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'User selection must not be empty
        If cmbOrchestrations.Text="" then
            MessageBox.Show("Pleae select a valid Ochestration", clsUtility.dialogTitle)
            cmbOrchestrations.Focus()
            Return
        End If
        'Save orchestration
        SaveSetting(clsUtility.keyProductName,clsUtility.keyConnection, clsUtility.keyOrchestration, cmbOrchestrations.Text)
        Dim oSelectedVal as String
        If chkRefreshWorksheet.Checked= True Then
            For Each item As OrchestrationsInfo In listOrchestrations
                If item.name=cmbOrchestrations.Text Then
                    oSelectedVal=item.input
                End If
            Next
            'Refresh sheet
            oGlobal.refreshWorksheet(oSelectedVal)
        End If
        me.Close()
    End Sub
    'Structure to store 3 dimension values
    Public structure OrchestrationsInfo
        Public name as String
        public desc as String
        Public input as String
        Public Sub New (ByVal _name As string, ByVal _desc As String, ByVal _input as String)
            _name=name
            _desc=desc
            _input=input
        End Sub
    End Structure

    Private Sub cmbOrchestrations_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbOrchestrations.Validating
        if cmbOrchestrations.Items.Contains(cmbOrchestrations.Text)=False Then
            e.Cancel=True
        End If
    End Sub

End Class