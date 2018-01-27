using System.Collections.Generic;
using DigitRecognitionService;

public class BasicClassifier : IClassifier
{
    private IList<Observation> _data;

    private readonly IDistance distance;

    public BasicClassifier(IDistance distance)
    {
        this.distance = distance;
    }

    public void Train(IList<Observation> trainingSet)
    {
        _data = trainingSet;
    }

    public string Predict(IList<int> data)
    {
        Observation currentBest = null;
        var shortest = double.MaxValue;
        foreach (Observation obs in _data)
        {
            var dist = distance.Between(obs.Data, data);
            if (dist < shortest)
            {
                shortest = dist; currentBest = obs;
            }
        }

        return currentBest.Label;
    }
}
