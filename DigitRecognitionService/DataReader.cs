using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace DigitRecognitionService
{
    public static class DataReader
    {
        public static Observation ObservationFactory(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
                return null;
            var pixels = data.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (pixels.Length <= 1)
                return null;
            var label = pixels[0];
            return new Observation(label, pixels.Skip(1).Select(p => Int32.Parse(p)).Select(i => i == 0 ? 0 : 1).ToList());
        }

        public static IEnumerable<Observation> ReadObservations(string dataPath)
        {
            var data = File
             .ReadAllLines(dataPath)
                .Skip(1)
                .Select(ObservationFactory)
                .ToList();

            return data;
        }
    }
}