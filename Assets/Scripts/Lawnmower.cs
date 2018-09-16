using CloudCanards.Util;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lawnmower : MonoBehaviour
{
    public float Speed = 4;

    void Start()
    {
        var angle = transform.eulerAngles.z;

        var body = GetComponent<Rigidbody2D>();
        body.velocity = Vector2Utils.CreateVector(Speed, angle * Mathf.Deg2Rad);


    }

}



   

    
   






	
	
