using System.Collections.Generic;

public interface IDistance 
{ 
    double Between(IList<int> pixels1, IList<int> pixels2); 
}
