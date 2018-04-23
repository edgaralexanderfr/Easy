using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour {

	private GameObject TorsoArmature;

	// Use this for initialization
	void Start () {
		this.TorsoArmature = GameObject.Find("TorsoArmature");
	}
	
	// Update is called once per frame
	void Update () {
		int speed = 1000;

		if (Input.GetKeyUp("up")) {
			this.TorsoArmature.transform.Rotate(Vector3.left * Time.deltaTime * speed);
		}

		if (Input.GetKeyUp("down")) {
			this.TorsoArmature.transform.Rotate(Vector3.right * Time.deltaTime * speed);
		}

		if (Input.GetKeyUp("left")) {
			this.TorsoArmature.transform.Rotate(Vector3.down * Time.deltaTime * speed, Space.World);
		}

		if (Input.GetKeyUp("right")) {
			this.TorsoArmature.transform.Rotate(Vector3.up * Time.deltaTime * speed, Space.World);
		}
	}
}
