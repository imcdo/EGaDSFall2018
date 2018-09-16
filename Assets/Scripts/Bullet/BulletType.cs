using UnityEngine;

namespace Bullet
{
	public class BulletType : ScriptableObject
	{
		public Sprite Sprite;
		public float Speed = 4f;
		public int DamageAmount = 1;

		public bool Cooler;
		public float TimeUntilSwitch = 0.5f;
		public float Acceleration = 10f;
	}
}