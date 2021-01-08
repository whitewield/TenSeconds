using UnityEngine;
using System.Collections;

public class CS_GuideTrigger : MonoBehaviour {
	public int deadTime;
	private int counter;
	public GameObject myGuideManager;
	public GameObject myGuideObject;
	// Use this for initialization
	void Start () {
		counter = 0;
		if (myGuideManager == null)
			myGuideManager = GameObject.Find (CS_Global.NAME_GUIDEMANAGER);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		if (myGuideObject == null)
			return;
		if (myGuideObject.activeSelf == false)
			return;
		if (deadTime == 0)
			return;

		counter++;
		if (counter >= deadTime) {
			myGuideManager.SendMessage("NextStep");
			Destroy (myGuideObject);
		}
	}
}
