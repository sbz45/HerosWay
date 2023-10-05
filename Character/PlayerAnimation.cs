using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator playerAnimator;
    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    public void SetLook(Vector2 look)
    {
        playerAnimator.SetFloat("LookY", look.y);
        playerAnimator.SetFloat("LookX", look.x);
    }
    public void SetMove(Vector2 direction)
    {
        playerAnimator.SetFloat("DirectionY", direction.y);
        playerAnimator.SetFloat("DirectionX", direction.x);
    }
    public void SetMoving(bool moving)
    {
        playerAnimator.SetBool("isMoving", moving);
        
    }
}
