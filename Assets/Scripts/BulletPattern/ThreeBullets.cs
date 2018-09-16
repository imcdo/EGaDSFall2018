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
        float angle = 0.0f;
        [Range(0, 360)]
        public float offset = 10.0f;
        [Range(0, 360)]
        public float changeAngle = 0.0f;

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
                shootsBullets(angle);
                angle += changeAngle;
                if (angle > 360)
                {
                    angle -= 360;
                }
                if (angle < 0)
                {
                    angle += 360;
                }
                
            }


        }

        void shootsBullet(float angle)
        {
            
            var bullet = (GameObject)Instantiate(Bullet, transform.position, Quaternion.identity);
            var a = bullet.GetComponent<VelBullet>();
            a.Speed = speed;
            a.Angle = angle;
            

        }

        void shootsBullets(float angle)
        {
            for (int i = 0; i < numBullets; i++)
            {
                var d = (numBullets - 1) / 2.0f;
                var o = (i * offset) - d * offset;
                shootsBullet(angle + o);
                
            }
        }
    }
}
