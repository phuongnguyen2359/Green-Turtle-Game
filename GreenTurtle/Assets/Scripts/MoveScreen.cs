using UnityEngine;
using System.Collections;

public class MoveScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (ScaleIncrease.HCM == true && ScoreSys.HN == true) {
			Application.LoadLevel ("Credit");
		}
	}
}
