using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider collider) {
		var hero = collider.gameObject.GetComponent<Hero>();
		
		if (hero) {
			hero.Jumping = false;
		}
	}
}
