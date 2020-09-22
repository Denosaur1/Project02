using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerInputDetector : MonoBehaviour
{
    [SerializeField] bool invertVertical = false;
    
    public event Action<Vector3> MoveInput = delegate { };
    public event Action<Vector3> RotateInput = delegate { };
    public event Action JumpInput = delegate { };
    public float sprintmod = 1f;
    float sprint =  1f;

    private void Update()
    {
        DetectMoveInput();
        DetectRotateInput();
        DetectJumpInput();
        DetectSprint();
        
    }
    void DetectMoveInput()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");

        if(xInput != 0 || yInput != 0)
        {
            Vector3 horizontalMovement = transform.right * xInput;
            Vector3 forwardMovement = transform.forward * yInput;

            Vector3 movement = sprint*(horizontalMovement + forwardMovement).normalized;
            MoveInput?.Invoke(movement);
        }
    }

    void DetectRotateInput() 
    {
        float xInput = Input.GetAxisRaw("Mouse X");
        float yInput = Input.GetAxisRaw("Mouse Y");

        if (xInput != 0 || yInput != 0)
        {
            if(invertVertical == true)
            {
                yInput = -yInput;
            }
            Vector3 rotation = new Vector3(yInput, xInput, 0);
            RotateInput?.Invoke(rotation);
        }
    }

    void DetectJumpInput() 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpInput?.Invoke();
        }
    }
    void DetectSprint()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            print("Sprint");
            sprint = sprintmod;
            
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            print("Stop Sprint");
            sprint = 1f;
        }

    }



}



