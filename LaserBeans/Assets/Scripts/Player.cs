using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	// Use this for initialization

	public float exforce, exradius;
	private Camera playerCamera;
	public GameObject bullet, target1, dontKill1, bulletImage, myCanvas, outofamo;
	public Text ammoc;
	public GameObject[] target;
    public GameObject[] dontKill;

	private GameObject[] bulletImage1;
	private float[] speed = new float [10];
	public int ammo;
	void Start () {
		Cursor.visible = false;
		target = new GameObject[10];
		dontKill = new GameObject[10];
		bulletImage1 = new GameObject[ammo];
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
        for (int i = 0; i < ammo; i++) {
			if (i < 1) {
                bulletImage1[i] = Instantiate(bulletImage, bulletImage.transform.position + (Vector3.down * 3f), Quaternion.identity);
			} else {
                bulletImage1[i] = Instantiate(bulletImage, bulletImage1[i - 1].transform.position + (Vector3.down * 3f), Quaternion.identity);
			}
            bulletImage1[i].transform.SetParent(myCanvas.transform);
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
		GetComponent<LineRenderer>().SetPosition(1, laserBean.direction * 1000f);
		GetComponent<LineRenderer>().SetPosition(0, transform.position + (Vector3.down/2f));
		if (Physics.Raycast(laserBean, out hitPoint)) {
			Physics.Linecast(transform.position, Input.mousePosition);
             if (Input.GetMouseButtonDown(0) && ammo != 0){
                GameObject clone;
				clone = Instantiate(bullet, transform.position + (Vector3.down/2), Quaternion.identity);
                clone.GetComponent<Rigidbody>().AddForce(laserBean.direction * 50f, ForceMode.Impulse);
                bulletImage1[ammo-1].SetActive(false);
				ammo--;
			}
		}
		if (ammo == 0) {
			outofamo.SetActive(true);
		}
		else {
			outofamo.SetActive(false);
		}
		ammoc.text = ammo.ToString();
		if (ammo == 0) {
			Invoke ("sceneHandler1", 5);
		}
	}

	void sceneHandler1() {
		SceneManager.LoadScene(3);
	}
}
