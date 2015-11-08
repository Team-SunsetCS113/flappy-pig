using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
    public class WeakEnemy : MonoBehaviour
    {
        private int health = 10;
        private Rigidbody2D ridgidBody2D;

        Vector3 velocity = Vector3.zero;
        public float flapSpeed = 100f;
        public float forwardSpeed = 0.001f;

        private bool dead = false;
        
        Animator animator;

        // Use this for initialization
        void Start()
        {
            ridgidBody2D = GetComponent<Rigidbody2D>();
        }


        public void Update()
        {
            if (health <= 0)
            {
                //TODO: HIDE Asset

            }
            else
            {
                ridgidBody2D.AddForce(Vector2.left * forwardSpeed);
            }
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            return;
        }
    }
}

