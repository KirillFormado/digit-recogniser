using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DigitRecognitionService;
using System.IO;

namespace DigitRecognition.Controllers
{
    [Route("api/[controller]")]
    public class DigitController : Controller
    {
        private static IClassifier _classifier = new BasicClassifier(new ManhattanDistance()); 

        static DigitController()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "DigitRecognitionWeb", "wwwroot", "data", "train.csv");

            var data = DataReader.ReadObservations(path).ToList();
            _classifier.Train(data);
        }

        [HttpPost]
        public string Post([FromBody] IEnumerable<int> data)
        {            
            return _classifier.Predict(data.ToList());
        }
    }
}
