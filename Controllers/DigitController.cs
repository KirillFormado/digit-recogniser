using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace DigitRecognition.Controllers
{
    [Route("api/[controller]")]
    public class DigitController : Controller
    {        
        [HttpPost]
        public int Post([FromBody] IEnumerable<int> data)
        {
            var img = data;
            var isAny = img.Where(i => i != 0);
            return 1;
        }
    }
}
