using UnityEngine;

namespace Bullet
{
	public class SwitchingVelBullet : VelBullet
	{
		[Range(0.1f, 10f)]
		public float TimeUntilSwitch = 0.5f;
		[Range(5f, 25f)]
		public float Acceleration = 10f;

		private float _startSpeed;

		protected override void Update()
		{
			base.Update();

			if (TimeUntilSwitch > 0f)
			{
				TimeUntilSwitch -= Time.deltaTime;
				_startSpeed = Speed;
			}
			else
			{
				if (Speed > -_startSpeed)
					Speed -= Time.deltaTime * Acceleration;
			}
		}
	}
}