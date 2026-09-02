using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody rb;
    private AudioSource audioSource;
    private Vector3 inputDirection;
    private List<Vector3> pressedDirections = new List<Vector3>();

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        var keyboard = Keyboard.current;
        if (keyboard == null) return;

        HandleKey(keyboard.upArrowKey, Vector3.forward);
        HandleKey(keyboard.downArrowKey, Vector3.back);
        HandleKey(keyboard.leftArrowKey, Vector3.left);
        HandleKey(keyboard.rightArrowKey, Vector3.right);

        inputDirection = pressedDirections.Count > 0
            ? pressedDirections[pressedDirections.Count - 1]
            : Vector3.zero;

        HandleMovementSound();
    }

    void HandleKey(KeyControl key, Vector3 direction)
    {
        if (key.wasPressedThisFrame)
        {
            pressedDirections.Remove(direction);
            pressedDirections.Add(direction);
        }
        else if (key.wasReleasedThisFrame)
        {
            pressedDirections.Remove(direction);
        }
    }

    void HandleMovementSound()
    {
        if (audioSource == null) return;

        if (inputDirection != Vector3.zero)
        {
            if (!audioSource.isPlaying)
                audioSource.Play();
        }
        else
        {
            if (audioSource.isPlaying)
                audioSource.Pause();
        }
    }

    void FixedUpdate()
    {
        Vector3 newPosition = rb.position + inputDirection * speed * Time.fixedDeltaTime;
        rb.MovePosition(newPosition);

        if (inputDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(inputDirection, Vector3.up);
            rb.MoveRotation(targetRotation);
        }
    }
}