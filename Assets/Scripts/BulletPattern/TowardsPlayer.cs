﻿using Bullet;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BulletPattern
{
    public class TowardsPlayer : MonoBehaviour
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
        private object pos;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            var p = Player.Instance;
            if (p != null)
            {
                var pos = p.transform.position;
            }
            float angleToPlayer = Mathf.Atan2(p.transform.position.y, p.transform.position.x) * Mathf.Rad2Deg;
            float delta = 10.0f;
            angleToPlayer -= delta * 2;
            
            counter += Time.deltaTime;
            if (counter > duration)
            {
                counter -= duration;

                for (int i = 1; i <= 3; i++)
                {
                    var bullet = (GameObject)Instantiate(Bullet, new Vector3(0, 0, 0), Quaternion.identity);
                    var a = bullet.GetComponent<VelBullet>();
                    a.Speed = speed;
                    a.Angle = angleToPlayer += delta;
                    if (a.Angle > 360)
                    {
                        a.Angle -= 360;
                    }
                }

            }


        }

    }
}
