using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [Header("PlayerCollision Settings")]
    [SerializeField] private int damageAmount = 5;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Homework") || other.gameObject.CompareTag("TeacherHomework"))
        {
            FindObjectOfType<Player>()?.TakeDamage(damageAmount);
            HomeworkObjectPool.Instance.ReturnObject(other.gameObject);
        }
    }
}
