using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

	[Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f;
	private Rigidbody2D rigidbody2D;
	bool facingRight = true;
	private Vector3 velocity = Vector3.zero;

	float horizontalMove = 0f;
	[SerializeField] float runSpeed = 400f;

	FlipEffect flipEffect;
	float levelFlipped = 1;

	int maxJumps = 1;
	int remainingJumps;
	bool canJump = false;

	bool playerHasControl = true;

	[SerializeField] float flippingWaitTime = 5f;

	[Header("Jump")]
	[SerializeField] float initialJumpVelocity = 5f;
	[SerializeField] float fallMultiplier = 2.5f;
	[SerializeField] float lowJumpMultiplier = 2f;

	

	private void Start()
	{
		rigidbody2D = GetComponent<Rigidbody2D>();
		flipEffect = GetComponent<FlipEffect>();
		remainingJumps = maxJumps;
	}

    private void Update()
    {
        if (playerHasControl)
        {
			horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
			//Debug.Log(horizontalMove.ToString());

			if (Input.GetButtonDown("Jump"))
			{
				if (remainingJumps > 0)
				{
					canJump = true;
				}
			}

			if (flipEffect.GetHasLevelFlipped() && levelFlipped == 1)
			{
				LevelHasFlipped();
			}
			else if (!flipEffect.GetHasLevelFlipped() && levelFlipped == -1)
			{
				LevelHasReFlipped();
			}
		}
	}

    private void FixedUpdate()
    {
        if (playerHasControl)
        {
			Move(horizontalMove * Time.deltaTime, canJump);
			if (canJump)
			{
			canJump = false;
			remainingJumps--;
			}
			//Debug.Log("Called move");
        }
    }


    public void Move(float move, bool jump)
	{
		//Vector2 targetVelocity = new Vector2(move, rigidbody2D.velocity.y);
		//rigidbody2D.velocity = Vector3.SmoothDamp(rigidbody2D.velocity, targetVelocity, ref velocity, movementSmoothing);
		transform.position += new Vector3(Input.GetAxisRaw("Horizontal") * runSpeed * Time.deltaTime * levelFlipped, 0, 0);

		//Debug.Log(targetVelocity.ToString());

		if (move * levelFlipped > 0 && !facingRight)
		{
			FlipCharacter();
		}
		else if (move * levelFlipped < 0 && facingRight)
		{
			FlipCharacter();
		}

        if (jump)
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 1 * initialJumpVelocity);
        }

		if (rigidbody2D.velocity.y < 0)
		{
			rigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
		}
		else if (rigidbody2D.velocity.y > 0 && !Input.GetButton("Jump"))
		{
			rigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
		}
	}


    private void FlipCharacter()
	{

		facingRight = !facingRight;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}


	private void LevelHasFlipped()
    {
		levelFlipped = -1;
		StartCoroutine(PauseCharacterControl(flippingWaitTime));
    }

	private void LevelHasReFlipped()
	{
		levelFlipped = 1;
		StartCoroutine(PauseCharacterControl(flippingWaitTime));
	}

	private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
			remainingJumps = maxJumps;
        }
    }

	public IEnumerator PauseCharacterControl(float waitTime)
    {
		playerHasControl = false;
		yield return new WaitForSeconds(waitTime);
		playerHasControl = true;
    }

	public void PauseCharacterControl()
    {
		playerHasControl = false;
    }

	public void ResumeCharacterControl()
	{
		playerHasControl = true;
	}
}
