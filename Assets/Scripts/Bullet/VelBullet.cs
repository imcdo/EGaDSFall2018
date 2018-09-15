using CloudCanards.Util;
using UnityEngine;

namespace Bullet
{
	public class VelBullet : BaseBullet
	{
		public float Speed = 4;

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
			Body.velocity = Vector2Utils.CreateVector(Speed, Angle * Mathf.Deg2Rad);
		}
	}
}