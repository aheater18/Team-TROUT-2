using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoor : MonoBehaviour
{
	//how many points player needs to unlock this door
	public int pointsCost = 500;
	
	//spawn locations to add to EnemySpawner from newly unlocked rooms
	public GameObject[] newSpawnLocations;
	
	//reference to spawn locations that are active in EnemySpawner
	private List<GameObject> gameManagerSpawnsList;

	//Refernce to player for checking score / removing points
	private GameObject player;

	//is the player touching a door?
	private bool playerNearDoor = false;
    // Start is called before the first frame update
    void Start()
    {
        gameManagerSpawnsList = GameObject.Find("Game Manager").GetComponent<EnemySpawner>().spawnLocations;
		player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space") && playerNearDoor == true)
		{
			//Check if player has enough points, subtract and continue if they do
			if (player.GetComponent<ScoreAndHealth>().points < pointsCost)
				return;
			player.GetComponent<ScoreAndHealth>().points -= pointsCost;
				
			for(int i = 0; i < newSpawnLocations.Length; i++)
			{
				//this makes it so unity prioritizes spawning zombies in the rooms the player opened recently
				gameManagerSpawnsList.Insert(0, newSpawnLocations[i]);
			}
				
			GameObject.Destroy(this.gameObject);
		}
    }
	
	private void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "Player")
		{
			playerNearDoor = true;
			Debug.Log("touching");
		}
		else
		{
			playerNearDoor = false;
		}
	}
}
