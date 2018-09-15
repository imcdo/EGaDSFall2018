using CloudCanards.Util;
using UnityEngine;

namespace Bullet
{
	public class VelBullet : BaseBullet
	{
		public float Speed;

		[Tooltip("In degrees")]
		public float Angle;

		protected override void OnHitShield()
		{
			base.OnHitShield();
			var shieldAngle = 0f; //todo
			var delta = AngleUtils.Distance(shieldAngle, Angle);
			Angle = shieldAngle - delta + 180f;
		}

		private void LateUpdate()
		{
			Body.MovePosition((Vector2) transform.position +
			                  Vector2Utils.CreateVector(Speed * Time.deltaTime, Angle * Mathf.Deg2Rad));
		}
	}
}