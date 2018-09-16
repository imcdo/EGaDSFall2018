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
        public int numBullets = 16;
        public BulletType Bullet;
        float counter = 0;
        bool b = true;
        public float speed = 5.0f;
        float lastAngle = 0.0f;
        [Range(0,360)]
        public float delta = 30.0f;
        // Use this for initialization
        void Start()
        {

        }

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