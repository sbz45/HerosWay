using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public Animator playerAnimator;
    public PlayerAnimation playerAnimation;
    private Vector2 faceAt;
    public float raycastDistance;
    public float moveSpeed;
    new Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerAnimation = GetComponent<PlayerAnimation>();
        faceAt = new Vector2(0, -1);
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            faceAt.x = -1;
            faceAt.y = 0;
            playerAnimation.SetLook(faceAt);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            faceAt.x = 0;
            faceAt.y = -1;
            playerAnimation.SetLook(faceAt);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            faceAt.x = 1;
            faceAt.y = 0;
            playerAnimation.SetLook(faceAt);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            faceAt.x = 0;
            faceAt.y = 1;
            playerAnimation.SetLook(faceAt);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            var hit = Physics2D.Raycast(GetComponent<BoxCollider2D>().bounds.center, faceAt, raycastDistance, LayerMask.NameToLayer("Player"));
            if (hit.collider != null)
            {
                Interractable i;

                if ((i = hit.collider.gameObject.GetComponent<Interractable>()) != null)
                {
                    if (this.GetComponent<Character>() == null)
                    {
                        Debug.Log("trying to interract without proper interracter");

                    }
                    {
                        i.Respond(this.GetComponent<Character>());
                    }
                    
                }
            }
        }
        Move();
    }
    Vector2 moveDirection;
    public void Move()
    {
        if (moveDirection == null) moveDirection = new Vector2();
        if (Input.GetKeyDown(KeyCode.A))
        {
            moveDirection.x = -1;
            playerAnimation.SetMove(moveDirection);
            playerAnimation.SetMoving(true);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            moveDirection.y = -1;
            playerAnimation.SetMove(moveDirection);
            playerAnimation.SetMoving(true);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            moveDirection.x = 1;
            playerAnimation.SetMove(moveDirection);
            playerAnimation.SetMoving(true);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            moveDirection.y = 1;
            playerAnimation.SetMove(moveDirection);
            playerAnimation.SetMoving(true);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            if (moveDirection.x == -1) moveDirection.x = 0;
            playerAnimation.SetMove(moveDirection);
            if (moveDirection.x == 0 && moveDirection.y == 0)
            {
                playerAnimation.SetMoving(false);
                return;
            }
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            if (moveDirection.y == -1)moveDirection.y = 0;
            playerAnimation.SetMove(moveDirection);
            if (moveDirection.x == 0 && moveDirection.y == 0)
            {
                playerAnimation.SetMoving(false);
                return;
            }
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            if (moveDirection.x == 1) moveDirection.x = 0;
            if (moveDirection.x == 0 && moveDirection.y == 0)
            {
                playerAnimation.SetMoving(false);
                return;
            }
            playerAnimation.SetMove(moveDirection);

        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            if (moveDirection.y == 1) moveDirection.y = 0;
            if (moveDirection.x == 0 && moveDirection.y == 0)
            {
                playerAnimation.SetMoving(false);
                return;
            }
            playerAnimation.SetMove(moveDirection);

        }
        if (rigidbody2D == null)
        {
            rigidbody2D = transform.GetComponent<Rigidbody2D>();
        }
        if (moveDirection.x == 0 && moveDirection.y == 0) {
           
            return; 
        }

        rigidbody2D.MovePosition(rigidbody2D.position + moveDirection * moveSpeed * Time.deltaTime);

    }
}
