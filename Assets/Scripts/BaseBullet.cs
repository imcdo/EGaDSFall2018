﻿using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class BaseBullet : MonoBehaviour {
	private void OnTriggerEnter2D(Collider2D other)
	{
		var layer = other.gameObject.layer;
		if (layer == LayerMask.NameToLayer("Player"))
		{
			OnHitPlayer();
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

	private void OnHitPlayer()
	{
		Destroy(gameObject);
	}

	private void OnHitEnemy()
	{
		Destroy(gameObject);
	}

	private void OnHitShield()
	{
		
	}

	private void Reset()
	{
		GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
		gameObject.layer = LayerMask.NameToLayer("Bullet");
	}
}