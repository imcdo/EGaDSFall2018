using System.Runtime.CompilerServices;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace CloudCanards.Util
{
	public static class Vector2Utils
	{
		private const float RoundCheck = 0.0005f;
		private const float SqrRoundCheck = RoundCheck * RoundCheck;

		/// <summary>
		/// Checks if the magnitude of the vector is close enough to (0, 0) and sets it to (0, 0) if so
		/// </summary>
		/// <param name="vector">vector to potentially modify</param>
		// ReSharper disable once UnusedMethodReturnValue.Global
		public static bool CheckRoundZero(ref Vector2 vector)
		{
			if (vector.sqrMagnitude < SqrRoundCheck)
			{
				vector.Set(0, 0);
				return true;
			}

			return false;
		}

		/// <summary>
		/// Gets the vector perpendicular to this vector. Length is not known
		/// </summary>
		/// <param name="vector">vector to get perp from</param>
		/// <returns>perp vector</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector2 Perp(this Vector2 vector)
		{
			return new Vector2(-vector.y, vector.x);
		}

		/// <summary>
		/// Gets the angle of this vector in radians
		/// </summary>
		/// <param name="vector">vector to get angle from</param>
		/// <returns>An angle, θ, measured in radians, such that -π≤θ≤π</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float GetAngle(this Vector2 vector)
		{
			return Mathf.Atan2(vector.y, vector.x);
		}

		/// <summary>
		/// Gets the minimum angle (in radians) between the two vectors. Assumes vectors are normalized
		/// </summary>
		/// <param name="from">vector a</param>
		/// <param name="to"> vector b</param>
		/// <returns></returns>
		public static float AngleRad(Vector2 from, Vector2 to)
		{
			return Mathf.Acos(Mathf.Clamp(Vector2.Dot(from, to), -1f, 1f));
		}

		/// <summary>
		/// Checks whether abs(a.x - b.x) &lt;= delta and abs(a.y - b.y) &lt;= delta
		/// </summary>
		public static bool AlmostEqual(this Vector2 a, Vector2 b, float tolerance = float.Epsilon)
		{
			return Mathf.Abs(a.x - b.x) <= tolerance && Mathf.Abs(a.y - b.y) <= tolerance;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Dot(this Vector2 a, Vector2 b)
		{
			return Vector2.Dot(a, b);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Cross(this Vector2 a, Vector2 b)
		{
			return a.x * b.y - a.y * b.x;
		}

		/// <summary>
		/// Project this (a) onto b
		/// </summary>
		/// <param name="a">vector a</param>
		/// <param name="b">vector b</param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector2 Projection(this Vector2 a, Vector2 b)
		{
			return Vector2.Dot(a, b) / Vector2.Dot(b, b) * b;
		}

		/// <summary>
		/// Project this (a) onto b
		/// </summary>
		/// <param name="a">vector a</param>
		/// <param name="b">vector b</param>
		/// <returns>magnitude and sign</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float ScalarProjection(this Vector2 a, Vector2 b)
		{
			return Vector2.Dot(a, b) / b.magnitude;
		}

		/// <summary>
		/// Reject this (a) onto b
		/// </summary>
		/// <param name="a">vector a</param>
		/// <param name="b">vector b</param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector2 Rejection(this Vector2 a, Vector2 b)
		{
			return a - a.Projection(b);
		}

		/// <summary>
		/// Constructs a new Vector from a radius and an angle
		/// </summary>
		/// <param name="radius">radius in world units</param>
		/// <param name="angle">angle in radians</param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector2 CreateVector(float radius, float angle)
		{
			return new Vector2(radius * Mathf.Cos(angle), radius * Mathf.Sin(angle));
		}

		/// <summary>
		/// Get the Vector with the larger magnitude
		/// </summary>
		/// <param name="a">vector</param>
		/// <param name="b">vector</param>
		/// <returns>larger vector</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector2 Max(Vector2 a, Vector2 b)
		{
			return a.sqrMagnitude > b.sqrMagnitude ? a : b;
		}

		/// <summary>
		/// If the magnitude of this vector > max, then magnitude is set to max
		/// </summary>
		/// <param name="vector">vector to clamp</param>
		/// <param name="max">max magnitude</param>
		/// <param name="maxSqr">max * max</param>
		/// <returns>potentially clamped vector</returns>
		public static Vector2 Clamp(this Vector2 vector, float max, float maxSqr)
		{
			var newForceSqrMagnitude = vector.sqrMagnitude;
			if (newForceSqrMagnitude > maxSqr)
			{
				var magnitude = Mathf.Sqrt(newForceSqrMagnitude);
				if (magnitude > 9.99999974737875E-06)
					vector = vector * (max / magnitude);
				else
					vector = Vector2.zero;
			}

			return vector;
		}

		public static Vector2 Normalize(this Vector2 vector2, float magnitudeSq)
		{
			var magnitude = Mathf.Sqrt(magnitudeSq);
			return magnitude > 9.99999974737875E-06 ? vector2 / magnitude : Vector2.zero;
		}

		/// <summary>
		/// normalizes without checking if magnitude is too close to 0
		/// </summary>
		/// <param name="vector2">vector to normalize</param>
		/// <param name="magnitudeSq">squared magnitude of this vector</param>
		/// <returns>normalized magnitude</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector2 DangerouslyNormalize(this Vector2 vector2, float magnitudeSq)
		{
			return vector2 / Mathf.Sqrt(magnitudeSq);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float SqrDistance(Vector2 a, Vector2 b)
		{
			return (a - b).sqrMagnitude;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector2 SetMagnitude(this Vector2 vector, float magnitude)
		{
			return vector.normalized * magnitude;
		}

		public static Vector2 PhysicsLerp(this Vector2 from, Vector2 target, float speed)
		{
			var delta = target - from;
			var magSq = delta.sqrMagnitude;

			if (magSq <= speed * speed)
				return target;

			var normalized = delta.DangerouslyNormalize(magSq);
			return from + speed * normalized;
		}

		/// <summary>
		/// Checks whether v is valid (not NaN)
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsValid(this Vector2 v)
		{
			return !float.IsNaN(v.x) && !float.IsNaN(v.y);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector2 Abs(this Vector2 v)
		{
			return new Vector2(Mathf.Abs(v.x), Mathf.Abs(v.y));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector2 Sign(this Vector2 v)
		{
			return new Vector2(Mathf.Sign(v.x), Mathf.Sign(v.y));
		}
	}
}