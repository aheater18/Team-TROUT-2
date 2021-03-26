using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Text health;
    public float currentHP = 5;
    private float maxHP = 5;
    private float damage = 1;
    private float timeTillNextAttack = 1.0f;
    private float nextAttack;
    public bool hpRegan = false;
    private WaitForSeconds healthRegan = new WaitForSeconds(3.0f);
    void Start()
    {
        
    }

    void Update()
    {
        if (currentHP <= 0) 
        {
            Destroy(this.gameObject);
        }

        if (hpRegan && maxHP != currentHP) 
        {
            StartCoroutine(Regan());
        }

        if (currentHP == maxHP) {
            hpRegan = false;
        }

        health.text = "Health: " + currentHP;
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Enemy")
    //    {
    //        hpRegan = false;
    //        currentHP -= damage;
    //        Debug.Log(currentHP);
    //    }
    //}

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" && Time.time > nextAttack)
        {
            hpRegan = false;
            nextAttack = Time.time + timeTillNextAttack; 
            currentHP -= damage;
            Debug.Log(currentHP);
        }
    }

    private void OnCollisionExit(Collision collision)
    {

        if (collision.gameObject.tag == "Enemy" && currentHP != maxHP)
        {
            hpRegan = true;           
        }
    }

    private IEnumerator Regan() 
    {
        yield return healthRegan;
        if (currentHP != maxHP)
        {
            currentHP++;
        }
    }
}
