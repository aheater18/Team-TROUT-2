using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    
    public float fireRate = .25f;
    public float weaponRange = 50f;
    public Transform gunEnd;
    [SerializeField] private float damage = 1f;

    // How long the bullet trail is on the screen
    private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);
    // Bullet trail
    private LineRenderer laserLine;
    private float nextFire;

    // Start is called before the first frame update
    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Can the user shoot agin
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire && Time.timeScale == 1.0f) {
            nextFire = Time.time + fireRate;

            StartCoroutine(ShotEffect());

            GetComponent<FMODUnity.StudioEventEmitter>().Play();

            // Begining of rayTrace
            Vector3 rayOrigin = gunEnd.transform.position;

            RaycastHit hit;

            // Begining of bullet trail
            laserLine.SetPosition(0, gunEnd.transform.position);

            

            // Checkes if the raytracing hit anything
            if (Physics.Raycast(rayOrigin, gunEnd.transform.forward, out hit, weaponRange))
            {
                // Stops the trail on the object that it hit
                laserLine.SetPosition(1, hit.point);
                if (hit.transform.GetComponent<MortalEntity>())
                {
                    hit.transform.GetComponent<MortalEntity>().Health -= this.damage;
                    GetComponent<ScoreAndHealth>().Points += 20;
                }
            }
            else
            {
                // Continues until the raytrace hit the weapon range
                laserLine.SetPosition(1, rayOrigin + (transform.forward * weaponRange));
            }
        }
    }

    // Shows the bullet trail
    private IEnumerator ShotEffect() 
    {
        laserLine.enabled = true;

        yield return shotDuration;

        laserLine.enabled = false;
    }
}
