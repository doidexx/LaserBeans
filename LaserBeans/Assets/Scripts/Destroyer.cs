using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Destroyer : MonoBehaviour {

	public GameObject resetPoint;
	private Vector3 origi;
	public static int victims, targets;
	public Text vicT, tarT;
	public AudioClip wrong, hit;
	// Use this for initialization
	void Start () {
		origi = transform.position;
		victims = 0;
		targets = 0;
	}
	
	// Update is called once per frame
	void Update () {
		vicT.text = "Your Victims: " + victims.ToString();
		tarT.text = "Your Targets: " + targets.ToString();
		if (victims == 3) {
			SceneManager.LoadScene(3);
		}
		if (targets == 7) {
			SceneManager.LoadScene(2);
		}
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.CompareTag("bullet")) {
            if (gameObject.CompareTag("left")){
                gameObject.GetComponent<AudioSource>().Play();
            }
			if (gameObject.CompareTag("right")){
                gameObject.GetComponent<AudioSource>().Play();
			}
			gameObject.SetActive(false);
			other.gameObject.SetActive(false);
		}
		if (gameObject.CompareTag("left") && other.gameObject.CompareTag("bullet")) {
			Destroyer.targets += 1;
		}
		if (gameObject.CompareTag("right") && other.gameObject.CompareTag("bullet")) {
            Destroyer.victims += 1;
        }
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject == resetPoint) {
			transform.position = origi;
		}
	}

}
