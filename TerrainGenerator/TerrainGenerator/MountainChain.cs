using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrainGenerator;
class MountainChain
{
    List<Mountain> mountains;
    List<MountainRidge> ridges;
    public void AddToChain(Mountain input)
    {
        if (mountains.Contains(input)) return;
        mountains.Add(input);
    }
}
