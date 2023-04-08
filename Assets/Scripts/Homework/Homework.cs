using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homework : MonoBehaviour
{
    [Header("Homework Settings")]
    [SerializeField] private int damageAmount = 5;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DestroyHomeworks"))
        {
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
