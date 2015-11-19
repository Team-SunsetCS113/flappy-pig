using UnityEngine;
using System.Collections;

public class PigMovement : MonoBehaviour {

	Vector3 velocity = Vector3.zero;
	public float flapSpeed    = 100f;
	public float forwardSpeed = 1f;

    private int health = 100;

	bool didFlap = false;
	public bool flapOnce = false;

	Animator animator;

	public bool dead = false;
	float deathCooldown;

	public bool godMode = true;

	// Use this for initialization
	void Start () {
		animator = transform.GetComponentInChildren<Animator>();

		if(animator == null) {
			Debug.LogError("Didn't find animator!");
		}
	}

	// Do Graphic & Input updates here
	void Update() {
		if(dead) {
			deathCooldown -= Time.deltaTime;

			if(deathCooldown <= 0) {
				if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) ) {
					Application.LoadLevel( Application.loadedLevel );
				}
			}
		}
		else {
			if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) ) {
				didFlap = true;
				flapOnce = true;
				AudioSource[] audios = GetComponents<AudioSource>();
				var randomAudio = audios[Random.Range(0,4)];
				randomAudio.Play();
			}
		}
	}

	
	// Do physics engine updates here
	void FixedUpdate () {

		if(dead)
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

	void OnCollisionEnter2D(Collision2D collision) {
		if(godMode)
			return;

		dead = false;
		deathCooldown = 0.5f;

		AudioSource[] audios = GetComponents<AudioSource>();
		var randomAudio = audios[Random.Range(4,7)];
		randomAudio.Play();
		StartCoroutine(DoBlinks(0.2f, 0.25f));

	}

	IEnumerator DoBlinks(float duration, float blinkTime) {
		while (duration > 0f) {
			duration -= Time.deltaTime;
			
			//toggle renderer
			GetComponentInChildren<Renderer>().enabled = !GetComponentInChildren<Renderer>().enabled;
			
			//wait for a bit
			yield return new WaitForSeconds(blinkTime);
		}
		
		//make sure renderer is enabled when we exit
		GetComponentInChildren<Renderer>().enabled = true;
	}


}
