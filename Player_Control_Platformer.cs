using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control_Platformer : MonoBehaviour
{
    private float idleTimer;
    private Vector2 speed;

    private float isGroundedCount;
    private bool isClimbing;

    private new Rigidbody2D rigidbody;
     private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask mask;
    public float maxSpeed;
    public float accelerate;

    public float jumpSpeed;
    private float jumpBuffer;
    private bool isJump;
    // Start is called before the first frame update
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
       
        
        
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {


    }
    private void Update()
    {
        Move();
        IsGrounded();
        jumpBuffer -= Time.deltaTime;
        isGroundedCount -= Time.deltaTime;
        JumpController();
        gravityChange();
    }
    private void IsGrounded()
    {
        if (rigidbody.velocity.y >0) return;
        float extraHeight = 0.83f;
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.size, 0, Vector2.down, extraHeight, mask);
        isJump = false;
        if (hit.collider != null)isGroundedCount=0.1f;
       
    }
    private void Move()
    {
        if (rigidbody.velocity.x < 0 && !Input.GetKey(KeyCode.A))
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x * 0.9f*Time.deltaTime * 80, rigidbody.velocity.y);
        }
        if (rigidbody.velocity.x > 0 && !Input.GetKey(KeyCode.D))
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x * 0.9f*Time.deltaTime * 80, rigidbody.velocity.y);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.velocity = new Vector2(Mathf.Clamp(rigidbody.velocity.x - accelerate*Time.deltaTime*80, - maxSpeed, maxSpeed / 5), rigidbody.velocity.y);
        }
        if (Input.GetKey(KeyCode.D))
        {
            
            rigidbody.velocity = new Vector2(Mathf.Clamp(rigidbody.velocity.x + accelerate*Time.deltaTime * 80,  -maxSpeed/ 5,maxSpeed), rigidbody.velocity.y);
        }
    }
    
    private void gravityChange()
    {
        if (rigidbody.velocity.y < 0)
        {
            rigidbody.gravityScale = 2.5f;
        }
        else
        {
            rigidbody.gravityScale = 1.6f;
        }
    }
    private void JumpController()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGroundedCount > 0)
            {

                rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpSpeed);
                isGroundedCount = 0;
                jumpBuffer = 0;
                isJump = true;

            }
            else
            {
                jumpBuffer = 0.1f;
            }
        }
       if(jumpBuffer > 0 && isGroundedCount > 0)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpSpeed);
            isGroundedCount = 0;
            jumpBuffer = 0;
            isJump = true;
        }
        if (Input.GetKeyUp(KeyCode.Space)&&isJump){
            if (rigidbody.velocity.y>0)
            {
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, rigidbody.velocity.y * 0.5f);
            }
        }

    }
}
