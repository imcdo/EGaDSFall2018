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
        [SerializeField]
        Object Bullet;
        float counter = 0;
        bool b = true;
        public float speed = 5.0f;
        float lastAngle = 0.0f;

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

                
                var bullet = (GameObject)Instantiate(Bullet, new Vector3(0, 0, 0), Quaternion.identity);
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