Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System.Xml

Public Class clsGlobal
    Private server As String
    Private port As String
    Private authorizationUserName As String
    Private authorizationPassword As String
    private authorization as String
    Private colon as String

    Public Sub refreshWorksheet(SelectedIndexVal As String, headerDetail As Boolean)
        Dim inputs As New List(Of String)
        Dim tempType As String
        Dim xlApp As Excel.Application
        xlApp = Globals.ThisAddIn.Application
        Dim oWorkbook As Excel.Workbook
        oWorkbook = xlApp.ActiveWorkbook
        Dim oWorkSheet As Excel.Worksheet
        oWorkSheet = oWorkbook.ActiveSheet
        Dim startCol As Integer = 0

        'Retrieve the inputs from the selected orchestration
        inputs = parseJSON(SelectedIndexVal)
        oWorkSheet.Unprotect()
        xlApp.DisplayAlerts = False

        'clear the worksheet and turn all cells gray
        With oWorkSheet
            .Cells.ClearContents()
            .Cells.Interior.ColorIndex = 15
            .Cells.Locked = True
        End With

        'check number of inputed
        If inputs.Count = 0 Then
            xlApp.DisplayAlerts = True
            'oWorkSheet.Protect()
            MessageBox.Show("The Orchestration Does Not Contain Any Inputs.", clsUtility.dialogTitle)
            Return
        End If


        'uncomment this if we want to show the header detail designation in the first column
        'If headerDetail = True Then

        '    oWorkSheet.Range(xlApp.Columns(1), xlApp.Columns(inputs.Count + 1)).Locked = False
        '    'oWorkSheet.Range("A1:D2").Interior.ColorIndex = 15
        '    oWorkSheet.Range(xlApp.Columns(1), xlApp.Columns(inputs.Count + 1)).Interior.ColorIndex = -4142

        '    oWorkSheet.Cells(1, 1).Value = "Header/Detail"
        '    oWorkSheet.Cells(1, 1).Locked = True
        '    oWorkSheet.Cells(1, 1).Font.Bold = True
        '    oWorkSheet.Cells(1, 1).Interior.ColorIndex = 15
        '    oWorkSheet.Cells(2, 1).Locked = True
        '    oWorkSheet.Cells(2, 1).EntireRow.Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous
        '    oWorkSheet.Cells(2, 1).EntireRow.Borders(Excel.XlBordersIndex.xlEdgeBottom).Weight = XlBorderWeight.xlMedium
        '    oWorkSheet.Cells(2, 1).Interior.ColorIndex = 15
        '    oWorkSheet.Cells(2, 1).Font.Bold = True
        '    oWorkSheet.Cells(2, 1).EntireColumn.AutoFit
        '    startCol = 2
        'Else

        'make the input cells white
        oWorkSheet.Range(xlApp.Columns(1), xlApp.Columns(inputs.Count)).Locked = False
            'oWorkSheet.Range("A1:D2").Interior.ColorIndex = 15
            oWorkSheet.Range(xlApp.Columns(1), xlApp.Columns(inputs.Count)).Interior.ColorIndex = -4142

            startCol = 1
        '       End If


        'loop through the inputs and populate the input names and types in column headers
        'update the formatting of the column headers
        For i As Integer = 0 To inputs.Count - 1
            With oWorkSheet
                .Cells(1, startCol + i).Value = getJSONKey(inputs.Item(i), "name", ",")
                .Cells(1, startCol + i).Locked = True
                .Cells(1, startCol + i).Font.Bold = True
                .Cells(1, startCol + i).Interior.ColorIndex = 15

                'retrieve the data type for the input
                tempType = getJSONKey(inputs.Item(i), "type", "}").Trim()
                '.Cells(2,i+1).Value="(" + Left(tempType, Len(tempType) - 3) + ")"
                .Cells(2, startCol + i).Value = "(" + Left(tempType, InStr(tempType, """") - 1) + ")"
                .Cells(2, startCol + i).Locked = True
                .Cells(2, startCol + i).EntireRow.Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous
                .Cells(2, startCol + i).EntireRow.Borders(Excel.XlBordersIndex.xlEdgeBottom).Weight = XlBorderWeight.xlMedium
                .Cells(2, startCol + i).Interior.ColorIndex = 15
                .Cells(2, startCol + i).Font.Bold = True
                .Cells(2, startCol + i).EntireColumn.AutoFit
            End With
        Next

        'freeze the header rows
        xlApp.Rows("3:3").Select
        xlApp.ActiveWindow.FreezePanes = True
        oWorkSheet.Cells(3, 1).Select
        xlApp.ScreenUpdating = True
        'Try
        'oWorkSheet.Protect()
        'Catch ex As Exception

        'End Try
    End Sub

    Public Property _authorization() As String
        Get
            Return authorization
        End Get
        Set(value As String)
            authorization=value
        End Set
    End Property
    Public Property _server() As String
        Get
            Return server
        End Get
        Set(value As String)
            server=value
        End Set
    End Property
    Public Property _port() As String
        Get
            Return port
        End Get
        Set(value As String)
            port=value
        End Set
    end property
    Public Property _authorizationUsername() As String
        Get
            Return authorizationUserName
        End Get
        Set(value As String)
            authorizationUserName=value
        End Set
    End Property
    Public Property _authorizationPassword() As String
        Get
            Return authorizationPassword
        End Get
        Set(value As String)
            authorizationPassword=value
        End Set
    End Property
    Public Property _colon() As String
        Get
            Return colon
        End Get
        Set(value As String)
            colon=value
        End Set
    End Property
Public Function parseJSON(inputJSON As String) As List(Of String)
        'Parse the discovery JSON to retrieve the input fields and data types
        Dim startPos As Integer
        Dim endPos As Integer
        Dim tempJSON As String
    Dim resultJSON As new List(Of String)
    Dim i As Long
    Dim count As Integer
        'findthe start and end characters of the inputs from the discovery service
        startPos = InStr(inputJSON, "[") + 1
    endPos = InStrRev(inputJSON, "]")
    If endPos > startPos Then
        tempJSON = Trim(Mid(inputJSON, startPos, endPos - startPos))
    Else
        tempJSON = ""
    End If

    i = 1
    count = -1
    startPos = 0

        'iterate through the JSON to find each input between the { and } delimiters
        While i <= Len(tempJSON)
        If Mid(tempJSON, i, 1) = "{" Then
            If count = -1 Then
                startPos = i
                count = 1
            Else
                count = count + 1
            End If
        ElseIf Mid(tempJSON, i, 1) = "}" Then
            count = count - 1
        End If
        If count = 0 Then
            endPos = i
            count = -1
        
            resultJSON.Add(Mid(tempJSON, startPos, endPos - startPos + 1))
        
        End If
        i = i + 1
    End While

parseJSON = resultJSON

End Function

Public Function getJSONKey(tempStr As String, keyName As String, lastChar As String) As String
        'parse a response to look for a particular type
        Dim startPos As Integer, endPos As Integer
        'determine the starting and ending positions
        'Add 5 to startPos because JSON contains the following 4 characters ": " +1 to start on the next character after "
        startPos = InStr(tempStr, keyName) + Len(keyName) + 5
        endPos = InStr(startPos, tempStr, lastChar)
        getJSONKey = Trim(Mid(tempStr, startPos, endPos - startPos - 1))

End Function

End Class
