﻿using UnityEngine;
using System.Collections;

public class ice_shoot : MonoBehaviour {
	private Transform shoot;
	private GameObject fireBall;
	private BoxCollider2D ballColl;
	private BoxCollider2D shotColl;


	// Use this for initialization
	void Start () {
		shoot = gameObject.GetComponent<Transform>();

		shotColl = gameObject.GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		shoot.Translate(Vector3.right *Time.deltaTime*3f);	
		
	}
}
