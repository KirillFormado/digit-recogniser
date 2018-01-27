using System.Collections.Generic;
using DigitRecognitionService;

public interface IClassifier
{
    void Train(IList<Observation> trainingSet);
    string Predict(IList<int> pixels);
}
