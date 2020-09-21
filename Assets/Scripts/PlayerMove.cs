using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private CharacterController characterController;
    private CharacterAnimations playerAnimations;

    public float movementSpeed = 3.5f;
    public float gravity = 9.8f;
    public float rotationSpeed = 0.15f;
    public float rotateDegreesPerSecond = 180f;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        playerAnimations = GetComponent<CharacterAnimations>();
    }

    void Update()
    {
        Move();
        Rotate();
        AnimateWalk();
    }

    void Move()
    {
        if (Input.GetAxis(Axis.VERTICAL_AXIS) > 0)
        {
            Vector3 moveDirection = transform.forward;
            moveDirection.y -= gravity * Time.deltaTime;

            characterController.Move(moveDirection * movementSpeed * Time.deltaTime);


        }else if (Input.GetAxis(Axis.VERTICAL_AXIS) < 0)
        {
            Vector3 moveDirection = -transform.forward;
            moveDirection.y -= gravity * Time.deltaTime;

            characterController.Move(moveDirection * movementSpeed * Time.deltaTime);
        }
        else
        {
            characterController.Move(Vector3.zero);
        }
        
    }//move

    void Rotate()
    {
        Vector3 rotationDirection = Vector3.zero;

        if (Input.GetAxis(Axis.HORIZONTAL_AXIS) < 0)
        {
            rotationDirection = transform.TransformDirection(Vector3.left);
        }
        if (Input.GetAxis(Axis.HORIZONTAL_AXIS) > 0)
        {
            rotationDirection = transform.TransformDirection(Vector3.right);
        }

        if (rotationDirection != Vector3.zero){
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(rotationDirection), rotateDegreesPerSecond * Time.deltaTime);
        }
    }//rotate

    void AnimateWalk()
    {
        if (characterController.velocity.sqrMagnitude != 0f)
        {
            playerAnimations.Walk(true);
        }
        else
        {
            playerAnimations.Walk(false);
        }
    }//animateWalk
}//class
