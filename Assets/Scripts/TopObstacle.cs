using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace Assets
{
    class TopObstacle : MonoBehaviour
    {
        void OnCollisionEnter2D(Collision2D collision)
        {
            var healthBar = GameObject.Find("guiHealth");
            healthBar.SendMessage("LostHealth", 5);
        }
    }
}
