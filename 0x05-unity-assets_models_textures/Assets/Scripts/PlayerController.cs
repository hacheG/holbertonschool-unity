using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public CharacterController charaContr;
    public float horizontalMove;
    public float verticalMove;
    public float speed = 3f;
    public float gravity = -9.8f;
    public float fallVelocity;
    public float jumpForce;

    private Vector3 playerInput;
    public Vector3 movePlayer;


    public Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight;
    

    // Start is called before the first frame update
    void Start()
    {
        charaContr = GetComponent<CharacterController>();
        
    }
    

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        playerInput = new Vector3(horizontalMove, 0, verticalMove);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);
        CamDirection();

        movePlayer = playerInput.x * camRight + playerInput.z * camForward;
        charaContr.transform.LookAt(charaContr.transform.position + movePlayer);

        movePlayer *= speed;
        SetGravity();
        PlayerSkills();
        charaContr.Move(movePlayer * Time.deltaTime);
        //Debug.Log(charaContr.velocity.magnitude);
        
    }
 
    void CamDirection()
    {
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }

    void SetGravity()
    {

        if (charaContr.isGrounded  )
        {
            fallVelocity = -gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
        }
        else
        {
            fallVelocity -= gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
        }
    }

    public void PlayerSkills()
    {

        if (charaContr.isGrounded && Input.GetButtonDown("Jump")) 
        {
            fallVelocity = jumpForce;
            movePlayer.y = fallVelocity;
        }
    }
}
