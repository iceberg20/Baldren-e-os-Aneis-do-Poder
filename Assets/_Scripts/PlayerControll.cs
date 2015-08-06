using UnityEngine;
using System.Collections;

public class PlayerControll : MonoBehaviour {
	public GameObject players;

	public float speed;
	public Animator Anime;
	private AudioSource audioPlayer;
	public AudioClip somHit;
	public AudioClip somPulo;
	public AudioClip somHitEletrico;
	
	public Rigidbody2D	PlayerRigdbod;
	public int 			Force;
	// Use this for initpublic ialization

	void Awake()
	{
		// Setting up references.
		groundCheck = transform.Find("groundCheck");
	}
	void Start () {	
		audioPlayer = GetComponent<AudioSource>();
	
	}
	//Igor script
	public bool jump = false;
	private Transform groundCheck;			// A position marking where to check if the player is grounded.
	private bool grounded = false;			// Whether or not the player is grounded.

	// Update is called once per frame
	void Update () {
		// The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
		grounded = Physics2D.Raycast(groundCheck.position, -Vector2.up, 0.1f);  

		float translation = Input.GetAxis("Horizontal")*speed;

		players.transform.Translate (translation, 0 , 0);



		if(Input.GetKeyDown(KeyCode.UpArrow) && grounded)
		{
			jump = true;
			PlayerRigdbod.AddForce(new Vector2(0,Force));
			audioPlayer.clip = somPulo; 
			audioPlayer.Play();
		}

		if(Input.GetKey(KeyCode.RightArrow) ||  Input.GetKey(KeyCode.LeftArrow))
		{	
			Anime.SetBool("Walk",true);
			if(Input.GetKey(KeyCode.RightArrow))
				players.transform.localScale = new Vector3(1,1,1);
			else
				players.transform.localScale = new Vector3(-1,1,1);
		}
		else
			Anime.SetBool("Walk",false);

		if(Input.GetKey(KeyCode.Space))
		{
			Anime.SetBool("Attack",true);
			audioPlayer.clip = somHit;
			if(Input.GetKeyDown(KeyCode.Space))
				audioPlayer.Play();
		}
		else 
			Anime.SetBool("Attack", false);

		if(Input.GetKey(KeyCode.E))
		{
			Anime.SetBool("Attack_Eletrico",true);
			audioPlayer.clip = somHitEletrico;
			if(Input.GetKeyDown(KeyCode.E))
				audioPlayer.Play();
		}
		else 
			Anime.SetBool("Attack_Eletrico", false);
	}


}	
