using UnityEngine;

// ReSharper disable once CheckNamespace
namespace CloudCanards.Util
{
	public static class AngleUtils
	{
		/// <summary>
		/// Gets the signed distance from arg0 to arg1. Negative is to move clockwise, and positive is to move counterclockwise.
		/// If abs(distance) is 180, then positive 180 is always returned.
		/// </summary>
		/// <param name="from">angle from</param>
		/// <param name="to">angle to</param>
		/// <returns></returns>
		public static float Distance(float from, float to)
		{
			var dist = (to - from + 180f) % 360f - 180f;
			return dist <= -180f ? dist + 360 : dist;
		}
		
		/// <summary>
		/// Gets the distance from arg0 to arg1 when moving clockwise.
		/// </summary>
		/// <param name="from">angle from</param>
		/// <param name="to">angle to</param>
		/// <returns>range [0, 360]</returns>
		public static float DistanceClockwise(float from, float to)
		{
			var dist = -Distance(from, to);
			if (dist < 0)
				dist = 360 + dist;
			return dist;
		}
		
		/// <summary>
		/// Gets the distance from arg0 to arg1 when moving counterclockwise.
		/// </summary>
		/// <param name="from">angle from</param>
		/// <param name="to">angle to</param>
		/// <returns>range [0, 360]</returns>
		public static float DistanceCounterClockwise(float from, float to)
		{
			var dist = Distance(from, to);
			if (dist < 0)
				dist = 360 + dist;
			return dist;
		}

		public static float Within0To360(float angle)
		{
			return (angle % 360 + 360) % 360;
		}

		/// <summary>
		/// Checks whether angle is within the smaller arc between angleA and angleB. Has undefined results when Distance(angleA, angleB) >= 180
		/// </summary>
		/// <param name="angle">angle to check</param>
		/// <param name="angleA">angle A, inclusive</param>
		/// <param name="angleB">angle B, inclusive</param>
		/// <returns></returns>
		public static bool WithinArc(float angle, float angleA, float angleB)
		{
			var dist = Distance(angleA, angleB);
			if (dist < 0)
			{
				angleA = angleB;
				dist *= -1;
			}

			var check = Distance(angleA, angle);
			if (check < 0)
				return false;
			return check <= dist;
		}

		/// <summary>
		/// Checks whether angle is within the arc of angle range * 2 where the midpoint angle is mid
		/// </summary>
		/// <param name="angle">angle to check</param>
		/// <param name="mid">middle of arc</param>
		/// <param name="range">distance from middle to edge, inclusive</param>
		/// <returns></returns>
		public static bool WithinRange(float angle, float mid, float range)
		{
			var dist = Distance(mid, angle);
			return Mathf.Abs(dist) <= range;
		}
	}
}