using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public float health, animationSlowness;
    private float maxHealth, realScale;


    void Start()
    {
        maxHealth = health;
    }

    void Update()
    {
        realScale = health / maxHealth;

        if (transform.localScale.x > realScale)
        {
            transform.localScale = new Vector3(transform.localScale.x - (transform.localScale.x-realScale) / animationSlowness, transform.localScale.y, transform.localScale.z);
        }

        if (transform.localScale.x < realScale)
        {
            transform.localScale = new Vector3(transform.localScale.x + (realScale - transform.localScale.x) / animationSlowness, transform.localScale.y, transform.localScale.z);
        }

        if (Input.GetKeyDown("a") && health>0)
        {
            health -= 10;
        }

        if (Input.GetKeyDown("s") && health > 0)
        {
            health -= 5;
        }

        if (Input.GetKeyDown("d") && health > 0)
        {
            health -= 1;
        }

        if (Input.GetKeyDown("r") && health < maxHealth)
        {
            health = maxHealth;
        }

        if (health < 0)
        {
            health = 0;
        }

        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
}
