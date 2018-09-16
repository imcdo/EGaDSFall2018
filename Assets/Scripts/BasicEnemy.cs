using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CloudCanards.Util;

public class BasicEnemy : MonoBehaviour {
    [SerializeField] float minDistanceFromPlayer = 3f;
    [SerializeField] float AIMoveSpeed = 10;
    public int healthOfAI = 20;
    Animator anim;
    Rigidbody2D rb;
    Transform target;

    public static object Instance { get; internal set; }

    // Use this for initialization
    void Start () {
        target = Player.Instance.gameObject.transform;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        MoveEnemy();
	}

    void MoveEnemy()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        Vector2 diff = target.position - transform.position;
        transform.eulerAngles = new Vector3(0, 0,diff.GetAngle() * Mathf.Rad2Deg - 90);
        if (distance > minDistanceFromPlayer)
        {
            rb.velocity = diff.normalized * AIMoveSpeed;
        }
        else
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
        anim.SetFloat("mag", rb.velocity.magnitude);
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
