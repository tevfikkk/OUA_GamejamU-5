using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [Header("PlayerCollision Settings")]
    [SerializeField] private int damageAmount = 5;

    private HomeworkObjectPool homeworkObjectPool;

    private void Awake()
    {
        homeworkObjectPool = FindAnyObjectByType<HomeworkObjectPool>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Homework") || other.gameObject.CompareTag("TeacherHomework"))
        {
            FindObjectOfType<Player>()?.TakeDamage(damageAmount);

            if (homeworkObjectPool != null)
            {
                homeworkObjectPool.ReturnObject(other.gameObject);
            }
        }
    }
}
