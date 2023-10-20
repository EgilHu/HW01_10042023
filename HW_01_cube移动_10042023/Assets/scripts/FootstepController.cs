using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    private AudioSource footstepAudioSource;

    void Start()
    {
        footstepAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        if (movement.magnitude > 0.01f && !footstepAudioSource.isPlaying)
        {
            footstepAudioSource.Play();
        }
        else if (movement.magnitude < 0.01f && footstepAudioSource.isPlaying)
        {
            footstepAudioSource.Stop();
        }
    }
}

