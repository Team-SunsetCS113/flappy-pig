using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace Assets
{
    public class HealthBar : MonoBehaviour
    {
        private int health;
        private float deathCooldown;

        public void Start()
        {
            health = 100;
            deathCooldown = 0.5f;
        }

        public void LostHealth(int lost)
        {
            health -= lost;
            Update();
        }

        public void Update()
        {
            if(health <= 0)
            {
                //Implement death
                var pigAnimator = GameObject.Find("PlayerBird").GetComponentInChildren<Animator>();
                pigAnimator.SetTrigger("Death");

                deathCooldown -= Time.deltaTime;

                GameObject player_go = GameObject.FindGameObjectWithTag("Player");
                var pig = player_go.GetComponent<PigMovement>();
                pig.dead = true;

                if (deathCooldown <= 0)
                {
                    if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                    {
                        Application.LoadLevel(Application.loadedLevel);
                    }
                }
            }

            GetComponent<GUIText>().text = "Health: " + health;
        }
    }
}
