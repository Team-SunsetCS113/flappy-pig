using UnityEngine;
using System.Collections;

public class TriggerScript : MonoBehaviour {

    PlayerHealthScript playerHealth;
    
    void Start() {
        playerHealth = gameObject.GetComponent<PlayerHealthScript>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {

        ShotScript shot = collider.gameObject.GetComponent<ShotScript>();
        HealthItemScript healthItem = collider.gameObject.GetComponent<HealthItemScript>();
        ShieldItemScript shieldItem = collider.gameObject.GetComponent<ShieldItemScript>();
        PointsItemScript pointsItem = collider.gameObject.GetComponent<PointsItemScript>();

        if (shot != null)
        {
            if (shot.isEnemyShot != playerHealth.enemy())
            {
                playerHealth.addDamage(shot.damage);
                Destroy(shot.gameObject);
            }
        }

        if (healthItem != null)
        {
            playerHealth.addHealth(healthItem.healthAmount);
            Destroy(healthItem.gameObject);
        }

        if (shieldItem != null)
        {
            gameObject.GetComponent<PlayerShieldScript>().shieldOn();
            Destroy(shieldItem.gameObject);
        }

        if (pointsItem != null)
        {
            gameObject.GetComponent<PlayerScoreScript>().addPoints(pointsItem.numPoints);
            Destroy(pointsItem.gameObject);
        }
    }
}
