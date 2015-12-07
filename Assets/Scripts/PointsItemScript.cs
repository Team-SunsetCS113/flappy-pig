using UnityEngine;
using System.Collections;

public class PointsItemScript : MonoBehaviour
{
    public int numPoints = 5;
    private GameObject player;

    // Use this for initialization
	void Start () {
        Destroy(gameObject, 10);
        player = GameObject.Find("Player");
	}

    void Update()
    {
        if (player == null)
        {
            Destroy(gameObject);
        }
    }
}
