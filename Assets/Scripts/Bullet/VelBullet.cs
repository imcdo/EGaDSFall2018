using CloudCanards.Util;
using UnityEngine;

namespace Bullet
{
	public class VelBullet : BaseBullet
	{
		public float Speed = 4;

		[Tooltip("In degrees")]
		public float Angle;

		private void OnCollisionEnter2D(Collision2D other)
		{
			if (!other.gameObject.CompareTag("Reflective"))
				return;

			Vector2 reflected = Vector3.Reflect(Vector2Utils.CreateVector(1, Angle * Mathf.Deg2Rad),
				other.GetContact(0).normal);
			Angle = reflected.GetAngle() * Mathf.Rad2Deg;
		}

		private void LateUpdate()
		{
			Body.velocity = Vector2Utils.CreateVector(Speed, Angle * Mathf.Deg2Rad);
		}
	}
}