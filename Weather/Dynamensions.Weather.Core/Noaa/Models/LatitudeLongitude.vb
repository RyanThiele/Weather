
''' <summary>
''' The latitude or longitude for a point on 
''' </summary>
Public Structure LatitudeLongitude


    Public ReadOnly Property Latitude As Double
    Public ReadOnly Property Longitude As Double


    Public Sub New(latitude As Double, longitude As Double)
        Me.Latitude = latitude
        Me.Longitude = longitude
    End Sub

End Structure
