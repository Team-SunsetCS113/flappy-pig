using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    public float flapSpeed = 175f;
    public float forwardSpeed = 0;
    private bool didFlap = false;
    public int movementPoints = 10;
    public float collisionDamage = 1f;
    private float xPosComplement;

    Animator animator;

    // Use this for initialization
    void Start () {
        animator = transform.GetComponentInChildren<Animator>();

        if (animator == null)
        {
            Debug.LogError("Didn't find animator!");
        }
        xPosComplement = 0 - transform.position.x;
        InvokeRepeating("addPoints", 1f, 1f);
	}
	
	// Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            didFlap = true;

			AudioSource[] audios = GetComponents<AudioSource>();
			var randomAudio = audios[Random.Range(0,4)];
			randomAudio.Play();
        }

        bool shoot = Input.GetButtonDown("Fire1");
        shoot |= Input.GetButtonDown("Fire2");

        if (shoot)
        {
            WeaponScript weapon = GetComponent<WeaponScript>();
            if (weapon != null)
            {
                weapon.Attack(false);
            }
        }

        // Make sure player is not outside the camera bounds
        var dist = (transform.position - Camera.main.transform.position).z;

        var leftBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(0, 0, dist)
        ).x;

        var rightBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(1, 0, dist)
        ).x;

        var bottomBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(0, 0, dist)
        ).y;

        var topBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(0, 1, dist)
        ).y;

        transform.position = new Vector3(
          Mathf.Clamp(transform.position.x, leftBorder + xPosComplement, rightBorder),
          Mathf.Clamp(transform.position.y, bottomBorder, topBorder),
          transform.position.z
        );
    }

    void FixedUpdate() {
        if(gameObject == null)
			return;

		GetComponent<Rigidbody2D>().AddForce( Vector2.right * forwardSpeed );

		if(didFlap) {
			GetComponent<Rigidbody2D>().AddForce( Vector2.up * flapSpeed );

            animator.SetTrigger("DoFlap");

			didFlap = false;
		}

		if(GetComponent<Rigidbody2D>().velocity.y > 0) {
			transform.rotation = Quaternion.Euler(0, 0, 0);
		}
		else {
			float angle = Mathf.Lerp (0, -90, (-GetComponent<Rigidbody2D>().velocity.y / 3f) );
			transform.rotation = Quaternion.Euler(0, 0, angle);
		}
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        bool damagePlayer = false;

		AudioSource[] audios = GetComponents<AudioSource>();
		var randomAudio = audios[Random.Range(4,7)];
		randomAudio.Play();

		// Collision with enemy
        WeaponizedEnemyScript enemy1 = collision.gameObject.GetComponent<WeaponizedEnemyScript>();
        if (enemy1 != null)
        {
            // Damage the enemy
            EnemyHealthScript enemyHealth = enemy1.GetComponent<EnemyHealthScript>();
            if (enemyHealth != null) enemyHealth.addDamage(collisionDamage);

            damagePlayer = true;
        }

        // Collision with enemy
        DynamicEnemyScript enemy2 = collision.gameObject.GetComponent<DynamicEnemyScript>();
        if (enemy2 != null)
        {
            // Damage the enemy
            EnemyHealthScript enemyHealth = enemy2.GetComponent<EnemyHealthScript>();
            if (enemyHealth != null) enemyHealth.addDamage(collisionDamage);

            damagePlayer = true;
        }

        // Collision with obstacle
        ObstacleScript obstacle = collision.gameObject.GetComponent<ObstacleScript>();
        if (obstacle != null)
        {
            // Damage the obstacle
            EnemyHealthScript obstacleHealth = obstacle.GetComponent<EnemyHealthScript>();
            if (obstacleHealth != null) obstacleHealth.addDamage(collisionDamage);

            damagePlayer = true;
        }

        // Damage the player
        if (damagePlayer)
        {
            PlayerHealthScript playerHealth = this.GetComponent<PlayerHealthScript>();
            if (playerHealth != null) playerHealth.addDamage(collisionDamage);
        }
    }

   // void OnDestroy()
   // {
        //Application.LoadLevel("UnderwaterLevel");    
   // }

    void addPoints()
    {
        if (gameObject != null)
        {
            gameObject.GetComponent<PlayerScoreScript>().addPoints(movementPoints);
        }
    }
}