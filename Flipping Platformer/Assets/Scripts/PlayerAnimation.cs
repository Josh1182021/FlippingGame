using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    Animator animator;
    Rigidbody2D rigidbody2D;
    private string currentState;

    bool playerIsFallingPlaying = false;
    bool playerIsJumpingPlaying = false;
    bool playerIsMovingPlaying = false;
    bool playerIsIdlePlaying = false;

    const string playerIdle = "PlayerIdle";
    const string playerRunning = "PlayerRunningAnimation";
    const string playerJumping = "PlayerJumping";
    const string playerFalling = "PlayerFalling";

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        bool playerIsMoving = false;
        bool playerIsJumping = false;
        bool playerIsFalling = false;

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            playerIsMoving = true;
        }
        if (rigidbody2D.velocity.y > 0)
        {
            playerIsJumping = true;
        }
        else if (rigidbody2D.velocity.y < -0.000001)
        {
            playerIsFalling = true;
            Debug.Log(rigidbody2D.velocity.y);
        }


        if (playerIsFalling)
        {
            if (playerIsFallingPlaying)
            {
                return;
            }

            ChangeAnimationState(playerFalling);
            ResetAnimationParameters();
            playerIsFallingPlaying = true;
        }
        else if (playerIsJumping)
        {
            if (playerIsJumpingPlaying)
            {
                return;
            }

            ChangeAnimationState(playerJumping);
            ResetAnimationParameters();
            playerIsJumpingPlaying = true;
        }
        else if (playerIsMoving)
        {
            if (playerIsMovingPlaying)
            {
                return;
            }

            ChangeAnimationState(playerRunning);
            ResetAnimationParameters();
            playerIsMovingPlaying = true;
        }
        else if (!playerIsIdlePlaying)
        {
            ChangeAnimationState(playerIdle);
            ResetAnimationParameters();
            playerIsIdlePlaying = true;
        }
    }

    void ResetAnimationParameters()
    {
        playerIsMovingPlaying = false;
        playerIsFallingPlaying = false;
        playerIsJumpingPlaying = false;
        playerIsIdlePlaying = false;
    }

    void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;

        animator.Play(newState);

        currentState = newState;
        
    }
}
