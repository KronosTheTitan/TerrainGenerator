using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrainGenerator;
class MountainRidge
{
    Mountain a;
    Mountain b;
    public float direction;
    public MountainRidge(Mountain pA, Mountain pB)
    {
        if (pA.position.z < pB.position.z)
        {
            b = pA;
            a = pB;
        }
        else
        {
            a = pA;
            b = pB;
        }
        Vector2 dir = new Vector2(a.position.x - b.position.x, a.position.y - b.position.y);
    }
}
