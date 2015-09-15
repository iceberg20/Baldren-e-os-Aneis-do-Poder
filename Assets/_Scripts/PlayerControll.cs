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
	//mana
	public RectTransform manaBar;
	public float mana;
	private float delayEletrico;
	private float delayShoot;
	public Rigidbody2D	PlayerRigdbod;
	public int 			Force;
	public GameObject shoot;
	private Transform hero;

	void Awake()
	{
		// Setting up references.
		groundCheck = transform.Find("groundCheck");
		mana = 301.7f; 

	}
	void Start () {	
		audioPlayer = GetComponent<AudioSource>();
		delayEletrico = 4.0f;	
		delayEletrico = 4.0f;	
		hero = gameObject.GetComponent<Transform>();
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
		//Debug.Log(players.transform.position.x);
		bool locked = false;
		if(players.transform.position.x< -11.82) {
			speed = 0.0f;
			locked = true;
		}
		if(locked && (Input.GetKey(KeyCode.RightArrow))){
			speed = 0.01f;
		    locked = false;

			translation = Input.GetAxis("Horizontal")*speed;
		}


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

		//cooldown
		delayEletrico += Time.deltaTime;
		delayShoot += Time.deltaTime;
		//Debug.Log(delayEletrico);

		if(Input.GetKey(KeyCode.W) && delayShoot>1f)
		{
			delayShoot = 0f;
			Instantiate(shoot, new Vector3(hero.position.x+0.5f, hero.position.y,1f),Quaternion.identity);			
		}


		if(Input.GetKey(KeyCode.E) && mana>10.0f && !Anime.GetBool("Walk") && delayEletrico>1f)
		{
			Anime.SetBool("Attack_Eletrico",true);
			mana = mana -5;
			delayEletrico=0.0f;
			reduzirMana(5.0f);
		
			audioPlayer.clip = somHitEletrico;

			audioPlayer.Play();

		}
	//	else {
	//		if(Anime.GetBool("Attack_Eletrico") == false)Anime.SetBool("Attack_Eletrico", false);
		//}
	}

	void reduzirMana(float valor){
		if(valor ==-1) {
			Anime.SetBool("Attack_Eletrico", false);
		}
		else{
			if(manaBar.rect.width <= 0){
				Debug.Log("Voce esta sem mana");
			}
			else
			{
				mana-=valor;
				manaBar.sizeDelta = new Vector2(mana,15.2f);
				manaBar.position = new Vector3(manaBar.position.x-valor, manaBar.position.y);
				
			}
		}
	}

	public void fillMana(){
			mana = 301.7f;
		}




}	
