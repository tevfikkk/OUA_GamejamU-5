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
    [SerializeField] private TeacherState state = TeacherState.IdleState;
    [SerializeField] private float throwingSpeed = 2.5f;

    private void Start()
    {
        // Set the initial state of the teacher
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
}
