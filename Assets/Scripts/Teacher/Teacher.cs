using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Teacher class is responsible for managing the teacher object.
/// It is responsible for the teacher's movement, animations, and interactions with the student.
/// </summary>

public class Teacher : MonoBehaviour, ITeacher
{
    // Teacher State Machine
    public enum TeacherState
    {
        IdleState,
        ThrowingState, // Throwing scholl stuff at the student
    }

    [Header("Teacher Object Settings")]
    [SerializeField] private TeacherState state = TeacherState.IdleState;
    [SerializeField] private float throwingSpeed = 2.5f;
    [SerializeField] private float delayBetweenThrows = 1f;

    private TeacherObjectPool teacherObjectPool;

    private void Awake()
    {
        teacherObjectPool = FindAnyObjectByType<TeacherObjectPool>();
    }

    private void Start()
    {
        SetState(TeacherState.ThrowingState);
    }

    // private void Update()
    // {
    //     switch (state)
    //     {
    //         case TeacherState.IdleState:
    //             IdlingState();
    //             break;
    //         case TeacherState.ThrowingState:
    //             ThrowingState();
    //             break;
    //         default:
    //             break;
    //     }
    // }

    /// <summary>
    /// Set the state of the teacher depending upon the state passed.
    /// </summary>
    private void SetState(TeacherState state)
    {
        this.state = state;
        Debug.Log($"Teacher is now in {state} state.");
    }

    /// <summary>
    /// Set the state to throwing state and start the coroutine.
    /// </summary>
    public void IdlingState()
    {
        SetState(TeacherState.ThrowingState);
        StartCoroutine(ThrowingHomeWorks());
    }

    /// <summary>
    /// Stop the coroutine so that the teacher can go back to the idle state.
    /// </summary>
    public void ThrowingState()
    {
        SetState(TeacherState.IdleState);
        StopCoroutine(ThrowingHomeWorks());
    }

    /// <summary>
    /// Coroutine for throwing the school stuff at the student.
    /// </summary>
    private IEnumerator ThrowingHomeWorks()
    {
        while (true)
        {
            if (TeacherState.ThrowingState == state)
            {
                GameObject homework = teacherObjectPool.GetObject();

                if (homework != null)
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
