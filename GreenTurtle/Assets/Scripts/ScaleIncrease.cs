using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScaleIncrease : MonoBehaviour {

	Vector3 temp;
	private Text score;
	int scoreNew;
	int scoreOld;
	bool finished;
	bool waterLow;
	bool waterHigh;
	public GameObject alertReference;
	public GameObject PauseMenu;
	public static bool HCM;

	// Use this for initialization
	void Start () {
		score = GameObject.Find("ScoreTextGUI").GetComponent<Text>();
		PauseMenu = GameObject.Find("WinMenu");
		scoreOld = 0;
		finished = true;
		waterLow = false;
		waterHigh = true;
		HCM = false;
	}
	
	// Update is called once per frame
	void Update () {
		scoreNew = int.Parse(score.text);
		temp = transform.localScale;

		if (scoreNew == scoreOld + 1) {
			temp = transform.localScale;
			temp.y -= 0.08f;
			transform.localScale = temp;
			scoreOld = scoreNew;
		}

		if (finished) {
			temp.y += 0.0005f;
			transform.localScale = temp;
		}

		if (scoreNew == 13) {
			finished = false;
		}

		if (scoreNew == 14) {
			waterLow = true;
			HCM = true;
		}

		if (waterLow && waterHigh) {
			temp.y -= 0.0005f;
			transform.localScale = temp;
		}

		if (temp.y <= 0.2f) {
			waterHigh = false;
			PauseMenu.SetActive(true);
			Instantiate(alertReference, new Vector3(0.5f, 0.5f, 0), transform.rotation);
			Time.timeScale = 0;
		}
	}
}
