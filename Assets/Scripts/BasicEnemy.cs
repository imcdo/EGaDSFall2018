using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CloudCanards.Util;

public class BasicEnemy : MonoBehaviour {
    [SerializeField] float minDistanceFromPlayer = 3f;
    [SerializeField] float AIMoveSpeed = 10;
    public int healthOfAI = 20;
    Rigidbody2D rb;
    Transform target;

	// Use this for initialization
	void Start () {
        target = Player.Instance.gameObject.transform;
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        FollowPlayer();
	}

    void FollowPlayer()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        Vector2 diff = target.position - transform.position;
        transform.eulerAngles = new Vector3(0, 0,diff.GetAngle() * Mathf.Rad2Deg);
        if (distance > minDistanceFromPlayer)
        {
            rb.velocity = diff.normalized * AIMoveSpeed;
        }
        else
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
    }

    public void DamageEnemy(int damage)
    {
        healthOfAI -= damage;
        Debug.Log("ai hit, life is " + healthOfAI);
        if (healthOfAI <= 0)
        {
            Destroy(gameObject);
        }
    }
}
