using System.Collections;
using UnityEngine;

namespace Bullet
{
	[RequireComponent(typeof(Rigidbody2D))]
	[RequireComponent(typeof(Collider2D))]
	public class BaseBullet : MonoBehaviour
	{
		protected Rigidbody2D Body;
		public int DamageAmount = 1;
		public bool CanAttackPlayer = true;

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
				OnHitEnemy();
			}
			else if (layer == LayerMask.NameToLayer("Shield"))
			{
				OnHitShield();
			}
		}

		private void OnHitPlayer(Collider2D other)
		{
			var player = other.GetComponent<Player>();
			if (player != null)
				player.damage(DamageAmount);
			Destroy(gameObject);
		}

		private void OnHitEnemy()
		{
			Destroy(gameObject);
		}

		protected virtual void OnHitShield()
		{
			CanAttackPlayer = !CanAttackPlayer;
		}

		protected virtual void Update()
		{
			var pos = Camera.main.WorldToViewportPoint(transform.position);
			if (0f <= pos.x && pos.x <= 1f && 0 <= pos.y && pos.y <= 1f)
				return;
			_deathTimer -= Time.deltaTime;
			if (_deathTimer <= 0)
				Destroy(gameObject);
		}

		private void Reset()
		{
			GetComponent<Collider2D>().isTrigger = true;
			GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
			gameObject.layer = LayerMask.NameToLayer("Bullet");
		}
	}
}