Imports System.Net.Http
Imports System.Net.Http.Headers

Public NotInheritable Class NoaaWeatherService


#Region "Methods"


    Private Function CreateHttpClient() As HttpClient
        Dim baseUrl As String = "https://graphical.weather.gov/xml/sample_products/browser_interface/ndfdXMLclient.php"

        Dim httpClient As New HttpClient With {
            .BaseAddress = New Uri(baseUrl)
        }
        httpClient.DefaultRequestHeaders.Add("User-Agent", "Dynamensions Weather Nuget Package")
        httpClient.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue("applicaton/json"))
        Return httpClient
    End Function

    Private Async Function SendRequestAsync(url As String) As Task(Of String)
        Dim baseUrl As String = "https://graphical.weather.gov/xml/sample_products/browser_interface/ndfdXMLclient.php"

        Using httpClient As New HttpClient()
            httpClient.BaseAddress = New Uri(baseUrl)
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Dynamensions Weather Nuget Package")
            httpClient.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue("applicaton/json"))

            Return Await httpClient.GetStringAsync(url)
        End Using

    End Function



    Public Async Function GetLatitudeLongitudeByZipCode(zipCode As String) As Task(Of ServiceResponse(Of LatitudeLongitude))

        Dim reason As String = String.Empty
        Dim result As New LatitudeLongitude

        Using client As HttpClient = CreateHttpClient()
            Dim response As HttpResponseMessage = Await client.GetAsync($"?listZipCodeList={zipCode}")
            If Not response.IsSuccessStatusCode Then
                reason = response.ReasonPhrase
            Else
                ' read the response
                Dim document As XDocument = XDocument.Parse(Await response.Content.ReadAsStringAsync())
                ' parse the string
                Dim latlongList As String = document.Root.<latLonList>.Value
                If String.IsNullOrWhiteSpace(latlongList) Then
                    reason = "Result was empty"
                Else
                    ' dissect the zipcode (it will have one comma)
                    Dim parts() As String = latlongList.Split(","c)

                    Dim latidude, longitude As Double
                    Double.TryParse(parts(0), latidude)
                    Double.TryParse(parts(1), longitude)

                    result = New LatitudeLongitude(latidude, longitude)
                End If
            End If
        End Using

        Return New ServiceResponse(Of LatitudeLongitude)(result, reason)
    End Function

#End Region

End Class
