using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrainGenerator;
class MountainRidge
{
    public Mountain a;
    public Mountain b;
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
        a.ridges.Add(this);
        b.ridges.Add(this);
        direction = dir.GetAngleDegrees();
    }
    public float GetSlopeFactorA()
    {
        float f = 0;
        Vector3 dist = a.position - b.position;
        float dZ = a.position.z - b.position.z;
        f = dZ / dist.LengthXY();
        return f;
    }    public float GetSlopeFactorB()
    {
        float f = 0;
        Vector3 dist = b.position - a.position;
        float dZ = b.position.z - a.position.z;
        f = dZ / dist.LengthXY();
        return f;
    }
    public float directionB2D()
    {
        float f;
        Vector2 dist = Vector2.FromVector3(a.position) - Vector2.FromVector3(b.position);
        f = dist.GetAngleDegrees();
        return f;
    }
    public float directionA2D()
    {
        float f;
        Vector2 dist = Vector2.FromVector3(b.position) - Vector2.FromVector3(a.position);
        f = dist.GetAngleDegrees();
        return f;
    }
}
