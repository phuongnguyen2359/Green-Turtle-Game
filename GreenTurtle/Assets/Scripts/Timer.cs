using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {
	private Text timeTF;
	public GameObject alertReference;
	public GameObject PauseMenu;
	public AudioClip warning1;
	public AudioClip warning2;

	void ReduceTime()
	{
		if (timeTF.text == "5") {
			SoundManager.instance.RandomizeSfx (warning1, warning2);
		}
			
		if (timeTF.text == "1")
		{
			/* Alert */
			PauseMenu.SetActive(true);
			Instantiate(alertReference, new Vector3(0.5f, 0.5f, 0), transform.rotation);
			Time.timeScale = 0;
//			audio.Play();
//			GameObject.Find("AppleGUI").GetComponent<AudioSource>().Stop();
		}

		timeTF.text = (int.Parse(timeTF.text) - 1).ToString();
//		Debug.Log ("Timer -1");
	}

	// Use this for initialization
	void Start () {
		timeTF = gameObject.GetComponent<Text>();
		InvokeRepeating("ReduceTime", 1, 1);
		//PauseMenu = GameObject.Find ("LoseMenu");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
