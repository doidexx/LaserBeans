using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class botton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Again() {
		SceneManager.LoadScene(0);
	}

	public void ExitGame(){
		Application.Quit();
	}

	public void StartGame(){
		SceneManager.LoadScene(1);
	}
}
