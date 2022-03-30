using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrainGenerator;
public struct Vector3
{
    public float x;
    public float y;
    public float z;
    public Vector3(float pX = 0, float pY = 0, float pZ = 0)
    {
        x = pX;
        y = pY;
        z = pZ;
    }
    public float Length()
    {
        float a = Mathf.Sqrt((x * x) + (z * z));
        return Mathf.Sqrt((a * a) + (y * y));
    }
    public float LengthXY()
    {
        return Mathf.Sqrt((x * x) + (y * y));
    }
    public void Normalize()
    {
        if (Length() == 0)
            return;
        float length = Length();
        x = x / length;
        y = y / length;
        z = z / length;
    }
    public Vector3 Normalized()
    {
        Vector3 output = new Vector3(x, y, z);
        output.Normalize();
        return output;
    }
    public void SetXY(float pX, float pY, float pZ)
    {
        x = pX;
        y = pY;
        z = pZ;
    }
    public static Vector3 operator +(Vector3 left, Vector3 right)
    {
        return new Vector3(left.x + right.x, left.y + right.y);
    }
    public static Vector3 operator -(Vector3 left, Vector3 right)
    {
        return new Vector3(left.x - right.x, left.y - right.y);
    }
    public static Vector3 operator *(Vector3 left, float right)
    {
        return new Vector3(left.x * right, left.y * right);
    }
    public static Vector3 operator *(float left, Vector3 right)
    {
        return new Vector3(left * right.x, left * right.y);
    }
    public static Vector3 operator /(float left, Vector3 right)
    {
        return new Vector3(left / right.x, left / right.y);
    }
    public static Vector3 operator /(Vector3 left, float right)
    {
        return new Vector3(left.x / right, left.y / right);
    }
}
