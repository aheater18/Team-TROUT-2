using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public GameObject enemy;
	public int maxNumOfEnemies = 0;
	public List<GameObject> enemyList;
	public GameObject[] spawnLocations;
	private float xPos;
	private float zPos;
	

    // Start is called before the first frame update
    void Start()
    {
		enemyList = new List<GameObject>();
		spawnLocations = GameObject.FindGameObjectsWithTag("Respawn");
    }
	
	void Update()
	{
		if(enemyList.Count == 0)
		{
			maxNumOfEnemies += 1;
			EnemyDrop();
		}
	}
	
	void EnemyDrop()
	{	
		for (int i = 0; i < maxNumOfEnemies; i++)
		{
			//xPos = Random.Range(-44, 46);
			//zPos = Random.Range(-44, 46);
			xPos = spawnLocations[i].transform.position.x;
			zPos = spawnLocations[i].transform.position.z;
			enemyList.Add(Instantiate(enemy, new Vector3(xPos, 1.5f, zPos), Quaternion.identity));
		}
	}
}
