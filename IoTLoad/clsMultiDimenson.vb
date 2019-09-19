Public Class clsMultiDimenson
    Public Property Name() As String
    Public Property Desc() As String
    Public Property Inputs() As String
    Public Sub New(oName as String,oDesc As String,oInputs as String)
        Name=oName
        Desc=oDesc
        Inputs=oInputs
    End Sub
    Public Function getData() As List(Of clsMultiDimenson)
        Dim DataList as New List(Of clsMultiDimenson)
        DataList.Add(New clsMultiDimenson(Name,Desc,Inputs))
        Return DataList
    End Function
    
End Class
