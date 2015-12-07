using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealthScript : MonoBehaviour {

    public float maxHealth = 100f;
    private float currHealth;

    private bool isEnemy = false;
    public bool hasShield = false;

    void Start()
    {
        currHealth = maxHealth;
    }

    public float hp()
    {
        return currHealth;
    }

    public bool enemy()
    {
        return isEnemy;
    }

    public void addDamage(float damageCount)
    {
        if (hasShield)
        {
            gameObject.GetComponent<PlayerShieldScript>().SendMessage("shieldDamage");
            return;
        }           
        
        currHealth -= damageCount;

        if (currHealth <= 0)
        {
            if (gameObject != null) { 
                // Explosion!
                SpecialEffectsHelper.Instance.Explosion(transform.position);
               // SoundEffectsHelper.Instance.MakeExplosionSound();
            
                // Dead!
                Destroy(gameObject);
                Destroy(GameObject.Find("playerHealthUI"));
            }
        }
    }

    public void addHealth(float healthAmount)
    {
        currHealth += healthAmount;
        if (currHealth > maxHealth)
        {
            currHealth = maxHealth;
        }
    }
}
