using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreSys : MonoBehaviour {

	private int scoreOld;
	private Text scoreNew;
	private Text timer;
	public GameObject alertReference;
	public GameObject PauseMenu;
	public int MaxScore;
	public AudioClip tink1;
	public AudioClip tink2;
	public static bool HN;

	// Use this for initialization
	void Start () {
		timer = GameObject.Find("TimerTextGUI").GetComponent<Text>();
		//PauseMenu = GameObject.Find("WinMenu");
		scoreOld = 0;
		HN = false;
	}

	void Update() {
		scoreNew = GameObject.Find ("ScoreTextGUI").GetComponent<Text> ();
		if (int.Parse(scoreNew.text) == scoreOld + 1) {
			SoundManager.instance.RandomizeSfx (tink1, tink2);
			scoreOld = int.Parse(scoreNew.text);
		}
		else if (int.Parse(scoreNew.text) == 11) {
			HN = true;
			PauseMenu.SetActive(true);
			Instantiate(alertReference, new Vector3(0.5f, 0.5f, 0), transform.rotation);
			Time.timeScale = 0;
		}
	}
}
