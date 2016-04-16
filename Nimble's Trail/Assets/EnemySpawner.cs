using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
    public GameObject enemy;
    float spawnTimer = 15.0f;

    GameObject currentEnemy;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (currentEnemy == null)
            spawnTimer -= Time.deltaTime;

        if(spawnTimer <= 0.0f)
        {
            spawnTimer = 15.0f;
            currentEnemy = (GameObject)GameObject.Instantiate(enemy, transform.position, transform.rotation);
        }
	}
}
