using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bullet;

public class ExplodingBullet : MonoBehaviour
    {

    public float duration = 1;
    public int numBullets = 16;
    public BulletType Bullet;
    float counter = 0f;
    private void Start()
    {
        
    }


	
	// Update is called once per frame
	void Update ()
    {
        float delta = (360f / numBullets);
        counter += Time.deltaTime;
        if (counter > duration)
        {
            counter = float.NegativeInfinity;

            for (int i = 1; i <= numBullets; i++)
            {
                float angle= i * delta;
                BaseBullet.Create(Bullet, transform.position, angle);
            }
        }
                
	}
}
