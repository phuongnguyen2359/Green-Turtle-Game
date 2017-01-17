using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseScript : MonoBehaviour {

	public GameObject WinMenu;
	public GameObject LoseMenu;

	// Use this for initialization
	void Start () {
		WinMenu = GameObject.Find("WinMenu");
		LoseMenu = GameObject.Find("LoseMenu");
		WinMenu.SetActive (false);
		LoseMenu.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	public void MainMenu () {
		Application.LoadLevel ("MapSelector");
	}

	public void Restart () {
		Application.LoadLevel(Application.loadedLevel);
		Time.timeScale = 1;
	}
}
