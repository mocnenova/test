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
        '        MessageBox.Show(clsUtility.licenseKeyMessage + clsUtility.expiration, clsUtility.dialogTitle) 
        '        Me.Close()   
        '    End If
        'End If

        Me.BringToFront()
        'sets default button
        ' Me.AcceptButton=btnSave
        Dim authorization As String
        Dim server As String
        Dim port As String
        Dim aisVersion As String
        Dim discoverResults As String
        Dim tempOrchestrations As List(Of String)
        Dim orchName As String
        dim oxlApp as Excel.Application
        Dim oWorkbook As Excel.Workbook
        Dim oWorkSheet As Excel.Worksheet
        Dim objHTTP As WinHttpRequest
        Dim URL As String


        oxlApp = Globals.ThisAddIn.Application
        oWorkbook = oxlApp.ActiveWorkbook
        oWorkSheet = oWorkbook.ActiveSheet
        oWorkSheet.Unprotect()
        oWorkSheet.Cells.Locked = False


        'Read Connection Information from registry
        server = GetSetting(clsUtility.keyProductName, clsUtility.keyConnection, clsUtility.keyServer, "")
        port = GetSetting(clsUtility.keyProductName, clsUtility.keyConnection, clsUtility.keyPort, 0)
        aisVersion = GetSetting(clsUtility.keyProductName, clsUtility.keyConnection, clsUtility.keyAIS, 0)
        authorization = GetSetting(clsUtility.keyProductName, clsUtility.keyConnection, clsUtility.keyAuthorization, "")



        'Validate authorization key
        If authorization<>"" Then
            'Validate version
            ' If aisVersion > "9.2.0.0" Or aisVersion = "" Then
            'some new versions (JDE in the cloud) didn't have an AIS version specified

            'create URL to connect to the discovery service
            URL = "https://" + server + ":" + port + "/jderest/discover"
            objHTTP = New WinHttpRequest()
            objHTTP.Open("GET", URL, False)
            objHTTP.Option(WinHttp.WinHttpRequestOption.WinHttpRequestOption_SslErrorIgnoreFlags) = WinHttp.WinHttpRequestSslErrorFlags.SslErrorFlag_Ignore_All            'Ignore SSL errors, The code works when I enable this, but then it is insecure                                                                                                                                     
            objHTTP.SetRequestHeader("Accept", clsUtility.contentType)
            objHTTP.SetRequestHeader("Authorization", "Basic " + authorization)
            cmbOrchestrations.Text = ""
            txtOrchDesc.Enabled = True
            chkRefreshWorksheet.Visible = True
            chkRefreshWorksheet.Checked = True

            Try
                'request and parse the discovery results
                'this line takes awhile to send and receive the data
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
                    MessageBox.Show("Discovery service is not available.  Please enter an orchestration name.", clsUtility.dialogTitle)
                End If
                objHTTP = Nothing
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString(), clsUtility.dialogTitle)
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
                If item.name = cmbOrchestrations.Text Then
                    txtOrchDesc.Text = item.desc
                End If
            Next
        Catch ex As Exception
            Return
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'Sub to create the template and save the orchestration name and header/detail setting to the worksheet property

        Dim oxlApp As Excel.Application
        oxlApp = Globals.ThisAddIn.Application
        Dim oWorkbook As Excel.Workbook
        oWorkbook = oxlApp.ActiveWorkbook
        Dim oWorkSheet As Excel.Worksheet
        oWorkSheet = oWorkbook.ActiveSheet


        'User selection must not be empty
        If cmbOrchestrations.Text = "" Then
            MessageBox.Show("Pleae select a valid Ochestration.", clsUtility.dialogTitle)
            cmbOrchestrations.Focus()
            Return
        End If
        'Save Orchestration Name in Custom Properties instead of registry
        'SaveSetting(clsUtility.keyProductName, clsUtility.keyConnection, clsUtility.keyOrchestration, cmbOrchestrations.Text)

        'If there are no custom properties then add them
        If oWorkSheet.CustomProperties.Count = 0 Then
            oWorkSheet.CustomProperties.Add(Name:="Orchestrations", Value:=cmbOrchestrations.Text)
            oWorkSheet.CustomProperties.Add(Name:="HeaderDetail", Value:=chkHeaderDetail.Checked)
            'If there are already custom properties then update the Orchestration and HeaderDetail settings
        Else
            Dim i As Integer
            For i = 1 To oWorkSheet.CustomProperties.Count
                If oWorkSheet.CustomProperties(i).Name = "Orchestrations" Then
                    oWorkSheet.CustomProperties(i).Value = cmbOrchestrations.Text
                ElseIf oWorkSheet.CustomProperties(i).Name = "HeaderDetail" Then
                    oWorkSheet.CustomProperties(i).Value = chkHeaderDetail.Checked
                End If
            Next i
        End If

        'MsgBox(oWorkSheet.CustomProperties(1).Name + " : " + oWorkSheet.CustomProperties(1).Value)
        'MsgBox(oWorkSheet.CustomProperties(2).Name + " : " + oWorkSheet.CustomProperties(2).Value)

        'If the refresh worksheet box is checked, then delete the worksheet and rebuild the template with the Orchestration Inpu information
        If chkRefreshWorksheet.Checked = True Then
            Dim oSelectedVal As String
            oSelectedVal = String.Empty
            'Find the selected Orchestration
            For Each item As OrchestrationsInfo In listOrchestrations
                If item.name = cmbOrchestrations.Text Then
                    oSelectedVal = item.input
                End If
            Next
            'Refresh sheet
            oGlobal.refreshWorksheet(oSelectedVal, chkHeaderDetail.Checked)
        End If
        Me.Close()
    End Sub
    'Structure to store name, description and inputs (array)
    Public Structure OrchestrationsInfo
        Public name As String
        Public desc As String
        Public input As String
        Public Sub New(ByVal _name As String, ByVal _desc As String, ByVal _input As String)
            _name = name
            _desc = desc
            _input = input
        End Sub
    End Structure

    'What does this do?
    Private Sub cmbOrchestrations_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        If cmbOrchestrations.Items.Contains(cmbOrchestrations.Text) = False Then
            e.Cancel = True
        End If
    End Sub


End Class