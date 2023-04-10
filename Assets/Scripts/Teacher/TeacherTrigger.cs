using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacherTrigger : MonoBehaviour
{
    private Teacher teacher;

    private void Awake()
    {
        teacher = FindAnyObjectByType<Teacher>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            teacher.IdlingState();
            print("Teacher is now in IdleState.");
        }
    }
}
