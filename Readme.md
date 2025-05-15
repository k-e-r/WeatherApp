# 🌤️ WeatherApp

A simple web application built with **.NET 9** and **ASP.NET Core MVC** that allows users to check current weather conditions for a given city using the [WeatherAPI](https://www.weatherapi.com/).

## Live Demo
https://weatherapp-vqri.onrender.com/

## Features
- Search weather by city name
- Uses [WeatherAPI](https://www.weatherapi.com/) for real-time weather data
- Secure API key management via environment variables
- Docker support for containerized deployment
- CI pipeline with GitHub Actions
- Auto-deployment to [Render](https://render.com)

## Tech Stack
- **Backend:** ASP.NET Core MVC (.NET 9)
- **DevOps:** Docker, GitHub Actions
- **Hosting:** Render
- **API:** WeatherAPI

## CI/CD with GitHub Actions
This project uses [GitHub Actions](https://github.com/features/actions) for continuous integration.
The CI workflow includes:

- Building and publishing the .NET app
- (Optional) Testing steps
- Auto-deploy to Render on push to `main`

You can find the workflow file in:

```
.github/workflows/ci.yml
```

### CI Status Badge
![CI](https://github.com/k-e-r/WeatherApp/actions/workflows/ci.yml/badge.svg)

## Docker Usage
To build and run the app with Docker:

```bash
docker build -t weatherapp .
docker run -e WEATHER_API_KEY=your_api_key_here -p 8080:80 weatherapp
```

## Environment Variables
Set the following environment variable before running the app:

- `WEATHER_API_KEY`: Your WeatherAPI key

## License
MIT © 2025 Kaori Era
