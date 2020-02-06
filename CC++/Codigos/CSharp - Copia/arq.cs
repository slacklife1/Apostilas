Public Class Accounts
    Inherits CollectionBase

    Public Sub Add(ByVal Value As Account)
        Me.InnerList.Add(Value)
    End Sub
    
    Default Public ReadOnly Property Item(ByVal Index As Integer) As Account
        Get
            Return CType(MyBase.InnerList.Item(Index), Account)
        End Get
    End Property

End Class

Public Class Account
    Public CodeListings As New CodeListings()
    Public AccountName As String
    Public Selection As String
End Class

Public Class CodeListings
    Inherits CollectionBase

    Public Sub Add(ByVal CodeValue As Integer, _
        ByVal CodeDisplayValue As String, ByVal CodeDescription As String)
        Dim objCodeListing As New CodeListing()
        objCodeListing.CodeValue = CodeValue
        objCodeListing.CodeDisplayValue = CodeDisplayValue
        objCodeListing.CodeDescription = CodeDescription
        Me.InnerList.Add(objCodeListing)
    End Sub

End Class

Public Class CodeListing
    Public CodeValue As Integer
    Public CodeDisplayValue As String
    Public CodeDescription As String
End Class

