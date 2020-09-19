Public NotInheritable Class ServiceResponse(Of T)

    Public ReadOnly Property Result As T
    Public ReadOnly Property Reason As String


    Public Sub New(result As T, reason As String)
        Me.Result = result
        Me.Reason = reason
    End Sub

End Class
