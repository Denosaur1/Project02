using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(PlayerInputDetector))]
[RequireComponent(typeof(FPSMotor))]
public class PlayerController : MonoBehaviour
{
    PlayerInputDetector input = null;
    FPSMotor motor = null;

    [SerializeField] float moveSpeed = .1f;
    [SerializeField] float turnSpeed = 6f;
    [SerializeField] float jumpStrength = 10f;
    private void Awake()
    {
        input = GetComponent<PlayerInputDetector>();
        motor = GetComponent<FPSMotor>();
    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void OnEnable()
    {
        input.MoveInput += OnMove;
        input.RotateInput += OnRotate;
        input.JumpInput += OnJump;
    }
    private void OnDisable()
    {
        input.MoveInput -= OnMove;
        input.RotateInput -= OnRotate;
        input.JumpInput -= OnJump;
    }
    void OnMove(Vector3 movement)
    {
        // Debug.Log("Move: " + movement);
        motor.Move(movement * moveSpeed);
    }
    void OnRotate(Vector3 rotation)
    {
        // Debug.Log("Turn: " + rotation);
        motor.Turn(rotation.y * turnSpeed);
        motor.Look(rotation.x * turnSpeed);
    }
     void OnJump()
    {
        //Debug.Log("Jump!");
        motor.Jump(jumpStrength);
    }
}
