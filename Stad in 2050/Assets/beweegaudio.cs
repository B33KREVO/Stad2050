using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beweegaudio : MonoBehaviour
{
    public AudioSource footstepAudioSource; // Attach your AudioSource here
    public AudioClip footstepSound;         // Drag and drop the footstep sound clip in Inspector
    public float stepDelay = 0.5f;          // Time between footsteps, adjust for realism
    private float stepCooldown = 0.0f;      // Tracks cooldown between steps

    private CharacterController characterController;

    void Start()
    {
        // Get the CharacterController component to check movement
        characterController = GetComponent<CharacterController>();

        // Ensure AudioSource is set up
        if (footstepAudioSource == null)
        {
            footstepAudioSource = gameObject.AddComponent<AudioSource>();
        }
        
        footstepAudioSource.clip = footstepSound;
        footstepAudioSource.playOnAwake = false;
    }

    void Update()
    {
        // Only play sound if character is moving and step cooldown has passed
        if (characterController.isGrounded && characterController.velocity.magnitude > 0.1f)
        {
            stepCooldown -= Time.deltaTime;

            if (stepCooldown <= 0f)
            {
                footstepAudioSource.Play();
                stepCooldown = stepDelay;  // Reset the cooldown
            }
        }
    }
}
