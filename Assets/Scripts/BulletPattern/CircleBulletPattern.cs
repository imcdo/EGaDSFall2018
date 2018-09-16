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
        [SerializeField]
        Object Bullet;
        float counter = 0;
        bool b = true;
        public float speed = 5.0f;

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
                    var bullet = (GameObject)Instantiate(Bullet, transform.position, Quaternion.identity);
                    var a = bullet.GetComponent<VelBullet>();
                    a.Speed = speed;
                    if (b)
                    {
                        a.Angle = i * delta + (delta / 2);
                    }
                    else
                    {
                        a.Angle = i * delta;
                    }
                }
                b = !b;

            }


        }
    }
}