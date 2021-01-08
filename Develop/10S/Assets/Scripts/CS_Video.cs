using UnityEngine;
using System.Collections;

public class CS_Video : MonoBehaviour {
	public GameObject myManager;
	public string myMessageMethodName;
	public string myMessageValue;
	// Use this for initialization
	void Start () {
		if (myManager == null)
			myManager = GameObject.Find (CS_Global.NAME_TRANSITIONMANAGER);
	}

	public void VideoEnding()
	{
		myManager.SendMessage (myMessageMethodName, myMessageValue);
	}
}
