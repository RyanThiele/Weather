Public Class ZipCodeLatitudeLongitude
    Inherits LatitudeLongitude

    Public ReadOnly Property ZipCode As String

    Public Sub New(zipcode As String, latitude As Double, longitude As Double)
        MyBase.New(latitude, longitude)

        Me.ZipCode = zipcode
    End Sub

End Class
