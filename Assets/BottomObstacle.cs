using System;
using System.Collections.Generic;

using UnityEngine;

namespace Assets
{
    class BottomObstacle : MonoBehaviour
    {
        void OnCollisionEnter2D(Collision2D collision)
        {
            var healthBar = GameObject.Find("guiHealth");
            healthBar.SendMessage("LostHealth", 5);
        }
    }
}
