using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchingDirections : MonoBehaviour
{
    public ContactFilter2D castFilter;
    public float groundDistance = 0.05f;
    public float wallDistance = 0.2f;
    public float ceilingDistance = 0.05f;

    CapsuleCollider2D touchingCol;
    Animator anim;

    RaycastHit2D[] groundHits = new RaycastHit2D[5];
    RaycastHit2D[] wallHits = new RaycastHit2D[5];
    RaycastHit2D[] ceilingHits = new RaycastHit2D[5];
    private Vector2 wallCheckDirection => gameObject.transform.localScale.x > 0 ? Vector2.right : Vector2.left;

    [SerializeField] private bool _isGrounded;
    [SerializeField] private bool _isOnCeiling;
    [SerializeField] private bool _isOnWall;
    public bool IsGrounded
    {
        get
        {
            return _isGrounded;
        }
        private set
        {
            _isGrounded = value;
            anim.SetBool(AnimationStrings.isGrounded, value);
        }
    }

    public bool IsOnWall
    {
        get
        {
            return _isOnWall;
        }
        private set 
        { 
            _isOnWall = value;
            anim.SetBool(AnimationStrings.isOnWall, value);
        }
    }
  
    void Awake()
    {
        touchingCol = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
    }


    void FixedUpdate()
    {
        IsGrounded = touchingCol.Cast(Vector2.down, castFilter, groundHits, groundDistance) > 0;
        IsOnWall = touchingCol.Cast(wallCheckDirection, castFilter, wallHits, wallDistance) > 0;
        IsOnCeiling = touchingCol.Cast(Vector2.up, castFilter, ceilingHits, ceilingDistance) > 0;
    }

    public bool IsOnCeiling
    { 
        get { return _isOnCeiling; }   
        private set
        {
            _isOnCeiling = value;
            anim.SetBool(AnimationStrings.isOnCeiling, value);
        }
    
    }
}
