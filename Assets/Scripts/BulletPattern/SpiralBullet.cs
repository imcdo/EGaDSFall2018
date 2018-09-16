using Bullet;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BulletPattern
{
    public class SpiralBullet : MonoBehaviour
    {

        [Tooltip("In Seconds")]
        [Range(0,1)]
        public float duration = 1;
        public BulletType Bullet;
        float counter = 0;
        float lastAngle = 0.0f;
        [Range(-360,360)]
        public float delta = 30.0f;

        // Update is called once per frame
        void Update()
        {
            
            counter += Time.deltaTime;
            if (counter > duration)
            {
                counter -= duration;

                BaseBullet.Create(Bullet, transform.position, lastAngle);
                lastAngle += delta;
                
                

            }


        }
    }
}