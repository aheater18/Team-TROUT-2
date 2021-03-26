using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMovement : MonoBehaviour
{
	[SerializeField]
	Transform playerPosition;
	NavMeshAgent zombieAgent;
	
	void Start()
	{
		zombieAgent = this.GetComponent<NavMeshAgent>();
		playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
	}

	void Update()
	{
		Vector3 target = playerPosition.position;
		zombieAgent.SetDestination(target);
	}
}

/*
Legacy code
public class ZombieMovement : MonoBehaviour
{
	public Transform playerPosition;
	public float minSpeed = 1.0f;
	public float maxSpeed = 1.0f;
	private float speed = 1.0f;
	private float rotationSpeed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
		playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
		speed = Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
		//Look at player
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(playerPosition.position - 
		transform.position), rotationSpeed * Time.deltaTime);
		
		//Move to player
		transform.position += transform.forward * speed * Time.deltaTime;
    }
}
*/