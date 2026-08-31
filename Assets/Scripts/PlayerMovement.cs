using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody rb;
    private Vector3 inputDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        inputDirection = Vector3.zero;

        var keyboard = Keyboard.current;
        if (keyboard == null) return;

        if (keyboard.upArrowKey.isPressed)    inputDirection += Vector3.forward;
        if (keyboard.downArrowKey.isPressed)  inputDirection += Vector3.back;
        if (keyboard.leftArrowKey.isPressed)  inputDirection += Vector3.left;
        if (keyboard.rightArrowKey.isPressed) inputDirection += Vector3.right;

        inputDirection = inputDirection.normalized;
    }

    void FixedUpdate()
    {
        Vector3 newPosition = rb.position + inputDirection * speed * Time.fixedDeltaTime;
        rb.MovePosition(newPosition);
    }
}