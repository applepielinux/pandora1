/** 
 Player movement script. Jump, Double jump, ground check for jumping, player box to connect to ground for jumping only and not obj, 
 */

using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(TouchingDirections))]
public class PlayerMovement : MonoBehaviour
{
    //Declaration
    public GameObject player;

    Vector2 moveInput;

    Animator anim;
    TouchingDirections touchingDirections;

    //double jump additions
    public int maxJumps = 30;
    //private int jumpsRemaining;

    //Serializations
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpImpulse;
    [SerializeField] private float speed; //walk speed
    [SerializeField] private bool _isMoving = false;
    [SerializeField] private int jumpsRemaining;

    public bool IsMoving { get 
        { 
            return _isMoving; 
        } private set 
        {
            _isMoving = value;
            anim.SetBool(AnimationStrings.isMoving, value);
        } 
    }

    public bool _isFacingRight = true;
     public bool IsFacingRight
    {
        get { return _isFacingRight; }
        private set
        {
            if (_isFacingRight != value)
            {
                //flip local scale
                transform.localScale *= new Vector2(-1, 1);
            }
            _isFacingRight = value;
        }
    }
    // Update is called once per frame
    void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        touchingDirections = GetComponent<TouchingDirections>();
    }

    private void Start()
    {
        //initialize jmups remaining
        jumpsRemaining = maxJumps;
    }
    //change to time.deltatime
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput.x * speed * Time.fixedDeltaTime, rb.velocity.y);

        anim.SetFloat(AnimationStrings.yVelocity, rb.velocity.y); 
            //moveInout.x acts as horizontal
    }


    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        IsMoving = moveInput != Vector2.zero;

        SetFacingDirection(moveInput);
    }
    
    //left and right facing directions
    private void SetFacingDirection(Vector2 moveInput)
    {
        if(moveInput.x > 0 && !IsFacingRight)
        {
            IsFacingRight = true;
        }
        else if(moveInput.x < 0 && IsFacingRight)
        {
            IsFacingRight = false;
        }
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.started && jumpsRemaining > 0)
        {
            if (touchingDirections.IsGrounded || jumpsRemaining < maxJumps) // Allow double jump even if not grounded, but not more than maxJumps
            {
                //todo - check if alive, damageable component
                anim.SetTrigger(AnimationStrings.jump);
                rb.velocity = new Vector2(rb.velocity.x, jumpImpulse);
                jumpsRemaining--; // Decrease jumps remaining after each jump
            }
        }

        //  if(context.started && touchingDirections.IsGrounded)
        //  {
        //      //todo - check if alive,, damagebale componenet
        //      anim.SetTrigger(AnimationStrings.jump);
        //      rb.velocity = new Vector2(rb.velocity.x, jumpImpulse);
        //  }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Reset jumps remaining when player lands on the ground
        if (collision.gameObject.CompareTag("Midground"))
        {
            jumpsRemaining = maxJumps;
        }
    }
}
