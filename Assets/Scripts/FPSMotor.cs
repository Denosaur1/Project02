using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[RequireComponent(typeof(Rigidbody))]
public class FPSMotor : MonoBehaviour
{
    public event Action Land = delegate { };

    [SerializeField] Camera mainCamera = null;
    [SerializeField] GroundDetector groundDetector = null;
    bool isGrounded = false;
    [SerializeField] float cameraAngleLimit = 70f;
    private float currentCameraRotationX = 0;
    Rigidbody rigidBody = null;
    Vector3 movementThisFrame = Vector3.zero;
    float turnAmountThisFrame = 0;
    float lookAmountThisFrame = 0;
    
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        ApplyMovement(movementThisFrame);
        ApplyTurn(turnAmountThisFrame);
        ApplyLook(lookAmountThisFrame);
    }

    public void Move(Vector3 requestedMovement)
    {
       // Debug.Log("Move: " + requestedMovement);
        movementThisFrame = requestedMovement;
    }
    public void Turn(float turnAmount)
    {
       // Debug.Log("Turn: " + turnAmount);
        turnAmountThisFrame = turnAmount;
    }
    public void Look(float lookAmount)
    {
        //Debug.Log("Look: " + lookAmount);
        lookAmountThisFrame = lookAmount;
    }
    public void Jump(float jumpForce)
    {
        if (isGrounded == false)
            return;
        
        
        //Debug.Log("Jump!");
        rigidBody.AddForce(Vector3.up * jumpForce);
    }
    void ApplyMovement(Vector3 moveVector)
    {
        if (moveVector == Vector3.zero)
            return;
        rigidBody.MovePosition(rigidBody.position + moveVector);
        movementThisFrame = Vector3.zero;
        

        
    }
    void ApplyTurn(float rotateAmount)
    {
        if (rotateAmount == 0)
            return;
        Quaternion newRotation = Quaternion.Euler(0, rotateAmount, 0);
        rigidBody.MoveRotation(rigidBody.rotation * newRotation);
        turnAmountThisFrame = 0;
    }
    void ApplyLook(float lookAmount)
    {
        if (lookAmount == 0)
            return;

        currentCameraRotationX -= lookAmount;
        currentCameraRotationX = Mathf.Clamp
            (currentCameraRotationX, -cameraAngleLimit, cameraAngleLimit);
        mainCamera.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0, 0);

        lookAmountThisFrame = 0;
    }
    private void OnEnable()
    {
        groundDetector.GroundDetected += OnGroundDetected;
        groundDetector.GroundVanished += OnGroundVanished;
    }
    private void OnDisable()
    {
        groundDetector.GroundDetected -= OnGroundDetected;
        groundDetector.GroundVanished -= OnGroundVanished;
    }
    void OnGroundDetected() 
    {
        isGrounded = true;
        Land?.Invoke();
    }
    void OnGroundVanished() 
    {
        isGrounded = false;
    }
}
    
