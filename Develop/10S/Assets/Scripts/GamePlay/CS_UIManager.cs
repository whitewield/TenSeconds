using UnityEngine;
using System.Collections;

public class CS_UIManager : MonoBehaviour {
	public GameObject UI_Pause;
	public GameObject UI_Play;

	void Start () {
		UI_Pause.SetActive (false);
	}

	void Update () {
	
	}

	public void Resume()
	{
		Time.timeScale = 1;
		if (UI_Play.activeSelf == false)
			UI_Play.SetActive (true);
		if (UI_Pause.activeSelf == true)
			UI_Pause.SetActive (false);
	}

	public void Pause()
	{
		Time.timeScale = 0;
		if (UI_Play.activeSelf == true)
			UI_Play.SetActive (false);
		if (UI_Pause.activeSelf == false)
			UI_Pause.SetActive (true);
	}
}
