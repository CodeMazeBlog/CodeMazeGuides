// <copyright file="WeatherForecast.cs" company="CodeMaze">
// Copyright (c) CodeMaze. All rights reserved.
// </copyright>

namespace StyleCop
{
    public class WeatherForecast
    {
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
}