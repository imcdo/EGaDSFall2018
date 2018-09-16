using Bullet;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BulletPattern
{
    public class ThreeBullets : MonoBehaviour
    {

        [Tooltip("In Seconds")]
        [Range(0, 1)]
        public float duration = 1;
        public int numBullets = 16;
        [SerializeField]
        Object Bullet;
        float counter = 0;
        bool b = true;
        public float speed = 5.0f;
        float lastAngle = 0.0f;
        [Range(0, 360)]
        public float angleInBtwn = 0.0f;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

            float delta = 30.0f;
            counter += Time.deltaTime;
            if (counter > duration)
            {
                counter -= duration;


                for (int i = 1; i <= 3; i++)
                {
                    var bullet = (GameObject)Instantiate(Bullet, transform.position, Quaternion.identity);
                    var a = bullet.GetComponent<VelBullet>();
                    a.Speed = speed;
                    a.Angle = lastAngle += delta;
                    if (a.Angle > 360)
                    {
                        a.Angle -= 360;
                    }
                    
                }
                
                
                
            }


        }
    }
}
