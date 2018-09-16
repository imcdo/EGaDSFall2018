using System;
using System.Collections.Generic;
using UnityEngine;

namespace Bullet
{
	[RequireComponent(typeof(Rigidbody2D))]
	[RequireComponent(typeof(Collider2D))]
	public class BaseBullet : MonoBehaviour
	{
		protected Rigidbody2D Body;
		public int DamageAmount = 1;
		public bool CanDamagePlayer = true;

		private float _deathTimer = 1f;

		private void Awake()
		{
			Body = GetComponent<Rigidbody2D>();
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			var layer = other.gameObject.layer;
			if (layer == LayerMask.NameToLayer("Player"))
			{
				OnHitPlayer(other);
			}
			else if (layer == LayerMask.NameToLayer("Enemy"))
			{
				OnHitEnemy(other);
			}
			else if (layer == LayerMask.NameToLayer("Shield"))
			{
				OnHitShield();
			}
		}

		private void OnHitPlayer(Collider2D other)
		{
			var player = other.GetComponent<Player>();
			if (player != null && CanDamagePlayer)
			{
				player.damage(DamageAmount);
				DestroySelf();
			}
		}

		private void OnHitEnemy(Collider2D other)
		{
			var enemy = other.GetComponent<BasicEnemy>();
			if (enemy != null && !CanDamagePlayer)
			{
				enemy.DamageEnemy(DamageAmount);
				DestroySelf();
			}
		}

		protected virtual void OnHitShield()
		{
			CanDamagePlayer = !CanDamagePlayer;
		}

		protected virtual void Update()
		{
			var pos = Camera.main.WorldToViewportPoint(transform.position);
			if (0f <= pos.x && pos.x <= 1f && 0 <= pos.y && pos.y <= 1f)
				return;
			_deathTimer -= Time.deltaTime;
			if (_deathTimer <= 0)
				DestroySelf();
		}

		private void Reset()
		{
			GetComponent<Collider2D>().isTrigger = false;
			GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
			GetComponent<Rigidbody2D>().useFullKinematicContacts = true;
			gameObject.layer = LayerMask.NameToLayer("Bullet");
		}

		private void DestroySelf()
		{
			transform.position = new Vector3(9999, 9999);
			gameObject.SetActive(false);

			var type = GetType();
			if (!Pool.ContainsKey(type))
				Pool.Add(type, new List<BaseBullet>());
			Pool[type].Add(this);
		}

		public static BaseBullet Create(BulletType bullet, Vector2 position, float angle)
		{
			if (bullet.Cooler)
			{
				return SwitchVelBullet(position, bullet.Radius, bullet.Sprite, bullet.Speed, angle, bullet.DamageAmount,
					bullet.TimeUntilSwitch, bullet.Acceleration);
			}

			return VelBullet(position, bullet.Radius, bullet.Sprite, bullet.Speed, angle, bullet.DamageAmount);
		}

		private static VelBullet VelBullet(Vector2 position, float radius, Sprite sprite, float speed, float angle, int damage)
		{
			if (!Pool.ContainsKey(typeof(VelBullet)))
				Pool.Add(typeof(VelBullet), new List<BaseBullet>());
			var list = Pool[typeof(VelBullet)];

			VelBullet bullet;
			if (list.Count == 0)
			{
				var obj = new GameObject("Bullet", typeof(SpriteRenderer), typeof(CircleCollider2D),
					typeof(Rigidbody2D), typeof(VelBullet)) {layer = LayerMask.NameToLayer("Bullet")};

				var body = obj.GetComponent<Rigidbody2D>();
				body.gravityScale = 0f;

				bullet = obj.GetComponent<VelBullet>();
			}
			else
			{
				bullet = (VelBullet) list[list.Count - 1];
				bullet.gameObject.SetActive(true);
				list.RemoveAt(list.Count - 1);
			}

			bullet.transform.position = position;
			bullet.transform.localScale = new Vector3(radius, radius, 1f);
			bullet.GetComponent<SpriteRenderer>().sprite = sprite;
			bullet.GetComponent<CircleCollider2D>().radius = 0.1f;
            //bullet.GetComponent<Transform>().localScale = bullet.GetComponent<Transform>().localScale * radius * 10;
			bullet.CanDamagePlayer = true;
			bullet.Speed = speed;
			bullet.Angle = angle;
			bullet.DamageAmount = damage;
			bullet._deathTimer = 1f;

			return bullet;
		}
		
		

		private static SwitchingVelBullet SwitchVelBullet(Vector2 position, float radius, Sprite sprite, float speed, float angle,
			int damage, float timeUntilSwitch = 0.5f, float acceleration = 10f)
		{
			if (!Pool.ContainsKey(typeof(SwitchingVelBullet)))
				Pool.Add(typeof(SwitchingVelBullet), new List<BaseBullet>());
			var list = Pool[typeof(SwitchingVelBullet)];

			SwitchingVelBullet bullet;
			if (list.Count == 0)
			{
				var obj = new GameObject("Bullet", typeof(SpriteRenderer), typeof(CircleCollider2D),
					typeof(Rigidbody2D), typeof(SwitchingVelBullet)) {layer = LayerMask.NameToLayer("Bullet")};

				var body = obj.GetComponent<Rigidbody2D>();
				body.gravityScale = 0f;

				bullet = obj.GetComponent<SwitchingVelBullet>();
			}
			else
			{
				bullet = (SwitchingVelBullet) list[list.Count - 1];
				bullet.gameObject.SetActive(true);
				list.RemoveAt(list.Count - 1);
			}

			bullet.transform.position = position;
			bullet.transform.localScale = new Vector3(radius, radius, 1f);
			bullet.GetComponent<SpriteRenderer>().sprite = sprite;
			bullet.GetComponent<CircleCollider2D>().radius = 0.1f;
			bullet.CanDamagePlayer = true;
			bullet.Speed = speed;
			bullet.Angle = angle;
			bullet.DamageAmount = damage;
			bullet.TimeUntilSwitch = timeUntilSwitch;
			bullet.Acceleration = acceleration;
			bullet._deathTimer = 1f;

			return bullet;
		}

		public static readonly Dictionary<Type, List<BaseBullet>> Pool = new Dictionary<Type, List<BaseBullet>>();
	}
}