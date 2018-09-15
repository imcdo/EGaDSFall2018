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

		protected override void OnHitShield()
		{
			base.OnHitShield();
			var shieldAngle = 0f; //todo
			var delta = AngleUtils.Distance(shieldAngle, Angle);
			Angle = shieldAngle - delta + 180f;
			
		}

		private void LateUpdate()
		{
			Body.velocity = Vector2Utils.CreateVector(Speed, Angle * Mathf.Deg2Rad);
		}
	}
}