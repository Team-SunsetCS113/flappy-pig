using UnityEngine;
using System.Collections;

public class PlayerShieldScript : MonoBehaviour {

    public float maxShieldHealth = 3f;
    private float currShieldHealth;
    private GameObject playerShield;
    private PlayerHealthScript playerHealth;
 
	// Use this for initialization
	void Start () {
        playerShield = gameObject.transform.FindChild("BubbleShield").gameObject;   
        currShieldHealth = maxShieldHealth;
        playerHealth = gameObject.GetComponentInParent<PlayerHealthScript>();
	}
	
	// Update is called once per frame
	void Update () {
        if (currShieldHealth <= 0)
        {
            shieldOff();
        }
	}

    public void shieldOn()
    {
        currShieldHealth = maxShieldHealth;
        playerShield.SetActive(true);
        playerHealth.hasShield = true;
    }

    public void shieldOff()
    {
        playerShield.SetActive(false);
        playerHealth.hasShield = false;            
    }

    public void shieldDamage()
    {
        currShieldHealth--;
    }
}
