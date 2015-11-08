using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    public class StrongEnemy : MonoBehaviour
    {
        private int health = 50;
        private Rigidbody2D ridgidBody2D;

        Vector3 velocity = Vector3.zero;
        public float flapSpeed = 100f;
        public float forwardSpeed = 0.001f;

        private bool dead = false;


        Animator animator;

        // Use this for initialization
        void Start()
        {
            //animator = transform.GetComponentInChildren<Animator>();
            ridgidBody2D = GetComponent<Rigidbody2D>();
            //if (animator == null)
            //{
            //    Debug.LogError("Didn't find animator!");
            //}
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
    
