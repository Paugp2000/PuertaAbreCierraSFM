using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] InputAction movement;
    [SerializeField] GameObject player;
    Rigidbody rb;
    public float speed;
    Vector2 movementIntro;
    [SerializeField] public float positionX;
    [SerializeField] public float positionY;
    [SerializeField] public float positionZ;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        movement.performed += OnMovement;
        movement.canceled += OnMovementCanceled;
    }
    private void OnMovement(InputAction.CallbackContext ctx)
    {
        movementIntro = ctx.ReadValue<Vector2>() * speed;
    }
    private void OnMovementCanceled(InputAction.CallbackContext ctx)
    {
        movementIntro = Vector2.zero; // ← Detiene el movimiento
    }
    private void OnEnable()
    {
        movement.Enable();
    }
    private void OnDisable()
    {
        movement.Disable();
    }
    private void Update()
    {
        rb.velocity = new Vector3(movementIntro.x, rb.velocity.y, movementIntro.y);
        positionX = player.transform.position.x;
        positionY = player.transform.position.y;
        positionZ = player.transform.position.z;
    }
}
