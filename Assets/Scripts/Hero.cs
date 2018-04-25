using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour {

	const float AIM_SPEED = 10.0f;
	const float MOVE_SPEED = 20.0f;

	private GameObject TorsoArmature;
	private Vector3 MoveDirection;

	// Use this for initialization
	void Start () {
		this.TorsoArmature = GameObject.Find("TorsoArmature");
	}
	
	// Update is called once per frame
	void Update () {
		this.TorsoArmature.transform.Rotate(Vector3.up * Time.deltaTime * AIM_SPEED * Input.GetAxis("Horizontal"), Space.World);
		this.TorsoArmature.transform.Rotate(Vector3.left * Time.deltaTime * AIM_SPEED * Input.GetAxis("Vertical"));

		this.MoveDirection.x = 0.0f;
		this.MoveDirection.y = this.TorsoArmature.transform.rotation.eulerAngles.y;
		this.MoveDirection.z = 0.0f;
		
		if (Input.GetKey(KeyCode.W)) {
			this.transform.Translate(Quaternion.Euler(this.MoveDirection) * Vector3.forward * Time.deltaTime * MOVE_SPEED);
		}

		if (Input.GetKey(KeyCode.S)) {
			this.transform.Translate(Quaternion.Euler(this.MoveDirection) * Vector3.back * Time.deltaTime * MOVE_SPEED);
		}

		if (Input.GetKey(KeyCode.A)) {
			this.transform.Translate(Quaternion.Euler(this.MoveDirection) * Vector3.left * Time.deltaTime * MOVE_SPEED);
		}

		if (Input.GetKey(KeyCode.D)) {
			this.transform.Translate(Quaternion.Euler(this.MoveDirection) * Vector3.right * Time.deltaTime * MOVE_SPEED);
		}
	}
}
