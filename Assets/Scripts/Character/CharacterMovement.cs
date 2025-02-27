using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{ 
  public float moveSpeed = 5f;
    public float gravity = 9.81f;
    public float jumpHeight = 2f;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    public Transform playerBody;
    public Transform playerCamera;
    public float mouseSensitivity = 2f;

    private float verticalRotation = 0f;
    public float maxLookAngle = 80f;

    public GameObject inventoryUI;
    private bool isUIOpen = false;

    private Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        HandleUI();

        if (!isUIOpen)
        {
            Move();
            Rotate();
            ApplyGravity();
            HandleAttack();
        }
    }

    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        controller.Move(move * moveSpeed * Time.deltaTime);

       
        bool isMoving = (horizontal != 0 || vertical != 0);
        animator.SetBool("isMoving", isMoving);
    }

    void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        playerBody.Rotate(Vector3.up * mouseX);

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -maxLookAngle, maxLookAngle);
        playerCamera.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }

    void ApplyGravity()
    {
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // if (isGrounded && Input.GetButtonDown("Jump"))
        // {
        //     velocity.y = Mathf.Sqrt(jumpHeight * 2f * gravity);
        // }

        velocity.y -= gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void HandleUI()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            isUIOpen = !isUIOpen;
            inventoryUI.SetActive(isUIOpen);

            if (isUIOpen)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }

    void HandleAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("isAttacking");
        }
    }
}
