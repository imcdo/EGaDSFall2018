using Bullet;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BulletPattern
{
    public class CircleBulletPattern : MonoBehaviour
    {
        
        [Tooltip("In Seconds")]
        public float duration = 1;
        public int numBullets = 16;
        public BulletType Bullet;
        float counter = 0;
        bool b = true;
        public float speed = 5.0f;
        public float angle = 0.0f;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            
            float delta = (360.0f / numBullets);
            
            counter += Time.deltaTime;
            if (counter > duration)
            {
                counter -= duration;

                for (int i = 1; i <= numBullets; i++)
                {
                    BaseBullet.Create(Bullet, transform.position, angle);
                    if (b)
                    {
                        angle = i * delta + (delta / 2);
                    }
                    else
                    {
                        angle = i * delta;
                    }
                }
                b = !b;

            }


        }
    }
}