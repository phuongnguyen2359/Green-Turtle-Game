using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreHCM : MonoBehaviour {

	private int scoreOld;
	private Text scoreNew;
	public AudioClip tink1;
	public AudioClip tink2;


	// Use this for initialization
	void Start () {
		scoreOld = 0;
	}

	void Update() {
		scoreNew = GameObject.Find ("ScoreTextGUI").GetComponent<Text> ();
		if (int.Parse(scoreNew.text) == scoreOld + 1) {
			SoundManager.instance.RandomizeSfx (tink1, tink2);
			scoreOld = int.Parse(scoreNew.text);
		}
	}
}