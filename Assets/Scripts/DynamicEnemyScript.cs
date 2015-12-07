using UnityEngine;
using System.Collections;

public class DynamicEnemyScript : MonoBehaviour {

    private bool hasSpawn;
    private DynamicMovementScript movementScript;
    private GameObject player;

    void Awake()
    {
        // Retrieve scripts to disable when not spawn
        movementScript = GetComponent<DynamicMovementScript>();
    }

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");

        hasSpawn = false;

        // Disable everything
        // -- collider
        GetComponent<Collider2D>().enabled = false;
        // -- Moving
        movementScript.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

        // If the player is null ? Destroy the game object.
        if (player == null)
        {
            Destroy(gameObject);
        }

        // Check if the enemy has spawned.
        if (hasSpawn == false)
        {
            if (GetComponent<Renderer>().IsVisibleFrom(Camera.main))
            {
                Spawn();
            }
        }
        else
        {
            // Out of the camera ? Destroy the game object.
            if (GetComponent<Renderer>().IsVisibleFrom(Camera.main) == false)
            {
                Destroy(gameObject);
            }
        }
	}

    // Activate itself.
    private void Spawn()
    {
        hasSpawn = true;

        // Enable everything
        // -- Collider
        GetComponent<Collider2D>().enabled = true;
        // -- Moving
        movementScript.enabled = true;
    }
}
