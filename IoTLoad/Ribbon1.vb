Imports System.Net
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports Microsoft.Office.Tools.Ribbon
Imports WinHttp

Public Class Ribbon1

    Private Sub Ribbon1_Load(ByVal sender As System.Object, ByVal e As RibbonUIEventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnSettings_Click(sender As Object, e As RibbonControlEventArgs) Handles btnSettings.Click
        'Load connection settings form
        Dim ConnectionSettings As New frmConnectionSettings
        ConnectionSettings.ShowDialog()
    End Sub

    Private Sub btnOrchInfo_Click(sender As Object, e As RibbonControlEventArgs) Handles btnOrchInfo.Click
        'Check if the user is currently editing a cell
        If IsEditing() = True Then
            Exit Sub
        End If
        'Load Orchinfo form
        Dim OrchInfo As New frmOrchInfo
        OrchInfo.ShowDialog()
    End Sub

    Private Sub btnConfiguration_Click(sender As Object, e As RibbonControlEventArgs) Handles btnConfiguration.Click
        'Load Configuration Form
        Dim Configuration As New frmConfiguration
        Configuration.ShowDialog()
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As RibbonControlEventArgs) Handles btnHelp.Click
        'Load About Form
        Dim About As New AboutBox1
        About.ShowDialog()
    End Sub

    Private Sub btnLoadData_Click(sender As Object, e As RibbonControlEventArgs) Handles btnLoadData.Click
        'Call postData here
        Dim iRow As Long
        Dim iCol As Integer
        Dim wk As Excel.Workbook
        Dim ws As Excel.Worksheet
        Dim firstRow As Long
        Dim lastRow As Long
        Dim lastCol As Integer
        Dim tempRow As String

        Dim Authorization As String
        Dim url As String
        Dim JSONString As String
        Dim inputString As String
        Dim token As String

        Dim objHTTP As WinHttpRequest
        Dim getTokenHTTP As WinHttpRequest
        Dim logoutHTTP As WinHttpRequest

        Dim server As String
        Dim port As String
        Dim orchestrationName As String

        Dim result As String
        Dim response As String
        Dim xlApp As Excel.Application

        Dim endPos As Integer
        Dim ServicePoint As New clsServicePoints

        Dim headerDetail As Boolean
        Dim gridName As String

        xlApp = Globals.ThisAddIn.Application

        'Check if the user is currently editing a cell
        If IsEditing() = True Then
            Exit Sub
        End If

        'If invalid license then inform user
        If ServicePoint.checkLicense("LoadData") = False Then
            MessageBox.Show("Please provide a valid license key.", clsUtility.dialogTitle)
            Exit Sub
        End If

        'confirm the user wants to submit data
        If MsgBox("Are you sure you want to submit this data?", vbYesNo) = vbNo Then
            Exit Sub
        End If

        wk = xlApp.ActiveWorkbook
        ws = wk.ActiveSheet

        'confirm an orchestration has been previously selected
        If ws.CustomProperties.Count = 0 Then
            MessageBox.Show("Please select an Orchestration before loading data.", clsUtility.dialogTitle)
            Exit Sub
        End If


        objHTTP = New WinHttpRequest()
        getTokenHTTP = New WinHttpRequest()

        'Load the server and port of the AIS server
        server = GetSetting(clsUtility.keyProductName, clsUtility.keyConnection, clsUtility.keyServer, "")
        port = CStr(GetSetting(clsUtility.keyProductName, clsUtility.keyConnection, clsUtility.keyPort, 0))
        authorization = GetSetting(clsUtility.keyProductName, clsUtility.keyConnection, clsUtility.keyAuthorization, "")
        'Retrieve Orchestration Name from custom worksheet property instead of registry key
        'orchestrationName = GetSetting(clsUtility.keyProductName, clsUtility.keyConnection, clsUtility.keyOrchestration, "")

        'Check the custom properties to retrieve the orchestration name and the header/detail setting
        For i = 1 To ws.CustomProperties.Count
            If ws.CustomProperties(i).Name = "Orchestrations" Then
                orchestrationName = ws.CustomProperties(i).Value
            ElseIf ws.CustomProperties(i).Name = "HeaderDetail" Then
                headerDetail = ws.CustomProperties(i).Value
            End If
        Next i

        ''''''''''''''''''''''''''''''''''
        'Add this to a worksheet property
        ''''''''''''''''''''''''''''''''''
        gridName = "GridData"

        'request a token from the AIS server
        url = "https://" + server + ":" + port + "/jderest/tokenrequest"
        getTokenHTTP.Open("POST", url, False)
        getTokenHTTP.Option(WinHttp.WinHttpRequestOption.WinHttpRequestOption_SslErrorIgnoreFlags) = WinHttp.WinHttpRequestSslErrorFlags.SslErrorFlag_Ignore_All            'Ignore SSL errors, The code works when I enable this, but then it is insecure                                                                                                                                     
        getTokenHTTP.SetRequestHeader("Content-type", "application/json")
        getTokenHTTP.SetRequestHeader("Accept", "application/json")
        getTokenHTTP.SetRequestHeader("Authorization", "Basic " + authorization)
        getTokenHTTP.Send("")

        token = """token"":" + getResponse(getTokenHTTP.responseText, """token"":", ",")
        getTokenHTTP = Nothing

        'create the URL to post to
        url = "https://" + server + ":" + port + "/jderest/orchestrator/" + orchestrationName
        objHTTP.Open("POST", url, False)
        objHTTP.Option(WinHttp.WinHttpRequestOption.WinHttpRequestOption_SslErrorIgnoreFlags) = WinHttp.WinHttpRequestSslErrorFlags.SslErrorFlag_Ignore_All            'Ignore SSL errors, The code works when I enable this, but then it is insecure                                                                                                                                     
        objHTTP.setRequestHeader("Content-type", "application/json")
        objHTTP.setRequestHeader("Accept", "application/json")
        'objHTTP.setRequestHeader ("Authorization", "Basic " + authorization)

        'retrieve the first and last rows
        firstRow = GetSetting(clsUtility.keyProductName, clsUtility.keyConfiguration, "HeaderRows", 3)
        tempRow = GetSetting(clsUtility.keyProductName, clsUtility.keyConfiguration, "LastRow", "")

        'update the last row to the last used row if no row number is specified
        If tempRow.ToString().Trim() = "0" Or tempRow.ToString().Trim() = "" Then
            lastRow = ws.UsedRange.Rows.count
        Else
            lastRow = tempRow
        End If

        'update the last row to the last used row if a number greater than the last used row was specified
        If lastRow > ws.UsedRange.Rows.count Then
            lastRow = ws.UsedRange.Rows.count
        End If
        lastCol = 1

        'Itererate through the columns to finr the last used column data
        While Not ws.Cells(1, lastCol).Value = Nothing
            lastCol = lastCol + 1
        End While

        'unprotect the sheet to make updates
        Try
            ws.Unprotect()
        Catch ex As Exception

        End Try

        'turn of screenupdating for improved performance
        xlApp.ScreenUpdating = False

        'clear all of the columns after the last used column
        For iCol = lastCol To ws.UsedRange.Columns.count
            ws.Cells(1, iCol).EntireColumn.ClearContents
        Next iCol
        'start at the last column
        iCol = lastCol

        Try
            'set all of the column widths
            ws.Cells(1, iCol).EntireColumn.ColumnWidth = 8.11

            'Create a HTTP status column if the status setting was checked
            If GetSetting(clsUtility.keyProductName, clsUtility.keyConfiguration, "Status", True) = True Then
                ws.Cells(1, iCol + 1).Value = "Status"
                ws.Cells(1, iCol + 1).Font.Bold = True
                ws.Cells(1, iCol + 1).EntireColumn.ColumnWidth = 5.44
                ws.Cells(1, iCol + 1).EntireColumn.WrapText = True
                ws.Cells(1, iCol + 1).EntireColumn.AutoFit
                iCol = iCol + 1
            End If

            'Create a column to show the input JSON, if the Input setting was checked
            If GetSetting(clsUtility.keyProductName, clsUtility.keyConfiguration, "Input", True) = True Then
                ws.Cells(1, iCol + 1).Value = "Input"
                ws.Cells(1, iCol + 1).Font.Bold = True
                ws.Cells(1, iCol + 1).EntireColumn.ColumnWidth = 50
                ws.Cells(1, iCol + 1).EntireColumn.WrapText = True
                iCol = iCol + 1
            End If

            'Create a column to show the return IDs if the Return setting was checked
            If GetSetting(clsUtility.keyProductName, clsUtility.keyConfiguration, "ReturnIDs", True) = True Then
                ws.Cells(1, iCol + 1).Value = "Return IDs"
                ws.Cells(1, iCol + 1).Font.Bold = True
                ws.Cells(1, iCol + 1).EntireColumn.ColumnWidth = 100
                ws.Cells(1, iCol + 1).EntireColumn.WrapText = True
                iCol = iCol + 1
            End If

            'Create a column to show the JDE warnings if the Warnings setting was checked
            If GetSetting(clsUtility.keyProductName, clsUtility.keyConfiguration, "Warnings", True) = True Then
                ws.Cells(1, iCol + 1).Value = "Warnings"
                ws.Cells(1, iCol + 1).Font.Bold = True
                ws.Cells(1, iCol + 1).EntireColumn.ColumnWidth = 50
                ws.Cells(1, iCol + 1).EntireColumn.WrapText = True
                iCol = iCol + 1
            End If

            'Create a column to show the JDE errors if the Errors setting was checked
            If GetSetting(clsUtility.keyProductName, clsUtility.keyConfiguration, "Errors", True) = True Then
                ws.Cells(1, iCol + 1).Value = "Errors"
                ws.Cells(1, iCol + 1).Font.Bold = True
                ws.Cells(1, iCol + 1).EntireColumn.ColumnWidth = 50
                ws.Cells(1, iCol + 1).EntireColumn.WrapText = True
                iCol = iCol + 1
            End If
        Catch ex As Exception

        End Try


        'Loop for each input
        '''''''''''''''''''''''''''''''''
        'move loop to inside If statement
        '''''''''''''''''''''''''''''''
        For iRow = firstRow To lastRow
            'If the worksheet is not a header/detail then send each row individually
            If headerDetail = False Then
                JSONString = """inputs"":[{""name"":""" + CStr(ws.Cells(1, 1).Value) + """,""" + "value""" + ":""" + CStr(ws.Cells(iRow, 1).Value) + """}"
                For iCol = 2 To lastCol - 1
                    JSONString = JSONString + "," + "{""name""" + ":""" + CStr(ws.Cells(1, iCol).Value) + """," + """value" + """:""" + CStr(ws.Cells(iRow, iCol).Value) + """}"
                Next iCol
                inputString = "{" + token + "," + JSONString + "]}"
                ''if the worksheet is header/detail then loop through a header record and all subsequent detail records until you get to the next header or last row
            Else
                '''''''''''''''''''''''''''''''
                'update to account for applications with grid only
                'powerforms??
                'headers with no detail reocords?
                ''''''''''''''''''''''''''''''''
                'create the JSON for the header record
                JSONString = """inputs"":[{""name"":""" + CStr(ws.Cells(1, 1).Value) + """,""" + "value""" + ":""" + CStr(ws.Cells(iRow, 1).Value) + """}"
                'loop through the remaining columns of the header record
                For iCol = 2 To lastCol - 1
                    'add each cell if the data is not blank
                    If CStr(ws.Cells(iRow, iCol).Value) <> "" Then
                        JSONString = JSONString + "," + "{""name""" + ":""" + CStr(ws.Cells(1, iCol).Value) + """," + """value" + """:""" + CStr(ws.Cells(iRow, iCol).Value) + """}"
                    End If
                Next iCol
                'add additional info for detail records (Repeating Inputs)
                JSONString = JSONString + "],""detailInputs"":[{""name"":""" + gridName + """, ""repeatingInputs"":["
                'loop through the detail records
                While (iRow + 1 <= lastRow And CStr(ws.Cells(iRow + 1, 1).value) = "")
                    iRow = iRow + 1
                    JSONString = JSONString + "{""inputs"":["
                    'loop throught the columns on each detail record
                    For iCol = 2 To lastCol - 1
                        'add each cell if the data is not blank
                        If CStr(ws.Cells(iRow, iCol).Value) <> "" Then
                            JSONString = JSONString + "{""name""" + ":""" + CStr(ws.Cells(1, iCol).Value) + """," + """value" + """:""" + CStr(ws.Cells(iRow, iCol).Value) + """},"
                        End If
                    Next iCol
                    'remove the last ',' from the inputs and add closing brackets
                    JSONString = JSONString.Remove(JSONString.Length - 1) + "]}"

                    If iRow + 1 <= lastRow And CStr(ws.Cells(iRow + 1, 1).value) = "" Then
                        JSONString = JSONString + ","
                    End If
                End While
                inputString = "{" + token + "," + JSONString + "]}]}"
            End If
            'MsgBox(inputString)
            'ws.Cells(10, 1).value = inputString
            Try
                'Post the request
                objHTTP.Send(inputString)
                'Retrieve and store the response of the post
                response = CStr(objHTTP.ResponseText)
                'check if the post was successfull and display the results
                If objHTTP.Status = 200 Then
                    'Display the HTTP status for each row, if the status setting was checked
                    If GetSetting(clsUtility.keyProductName, clsUtility.keyConfiguration, "Status", True) = True Then
                        ws.Cells(iRow, iCol + 1).Value = CStr(objHTTP.Status)
                        iCol = iCol + 1
                    End If
                    'Display the input JSON for each row, if the Input setting was checked
                    If GetSetting(clsUtility.keyProductName, clsUtility.keyConfiguration, "Input", True) = True Then
                        ws.Cells(iRow, iCol + 1).Value = JSONString
                        iCol = iCol + 1
                    End If
                    ''Display the Return IDs for each row, if the Return ID setting was checked
                    If GetSetting(clsUtility.keyProductName, clsUtility.keyConfiguration, "ReturnIDs", True) = True Then
                        'Orchestrations used to return data after the summary label, then after the data label
                        'Now with Orchestration Output(available starting in AIS Version 9.2.1.2)
                        'the summary And Data tags are no longer present And the errors tag only appear if there are errors

                        'Check for Orchestration Return IDs in newer versions
                        If InStr(response, "data") Then
                            ws.Cells(iRow, iCol + 1).Value = "{" + getResponse(response, ",""data"":{", "}}") + "}}"
                            'Check for Orchestration Return IDs in older versions
                        ElseIf InStr(response, "summary") Then
                            ws.Cells(iRow, iCol + 1).Value = getResponse(response, "{", ",""summary"":{")
                            'ws.Cells(iRow, iCol + 5).value = response
                            'Check for Orchestration Output with Errors (available since 9.2.1.2)
                        ElseIf InStr(response, "Errors") Then
                            endPos = InStr(response, "Errors")
                            ws.Cells(iRow, iCol + 1).Value = Left(response, endPos - 3) + "}"
                            'if none of the conditions are met print the whole response
                            'This should only print for Orchestration Output without errors (available since 9.2.1.2)
                        Else
                            ws.Cells(iRow, iCol + 1).Value = response
                        End If
                        iCol = iCol + 1
                    End If
                    'Display the JDE Warning message for each row, if the Warning setting was checked
                    If GetSetting(clsUtility.keyProductName, clsUtility.keyConfiguration, "Warnings", True) = True Then
                        'ws.Cells(iRow, iCol + 1).Value = getResponse(response, """warnings"":[", "]")
                        'updated because warning responses may have different capitalization
                        ws.Cells(iRow, iCol + 1).Value = getResponseUpper(response, """warnings"":[", "]")
                        iCol = iCol + 1
                    End If
                    'Display the JDE Error message for each row, if the Error setting was checked
                    If GetSetting(clsUtility.keyProductName, clsUtility.keyConfiguration, "Errors", True) = True Then
                        'ws.Cells(iRow, iCol + 1).Value = getResponse(response, """errors"":[", "]")
                        'updated because error responses may different capitalization
                        ws.Cells(iRow, iCol + 1).Value = getResponseUpper(response, """errors"":[", "]")
                        iCol = iCol + 1
                    End If
                    'Resize any large rows to a max of 100
                    If ws.Cells(iRow, 1).EntireRow.RowHeight > 100 Then
                        ws.Cells(iRow, 1).EntireRow.RowHeight = 100
                    End If
                    'If the post was not successfull, then display the error message and release the token
                Else
                    result = MessageBox.Show("HTTP " + Convert.ToString(objHTTP.Status) + " " + Convert.ToString(objHTTP.StatusText) + vbCrLf + "Do you want to continue?", clsUtility.dialogTitle, MessageBoxButtons.YesNo)
                    If result = DialogResult.No Then
                        url = "https://" + server + ":" + port + "/jderest/tokenrequest/logout"
                        logoutHTTP = New WinHttpRequest()
                        logoutHTTP.Option(WinHttp.WinHttpRequestOption.WinHttpRequestOption_SslErrorIgnoreFlags) = WinHttp.WinHttpRequestSslErrorFlags.SslErrorFlag_Ignore_All            'Ignore SSL errors, The code works when I enable this, but then it is insecure                                                                                                                                     
                        logoutHTTP.Open("POST", url, False)

                        logoutHTTP.SetRequestHeader("Content-type", "application/json")
                        logoutHTTP.SetRequestHeader("Accept", "application/json")
                        logoutHTTP.Send("{" + token + "}")

                        logoutHTTP = Nothing
                        objHTTP = Nothing

                        xlApp.StatusBar = " "
                        xlApp.ScreenUpdating = True
                        Exit Sub
                    End If
                End If
            Catch ex As Exception
                'release the token if there was an exception
                MessageBox.Show(ex.Message.ToString(), clsUtility.dialogTitle)
                url = "https://" + server + ":" + port + "/jderest/tokenrequest/logout"

                logoutHTTP = New WinHttpRequest()
                logoutHTTP.Open("POST", url, False)
                logoutHTTP.Option(WinHttp.WinHttpRequestOption.WinHttpRequestOption_SslErrorIgnoreFlags) = WinHttp.WinHttpRequestSslErrorFlags.SslErrorFlag_Ignore_All            'Ignore SSL errors, The code works when I enable this, but then it is insecure                                                                                                                                     
                logoutHTTP.SetRequestHeader("Content-type", "application/json")
                logoutHTTP.SetRequestHeader("Accept", "application/json")
                logoutHTTP.Send("{" + token + "}")
                logoutHTTP = Nothing
                objHTTP = Nothing

                xlApp.StatusBar = " "
                xlApp.ScreenUpdating = True
                Exit Sub
            End Try
            'update the status bar with the current progress
            xlApp.StatusBar = "Progress: " & CStr(iRow - firstRow + 1) & " of " & CStr(lastRow - firstRow + 1) & " (" & CStr(CInt(100 * (iRow - firstRow + 1) / (lastRow - firstRow + 1))) & ")%"
        Next
        'logout and release the token
        url = "https://" + server + ":" + port + "/jderest/tokenrequest/logout"
        logoutHTTP = New WinHttpRequest()
        logoutHTTP.Open("POST", url, False)
        logoutHTTP.Option(WinHttp.WinHttpRequestOption.WinHttpRequestOption_SslErrorIgnoreFlags) = WinHttp.WinHttpRequestSslErrorFlags.SslErrorFlag_Ignore_All            'Ignore SSL errors, The code works when I enable this, but then it is insecure                                                                                                                                     
        logoutHTTP.SetRequestHeader("Content-type", "application/json")
        logoutHTTP.SetRequestHeader("Accept", "application/json")
        logoutHTTP.Send("{" + token + "}")

        logoutHTTP = Nothing
        objHTTP = Nothing

        xlApp.StatusBar = " "
        xlApp.ScreenUpdating = True
        'ws.Protect()

    End Sub

    Private Function IsEditing() As Boolean
        'Function to test if a cell is currently being edited
        Dim xlApp As Excel.Application
        xlApp = Globals.ThisAddIn.Application

        If xlApp.Interactive = False Then Return False
        Try
            xlApp.Interactive = False
            xlApp.Interactive = True
        Catch
            MessageBox.Show("Excel Is currently editing a cell." + vbCrLf + "Please exit the cell And try again.", clsUtility.dialogTitle)
            Return True
        End Try
        Return False
    End Function

    Private Function getResponse(tempStr As String, responseType As String, lastChar As String) As String
        'parse a response to look for a particular type
        Dim startPos As Integer, endPos As Integer
        'determine the starting and ending positions
        '+1 to start on the next character after "
        startPos = InStr(tempStr, responseType) + Len(responseType) 'the length of the responseType is added to start after the responseType
        endPos = InStr(startPos, tempStr, lastChar)
        If endPos > 0 Then
            getResponse = Trim(Mid(tempStr, startPos, endPos - startPos))
        Else
            getResponse = ""
        End If

    End Function
    Private Function getResponseUpper(tempStr As String, responseType As String, lastChar As String) As String
        'This is the same as Get Response, ecept this function uses upper case
        'parse a response to look for a particular type
        Dim startPos As Integer, endPos As Integer
        'determine the starting and ending positions
        '+1 to start on the next character after "
        startPos = InStr(tempStr.ToUpper(), responseType.ToUpper()) + Len(responseType) 'the length of the responseType is added to start after the responseType
        endPos = InStr(startPos, tempStr, lastChar)
        If endPos > 0 Then
            getResponseUpper = Trim(Mid(tempStr, startPos, endPos - startPos))
        Else
            getResponseUpper = ""
        End If

    End Function


    'Designate each row as a header or detail record based on if the first column is populated
    '    Private Sub btnHeaderDetail_Click(sender As Object, e As RibbonControlEventArgs)
    '        'Call postData here
    '        Dim iRow As Long
    '        Dim wk As Excel.Workbook
    '        Dim ws As Excel.Worksheet
    '        Dim firstRow As Long
    '        Dim lastRow As Long

    '        Dim tempRow As String

    '        Dim xlApp As Excel.Application

    '        Dim ServicePoint As New clsServicePoints

    '        xlApp = Globals.ThisAddIn.Application

    '        'Check if the user is currently editing a cell
    '        If IsEditing() = True Then
    '            Exit Sub
    '        End If

    '        'Check worksheet prop to verify it is header detail
    '        '''''''''''''''''''''''''''''''''''''''''''''''''
    '        ''''''''''''''''''''''''''''''''''''''''''''''''''

    '        wk = xlApp.ActiveWorkbook
    '        ws = wk.ActiveSheet

    '        firstRow = GetSetting(clsUtility.keyProductName, clsUtility.keyConfiguration, "HeaderRows", 3)
    '        tempRow = GetSetting(clsUtility.keyProductName, clsUtility.keyConfiguration, "LastRow", "")

    '        If tempRow.ToString().Trim() = "0" Or tempRow.ToString().Trim() = "" Then
    '            lastRow = ws.UsedRange.Rows.Count
    '        Else
    '            lastRow = tempRow
    '        End If

    '        If lastRow > ws.UsedRange.Rows.Count Then
    '            lastRow = ws.UsedRange.Rows.Count
    '        End If

    '        xlApp.ScreenUpdating = False

    '        'Loop for each row
    '        For iRow = firstRow To lastRow
    '            If CStr(ws.Cells(iRow, 2).value) = "" Then
    '                ws.Cells(iRow, 1).value = "D"
    '            Else
    '                ws.Cells(iRow, 1).value = "H"
    '            End If
    '        Next iRow

    '        xlApp.ScreenUpdating = True


    '    End Sub
End Class
