using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrainGenerator;
class Mountain
{
    public Vector3 position;
    public float slopeFactor = 0.9f;
    public Mountain(int x,int y,int z,float slope = 0.5f)
    {
        position = new Vector3(x, y, z);
        slopeFactor = slope;
    }
}
