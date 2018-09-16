using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CloudCanards.Util;
 

public class Player : MonoBehaviour
{
	Rigidbody2D rb;

	[SerializeField]
	float speed = 20;

	[SerializeField]
	LifeHearts lifeBar;

    Animator anim;
	public int startinghealth = 50;
	public int currenthealth;
	bool isDead;

	// Use this for initialization
	void Start()
	{
        anim = gameObject.GetComponent<Animator>();
		rb = gameObject.GetComponent<Rigidbody2D>();
		currenthealth = startinghealth;
		lifeBar.updateLifeUI(currenthealth);
		isDead = false;
	}

	// Update is called once per frame
	void Update()
	{
        Vector3 sp = Camera.main.WorldToViewportPoint(transform.position);
        Vector3 playerMove;
        
		rb.velocity = new Vector3((sp.x < 0f || sp.x > 1f)?
                (sp.x < 0f)? Mathf.Max(0, Input.GetAxis("Horizontal") * speed) :
                Mathf.Min(0, Input.GetAxis("Horizontal") * speed)
                : Input.GetAxis("Horizontal") * speed,
            (sp.y < 0f || sp.y > 1f) ?
                (sp.y < 0f) ? Mathf.Max(0, Input.GetAxis("Vertical") * speed) :
                Mathf.Min(0, Input.GetAxis("Vertical") * speed)
                : Input.GetAxis("Vertical") * speed, 0);
        float mag = rb.velocity.magnitude;
        anim.SetFloat("mag", mag);
        if (mag != 0)
            transform.eulerAngles = new Vector3(0, 0, rb.velocity.GetAngle() * Mathf.Rad2Deg - 90);
    }

	public void damage(int amount)
	{
		currenthealth -= amount;
		if (currenthealth <= 0 && !isDead)
		{
			isDead = true;
		}

		lifeBar.updateLifeUI(currenthealth);
	}

	private void FixedUpdate()
	{
       
    }

   
    private void Awake()
	{
		Instance = this;
	}

	public static Player Instance { get; private set; }
}