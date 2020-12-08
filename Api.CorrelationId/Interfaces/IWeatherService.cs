using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.CorrelationId.Interfaces
{
    public interface IWeatherService
    {
        IEnumerable<WeatherForecast> DoSomething();
    }
}
