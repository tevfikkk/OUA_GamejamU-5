using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] Button muteButton;

    private bool isMuted = false;
    private float volume = 1f;

    private void Start()
    {
        muteButton.onClick.AddListener(ToggleMute);
    }

    private void Update()
    {
        // Check if the audio source is not playing and play it
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    private void ToggleMute()
    {
        // Toggle the mute state
        isMuted = !isMuted;

        // Set the volume to 0 if muted, otherwise set it to the volume
        audioSource.volume = isMuted ? 0.0f : volume;
    }
}
