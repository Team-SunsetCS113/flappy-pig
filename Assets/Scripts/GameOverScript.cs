using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameOverScript : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0;
                GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }

}
