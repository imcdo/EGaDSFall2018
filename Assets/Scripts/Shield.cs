﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {

    Vector3 mouse_pos;
    public new Transform transform;
    Vector3 object_pos;
    float angle;
    public float reflectMeeter = 20f;
    float reflectMeeterMax;
    bool mouseClicked = false;
    [SerializeField] float rechargeRate = 1;
    [SerializeField] float depleateRate = 1;


    // Use this for initialization
    void Start () {
        reflectMeeterMax = reflectMeeter;
	}
	
	// Update is called once per frame
	void Update ()
    {
        float fire = Input.GetAxis("Fire1");
        if (fire > 0)
        {
            reflectMeeter -= (reflectMeeter <= 0)? 0 : Time.deltaTime * depleateRate;
        }
        else
        {
            reflectMeeter += (reflectMeeter >= reflectMeeterMax) ? 0 : Time.deltaTime * rechargeRate;
        }
        GameObject child = gameObject.transform.GetChild(0).gameObject;
        if (reflectMeeter > 0f && fire > 0)
        {

            //child.transform.tag = "Reflective";
            child.GetComponent<BoxCollider2D>().enabled = true;
            
        }
        else
        {
            //child.transform.tag = "Untagged";
            child.GetComponent<BoxCollider2D>().enabled = false;
        }
        mouse_pos = Input.mousePosition;
        mouse_pos.z = 0;
        object_pos = Camera.main.WorldToScreenPoint(base.transform.position);
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;
        angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        base.transform.rotation = Quaternion.Euler(0, 0, angle);
    
	}
}
