using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrainGenerator;
class MountainChain
{
    List<Mountain> mountains;
    public void AddToChain(Mountain input)
    {
        if (mountains.Contains(input)) return;
        mountains.Add(input);
    }
}
