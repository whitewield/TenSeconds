using UnityEngine;
using System.Collections;

public class CS_Botton : MonoBehaviour {
	public GameObject myManager;
	public string myManagerName;
	public string myMessageMethodName;
	public string myMessageValue;
	public AudioClip mySFX;

	void OnMouseDown () {
		if (myManager == null) {
			if (myManagerName == "")
				myManager = GameObject.Find (CS_Global.NAME_MESSAGEBOX);
			else
				myManager = GameObject.Find (myManagerName);
		}

		if (myMessageValue == "")
			myManager.SendMessage (myMessageMethodName);
		else
			myManager.SendMessage (myMessageMethodName, myMessageValue);

		if (mySFX != null)
			CS_AudioManager.Instance.PlaySFX (mySFX);
//		Debug.Log("send");
	}

	public void SetValue(string t_value)
	{
		myMessageValue = t_value;
	}
}
