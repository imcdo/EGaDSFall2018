using CloudCanards.Util;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lawnmower : MonoBehaviour
{
    Vector3 startposition;
    Rigidbody2D body;
    [SerializeField] float distance = 20;
    void Start()
    {
        startposition = transform.position;
        var angle = transform.eulerAngles.z;

        body = GetComponent<Rigidbody2D>();
        body.velocity = Vector2Utils.CreateVector(Speed, angle * Mathf.Deg2Rad);

    }
    public float Speed = 4;

    public Vector3 pointB;

    private void Update()
    {
       if ((transform.position - startposition).magnitude  > distance)
        {
            body.velocity = body.velocity * -1;
        }
   
    }





}




   

    
   






	
	
