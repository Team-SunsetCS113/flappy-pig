using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealthScript : MonoBehaviour {

    public float maxHealth = 2f;
    private float currHealth;
    public int deadPoints = 20;

    private bool isEnemy = true;
    public GameObject itemDrops;
    private int item;
    
    void Start()
    {
        currHealth = maxHealth;
    }

    public float hp()
    {
        return currHealth;
    }

    public void addDamage(float damageCount)
    {
        currHealth -= damageCount;

        if (currHealth <= 0)
        {
            if (gameObject != null) { 
                // Explosion!
                SpecialEffectsHelper.Instance.Explosion(transform.position);
                // SoundEffectsHelper.Instance.MakeExplosionSound();
            
                // Dead!
                Destroy(gameObject);

                // Add points
                GameObject.Find("Player").GetComponent<PlayerScoreScript>().addPoints(deadPoints);

                // Random item drop
                item = Random.Range(0, 10);
                if (item == 0 || item == 1)
                {
                    GameObject healthItem = itemDrops.transform.FindChild("HealthItem").gameObject;
                    Instantiate(healthItem, transform.position, transform.rotation);
                }
                else if (item == 2 || item == 3)
                {
                    GameObject shieldItem = itemDrops.transform.FindChild("ShieldItem").gameObject;
                    Instantiate(shieldItem, transform.position, transform.rotation);
                }
                else if (item == 4 || item == 5)
                {
                    GameObject pointsItem = itemDrops.transform.FindChild("PointsItem").gameObject;
                    Instantiate(pointsItem, transform.position, transform.rotation);
                }         
            }
        }
    }

	void OnTriggerEnter2D (Collider2D collider) {
        ShotScript shot = collider.gameObject.GetComponent<ShotScript>();
      
        if (shot != null)
        {
            if (shot.isEnemyShot != isEnemy)
            {
               addDamage(shot.damage);
               Destroy(shot.gameObject);
            }
        }
    }
}
