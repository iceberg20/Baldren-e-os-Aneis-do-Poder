using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	[HideInInspector]
	public bool facingRight = true;			// For determining which way the player is currently facing.

	[HideInInspector]
	public float maxSpeed = 0.5f;				// The fastest the player can travel in the x axis.

	[HideInInspector]
	/// <summary>
	/// The jump.
	/// </summary>
	public bool jump = false;				// Condition for whether the player should jump.

	/// <summary>
	/// The jump force.
	/// </summary>
	public float jumpForce = 20f;	

	private Transform groundCheck;			// A position marking where to check if the player is grounded.
	private bool grounded = false;			// Whether or not the player is grounded.

	private Animator anim;					// Reference to the player's animator component.

	void Awake()
	{
		// Setting up references.;
		anim = GetComponent<Animator>();

		// Setting up references.
		groundCheck = transform.Find("groundCheck");
	}

	void Update()
	{
		// The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
		grounded = Physics2D.Raycast(groundCheck.position, -Vector2.up, 0.1f);  
		
		// If the jump button is pressed and the player is grounded then the player should jump.
		if(Input.GetButtonDown("Jump") && grounded)
			jump = true;
	}


	void FixedUpdate () {

		if (Input.GetKey (KeyCode.D)) {
			transform.Translate (Vector2.right * maxSpeed * Time.deltaTime);

			// The Speed animator parameter is set to the absolute value of the horizontal input.
			anim.SetBool("Walk",true);
		} else if (Input.GetKey (KeyCode.A)) {
			transform.Translate (-Vector2.right * maxSpeed * Time.deltaTime);

			// The Speed animator parameter is set to the absolute value of the horizontal input.
			anim.SetBool("Walk",true);
		} else {
			// The Speed animator parameter is set to the absolute value of the horizontal input.
			anim.SetBool("Walk",false);
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			transform.Translate (Vector2.up * jumpForce * Time.deltaTime, Space.Self);
		}

		// If the input is moving the player right and the player is facing left...
		if(Input.GetKey(KeyCode.D) && !facingRight)
			// ... flip the player.
			Flip();
		// Otherwise if the input is moving the player left and the player is facing right...
		else if(Input.GetKey(KeyCode.A) && facingRight)
			// ... flip the player.
			Flip();

		if(jump)
		{	
			// Add a vertical force to the player.
			GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, jumpForce));
			
			// Make sure the player can't jump again until the jump conditions from Update are satisfied.
			jump = false;
		}
	}



	void Flip ()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;
		
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	
}