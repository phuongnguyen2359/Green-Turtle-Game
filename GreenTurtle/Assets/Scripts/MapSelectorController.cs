using UnityEngine;
using System.Collections;

public class MapSelectorController : MonoBehaviour {


	public void GoHN () {
		Application.LoadLevel ("HN");
		Time.timeScale = 1;
	}

	public void GoHCM () {
		Application.LoadLevel ("HCM");
		Time.timeScale = 1;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
