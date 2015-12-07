using UnityEngine;

/// <summary>
/// Enemy generic behavior
/// </summary>
public class WeaponizedEnemyScript : MonoBehaviour
{
    private bool hasSpawn;
    private SimpleMovementScript movementScript;
    private WeaponScript[] weapons;

    GameObject player;

    void Awake()
    {
        // Retrieve the weapon only once
        weapons = GetComponentsInChildren<WeaponScript>();

        // Retrieve scripts to disable when not spawn
        movementScript = GetComponent<SimpleMovementScript>();
    }

    // Disable everything
    void Start()
    {
        player = GameObject.Find("Player");

        hasSpawn = false;

        // Disable everything
        // -- collider
        GetComponent<Collider2D>().enabled = false;
        // -- Moving
        movementScript.enabled = false;
        // -- Shooting
        foreach (WeaponScript weapon in weapons)
        {
            weapon.enabled = false;
        }
    }

    void Update()
    {
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
            // Auto-fire
            foreach (WeaponScript weapon in weapons)
            {
                if (weapon != null && weapon.enabled && weapon.CanAttack)
                {
                    weapon.Attack(true);
                }
            }

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
        // -- Shooting
        foreach (WeaponScript weapon in weapons)
        {
            weapon.enabled = true;
        }
    }
}
