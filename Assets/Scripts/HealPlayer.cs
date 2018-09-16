using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPlayer : MonoBehaviour
{
    [SerializeField] int health = 20;
    GameObject pl;
    // Use this for initialization
    void Start()
    {
        pl = Player.Instance.gameObject;
    }

    // Update is called once per frame
    void Update()
    {


    }

    void Heal()
    {
        pl.GetComponent<Player>().damage(-1 * health);
        Destroy(gameObject);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("yes");
        if (collision.gameObject.transform.Equals(pl.transform))
        {
            Heal();
        }
    }

}
