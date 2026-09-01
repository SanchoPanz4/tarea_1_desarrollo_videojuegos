using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody rb;
    private Vector3 inputDirection;
    private List<Vector3> pressedDirections = new List<Vector3>();

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        var keyboard = Keyboard.current;
        if (keyboard == null) return;

        HandleKey(keyboard.upArrowKey, Vector3.forward);
        HandleKey(keyboard.downArrowKey, Vector3.back);
        HandleKey(keyboard.leftArrowKey, Vector3.left);
        HandleKey(keyboard.rightArrowKey, Vector3.right);

        // Usa SOLO la ultima direccion que sigue apretada (nada de diagonales)
        inputDirection = pressedDirections.Count > 0
            ? pressedDirections[pressedDirections.Count - 1]
            : Vector3.zero;
    }

    void HandleKey(KeyControl key, Vector3 direction)
    {
        if (key.wasPressedThisFrame)
        {
            pressedDirections.Remove(direction); // evita duplicados
            pressedDirections.Add(direction);    // la mas reciente queda al final
        }
        else if (key.wasReleasedThisFrame)
        {
            pressedDirections.Remove(direction); // al soltar, cae a la anterior si sigue apretada
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