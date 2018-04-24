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
		int speed = 10;
		this.TorsoArmature.transform.Rotate(Vector3.up * Time.deltaTime * speed * Input.GetAxis("Horizontal"), Space.World);
		this.TorsoArmature.transform.Rotate(Vector3.left * Time.deltaTime * speed * Input.GetAxis("Vertical"));
	}
}
