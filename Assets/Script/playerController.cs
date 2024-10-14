using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class playerController : MonoBehaviour
{
    Rigidbody2D rb;
    //Animator animator;

    public float moveSpeed = 5f;
    Vector2 moveInput;

    public bool IsMoving {  get; private set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput.x * moveSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        IsMoving = moveInput != Vector2.zero;
    }
}
