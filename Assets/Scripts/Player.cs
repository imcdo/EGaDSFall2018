using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Rigidbody2D rb;
    [SerializeField]float speed = 20;

	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        rb.velocity = new Vector3(Input.GetAxis("Horizontal") * speed,
            Input.GetAxis("Vertical") * speed, 0);

	}

    private void FixedUpdate()
    {
        
    }
}
