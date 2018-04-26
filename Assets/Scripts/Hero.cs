﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour {

	const float AIM_SPEED = 10.0f;
	const float MOVE_SPEED = 20.0f;

	[SerializeField]
	private Camera MainCamera;
	[SerializeField]
	private Camera ThirdPersonCamera;
	
	private Animator HeroAnimator;
	private GameObject TorsoArmature;
	private Vector3 MoveDirection;
	private bool PlayingWalkAnimation = false;

	// Use this for initialization
	void Start () {
		this.HeroAnimator = this.GetComponent<Animator>();
		this.TorsoArmature = GameObject.Find("TorsoArmature");

		this.MainCamera.enabled = true;
		this.ThirdPersonCamera.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		this.TorsoArmature.transform.Rotate(Vector3.up * Time.deltaTime * AIM_SPEED * Input.GetAxis("Horizontal"), Space.World);
		this.TorsoArmature.transform.Rotate(Vector3.left * Time.deltaTime * AIM_SPEED * Input.GetAxis("Vertical"));

		this.MoveDirection.x = 0.0f;
		this.MoveDirection.y = this.TorsoArmature.transform.rotation.eulerAngles.y;
		this.MoveDirection.z = 0.0f;

		bool moving = false;
		
		if (Input.GetKey(KeyCode.W)) {
			this.transform.Translate(Quaternion.Euler(this.MoveDirection) * Vector3.forward * Time.deltaTime * MOVE_SPEED);
			moving = true;
		}

		if (Input.GetKey(KeyCode.S)) {
			this.transform.Translate(Quaternion.Euler(this.MoveDirection) * Vector3.back * Time.deltaTime * MOVE_SPEED);
			moving = true;
		}

		if (Input.GetKey(KeyCode.A)) {
			this.transform.Translate(Quaternion.Euler(this.MoveDirection) * Vector3.left * Time.deltaTime * MOVE_SPEED);
			moving = true;
		}

		if (Input.GetKey(KeyCode.D)) {
			this.transform.Translate(Quaternion.Euler(this.MoveDirection) * Vector3.right * Time.deltaTime * MOVE_SPEED);
			moving = true;
		}

		if (Input.GetKeyUp(KeyCode.F7)) {
			this.MainCamera.enabled = !this.MainCamera.enabled;
			this.ThirdPersonCamera.enabled = !this.ThirdPersonCamera.enabled;
		}

		if (moving) {
			if (!this.PlayingWalkAnimation) {
				this.HeroAnimator.Play("Walk");
				this.PlayingWalkAnimation = true;
			}
		} else {
			if (this.PlayingWalkAnimation) {
				this.HeroAnimator.Play("Idle");
				this.PlayingWalkAnimation = false;
			}
		}
	}
}
