using Api.CorrelationId.Service;
using Microsoft.Extensions.Logging;
using System;
using Xunit;
using Moq;

namespace xUnit.ILogger.Tests
{


    public class SampleTests 
    {
        
        private readonly Mock<ILogger<WeatherService>> _loggerMock;

        public SampleTests( )
        {
             
            _loggerMock = new Mock<ILogger<WeatherService>>();
        }

        
 

        [Fact]
        public void SampleTest()
        {

            var service = new WeatherService(_loggerMock.Object);
            service.DoSomething();

            _loggerMock.Verify(l => l.Log(
               LogLevel.Debug,
               It.IsAny<EventId>(),
               It.IsAny<It.IsAnyType>(),
               It.IsAny<Exception>(),
               (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()), Times.Exactly(1));
        }


        
    }
}
