using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homework : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wall"))
        {
            if (gameObject.CompareTag("Homework"))
            {
                HomeworkObjectPool.Instance.ReturnObject(gameObject);
            }
            else if (gameObject.CompareTag("TeacherHomework"))
            {
                TeacherObjectPool.Instance.ReturnObject(gameObject);
            }

            // HomeworkObjectPool.Instance.ReturnObject(gameObject);
            // TeacherObjectPool.Instance.ReturnObjectToPool(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            // Student.Instance.TakeDamage();
            // TeacherObjectPool.Instance.ReturnObject(gameObject);
            // HomeworkObjectPool.Instance.ReturnObject(gameObject);
            if (gameObject.CompareTag("Homework"))
            {
                HomeworkObjectPool.Instance.ReturnObject(gameObject);
            }
            else if (gameObject.CompareTag("TeacherHomework"))
            {
                TeacherObjectPool.Instance.ReturnObject(gameObject);
            }
        }
    }
}
