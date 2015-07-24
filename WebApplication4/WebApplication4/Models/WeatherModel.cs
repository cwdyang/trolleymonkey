
public class Rootobject
{
    public Weather weather { get; set; }
}

public class Weather
{
    public Curren_Weather[] curren_weather { get; set; }
    public Forecast[] forecast { get; set; }
}

public class Curren_Weather
{
    public string humidity { get; set; }
    public string pressure { get; set; }
    public string temp { get; set; }
    public string temp_unit { get; set; }
    public string weather_code { get; set; }
    public string weather_text { get; set; }
    public Wind[] wind { get; set; }
}

public class Wind
{
    public string dir { get; set; }
    public string speed { get; set; }
    public string wind_unit { get; set; }
}

public class Forecast
{
    public string date { get; set; }
    public Day[] day { get; set; }
    public string day_max_temp { get; set; }
    public Night[] night { get; set; }
    public string night_min_temp { get; set; }
    public string temp_unit { get; set; }
}

public class Day
{
    public string weather_code { get; set; }
    public string weather_text { get; set; }
    public Wind1[] wind { get; set; }
}

public class Wind1
{
    public string dir { get; set; }
    public string dir_degree { get; set; }
    public string speed { get; set; }
    public string wind_unit { get; set; }
}

public class Night
{
    public string weather_code { get; set; }
    public string weather_text { get; set; }
    public Wind2[] wind { get; set; }
}

public class Wind2
{
    public string dir { get; set; }
    public string dir_degree { get; set; }
    public string speed { get; set; }
    public string wind_unit { get; set; }
}
