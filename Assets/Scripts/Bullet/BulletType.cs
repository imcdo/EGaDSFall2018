using UnityEngine;

namespace Bullet
{
	[CreateAssetMenu]
	public class BulletType : ScriptableObject
	{
		public Sprite Sprite;
		public float Speed = 4f;
		public int DamageAmount = 1;
		public float Radius = 0.1f;

		public bool Cooler;
		public float TimeUntilSwitch = 0.5f;
		public float Acceleration = 10f;
	}
}