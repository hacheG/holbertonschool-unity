using UnityEngine;

public class PlayerController : MonoBehaviour
{
    # region Gameplay variables
    // Animation
    // Basic Movement
    [HideInInspector]
    public CharacterController controller;
    private Vector3 direction = Vector3.zero;
    private Animator anim;
    private float speed = 9.0f;
    [Header("Basic Movement")]
    public float jumpSpeed = 10.0f;
    public float turnSpeed = 4.0f;
    private Vector3 velocity;

    // Physics
    [Header("Physics")]
    public float gravity = 7.0f;
    private int jumps;
    bool m_Jump;
    // public float timeFalling = 0;
    // private float timeToSayGoodbye = 5f;

    private Vector3 startPosition;
    private Transform _transform;
    private Transform groundCheck;
    public bool _isGrounded = true;
    public bool freeFalling = false;
    public float lastY;
    public float groundDistance = 1f;
    // int layermask = 1 << 8;
    [Tooltip("Select layer where ground objects are located")]
    public LayerMask Ground;


    #endregion


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        _transform = GetComponent<Transform>();
        startPosition = transform.position;
        groundCheck = transform.GetChild(0);
        m_Jump = false;
        lastY = transform.position.y;
    }
    void OnCollisionEnter(Collision other)
    {
        // _isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, Ground, QueryTriggerInteraction.Collide);
        if (other.gameObject.CompareTag("Untagged"))
        {
            _isGrounded = true;
        }
        else if (other.relativeVelocity.magnitude > .5)
        {
            Debug.Log("try again!");
            _isGrounded = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (controller.isGrounded)
        {
            direction = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            direction = transform.TransformDirection(direction);
            direction *= speed;
            // Running
            Running();

            Jumping();
            // // Jumping
            // if (Input.GetButton("Jump"))
            // {
            //     m_Jump = true;
            //     direction.y = jumpSpeed;
            // }
            // jumps = 0;
        }
        else
        {
            direction = new Vector3(Input.GetAxis("Horizontal"), direction.y, Input.GetAxis("Vertical"));
            direction = transform.TransformDirection(direction);
            direction.x *= speed;
            direction.z *= speed;
        }


        float turn = Input.GetAxis("Horizontal");
        transform.Rotate(0, turn * turnSpeed, 0);

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        direction.y -= gravity * Time.deltaTime;

        // Move the controller
        controller.Move(direction * Time.deltaTime);
        // falling();
        if (falling() == true && _transform.position.y < -100)
        {
            ResetPosition();
        }
    }

    void Running()
    {
        if (Input.GetButton("Vertical") || Input.GetButton("Horizontal"))
        {
            anim.SetInteger("animPar", 1);
        }
        else
        {
            anim.SetInteger("animPar", 0);
        }
    }
    void Jumping()
    {
        if (controller.isGrounded || _isGrounded && !m_Jump)
        {
            if (Input.GetButton("Jump"))
            {
                direction.y = jumpSpeed;
                m_Jump = true;
            }
            jumps = 0;
        }
        else
        {
            if (Input.GetButton("Jump") && jumps < 1)
            {
                m_Jump = true;
                direction.y = jumpSpeed;
                jumps++;
            }
        }

        if (m_Jump == true)
        {
            anim.SetBool("isJumping", true);
        }
        else
        {
            anim.SetBool("isJumping", false);
        }
    }

    bool falling()
    {
        if (controller.isGrounded == false)
        {
            freeFalling = true;
            return true;
        }

        if (freeFalling)
        {
            // start falling
            anim.SetBool("isFalling", true);

        }
        return false;
        // float distanceFallen;
        // else if (freeFalling)
        // {
        //     // but was falling last update... var 
        //     distanceFallen = lastY - transform.position.y;
        //     // calculate the fall height... 
        //     if (distanceFallen > 8)
        //     { // then check the damage/death
        //         Debug.Log("player dead");
        //     }
        // }
        // lastY = transform.position.y; // update lastY when character grounded }
    }
    /// <summary>
    /// check animation states
    /// </summary>
    private void LateUpdate()
    {
        // check if animator state is still active while grounded
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Jump") && _isGrounded)
        {
            m_Jump = false;
        }
        // if (anim.GetCurrentAnimatorStateInfo(0).IsName("Happy Idle"))
        // {
        //     anim.SetBool("isFalling", false);
        //     anim.SetBool("isJumping", false);
        // }
    }

    /// <summary>
    /// Prevents player from falling infinitely and resets back to starting position
    /// </summary>
    void ResetPosition()
    {
        // direction = new Vector3(0.0f, direction.y, 0.0f);
        // controller.Move(direction * Time.deltaTime);
        transform.position = new Vector3(
            startPosition.x,
            startPosition.y,
            startPosition.z);
        anim.SetBool("isFalling", false);
        anim.SetBool("isJumping", false);
        anim.SetInteger("animPar", 0);
    }
}

