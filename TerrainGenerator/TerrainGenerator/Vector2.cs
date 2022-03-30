using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrainGenerator;
public struct Vector2
{
	public float x;
	public float y;

	public Vector2(float pX = 0, float pY = 0)
	{
		x = pX;
		y = pY;
	}
	public void Normalize()
	{
		if (Length() == 0)
			return;
		float length = Length();
		x = x / length;
		y = y / length;
	}
	public Vector2 Normalized()
	{
		Vector2 output = new Vector2(x, y);
		output.Normalize();
		return output;
	}
	public void SetXY(float X, float Y)
	{
		x = X;
		y = Y;
	}

	// TODO: Implement Length, Normalize, Normalized, SetXY methods (see Assignment 1)

	public float Length()
	{
		// TODO: return the vector length
		return Mathf.Sqrt((x * x) + (y * y));
	}

	// TODO: Implement subtract, scale operators

	public static Vector2 operator +(Vector2 left, Vector2 right)
	{
		return new Vector2(left.x + right.x, left.y + right.y);
	}
	public static Vector2 operator -(Vector2 left, Vector2 right)
	{
		return new Vector2(left.x - right.x, left.y - right.y);
	}
	public static Vector2 operator *(Vector2 left, Vector2 right)
	{
		return new Vector2(left.x * right.x, left.y * right.y);
	}
	public static Vector2 operator *(Vector2 left, float right)
	{
		return new Vector2(left.x * right, left.y * right);
	}
	public static Vector2 operator *(float left, Vector2 right)
	{
		return new Vector2(left * right.x, left * right.y);
	}
	public static Vector2 operator /(float left, Vector2 right)
	{
		return new Vector2(left / right.x, left / right.y);
	}
	public static Vector2 operator /(Vector2 left, float right)
	{
		return new Vector2(left.x / right, left.y / right);
	}
	public override string ToString()
	{
		return String.Format("({0},{1})", x, y);
	}
	public static float Deg2Rad(float f)
	{
		return f * (Mathf.PI / 180f);

	}
	public static Vector2 FromVector3(Vector3 vec3)
    {
		return new Vector2(vec3.x, vec3.y);
    }
	public static float Rad2Deg(float f)
	{
		return f * (180f / Mathf.PI);
	}
	public static Vector2 GetUnitVectorDeg(float f)
	{
		float radian = Deg2Rad(f);
		Vector2 output = new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
		return output;
	}
	public static Vector2 GetUnitVectorRad(float f)
	{
		Vector2 output = new Vector2(Mathf.Cos(f), Mathf.Sin(f));
		return output;
	}
	public void SetAngleDegrees(float f)
	{
		f = Deg2Rad(f);
		float l = Length();
		x = Mathf.Cos(f);
		y = Mathf.Sin(f);
		Normalize();
		this = this * l;
	}
	public void SetAngleRadians(float f)
	{
		float l = Length();
		x = Mathf.Cos(f);
		y = Mathf.Sin(f);
		Normalize();
		this = this * l;
	}
	public float GetAngleRadians()
	{
		return Mathf.Atan2(y, x);
	}
	public float GetAngleDegrees()
	{
		return Rad2Deg(Mathf.Atan2(y, x));
	}
	public void RotateDegrees(float f)
	{
		f = Deg2Rad(f);
		float xo = x;
		x = x * Mathf.Cos(f) - y * Mathf.Sin(f);
		y = xo * Mathf.Sin(f) + y * Mathf.Cos(f);
	}
	public void RotateRadians(float f)
	{
		float xo = x;
		x = x * Mathf.Cos(f) - y * Mathf.Sin(f);
		y = xo * Mathf.Sin(f) + y * Mathf.Cos(f);
	}
	public void RotateAroundDegrees(Vector2 point, float angle)
	{
		Vector2 dist = this - point;
		dist.RotateDegrees(angle);
		dist += point;
		this = dist;
	}
	public void RotateAroundRadians(Vector2 point, float angle)
	{
		RotateAroundDegrees(point, Rad2Deg(angle));
	}
}