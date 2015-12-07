using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour {

    public float damage = 1f;

    public bool isEnemyShot = false;

	// Use this for initialization
	void Start () {

        Destroy(gameObject, 7);

	}
	
}
