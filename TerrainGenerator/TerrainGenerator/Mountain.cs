using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrainGenerator;
class Mountain
{
    public Vector3 position;
    public List<MountainRidge> ridges;
    public Mountain(int x,int y,int z)
    {
        position = new Vector3(x, y, z);
    }
    public float GetHeightEffect(int x,int y)
    {
        float height = 0;

        Vector2 pixel = new Vector2(x, y);
        Vector2 mt = Vector2.FromVector3(position);
        Vector2 dist = mt - pixel;
        float dirToPixel = dist.GetAngleDegrees();
        MountainRidge cL;
        float closestLrot = 1000f;
        float slopeL=0;
        foreach(MountainRidge ridge in ridges)
        {
            if(ridge.a == this)
            {
                float f = ridge.directionA2D();
                if (closestLrot < f)
                {
                    closestLrot = f;
                    cL = ridge;
                    slopeL = ridge.GetSlopeFactorA();
                }
            }
            else
            {
                float f = ridge.directionB2D();
                if (closestLrot < f)
                {
                    closestLrot = f;
                    cL = ridge;
                    slopeL = ridge.GetSlopeFactorB();
                }

            }
        }
        MountainRidge cR;
        float closestRrot = 1000f;
        float slopeR = 0;
        foreach (MountainRidge ridge in ridges)
        {
            if (ridge.a == this)
            {
                float f = ridge.directionA2D();
                if (closestRrot > f)
                {
                    closestRrot = f;
                    cR = ridge;
                    slopeR = ridge.GetSlopeFactorA();
                }
            }
            else
            {
                float f = ridge.directionB2D();
                if (closestRrot > f)
                {
                    closestRrot = f;
                    cR = ridge;
                    slopeR = ridge.GetSlopeFactorB();
                }
            }
        }
        float rotWindow = closestLrot - closestRrot;
        float slopeWindow = slopeL - slopeR;
        slopeWindow /= rotWindow;
        float slopeFactor = slopeWindow * (closestLrot - dirToPixel);
        height = Mathf.Clamp(position.z - (dist.Length() * slopeFactor), 0, 255);
        return height;
    }
    public void AddRidges()
    {
        if (ridges.Count >= 4) return;
        for (int i = ridges.Count; i < 4; i++)
        {
            float randomDist = position.z + Utils.Random(position.z*.75f, position.z * 2);
            float direction = Utils.Random(0,360);
            if(ridges.Count > 0)
            {
                foreach (MountainRidge mountainRidge in ridges)
                {
                    if (mountainRidge.a == this)
                    {
                        float f = mountainRidge.directionA2D() - direction;
                        if (f > -45 && f < 45)
                        {

                        }
                    }
                    else
                    {
                        float f = mountainRidge.directionB2D() - direction;
                        if (f > -45 && f < 45)
                        {

                        }
                    }
                }
            }
        }
    }
}
