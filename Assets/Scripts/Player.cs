using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	Rigidbody2D rb;

	[SerializeField]
	float speed = 20;

	[SerializeField]
	LifeHearts lifeBar;

	public int startinghealth = 50;
	public int currenthealth;
	bool isDead;

	// Use this for initialization
	void Start()
	{
		rb = gameObject.GetComponent<Rigidbody2D>();
		currenthealth = startinghealth;
		lifeBar.updateLifeUI(currenthealth);
		isDead = false;
	}

	// Update is called once per frame
	void Update()
	{
		rb.velocity = new Vector3(Input.GetAxis("Horizontal") * speed,
			Input.GetAxis("Vertical") * speed, 0);
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