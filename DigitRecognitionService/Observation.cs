using System;
using System.Collections.Generic;

namespace DigitRecognitionService
{
    public class Observation
    {
        public IList<int> Data { get; }
        public string Label { get; }

        public Observation(string label, IList<int> data) : this(data)
        {
            Label = label;
        }

        public Observation(IList<int> data)
        {
            Data = data;
        }
    }
}
