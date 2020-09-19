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
        Dim result As ServiceResponse(Of ZipCodeLatitudeLongitude) = Await service.GetLatitudeLongitudeByZipCode(zipcode)


        ' Assert
        Assert.NotNull(result)
        Assert.True(String.IsNullOrEmpty(result.Reason))
        Assert.Equal(result.Result.ZipCode, zipcode)
        Assert.Equal(result.Result.Latitude, latitude)
        Assert.Equal(result.Result.Longitude, longitude)
    End Function


    <Theory>
    <ClassData(GetType(ZipCodeData))>
    Public Async Function GetLatitudeLongitudeByZipCodes_ValidZipCodes_ShouldReturnListOfLatitudeLongitude(zipCodeLatitudeLongitude As ZipCodeLatitudeLongitude()) As Task

        ' Arrange
        Dim service As New NoaaWeatherService()

        ' Act
        Dim result As ServiceResponse(Of IEnumerable(Of ZipCodeLatitudeLongitude)) =
            Await service.GetLatitudeLongitudeByZipCodes(zipCodeLatitudeLongitude.Select(Function(data) data.ZipCode))


        ' Assert
        Assert.NotNull(result)
        Assert.True(String.IsNullOrEmpty(result.Reason))


        For index = 0 To zipCodeLatitudeLongitude.Length - 1
            Assert.Equal(result.Result(index).ZipCode, zipCodeLatitudeLongitude(index).ZipCode)
            Assert.Equal(result.Result(index).Latitude, zipCodeLatitudeLongitude(index).Latitude)
            Assert.Equal(result.Result(index).Longitude, zipCodeLatitudeLongitude(index).Longitude)
        Next

    End Function


    Private Class ZipCodeData
        Inherits TheoryData(Of ZipCodeLatitudeLongitude())

        Public Sub New()

            AddRow(New List(Of ZipCodeLatitudeLongitude)(
                   {New ZipCodeLatitudeLongitude("20910", 39.0138, -77.0242),
                   New ZipCodeLatitudeLongitude("25414", 39.2851, -77.8575)
                   }))

        End Sub


    End Class




End Class
