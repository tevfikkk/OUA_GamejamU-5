using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuffCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            // Student.Instance.TakeDamage();
            TeacherObjectPool.Instance.ReturnObject(gameObject);
            print($"other.gameObject.name: {gameObject.name}");
        }
    }
}
