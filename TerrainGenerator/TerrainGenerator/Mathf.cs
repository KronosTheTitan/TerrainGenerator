using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrainGenerator;
class Mathf
{
    public static float Sqrt(float f)
    {
        return (float)Math.Sqrt(f);
    }
    public static float Clamp(float f,float min,float max)
    {
        if (f > max) return max;
        if (f < min) return min;
        return f;
    }
}
