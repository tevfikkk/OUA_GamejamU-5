using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    [SerializeField] private float jiggleSpeed = 1f; // Platformun jiggle hizi

    private Vector3 startPos; // Platformun baslangic konumu

    private void Start()
    {
        startPos = transform.position; // Platformun baslangic konumunu kaydet
    }

    private void FixedUpdate()
    {
        StartCoroutine(MakeThePlatformJiggle()); // Platformun jiggle fonksiyonunu calistir
    }


    /// <summary>
    /// Platformun jiggle fonksiyonu
    /// </summary>
    private IEnumerator MakeThePlatformJiggle()
    {
        while (true)
        {
            transform.position = Vector3.right * Mathf.Sin(Time.time * jiggleSpeed) * 0.5f + startPos; // Platformun jiggle fonksiyonu
            yield return null;
        }
    }
}
