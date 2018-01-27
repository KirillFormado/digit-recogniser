using System;
using Xunit;
using DigitRecognitionService;
using System.Collections.Generic;

namespace DigitRecognitionServiceUnitTests
{
    public class DataReaderTests
    {
        [Fact]
        public void ObservationFactory_SetNull_Null()
        {
            var result = DataReader.ObservationFactory(null);
            Assert.Null(result);
        }       

        [Fact]
        public void ObservationFactory_SetEmptyString_Null()
        {
            var result = DataReader.ObservationFactory(string.Empty);
            Assert.Null(result);
        }       

        [Fact]
        public void ObservationFactory_SetStringWithoutData_Null()
        {
            var result = DataReader.ObservationFactory("1");
            Assert.Null(result);
        }

        [Fact]
        public void ObservationFactory_SetCorrectString_CorrectObject()
        {
            var result = DataReader.ObservationFactory("1, 0, 0, 123");
            Assert.Equal("1", result.Label);
            Assert.Equal<int>(new List<int> { 0, 0, 123 }, result.Data);
        } 
    }
}
