using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPlayer: MonoBehaviour {
    [SerializeField] int health = 20;
    GameObject pl;
	// Use this for initialization
	void Start () {
        pl = Player.Instance.gameObject;
	}
	
	// Update is called once per frame
	void Update () { 
        
    
    }

    void Heal()
    {
        pl.GetComponent<Player>().damage(-1 * health);
        Destroy(gameObject);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("player :" + pl + " collision: " + collision.gameObject);
        if (collision.gameObject.transform.Equals(pl.transform))
        {
            Debug.Log("here");
            Heal();
        }
    }
        
}
