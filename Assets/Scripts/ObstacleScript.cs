using UnityEngine;

/// <summary>
/// Enemy generic behavior
/// </summary>
public class ObstacleScript : MonoBehaviour
{
    private bool hasSpawn;

    GameObject player;

    // Disable everything
    void Start()
    {
        player = GameObject.Find("Player");

        hasSpawn = false;

        // Disable everything
        // -- collider
        GetComponent<Collider2D>().enabled = false;
    }

    void Update()
    {
        // In the camera but player is null ? Destroy the game object.
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
    }
}
