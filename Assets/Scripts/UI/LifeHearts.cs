﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeHearts : MonoBehaviour {
    [SerializeField] int lifePerHeart = 20;
    [SerializeField] GameObject heart;
    int numberOfHearts;
    int prevNumHearts = 0;
    Stack<GameObject> hearts;
    


	// Use this for initialization
	void Start () {
        hearts = new Stack<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void updateLifeUI(int life)
    {

        int numHearts = life / lifePerHeart + ((life % lifePerHeart == 0)? 0:1);
        float lastHeartOpacity = ((life %lifePerHeart == 0)? lifePerHeart * 1f : life % lifePerHeart * 1f) / lifePerHeart;
  

        int dif = numHearts - prevNumHearts;
        if (dif == 0) { }
        else if (dif < 0)
        {
            //lost life
            for (int i = dif; i < 0; i++)
            {
                if (hearts.Count > 0) { 
                    GameObject oldHeart = hearts.Pop();
                Destroy(oldHeart);
                dif++;
                }
            }
        }
        else
        {
            //gained life
            for (int i = 0; i < dif; i++)
            {
                GameObject newHeart = Instantiate(heart);
                newHeart.transform.SetParent(transform);
                hearts.Push(newHeart);
            }
        }

        //update last heart opacity
        if (hearts.Count > 0)
        {
            GameObject lastHeart = hearts.Peek();
            lastHeart.GetComponent<Image>().color = new Color(255, 255, 255, lastHeartOpacity);

            prevNumHearts = numHearts;
        }

       
        
    }

}
