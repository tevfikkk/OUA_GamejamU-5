using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaDamage : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    [SerializeField] private float damageRate = 1;
    [SerializeField] private float pushBackForce = 10;

    private float nextDamage;
    private Player player;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }


    /// <summary>
    /// Deals damage to the player when it collides with the lava
    /// </summary>
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Player>() && nextDamage < Time.time)
        {
            player.TakeDamage(damage);
            player._particleSystem.Play();
            nextDamage = Time.time + damageRate;

            PushBack(other.transform);
        }
    }

    /// <summary>
    /// Stops the particle system when the player leaves the lava
    /// </summary>
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            player._particleSystem.Stop();
        }
    }

    /// <summary>
    /// Pushes the object back when it collides with the lava
    /// </summary>
    private void PushBack(Transform pushedObject)
    {
        Vector2 pushDirection = new Vector2(0, (pushedObject.position.y - transform.position.y)).normalized;
        pushDirection *= pushBackForce;
        Rigidbody2D pushRB = pushedObject.gameObject.GetComponent<Rigidbody2D>();
        pushRB.velocity = Vector2.zero;
        pushRB.AddForce(pushDirection, ForceMode2D.Impulse);
    }
}
