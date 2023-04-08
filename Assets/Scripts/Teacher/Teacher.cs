using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Teacher class is responsible for managing the teacher object.
/// It is responsible for the teacher's movement, animations, and interactions with the student.
/// </summary>

public class Teacher : MonoBehaviour
{
    // Teacher State Machine
    public enum TeacherState
    {
        IdleState,
        ThrowingState, // Throwing scholl stuff at the student
        CollectingState // Collecting the scholl stuff
    }

    [Header("Teacher Object Settings")]
    [SerializeField] private GameObject homeworkPrefabVar;
    [SerializeField] private TeacherState state = TeacherState.IdleState;
    [SerializeField] private float throwingSpeed = 2.5f;
    [SerializeField] private float delayBetweenThrows = 1f;
    [SerializeField] private Transform studentPoint; // 


    private void Start()
    {
        SetState(TeacherState.IdleState);
    }

    private void Update()
    {
        switch (state)
        {
            case TeacherState.IdleState:
                IdlingState();
                break;
            case TeacherState.ThrowingState:
                ThrowingState();
                break;
            case TeacherState.CollectingState:
                CollectingState();
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Set the state of the teacher depending upon the state passed.
    /// </summary>
    private void SetState(TeacherState state)
    {
        this.state = state;
        Debug.Log($"Teacher is now in {state} state.");
    }

    private void IdlingState()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetState(TeacherState.ThrowingState);
            StartCoroutine(ThrowingHomeWorks(studentPoint.position));
        }
    }

    private void ThrowingState()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetState(TeacherState.CollectingState);
            Debug.Log("Teacher is throwing school stuff at the student.");
        }
    }

    private void CollectingState()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SetState(TeacherState.IdleState);
            Debug.Log("Teacher is collecting the school stuff.");
        }
    }

    /// <summary>
    /// Coroutine for throwing the school stuff at the student.
    /// </summary>
    private IEnumerator ThrowingHomeWorks(Vector3 targetPosition)
    {
        while (true)
        {
            if (TeacherState.ThrowingState == state)
            {
                GameObject homework = TeacherObjectPool.Instance.GetObject();
                targetPosition = studentPoint.position;

                if (homework != null && targetPosition != null)
                {
                    float step = throwingSpeed * Time.deltaTime;

                    homework.transform.position = transform.position;
                    // Random range is used to make the homework throw more random.
                    homework.GetComponent<Rigidbody2D>().AddForce(Vector2.left * Random.Range(300f, 500f));
                    // homework.transform.position = Vector3.Lerp(homework.transform.position, targetPosition, step);
                    homework.SetActive(true);
                }
            }

            yield return new WaitForSeconds(delayBetweenThrows);
        }
    }
}
