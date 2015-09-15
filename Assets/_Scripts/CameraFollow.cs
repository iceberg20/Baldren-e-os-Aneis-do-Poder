using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public float xMargin = 1f;        // Distance in the x axis the player can move before the camera follows.
	public float yMargin = 1f;        // Distance in the y axis the player can move before the camera follows.
	public float xSmooth = 8f;        // How smoothly the camera catches up with it's target movement in the x axis.
	public float ySmooth = 8f;        // How smoothly the camera catches up with it's target movement in the y axis.
	public Vector2 maxXAndY;        // The maximum x and y coordinates the camera can have.
	public Vector2 minXAndY;        // The minimum x and y coordinates the camera can have.
	public Transform hero;
	private bool follow = true;
	private Transform camera;
	private float shakeTimer =4f;
	private float shakePower;
	private float shakeAmount = 0.03f;
	private float initial_y;
	private AudioSource audioPlayer;
	
	private Transform player;        // Reference to the player's transform.
	
	
	void Awake ()
	{
		// Setting up the reference.
		player = GameObject.FindGameObjectWithTag("Player").transform;
		camera = gameObject.GetComponent<Transform>(); 
		follow = true;
		initial_y = camera.position.y;
		audioPlayer = GetComponent<AudioSource>();
	}
	

	bool CheckXMargin()
	{
		// Returns true if the distance between the camera and the player in the x axis is greater than the x margin.
		return Mathf.Abs(transform.position.x - player.position.x) > xMargin;
	}
	
	
	bool CheckYMargin()
	{
		// Returns true if the distance between the camera and the player in the y axis is greater than the y margin.
		return Mathf.Abs(transform.position.y - player.position.y) > yMargin;
	}
	
	
	void FixedUpdate ()
	{

			if(hero.position.x <=13f && follow) 
				TrackPlayer();


		//pare em x=15
		if(hero.position.x > 13f){
			if(camera.position.x<15)
				camera.transform.Translate(Vector3.right* Time.deltaTime);


			follow = false;
		}

		//Let's shake
		if(shakeTimer >=0 && hero.position.x > 13f){
			audioPlayer.Play();
			Vector2 shakePos = Random.insideUnitCircle * shakeAmount;
			shakeTimer-= Time.deltaTime;
			camera.position = new Vector3(camera.position.x+shakePos.x,camera.position.y+shakePos.y, camera.position.z);
			if(shakeTimer <0.1f) 
				camera.position = new Vector3(camera.position.x+shakePos.x,initial_y, camera.position.z);

		}


	}

	public void shakeCamera(float power, float duration){
		shakePower = power;
		shakeTimer = duration;
	}



	
	
	void TrackPlayer ()
	{
		// By default the target x and y coordinates of the camera are it's current x and y coordinates.
		float targetX = transform.position.x;
		float targetY = transform.position.y;
		
		// If the player has moved beyond the x margin...
		if(CheckXMargin())
			// ... the target x coordinate should be a Lerp between the camera's current x position and the player's current x position.
			targetX = Mathf.Lerp(transform.position.x, player.position.x, xSmooth * Time.deltaTime);
		
		// If the player has moved beyond the y margin...
		if(CheckYMargin())
			// ... the target y coordinate should be a Lerp between the camera's current y position and the player's current y position.
			targetY = Mathf.Lerp(transform.position.y, player.position.y, ySmooth * Time.deltaTime);
		
		// The target x and y coordinates should not be larger than the maximum or smaller than the minimum.
		targetX = Mathf.Clamp(targetX, minXAndY.x, maxXAndY.x);
		targetY = Mathf.Clamp(targetY, minXAndY.y, maxXAndY.y);
		
		// Set the camera's position to the target position with the same z component.
		transform.position = new Vector3(targetX, targetY, transform.position.z);
	}
}
