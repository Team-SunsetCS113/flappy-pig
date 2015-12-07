using UnityEngine;
using System.Collections;

public class DynamicMovementScript : MonoBehaviour {

    public float followSpeed = 3f;
    public float minDistance = 1f;
    // private float range;
    public Vector2 direction = new Vector2(-1, 0);
    public Vector2 forwardSpeed = new Vector2(3, 10);

    private GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x <= player.transform.position.x + minDistance)
        {
            Vector3 movement = new Vector3(forwardSpeed.x * direction.x, forwardSpeed.y * direction.y, 0);
            movement *= Time.deltaTime;
            transform.Translate(movement);
        }
        else
        {
            //range = Vector2.Distance(transform.position, player.transform.position);
            //if (range > minDistance)
            //{
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, followSpeed * Time.deltaTime);
            //}
        }
	
	}
}
