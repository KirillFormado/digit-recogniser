using System;
using System.Collections.Generic;

public class ManhattanDistance : IDistance
{
    public double Between(IList<int> pixels1, IList<int> pixels2)
    {
        if (pixels1.Count != pixels2.Count)
        {
            throw new ArgumentException("Inconsistent image sizes.");
        }

        var length = pixels1.Count;

        var distance = 0;

        for (int i = 0; i < length; i++)
        {
            distance += Math.Abs(pixels1[i] - pixels2[i]);
        }

        return distance;
    }
}
