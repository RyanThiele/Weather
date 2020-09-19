Imports Dynamensions.Weather.Core
Imports Xunit

Public Class GetLatitudeLongitudeByZipCodeTests

    <Theory>
    <InlineData("20910", 39.0138, -77.0242)>
    <InlineData("25414", 39.2851, -77.8575)>
    Public Async Function GetLatitudeLongitudeByZipCode_ValidZipCode_ShouldReturnLatitudeLongitude(zipcode As String,
                                                                                                   latitude As Double,
                                                                                                   longitude As Double) As Task

        ' Arrange
        Dim service As New NoaaWeatherService()

        ' Act
        Dim result As ServiceResponse(Of LatitudeLongitude) = Await service.GetLatitudeLongitudeByZipCode(zipcode)


        ' Assert
        Assert.NotNull(result)
        Assert.True(String.IsNullOrEmpty(result.Reason))
        Assert.Equal(result.Result.Latitude, latitude)
        Assert.Equal(result.Result.Longitude, longitude)
    End Function

End Class
