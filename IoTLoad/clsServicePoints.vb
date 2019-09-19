Imports System.Net.WebClient
Imports System.Net
Imports System.Windows.Forms
Imports WinHttp
Public Class clsServicePoints
    'function to test the connection to the AIS server
    'this does not test the validity of jde user credentials
    'can be updated in the future to request a token (and release) to test user credentials
    Public Function testConnection(server As String, port As String, userName As String, password As String, Optional ByRef aisVersion As String = "") As Boolean
        testConnection = False

        Dim URL As String
        Dim objHTTP As WinHttpRequest
        'Dim objHTTP As Object 'WinHttp.WinHttpRequest 'Was used for testing, works as well
        Dim httpResponse As String
        Dim startPos As Integer
        Dim endPos As Integer

        objHTTP = New WinHttpRequest()

        'objHTTP = CreateObject("WinHttp.WinHttpRequest.5.1") 'Used for testing works too

        'build URL to default config page of AIS server        
        URL = "https://" + server + ":" + port + "/jderest/defaultconfig"
        objHTTP.Open("GET", URL, False)
        'Next line is need to ignore self-signed SSL errors
        objHTTP.Option(WinHttp.WinHttpRequestOption.WinHttpRequestOption_SslErrorIgnoreFlags) = WinHttp.WinHttpRequestSslErrorFlags.SslErrorFlag_Ignore_All            'Ignore SSL errors, The code works when I enable this, but then it is insecure                                                                                                                                     
        'certResponse = objHTTP.SetClientCertificate("LOCAL_MACHINE\Personal\JDExcelerator Cert") 'Perhaps use this to self sign app, not sure if this is needed at all
        'objHTTP.Option(9) = 2048 'Different options I saw when trying to get TLS 1.2 to work - not a valid value for Windows 7
        'objHTTP.Option(9) = 2070 'Different options I saw when trying to get TLS 1.2 to work - not a valid value for Windows 7
        objHTTP.SetRequestHeader("Content-type", clsUtility.contentType)
        objHTTP.SetRequestHeader("Accept", clsUtility.contentType)

        Try

            'test if we can connect to the default config page of AIS server
            objHTTP.Send()
            'check server status 

            If objHTTP.Status = 200 Then
                httpResponse = objHTTP.ResponseText
                'find where the AIS version is specified in the default config response text
                startPos = InStr(InStr(httpResponse, "aisVersion"), httpResponse, ":") + 1
                endPos = InStr(startPos, httpResponse, ",")
                'store the AIS version for branching newer functionality
                aisVersion = Trim(Mid(httpResponse, startPos, endPos - startPos - 1))
                aisVersion = aisVersion.Remove(0, 1)
                'the AIS version can be prefixed with "EnterpriseOne"  this should be removed to determine the real AIS version

                If Left(aisVersion, 13) = "EnterpriseOne" Then
                    aisVersion = Trim(Mid(aisVersion, 14, Len(aisVersion) - 13))
                End If

                'store the AIS version
                clsUtility.aisVersion = aisVersion
                testConnection = True

            Else
                '    MessageBox.Show("HTTP " + CStr(objHTTP.Status) + " " + CStr(objHTTP.StatusText), clsUtility.dialogTitle)
                testConnection = False
            End If
            objHTTP = Nothing
        Catch ex As Exception
            testConnection = False
        End Try
    End Function

    Public Function checkLicense(action As String) As Boolean

        checkLicense = True

    End Function
End Class
