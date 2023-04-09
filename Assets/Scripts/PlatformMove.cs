using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    [SerializeField] private float jiggleSpeed = 1f; // Platformun jiggle hizi
    [SerializeField] private float distance = 1f; // Platformun jiggle mesafesi

    private Vector3 startPos; // Platformun baslangic konumu
    private float sineValue = 0f;

    private void Start()
    {
        startPos = transform.position; // Platformun baslangic konumunu kaydet
    }

    private void Update()
    {
        sineValue = Mathf.Sin(Time.time * jiggleSpeed);
        transform.position = Vector3.right * distance * sineValue * 0.5f + startPos;
    }
}
