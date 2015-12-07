using UnityEngine;
using System.Collections;

public class SpawnObstacleScriptV1 : MonoBehaviour {

    public GameObject topObstacle;
    public float topAdjustment;
    public GameObject bottomObstacle;
    public float bottomAdjustment;
    public float initialSpawnTime = 2f;
    public float spawnTime = 5f;
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
        ).y;

        var topBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(0, 1, dist)
        ).y;

        Vector2 spawnPoint;

        spawn = Random.Range(0, 10);

        if (spawn == 0 || spawn == 1 || spawn == 2)
        {
            spawnPoint = new Vector2(transform.position.x, topBorder + topAdjustment);
            Instantiate(topObstacle, spawnPoint, Quaternion.identity);
        }
        else if (spawn == 3 || spawn == 4 || spawn == 5)
        {
            spawnPoint = new Vector2(transform.position.x, bottomBorder + bottomAdjustment);
            Instantiate(bottomObstacle, spawnPoint, Quaternion.identity);
        }
        else if (spawn == 6 || spawn == 7 || spawn == 8)
        {
            spawnPoint = new Vector2(transform.position.x, topBorder + topAdjustment);
            Instantiate(topObstacle, spawnPoint, Quaternion.identity);
            spawnPoint = new Vector2(transform.position.x, bottomBorder + bottomAdjustment);
            Instantiate(bottomObstacle, spawnPoint, Quaternion.identity);
        }
    }
}
