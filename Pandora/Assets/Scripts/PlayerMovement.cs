/** 
 Player movement script. Jump, Double jump, ground check for jumping, player box to connect to ground for jumping only and not obj, 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //Declarations
    private float horizontal;
    // [SerializeField] - this makes it serialized and delcared for speed, ignore
    //private float speed;
    private float jumpingPower = 8f;
    // private bool isFacingRight = true;
    private BoxCollider2D coll;
    public GameObject player;

     Animator anim;
    // bool jump for if jump true then use animation, bool false thrn no
   // bool jump;

    //Serializations
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private float speed; //walk speed
    [SerializeField] private Transform groundCheck; //?
    [SerializeField] private LayerMask jumpableGround; //?\

    [SerializeField] private bool _isMoving = false;


    Vector2 moveInput;  //vec2 is also horzon, so asigning horizon as moveInput
    public bool IsMoving { get 
        { 
            return _isMoving;
        } private set 
        {
            _isMoving = value;
            anim.SetBool("isMoving", value);
        } 
    }

    /* There is no "run" that is different from "walk" so im probably blocking out walk here because it is the 
           same as "move" w/left key etc.. its already established. 


       private bool _isWalking = false;

       public bool IsWalking
       { get 
           {
               return _isWalking;
           } 
           set 
           {
               _isWalking = value;
               anim.SetBool("isWalking", value);
           }
       }
     **/



    // Update is called once per frame
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal"); //horizonatl movement 

        //if jump while grounded, y component of rb jump power
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            //bool grounded = IsGrounded(); //not grounded
            //anim.SetBool("Jump", !grounded); //Set the "Jump" parameter of the Animator based on whether the character is grounded or not

            //jump = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        //if release jump, mult vert veloc. by .5; basically dble jump
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    //change to time.deltatime
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput.x * speed, rb.velocity.y);  //moveInout.x acts as horizontal
    }

    private bool IsGrounded()
    {
        /** Changing yhis method to actually use boxcollider2D and to put a 
         * box on player with a littl give at bottom to make sure overlap with terrain, 
         * also no jumping off objects
         * //collide with graound layer and jump
          return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        */

        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
     
        IsMoving = moveInput != Vector2.zero;

        if (context.started)
        {
            IsMoving
        }
    }
    /**
     // Swap direction of sprite depending on walk direction
        if (inputX > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            m_facingDirection = 1;
        }


        else if (inputX < 0)
{
    GetComponent<SpriteRenderer>().flipX = true;
    m_facingDirection = -1;
}

  //private void OnWalk(InputAction.CallbackContext context) 
  //{
  //    if (context.started)
  //    {
  //        IsWalking = true;
  //    } else if(context.canceled)
  //    {
  //        IsWalking = false;
  //    }
  //
  //} **/
}
