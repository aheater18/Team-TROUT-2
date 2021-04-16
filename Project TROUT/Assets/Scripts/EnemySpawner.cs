using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
	public GameObject enemy;
	public int maxNumOfEnemies = 0;
	public float maxSpeed = 5.0f;
	public List<GameObject> enemyList;
	public List<GameObject> spawnLocations = new List<GameObject>();
	private float xPos;
	private float zPos;
	private MortalEntity mortalEntityRef;
	private NavMeshAgent enemyAgent;
	

    // Start is called before the first frame update
    void Start()
    {
		mortalEntityRef = enemy.GetComponent<MortalEntity>();
		enemyList = new List<GameObject>();
		enemyAgent = enemy.GetComponent<NavMeshAgent>();
		enemyAgent.speed = 1.8f;
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
		//difficulty so far is mostly increasing zombie speed after every wave
		if(enemyAgent.speed <= maxSpeed)
		{
			enemyAgent.speed += .2f ;
		}
		
		/*
		if(maxNumOfEnemies > 1)
		{
			//doesn't work due to hp being clamped in MortalEntity
			//mortalEntityRef.Health = 6;
		}
		
		else if(maxNumOfEnemies > 19)
		{
			mortalEntityRef.damage = 2;
		}
		*/
		for (int i = 0; i < maxNumOfEnemies; i++)
		{
			//if there unique spawn locations remaining, use them
			if(i < spawnLocations.Count)
			{
				xPos = spawnLocations[i].transform.position.x;
				zPos = spawnLocations[i].transform.position.z;
			}
			//otherwise, have extra zombies share spawns at random
			else
			{
				int randomSpawn = Random.Range(0, spawnLocations.Count);
				xPos = spawnLocations[randomSpawn].transform.position.x;
				zPos = spawnLocations[randomSpawn].transform.position.z;
			}
			enemyList.Add(Instantiate(enemy, new Vector3(xPos, 1.5f, zPos), Quaternion.identity));
		}
	}
}
