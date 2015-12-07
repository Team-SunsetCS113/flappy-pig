using UnityEngine;
using System.Collections;

public class SpawnEnemyScript : MonoBehaviour {

    public GameObject weaponizedEnemy;  
    public GameObject dynamicEnemy;
    public float topAdjustment;
    public float bottomAdjustment;
    public float initialSpawnTime = 5f;
    public float spawnTime = 2f;
    private int spawn;

    GameObject player;
  
    // Use this for initialization
	void Start () {
       player = GameObject.Find("Player");
       InvokeRepeating("addEnemy", initialSpawnTime, spawnTime);
	}

    void Update()
    {
        if (player == null)
        {
            Destroy(gameObject);
        }
    }

    void addEnemy()
    {
        var dist = (transform.position - Camera.main.transform.position).z;

        var bottomBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(0, 0, dist)
        ).y + bottomAdjustment;

        var topBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(0, 1, dist)
        ).y + topAdjustment;

        var spawnPoint = new Vector2(transform.position.x, Random.Range(topBorder, bottomBorder));
        
        spawn = Random.Range(0, 2);

        if (spawn == 0)
        {
            Instantiate(weaponizedEnemy, spawnPoint, Quaternion.identity);
        }
        else if (spawn == 1)
        {
            Instantiate(dynamicEnemy, spawnPoint, Quaternion.identity);
        }
    }
}
