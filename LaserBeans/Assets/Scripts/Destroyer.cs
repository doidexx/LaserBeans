using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

	public GameObject resetPoint;
	private Vector3 origi;
	// Use this for initialization
	void Start () {
		origi = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.CompareTag("bullet")) {
			gameObject.SetActive(false);
			other.gameObject.SetActive(false);
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject == resetPoint) {
			transform.position = origi;
		}
	}

}
