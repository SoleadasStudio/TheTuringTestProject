using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] private float turnSpeed;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private float jumpForce;

    [SerializeField] private bool invertedMouseCheck;

    [SerializeField] private Transform cameraTransform;
   
    private PlayerInput input;

    private float mouseX, mouseY;
    private float horizontal, vertical;
    private float cameraXRotation;

    private CharacterController _characterController;
    private Vector3 playerVelocity;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();

        input = PlayerInput.GetInstance();
    }

    void Update()
    {
        RotatePlayer();
        MovePlayer();
        Jump();
    }

    private void Jump()
    {
        if (_characterController.isGrounded)
        {
            if (input.jumpActivated)
            {

                playerVelocity.y = jumpForce;
            }
        }
    }
    private void MovePlayer()
    {
        _characterController.Move(((transform.forward * input.vertical) + (transform.right * input.horizontal)) * moveSpeed * Time.deltaTime);

        if (_characterController.isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }

        playerVelocity.y += gravity * Time.deltaTime;

        _characterController.Move(playerVelocity * Time.deltaTime);
    }
    private void RotatePlayer()
    {
        //Turn side to side
        transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime * input.mouseX);

        //Turn head up and down
        cameraXRotation += Time.deltaTime * input.mouseY * turnSpeed * (invertedMouseCheck ? 1 : -1);

        cameraXRotation = Mathf.Clamp(cameraXRotation, -85, 85);

        cameraTransform.localRotation = Quaternion.Euler(cameraXRotation, 0, 0);
    }

}
