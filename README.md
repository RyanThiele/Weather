# Weather
A universal weather nuget package

## Builds
CI Build Status (Builds from Pull Requests)
[![Build status](https://dynamensions.visualstudio.com/Open%20Source/_apis/build/status/Weather%20CI%20Pipline)](https://dynamensions.visualstudio.com/Open%20Source/_build/latest?definitionId=28)

## Overview
This will start with NOAA's weather stations, but will expand to other weather stations and will eventually become atronomical for stargazers.

### NOAA
National Oceanic and Atmospheric Administration one of North America's top weather providers. They have a back end that parses weather stations around North America (including some places outside of North America) and provide a REST service to query the stations data be either latitude/longitude, or by zip code. The service provides a wide veriety of informaiton including:
- Current Observations
- Forecasts
- Hazordous weather alerts
- Fire alerts
- Volcano Alerts
- Hurricane Tracking
- Tornado Tracking


## Project Structure
We will attempt to structure this in OOP, and not an SOA paradigm. Each weather *service* will have it's own container.