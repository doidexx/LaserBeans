using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	// Use this for initialization

	public float exforce, exradius;
	private Camera playerCamera;
	public GameObject bullet, target1, dontKill1;
	public GameObject[] target;
    public GameObject[] dontKill;
	private float[] speed = new float [10];
	public int ammo;
	void Start () {
		target = new GameObject[10];
		dontKill = new GameObject[10];
		playerCamera = GetComponent<Camera>();
		for (int i = 0; i < 10; i++) {
			if (i < 1){
				target[i] = Instantiate(target1, new Vector3(target1.transform.position.x, target1.transform.position.y, 5), Quaternion.identity);
				dontKill[i] = Instantiate(dontKill1, new Vector3(dontKill1.transform.position.x, dontKill1.transform.position.y, 6), Quaternion.identity);
				speed[i] = Random.Range(5, 15);
            } else {
            	target[i] = Instantiate(target1, new Vector3(target1.transform.position.x, target1.transform.position.y, target[i - 1].transform.position.z + 2), Quaternion.identity);
                dontKill[i] = Instantiate(dontKill1, new Vector3(dontKill1.transform.position.x, dontKill1.transform.position.y, dontKill[i - 1].transform.position.z + 2), Quaternion.identity);
            	speed[i] = Random.Range(5, 15);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < 10; i++) {
        	target[i].GetComponent<Rigidbody>().velocity = Vector3.left * speed[i];
			dontKill[i].GetComponent<Rigidbody>().velocity = Vector3.left * speed[i];
        }
		Ray laserBean = playerCamera.ScreenPointToRay(Input.mousePosition);
		RaycastHit hitPoint;
		if (Physics.Raycast(laserBean, out hitPoint) && Input.GetMouseButtonDown(0) && ammo != 0) {
			Physics.Linecast(transform.position, Input.mousePosition);
                GameObject clone;
				clone = Instantiate(bullet, transform.position, Quaternion.identity);
                clone.GetComponent<Rigidbody>().AddForce(laserBean.direction * 40f, ForceMode.Impulse);
				ammo--;
		}
	}
}
