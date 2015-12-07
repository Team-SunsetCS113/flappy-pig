using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealthBarScript : MonoBehaviour {

    public Slider healthSlider;
    public Image healthColorFill;

    PlayerHealthScript playerHealth;

	// Use this for initialization
	void Start () {
        playerHealth = gameObject.GetComponent<PlayerHealthScript>();
	}
	
	// Update is called once per frame
	void Update () {
        
        healthSlider.value = playerHealth.hp() / playerHealth.maxHealth;

        if (healthSlider.value > 0.2)
        {
            healthColorFill.color = new Color(0, 255, 0, 255);
        }

        else {
            healthColorFill.color = Color.red;
        }
	}
}
