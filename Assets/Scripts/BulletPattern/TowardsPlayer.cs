﻿using Bullet;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CloudCanards.Util;

namespace BulletPattern
{
    public class TowardsPlayer : MonoBehaviour
    {

        [Tooltip("In Seconds")]
        [Range(0, 1)]
        public float duration = 1;
        public int numBullets = 16;
        
        float counter = 0;
        bool b = true;
        public float speed = 5.0f;
        float lastAngle = 0.0f;
        private Vector2 pos;
        public BulletType Bullet;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            var p = Player.Instance.transform;
           
            Vector2 pos = p.position;
            
           
            Vector2 enemyPosition = gameObject.transform.position;
     
            Vector2 diff = enemyPosition - pos;

            float diffAngle = diff.GetAngle() * Mathf.Rad2Deg + 180;

            float delta = 10.0f;
            float angleToPlayer = Mathf.Atan2(p.transform.position.y, p.transform.position.x) * Mathf.Rad2Deg;
            
            counter += Time.deltaTime;
            if (counter > duration)
            {
                counter -= duration;
                /*
                if (diffAngle > 360)
                {
                    diffAngle -= 360;
                }
                if (diffAngle < 0)
                {
                    diffAngle += 360;
                } */

                BaseBullet.Create(Bullet, transform.position, diffAngle);
                
                /*for (int i = 1; i <= 3; i++)
                {
                    BaseBullet.Create(Bullet, transform.position, diffAngle);
                    
                    
                
                   
                } */

            }


        }

    }
}
