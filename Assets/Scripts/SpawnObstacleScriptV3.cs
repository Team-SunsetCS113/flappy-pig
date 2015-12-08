using UnityEngine;
using System.Collections;

public class SpawnObstacleScriptV3 : MonoBehaviour {

    private GameObject topObstacle;
    public GameObject topObstacle1;
    public GameObject topObstacle2;
    public GameObject topObstacle3;
    public GameObject topObstacle4;
    public GameObject topObstacle5;
    public GameObject topObstacle6;
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
            int top = Random.Range(0, 6);
            switch (top)
            {
                case 0: topObstacle = topObstacle1;
                        break;
                case 1: topObstacle = topObstacle2;
                        break;
                case 2: topObstacle = topObstacle3;
                        break;
                case 3: topObstacle = topObstacle4;
                        break;
                case 4: topObstacle = topObstacle5;
                        break;
                case 5: topObstacle = topObstacle6;
                        break;
            }
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
            int top = Random.Range(0, 6);
            switch (top)
            {
                case 0: topObstacle = topObstacle1;
                    break;
                case 1: topObstacle = topObstacle2;
                    break;
                case 2: topObstacle = topObstacle3;
                    break;
                case 3: topObstacle = topObstacle4;
                    break;
                case 4: topObstacle = topObstacle5;
                    break;
                case 5: topObstacle = topObstacle6;
                    break;
            }
            Instantiate(topObstacle, spawnPoint, Quaternion.identity);
            spawnPoint = new Vector2(transform.position.x, bottomBorder + bottomAdjustment);
            Instantiate(bottomObstacle, spawnPoint, Quaternion.identity);
        }
    }
}
