using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    class ModerateEnemy : MonoBehaviour
    {
        private int health = 25;
		private Rigidbody2D ridgidBody2D;
		private bool dead = false;
		private Vector3 velocity = Vector3.zero;

		public float forwardSpeed = 0.001f;	
		Animator animator;

		void Start()
		{
			ridgidBody2D = GetComponent<Rigidbody2D>();
		}

		//Moderate enemies should move to the left
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

		// Moderate enemies inflict 8 of damage, less than strong enemies
		void OnCollisionEnter2D(Collision2D collision)
		{
			var healthBar = GameObject.Find("guiHealth");
			healthBar.SendMessage("LostHealth", 8);
		}
    }
}
