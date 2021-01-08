using UnityEngine;
using System.Collections;

public class CS_GuideManager : MonoBehaviour {
	public GameObject[] guideObjects;
	public int guideStep;
	public bool onGuide;
	// Use this for initialization
	void Start () {
		guideStep = 0;
		onGuide = true;
		for (int i = 1; i < guideObjects.Length; i++) {
			guideObjects[i].SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (onGuide == false)
			return;

		if (guideObjects [guideStep] == null) 
			NextStep ();
	}

	public void NextStep()
	{
		if (onGuide == false)
			return;

		guideStep ++;
		if (guideStep < guideObjects.Length)
			guideObjects [guideStep].SetActive (true);
		else
			onGuide = false;
	}
}
