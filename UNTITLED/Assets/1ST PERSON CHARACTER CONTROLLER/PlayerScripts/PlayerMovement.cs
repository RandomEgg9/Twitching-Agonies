using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


public CharacterController controller;
public Transform cam;
public Transform orientation;
public Transform groundcheck;
private Vector3 PlayerVelocity;
public LayerMask groundLayer;
public float lastJumped;
private float moveSpeed = 8;

private float jumpHeight = 3;

private float gravityValue = -10f;


public float lastGrounded;
public float tempGroundtime;
public bool isGrounded;

    void Start()
    {
        setstage();
    }

    void Update()
    {
        move();
        jump();
    }
    void FixedUpdate()
    {
        playerphysics();
    }




    private void setstage()
    {

    }











    private void move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = cam.right * x + orientation.forward * z;

        controller.Move(move * moveSpeed * Time.deltaTime);
    }

    private void gravity()
    {
        PlayerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(PlayerVelocity * Time.deltaTime);
    }

private void playerphysics()
{
isGrounded = Physics.CheckSphere(groundcheck.position, 0.2f, groundLayer);


lastGrounded -= Time.deltaTime;


if (isGrounded)
{
    PlayerVelocity.y = -3f;
    lastGrounded = 0f;
    
}
else
{
gravity();    
}
Debug.DrawRay(groundcheck.position, transform.TransformDirection(Vector3.up) * 0.4f, Color.red);

}


    private void jump()
    {
        lastJumped -= Time.deltaTime; 
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            
            PlayerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            Debug.Log("jump");
        }
            PlayerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(PlayerVelocity * Time.deltaTime);
    }


















}
